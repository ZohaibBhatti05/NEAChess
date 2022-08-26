using Prototype5.Database;
using Prototype5.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Prototype5.Boards
{
    public enum WinStatus
    {
        None,
        WhiteCheck,
        BlackCheck,
        WhiteMate,
        BlackMate,
        Stalemate,
        DrawInsufficient,
        DrawRepetition,
        DrawThreefold,
        DrawFifty,
        WhiteResign,
        BlackResign,
        WhiteTimeout,
        BlackTimeout,
    }

    public enum PlayerColour
    {
        White, Black
    }

    // class has two attributes : column (file), row (rank)
    public class Position
    {
        public Position(int column, int row)
        {
            this.column = column; this.row = row;
        }

        public int column { get; private set; }
        public int row { get; private set; }

        public static Position Add(Position pos1, Position pos2) // static, instantiation not needed
        {
            return new Position(pos1.column + pos2.column, pos1.row + pos2.row);
        }
    }

    public class ChessBoard
    {
        protected UpdateBoardGraphicsCallBack graphicsCallBack;
        private string username;

        public PlayerColour currentTurn { get; private set; }

        public Position selectedCell { get; private set; }
        public Position checkCell { get; private set; }

        public List<Move> selectedMoves { get; private set; }

        public Stack<Move> moveHistory { get; private set; }
        public List<string> moveNameHistory { get; private set; }
        private Stack<Position> checkCellHistory;
        private Stack<WinStatus> winStatusHistory;
        private Stack<bool> castleChangeHistory;
        private List<string> positionHistory;

        public Piece[][] board { get; private set; }

        private Player whitePlayer;
        private Player blackPlayer;

        private int fiftyMoveCounter = 0;

        public WinStatus winStatus { get; private set; }

        public Stopwatch whiteTimer { get; private set; }
        public Stopwatch blackTimer { get; private set; }

        // initialise new instance of board
        public ChessBoard(UpdateBoardGraphicsCallBack updateGraphicsCallback)
        {
            // create an empty array for the board //
            board = new Piece[8][];
            for (int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }
            // ----------------------------------- //

            // set callback //
            graphicsCallBack = updateGraphicsCallback;

            // initalise empty variables
            moveHistory = new Stack<Move>();
            moveNameHistory = new List<string>();
            checkCellHistory = new Stack<Position>();
            checkCellHistory.Push(null);
            winStatusHistory = new Stack<WinStatus>();
            winStatusHistory.Push(WinStatus.None);
            currentTurn = PlayerColour.White;
            selectedMoves = new List<Move>();
            castleChangeHistory = new Stack<bool>();
            positionHistory = new List<string>();
            winStatus = WinStatus.None;

            // initialise timers
            InitialiseTimers();
        }

        // initialise players of a game
        public void InitialisePlayers(string username, bool AI, int plyDepth)
        {
            this.username = username;
            whitePlayer = new Human(username);

            if (AI)
            {
                blackPlayer = new AI(plyDepth, PlayerColour.Black);
            }
            else
            {
                blackPlayer = new Human(null);
            }
        }

        private void InitialiseTimers()
        {
            whiteTimer = new Stopwatch();
            blackTimer = new Stopwatch();
            whiteTimer.Start();
        }

        // toggles both the white and black player's timers
        private void SwapTimers()
        {
            if (whiteTimer.IsRunning)
            {
                whiteTimer.Stop();
                blackTimer.Start();
            }
            else
            {
                blackTimer.Stop();
                whiteTimer.Start();
            }
        }

        // function loads standard positions :: override if child classes are implemented
        public void StandardPositions()
        {
            // fen for standard position
            //PositionFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            // custom fen for testing
            PositionFromFEN("r2q1rk1/p5pp/1p1bp3/3bBp2/3P4/3Q4/PP2BPPP/R4RK1 w - - 2 17");

            // empty for analysis setup boards: 8/8/8/8/8/8/8/8 w - - 0 1
        }

        public void CustomPosition(string FEN)
        {
            PositionFromFEN(FEN);
        }

        // places pieces from a FEN string
        private void PositionFromFEN(string FEN)
        {
            // split relevant parts of string into seperate sections
            string[] partFEN = FEN.Split(' ');

            // position
            int file = 0; int rank = 7; // program displays from bottom up, FEN goes from top to bottom, so rank goes from 7 to 0
            foreach (char c in partFEN[0])
            {
                if (c == '/') // / denotes new line, go down
                {
                    file = 0; rank--;
                }
                else if (int.TryParse(c.ToString(), out int stride))
                {
                    file += stride;
                }
                else if (c != ' ')
                {
                    // uppercase for white pieces
                    if (char.IsUpper(c))
                    {
                        board[file][rank] = NewPieceFromCharType(char.ToLower(c), PlayerColour.White);
                    }
                    else
                    {
                        board[file][rank] = NewPieceFromCharType(char.ToLower(c), PlayerColour.Black);
                    }
                    file++; // next position
                }
            }

            // current turn
            currentTurn = (partFEN[1] == "w") ? PlayerColour.White : PlayerColour.Black;

            // castling rights (if found)
            if (partFEN[2] != "-")
            {
                foreach (char c in partFEN[2])
                {
                    switch (c)
                    {
                        case 'k': // black kingside
                            board[4][7].SetCastle(true);
                            board[7][7].SetCastle(true);
                            break;
                        case 'q': // black queenside
                            board[4][7].SetCastle(true);
                            board[0][7].SetCastle(true);
                            break;

                        case 'K': // white kingside
                            board[4][0].SetCastle(true);
                            board[7][0].SetCastle(true);
                            break;
                        case 'Q': // white queenside
                            board[4][0].SetCastle(true);
                            board[0][0].SetCastle(true);
                            break;

                    }
                }
            }

            // en passant (if found)
            if (partFEN[3] != "-")
            {
                Position position = PositionFromAlgebraicPos(partFEN[3]);
                if (position.row == 2) // white pawn
                {
                    (board[position.column][3] as Pawn).SetEnPassant(true);
                }
                else // black pawn
                {
                    (board[position.column][4] as Pawn).SetEnPassant(true);
                }

            }

            // fifty move
            fiftyMoveCounter = int.Parse(partFEN[4]);


            positionHistory.Add(FEN); // inital position
        }

        // method returns the FEN string of the current board state
        private string PositionToFEN()
        {
            string FEN = string.Empty;
            (int c, int r)? enPassantTarget = null;

            // pieces
            for (int j = 7; j >= 0; j--)
            {
                int stride = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (ContainsPiece(i, j)) // if piece found, add stride and reset, add piece fen
                    {
                        if (stride > 0)
                        {
                            FEN += stride.ToString();
                        }
                        stride = 0;
                        FEN += CharFromPiece(GetPiece(i, j));

                        // do en passant calcs here to avoid two iterations
                        if (GetPiece(i, j) is Pawn)
                        {
                            if ((GetPiece(i, j) as Pawn).canBeEnPassanted)
                            {
                                enPassantTarget = (i, j);
                            }
                        }
                    }
                    else // no piece
                    {
                        stride++;
                        if (i == 7)
                        {
                            FEN += stride.ToString();
                        }
                    }
                }

                if (j > 0) // dont add / on final line
                {
                    FEN += "/";
                }
            }

            // current turn
            FEN += " " + ((currentTurn == PlayerColour.White) ? "w " : "b ");

            // castling rights
            bool castlingRightsAvailable = false;

            if (GetPiece(GetKingPosition(PlayerColour.White)).canCastle) // if white king can castle
            {
                if (ContainsPiece(0, 7)) // kingside
                {
                    if (GetPiece(0, 7).canCastle)
                    {
                        FEN += "K";
                        castlingRightsAvailable = true;
                    }
                }
                if (ContainsPiece(7, 7)) // queenside
                {
                    if (GetPiece(7, 7).canCastle)
                    {
                        FEN += "Q";
                        castlingRightsAvailable = true;
                    }
                }
            }

            if (GetPiece(GetKingPosition(PlayerColour.Black)).canCastle) // if black king can castle
            {
                if (ContainsPiece(0, 0)) // kingside
                {
                    if (GetPiece(0, 0).canCastle)
                    {
                        FEN += "k";
                        castlingRightsAvailable = true;
                    }
                }
                if (ContainsPiece(7, 0)) // queenside
                {
                    if (GetPiece(7, 0).canCastle)
                    {
                        FEN += "q";
                        castlingRightsAvailable = true;
                    }
                }
            }

            if (!castlingRightsAvailable)
            {
                FEN += "- ";
            }
            else
            {
                FEN += " ";
            }

            // en passant
            if (enPassantTarget != null)
            {
                FEN += (char)(enPassantTarget.Value.c + 97); // file
                FEN += (enPassantTarget.Value.r == 3) ? "3 " : "6 "; // rank
                // FEN takes the position where the taking pawn will end up, not the position of the pawn being taken
            }
            else
            {
                FEN += "- ";
            }

            // fifty move
            FEN += fiftyMoveCounter.ToString() + " ";

            FEN += (moveHistory.Count / 2) + 1;

            return FEN;
        }

        // takes e4, returns Position(4, 4)
        private Position PositionFromAlgebraicPos(string pos)
        {
            return new Position((int)pos[0] - 97, int.Parse(pos[1].ToString()));
        }


        // takes a character, returns a piece
        private Piece NewPieceFromCharType(char type, PlayerColour colour)
        {
            switch (type)
            {
                case 'p':
                    return new Pawn(colour);
                case 'r':
                    return new Rook(colour);
                case 'n':
                    return new Knight(colour);
                case 'b':
                    return new Bishop(colour);
                case 'q':
                    return new Queen(colour);
                case 'k':
                    return new King(colour);
                default:
                    break;
            }
            return null;
        }

        // returns the FEN/PGN char of a given piece
        public char CharFromPiece(Piece piece)
        {
            char character = new char();

            if (piece is Pawn)
            {
                character = 'p';
            }
            else if (piece is Rook)
            {
                character = 'r';
            }
            else if (piece is Bishop)
            {
                character = 'b';
            }
            else if (piece is Knight)
            {
                character = 'n';
            }
            else if (piece is Queen)
            {
                character = 'q';
            }
            else if (piece is King)
            {
                character = 'k';
            }

            return (piece.colour == PlayerColour.White) ? char.ToUpper(character) : character;
        }

        // returns if a position has a piece in it
        public bool ContainsPiece(Position position)
        {
            return (board[position.column][position.row] != null);
        }
        public bool ContainsPiece(int column, int row)
        {
            return (board[column][row] != null);
        }

        // returns the piece at the specified position
        public Piece GetPiece(Position position)
        {
            // jank code remove later
            if (position == null) return null;

            return (board[position.column][position.row]);
        }
        public Piece GetPiece(int column, int row)
        {
            return (board[column][row]);
        }

        // method run from form when a cell is clicked
        public void SelectCell(Position position)
        {
            if (winStatus == WinStatus.None || winStatus == WinStatus.WhiteCheck || winStatus == WinStatus.BlackCheck) // if noone won
            {

                // if there is no selected position
                if (selectedCell == null)
                {
                    // cant select what isnt there
                    if (!ContainsPiece(position))
                    {
                        return;
                    }
                    // cant select opponents pieces
                    else if (GetPiece(position).colour != currentTurn)
                    {
                        return;
                    }
                    else
                    {
                        // select piece
                        selectedCell = position;
                        selectedMoves = GetPiece(position).GenerateLegalMoves(this, position); // get valid moves
                        graphicsCallBack.Invoke(false);
                        return;
                    }
                }

                // if there IS a selected piece
                else
                {
                    // clicking a piece:
                    if (ContainsPiece(position))
                    {
                        // of the same colour: select it
                        if (GetPiece(position).colour == currentTurn)
                        {
                            selectedCell = position; // select cell
                            selectedMoves = GetPiece(position).GenerateLegalMoves(this, position); // get valid moves
                            graphicsCallBack.Invoke(false);
                            return;
                        }

                        // of a different colour: try to make a move
                        else
                        {
                            foreach (Move move in selectedMoves) // if position is in a valid move, make the move
                            {
                                if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                                {
                                    MakeMove(move);
                                    AfterMove(move);
                                    return;
                                }
                            }
                        }
                    }

                    // if selecting an empty square
                    else
                    {
                        foreach (Move move in selectedMoves) // if position is in a valid move, make the move
                        {
                            if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                            {
                                MakeMove(move);
                                AfterMove(move);
                                return;
                            }
                        }
                    }
                }
            }
        }

        // method takes a move and performs it
        internal void MakeMove(Move move)
        {
            // en passant 
            if (move is EnPassant)
            {
                AddPiece(move.movingPiece, move.positionTo);
                RemovePiece(move.positionFrom);
                RemovePiece((move as EnPassant).takenPosition);
            }
            // castling
            else if (move is Castle)
            {
                AddPiece(move.movingPiece, move.positionTo);
                RemovePiece(move.positionFrom);
                AddPiece((move as Castle).rook, (move as Castle).rookTo);
                RemovePiece((move as Castle).rookFrom);
            }
            else // standard move
            {
                AddPiece(move.movingPiece, move.positionTo);

                RemovePiece(move.positionFrom);
            }
        }

        // undoes a specified instance of a move
        internal void UndoMove(Move move)
        {
            // en passant 
            if (move is EnPassant)
            {
                AddPiece(move.movingPiece, move.positionFrom);
                RemovePiece(move.positionTo);
                AddPiece(move.takenPiece, (move as EnPassant).takenPosition);
            }
            // castling
            else if (move is Castle)
            {
                AddPiece(move.movingPiece, move.positionFrom); // put king back
                RemovePiece(move.positionTo);
                AddPiece((move as Castle).rook, (move as Castle).rookFrom); // put rook back
                RemovePiece((move as Castle).rookTo);
            }
            // standard move
            else
            {
                AddPiece(move.takenPiece, move.positionTo); // put taken piece back
                AddPiece(move.movingPiece, move.positionFrom); // put the moving piece back
            }
        }

        // runs when the undo button is clicked. if move history empty, do nothing
        public void UndoLastMove()
        {
            if (moveHistory.Count == 0)
            {
                return;
            }
            else
            {
                Move move = moveHistory.Pop();
                checkCellHistory.Pop();
                checkCell = checkCellHistory.Peek();
                winStatusHistory.Pop();
                winStatus = winStatusHistory.Peek();
                moveNameHistory.RemoveAt(moveNameHistory.Count - 1);
                positionHistory.RemoveAt(positionHistory.Count - 1);

                UndoMove(move); // undo the move
                // switch back to player who made move
                currentTurn = (currentTurn == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;

                // unselect cell
                selectedCell = null;

                // reset castling rights
                if (move is Castle)
                {
                    GetPiece(move.positionFrom).SetCastle(true); // ensure king can castle again
                    GetPiece((move as Castle).rookFrom).SetCastle(true); // ensure rook can castle again
                    castleChangeHistory.Pop();
                }
                else
                {
                    // reset castling changes
                    GetPiece(move.positionFrom).SetCastle(castleChangeHistory.Pop());
                }

                graphicsCallBack.Invoke(false); // redraw board
            }
        }

        // function run when a player hits the resign button
        public void Resign()
        {
            if (currentTurn == PlayerColour.White)
            {
                winStatus = WinStatus.WhiteResign;
            }
            else
            {
                winStatus = WinStatus.BlackResign;
            }
            UpdatePostGame();
            graphicsCallBack.Invoke(false);
        }

        // function run when a player runs out of time
        public void Timeout()
        {
            if (currentTurn == PlayerColour.White)
            {
                winStatus = WinStatus.WhiteTimeout;
            }
            else
            {
                winStatus = WinStatus.BlackTimeout;
            }
            UpdatePostGame();
            graphicsCallBack.Invoke(false);
        }

        // function does logistics after a move is made
        private void AfterMove(Move move)
        {

            // switch turns
            currentTurn = (currentTurn == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;

            // clear selections
            selectedCell = null;
            selectedMoves = null;

            // update enpassant pawn
            UpdateEnPassant(move);

            // update castling procedures
            UpdateCastling(move);

            // promotion
            UpdatePromotion(move);

            // add move to history
            positionHistory.Add(PositionToFEN()); // add position before draws
            moveHistory.Push(move);
            checkCellHistory.Push(checkCell);
            winStatusHistory.Push(winStatus);

            // update draw conditions BEFORE win status
            bool draw = UpdateDrawConditions(move);

            if (!draw)
            {
                // update win status for check/mate/draw
                UpdateWinStatus();
            }

            // push move name to stack, overwrite/append where needed
            switch (winStatus)
            {
                case WinStatus.Stalemate:
                case WinStatus.DrawFifty:
                case WinStatus.DrawInsufficient:
                case WinStatus.DrawRepetition:
                case WinStatus.DrawThreefold:
                    moveNameHistory.Add("1/2 - 1/2"); break;

                case WinStatus.WhiteCheck:
                case WinStatus.BlackCheck:
                    moveNameHistory.Add(move.GetMoveName(this) + "+"); break;

                case WinStatus.WhiteMate:
                case WinStatus.BlackMate:
                    moveNameHistory.Add(move.GetMoveName(this) + "#"); break;
                default:

                    string name = move.GetMoveName(this);

                    if (move.movingPiece is Pawn && (move.positionTo.row == 0 || move.positionTo.row == 7)) // promotion name
                    {
                        name += "=" + char.ToUpper(CharFromPiece(GetPiece(move.positionTo)));
                    }

                    moveNameHistory.Add(name); break;
            }
            SwapTimers();

            graphicsCallBack.Invoke(true);
        }

        // method run after board redrawn
        public void PostBoardRedraw()
        {
            // if other player is an AI, make an AI move
            UpdatePlayers();

            // method checks for a winner
            UpdatePostGame();
        }

        // method perofrms post-game logistics
        private void UpdatePostGame()
        {
            if (!(winStatus == WinStatus.None || winStatus == WinStatus.WhiteCheck || winStatus == WinStatus.BlackCheck) && whitePlayer is Human && blackPlayer is Human) // if someone won and its humans
            {

                // add name to abrupt game ends
                switch (winStatus)
                {
                    case WinStatus.WhiteResign:
                    case WinStatus.WhiteTimeout:
                        moveNameHistory.Add("0-1");
                        break;

                    case WinStatus.BlackResign:
                    case WinStatus.BlackTimeout:
                        moveNameHistory.Add("1-0");
                        break;
                }

                if (username != "Guest") // if someone is logged in
                {

                    string winState = string.Empty;
                    switch (winStatus)
                    {
                        case WinStatus.BlackMate: // white wins
                            winState = "White Wins";
                            break;
                        case WinStatus.WhiteMate: // black wins
                            winState = "Black Wins";
                            break;
                        case WinStatus.Stalemate:
                            winState = "Stalemate";
                            break;
                        case WinStatus.DrawInsufficient:
                            winState = "Draw by Insufficient Material";
                            break;
                        case WinStatus.DrawRepetition:
                            winState = "Draw by Repetition";
                            break;
                        case WinStatus.DrawFifty:
                            winState = "Draw by 50 Move Rule";
                            break;
                        case WinStatus.DrawThreefold:
                            winState = "Draw by Repetition";
                            break;

                        case WinStatus.WhiteResign:
                        case WinStatus.BlackResign:
                            winState = "Resignation";
                            break;

                        case WinStatus.WhiteTimeout:
                        case WinStatus.BlackTimeout:
                            winState = "Timeout";
                            break;

                    }


                    string PGN = string.Join(", ", moveNameHistory.ToArray()); // convert pgn history to single string

                    DatabaseConnection dbConnection = new DatabaseConnection();
                    dbConnection.StoreNewGame(username, winState, PGN);
                }

                // stop both timers
                whiteTimer.Stop();
                blackTimer.Stop();
            }
        }

        // method allows computer players to make moves
        private void UpdatePlayers()
        {
            if ((winStatus == WinStatus.None || winStatus == WinStatus.WhiteCheck || winStatus == WinStatus.BlackCheck)) // if no winner
            {

                if (currentTurn == PlayerColour.White && whitePlayer is AI)
                {
                    Move move = (whitePlayer as AI).MakeMove(this);
                    MakeMove(move);
                    AfterMove(move);
                }

                else if (currentTurn == PlayerColour.Black && blackPlayer is AI)
                {
                    Move move = (blackPlayer as AI).MakeMove(this);
                    MakeMove(move);
                    AfterMove(move);
                }
            }
        }

        // check for draw by insufficiency, 50 move and threefold repetition
        private bool UpdateDrawConditions(Move move)
        {
            // 50 move rule
            if (move.takenPiece is null && move.movingPiece is not Pawn) // if no piece taken / pawn moved
            {
                fiftyMoveCounter++;
                if (fiftyMoveCounter == 100) // 100 used as 2 board "moves" make an actual turn
                {
                    winStatus = WinStatus.DrawFifty; // draw by fifty move rule
                    return true;
                }
            }
            else // reset counter on taking move / pawn move :: these invalidate insufficient material as well
            {
                fiftyMoveCounter = 0;
            }

            // insufficient material :: only run if taking move
            if (move.takenPiece != null)
            {
                bool insufficient = true;
                int whitePieces = 0;
                int blackPieces = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (ContainsPiece(i, j)) // foreach piece on the board, collate pieces or discontinue if a pawn is found
                        {
                            Piece piece = GetPiece(i, j);
                            if (piece is Pawn || piece is Queen || piece is Rook) // pieces that invalidate the draw condition
                            {
                                insufficient = false;
                                break;
                            }
                            else if (piece.colour == PlayerColour.White)
                            {
                                whitePieces++;
                            }
                            else
                            {
                                blackPieces++;
                            }
                        }
                    }
                    if (!insufficient) { break; } // break from both loops if impossible
                }

                // if no pawns found and neither side has enough pieces
                if (insufficient && whitePieces < 3 && blackPieces < 3)
                {
                    winStatus = WinStatus.DrawInsufficient;
                    checkCell = null; // check wont be updated, clear it manually
                    return true;
                }
            }

            // draw by threefold repetition
            for (int i = 0; i < positionHistory.Count - 2; i++)
            {
                int repeats = 1;
                for (int j = i + 1; j < positionHistory.Count; j++)
                {
                    if (positionHistory[i].Substring(0, positionHistory[i].Length - 3) == positionHistory[j].Substring(0, positionHistory[j].Length - 3))
                    {
                        repeats++;
                    }
                }
                if (repeats >= 3)
                {
                    winStatus = WinStatus.DrawThreefold;
                    return true;
                }
            }

            return false; // no draw found
        }

        // updates castling rights of moving pieces after a move is made
        private void UpdateCastling(Move move)
        {
            if (move.movingPiece is King || move.movingPiece is Rook) // if king or rook moved, flag it as uncastleable
            {
                if (move.movingPiece.canCastle == true)
                {
                    GetPiece(move.positionTo).SetCastle(false);
                    castleChangeHistory.Push(true);
                }
                else
                {
                    castleChangeHistory.Push(false);
                }
            }
            else
            {
                castleChangeHistory.Push(false);
            }
        }

        // unmarks all untaken en passant pawns as takeable and assigns double jumping pawns the takeable attribute
        private void UpdateEnPassant(Move move)
        {
            bool loop = true;
            // clear all en passantable pawns
            for (int x = 0; x < 8; x++)
            {
                if (!loop) { break; }
                for (int y = 0; y < 8; y++)
                {
                    if (!loop) { break; }
                    if (ContainsPiece(x, y))
                    {
                        Piece piece = GetPiece(x, y);
                        if (piece is Pawn)
                        {
                            if ((piece as Pawn).canBeEnPassanted)   // if a pawn is flagged as takeable, unflag it
                            {
                                (GetPiece(x, y) as Pawn).SetEnPassant(false);
                                loop = false; // only one pawn can be flagged as enpassantable, dont bother checking the rest
                                              // use a variable, dont return or pawns wont be flagged as enpassantable
                            }
                        }
                    }
                }
            }

            // update pawn
            if (move.movingPiece is Pawn)
            {
                Position posF = move.positionFrom; Position posT = move.positionTo;
                if ((posF.row == 1 && posT.row == 3) || (posF.row == 6 && posT.row == 4)) // if pawn doubles, flag as takeable
                {
                    (GetPiece(posT) as Pawn).SetEnPassant(true);
                }
            }
        }

        // method run when a pawn needs to promote
        private void UpdatePromotion(Move move)
        {

            if (move.movingPiece is Pawn && (move.positionTo.row == 0 || move.positionTo.row == 7))
            {
                if ((currentTurn == PlayerColour.White && blackPlayer is AI) || (currentTurn == PlayerColour.Black && whitePlayer is AI))
                {
                    Promote((currentTurn == PlayerColour.White) ? 'q' : 'Q', move); // promote automatically for ais
                    return;
                }

                PromotionForm promotionForm = new PromotionForm(new GetPromotionCallback(Promote), move.movingPiece.colour, move);
                promotionForm.ShowDialog();
            }
        }

        // method run from promotion form when a piece is selected
        private void Promote(char type, Move move)
        {
            AddPiece(NewPieceFromCharType(type, move.movingPiece.colour), move.positionTo);
        }

        // adds a specified piece to the specified position
        internal void AddPiece(Piece piece, Position position)
        {
            board[position.column][position.row] = piece;
        }

        // removes the piece at the specified position
        private void RemovePiece(Position position)
        {
            board[position.column][position.row] = null;
        }

        // returns the position of the king of the specified colour
        private Position GetKingPosition(PlayerColour colour)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++) // foreach piece on the board
                {
                    if (ContainsPiece(i, j))
                    {
                        Piece piece = GetPiece(i, j);
                        if (piece is King && piece.colour == colour) { return new Position(i, j); }
                        // if it is a king of the specified colour, return the position
                    }
                }
            }
            return null; // prevent error throwing
        }

        // function takes a list of moves and removes all that result in check
        public List<Move> CullCheckMoves(List<Move> moves, PlayerColour colour)
        {
            List<Move> validMoves = new List<Move>();

            foreach (Move move in moves)
            {
                MakeMove(move); // make the move
                Position position = GetKingPosition(colour); // get the king
                King king = (GetPiece(position) as King);

                if (king != null)
                {
                    if (!king.IsInCheck(this, position)) // if move doesnt result in check, add the move
                    {
                        validMoves.Add(move);
                    }
                }

                UndoMove(move); // undo the move
            }

            return validMoves;
        }

        // function takes a colour and returns all possible moves for every piece of that colour
        public List<Move> AllPossibleMoves(PlayerColour colour)
        {
            List<Move> possibleMoves = new List<Move>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++) // for every piece on the board
                {
                    if (ContainsPiece(x, y))
                    {
                        if (GetPiece(x, y).colour == colour) // if it is of the specified colour
                        {
                            possibleMoves.AddRange(GetPiece(x, y).GenerateLegalMoves(this, new Position(x, y)));
                            // add all moves to big list
                        }
                    }
                }
            }
            return possibleMoves;
        }

        // updates whether a side is in check/mate or a draw
        private void UpdateWinStatus()
        {
            UpdateWinStatus(currentTurn);
        }

        internal void UpdateWinStatus(PlayerColour turn)
        {
            Position position = GetKingPosition(turn); // get the king
            King king = (GetPiece(position) as King);

            if (king.IsInCheck(this, position)) // if in check:
            {
                if (AllPossibleMoves(turn).Count == 0) // no possible moves
                {
                    winStatus = (turn == PlayerColour.White) ? WinStatus.WhiteMate : WinStatus.BlackMate; // checkmate
                    checkCell = GetKingPosition(currentTurn);
                }
                else // possible moves
                {
                    winStatus = (turn == PlayerColour.White) ? WinStatus.WhiteCheck : WinStatus.BlackCheck; // check (regular)
                    checkCell = GetKingPosition(turn);
                }
            }
            else // not in check
            {
                if (AllPossibleMoves(turn).Count == 0) // no possible moves
                {
                    winStatus = WinStatus.Stalemate; // stalemate
                }
                else // possible moves
                {
                    winStatus = WinStatus.None; // noones winning
                    checkCell = null;
                }
            }
        }

        #region board value

        public int BoardValue(bool max, int depth)
        {
            // winstatus
            switch (winStatus)
            {
                case WinStatus.WhiteMate:
                    return int.MinValue + 1 + depth;
                case WinStatus.BlackMate:
                    return int.MaxValue - depth;
                case WinStatus.Stalemate:
                    return (max ? (int.MaxValue / 2) : (int.MinValue / 2)); // HEAVILY discourage a stalemate
                default:
                    break;
            }

            int midValue = 0;
            int endValue = 0;
            int phase = 0; // use an integer instead of a bool

            // collate pieces on the board // material block
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ContainsPiece(i, j))
                    {
                        Piece piece = GetPiece(i, j);
                        bool white = (piece.colour == PlayerColour.White);

                        midValue += (white ? 1 : -1) * MaterialValue(piece.type, false); // midgame values
                        midValue += (white ? 1 : -1) * PositionalValue(i, j, piece.colour, piece.type, false);

                        endValue += (white ? 1 : -1) * MaterialValue(piece.type, true); // endgame values
                        endValue += (white ? 1 : -1) * PositionalValue(i, j, piece.colour, piece.type, true);

                        phase += piece.weight; // increment phase for piece type, pseudo "count" of pieces on the board
                        // pawns/king weigh 0, bishops/knights weigh 1, rooks weigh 2 and queens weigh 4. Change in piece classes if erroneous behaviour

                        // if white, add value, if black, subtract value
                    }
                }
            }

            // tapered evaluation // use 24 as its the default weight of the board (100% mid weight at first)
            int midWeight = phase;
            if (midWeight > 24)
            {
                midWeight = 24; // avoid errors in promotion overflow
            }
            int endWeight = 24 - midWeight;

            int value = (midValue * midWeight) + (endValue * endWeight);
            value /= 24; // take weighted average

            return value + (max ? -depth : depth); // slight penalty per depth
        }

        // MATERIAL

        private int MaterialValue(int type, bool endGame)
        {
            if (endGame)
            {
                return PIECE_MATERIAL_VALUES_END[type];
            }
            else
            {
                return PIECE_MATERIAL_VALUES_MID[type];
            }
        }

        public readonly int[] PIECE_MATERIAL_VALUES_MID = { 82, 477, 337, 365, 1025, 10000 };
        public readonly int[] PIECE_MATERIAL_VALUES_END = { 94, 512, 281, 297, 936, 10000 };

        // PIECE TABLES
        // positive is good and negative is bad for either side. usually reflections

        // function returns position value of a given piece
        private int PositionalValue(int column, int row, PlayerColour colour, int type, bool endGame)
        {
            int offset = (endGame ? 8 : 0);
            // white
            if (colour == PlayerColour.White)
            {
                int temp = (7 - row) + offset;
                switch (type)
                {
                    case 0: // pawn
                        return PAWN_TABLE[(7 - row) + offset][column]; // board starts at bottom left, array starts at top left and goes row->column
                    case 1: // rook
                        return ROOK_TABLE[(7 - row) + offset][column];
                    case 2: // knight
                        return KNIGHT_TABLE[(7 - row) + offset][column];
                    case 3: // bishop
                        return BISHOP_TABLE[(7 - row) + offset][column];
                    case 4: // queen
                        return QUEEN_TABLE[(7 - row) + offset][column];
                    case 5: // king
                        return KING_TABLE[(7 - row) + offset][column];
                }
            }
            // black
            else
            {
                switch (type)
                {
                    case 0: // pawn
                        return PAWN_TABLE[row + offset][column];
                    case 1: // rook
                        return ROOK_TABLE[row + offset][column];
                    case 2: // knight
                        return KNIGHT_TABLE[row + offset][column];
                    case 3: // bishop
                        return BISHOP_TABLE[row + offset][column];
                    case 4: // queen
                        return QUEEN_TABLE[row + offset][column];
                    case 5: // king
                        return KING_TABLE[row + offset][column];
                }
            }

            return 0;
        }

        // pawns
        private readonly int[][] PAWN_TABLE =
        {
            // mid
            new int[] { 300, 300, 300, 300, 300, 300, 300, 300, },
            new int[] { 98, 134,  61,  95,  68, 126, 34, -11, },
            new int[] { -6,   7,  26,  31,  65,  56, 25, -20, },
            new int[] { -14,  13,   6,  21,  23,  12, 17, -23, },
            new int[] { -27,  -2,  -5,  12,  17,   6, 10, -25, },
            new int[] { -26,  -4,  -4, -10,   3,   3, 33, -12, },
            new int[] { -35,  -1, -20, -23, -15,  24, 38, -22, },
            new int[] { 0,   0,   0,   0,   0,   0,   0,   0, },
            // end
            new int[] {  100, 140, 80,  100, 90,  130, 50,  0, },
            new int[] {  178, 173, 158, 134, 147, 132, 165, 187, },
            new int[] {  94, 100,  85,  67,  56,  53,  82,  84, },
            new int[] { 32,  24,  13,   5,  -2,   4,  17,  17, },
            new int[] { 13,   9,  -3,  -7,  -7,  -8,   3,  -1, },
            new int[] {  4,   7,  -6,   1,   0,  -5,  -1,  -8, },
            new int[] { 13,   8,   8,  10,  13,   0,   2,  -7, },
            new int[] {  0,   0,   0,   0,   0,   0,   0,   0, },
        };

        // rooks
        private readonly int[][] ROOK_TABLE =
        {
            new int[] {  32,  42,  32,  51, 63,  9,  31,  43, },
            new int[] {  27,  32,  58,  62, 80, 67,  26,  44, },
            new int[] { -5, 19, 26, 36, 17, 45, 61, 16, },
            new int[] { -24, -11,   7,  26, 24, 35,  -8, -20, },
            new int[] { -36, -26, -12,  -1,  9, -7,   6, -23, },
            new int[] { -45, -25, -16, -17,  3,  0,  -5, -33, },
            new int[] { -44, -16, -20,  -9, -1, 11,  -6, -71, },
            new int[] { -19, -13,   1,  17, 16,  7, -37, -26, },

            new int[] {  13, 10, 18, 15, 12,  12,   8,   5, },
            new int[] {  11, 13, 13, 11, -3,   3,   8,   3, },
            new int[] {  7,  7,  7,  5,  4,  -3,  -5,  -3, },
            new int[] {  4,  3, 13,  1,  2,   1,  -1,   2, },
            new int[] {  3,  5,  8,  4, -5,  -6,  -8, -11, },
            new int[] { -4,  0, -5, -1, -7, -12,  -8, -16, },
            new int[] { -6, -6,  0,  2, -9,  -9, -11,  -3, },
            new int[] { -9,  2,  3, -1, -5, -13,   4, -20, },
        };

        // knights
        private readonly int[][] KNIGHT_TABLE =
        {
            new int[] { -167, -89, -34, -49,  61, -97, -15, -107, },
            new int[] { -73, -41,  72,  36,  23,  62,   7,  -17, },
            new int[] { -47,  60,  37,  65,  84, 129,  73,   44, },
            new int[] { -9,  17,  19,  53,  37,  69,  18,   22, },
            new int[] { -13,   4,  16,  13,  28,  19,  21,   -8, },
            new int[] { -23,  -9,  12,  10,  19,  17,  25,  -16, },
            new int[] { -29, -53, -12,  -3,  -1,  18, -14,  -19, },
            new int[] { -105, -21, -58, -33, -17, -28, -19,  -23, },

            new int[] { -58, -38, -13, -28, -31, -27, -63, -99, },
            new int[] { -25,  -8, -25,  -2,  -9, -25, -24, -52, },
            new int[] { -24, -20,  10,   9,  -1,  -9, -19, -41, },
            new int[] { -17,   3,  22,  22,  22,  11,   8, -18, },
            new int[] { -18,  -6,  16,  25,  16,  17,   4, -18, },
            new int[] { -23,  -3,  -1,  15,  10,  -3, -20, -22, },
            new int[] { -42, -20, -10,  -5,  -2, -20, -23, -44, },
            new int[] { -29, -51, -23, -15, -22, -18, -50, -64, },
        };

        // bishops
        private readonly int[][] BISHOP_TABLE =
        {
            new int[] { -29,   4, -82, -37, -25, -42,   7,  -8, },
            new int[] { -26,  16, -18, -13,  30,  59,  18, -47, },
            new int[] { -16,  37,  43,  40,  35,  50,  37,  -2, },
            new int[] { -4,   5,  19,  50,  37,  37,   7,  -2, },
            new int[] { -6,  13,  13,  26,  34,  12,  10,   4, },
            new int[] {  0,  15,  15,  15,  14,  27,  18,  10, },
            new int[] {  4,  15,  16,   0,   7,  21,  33,   1, },
            new int[] { -33,  -3, -14, -21, -13, -12, -39, -21, },

            new int[] { -14, -21, -11,  -8, -7,  -9, -17, -24, },
            new int[] { -8,  -4,   7, -12, -3, -13,  -4, -14, },
            new int[] {  2,  -8,   0,  -1, -2,   6,   0,   4, },
            new int[] { -3,   9,  12,   9, 14,  10,   3,   2, },
            new int[] { -6,   3,  13,  19,  7,  10,  -3,  -9, },
            new int[] { -12,  -3,   8,  10, 13,   3,  -7, -15, },
            new int[] { -14, -18,  -7,  -1,  4,  -9, -15, -27, },
            new int[] { -23,  -9, -23,  -5, -9, -16,  -5, -17, },
        };

        // queens
        private readonly int[][] QUEEN_TABLE =
        {
            new int[] { -28,   0,  29,  12,  59,  44,  43,  45, },
            new int[] { -24, -39,  -5,   1, -16,  57,  28,  54, },
            new int[] { -13, -17,   7,   8,  29,  56,  47,  57, },
            new int[] { -27, -27, -16, -16,  -1,  17,  -2,   1, },
            new int[] { -9, -26,  -9, -10,  -2,  -4,   3,  -3, },
            new int[] { -14,   2, -11,  -2,  -5,   2,  14,   5, },
            new int[] { -35,  -8,  11,   2,   8,  15,  -3,   1, },
            new int[] { -1, -18, -9, 10, -15, -25, -31, -50, },

            new int[] { -9,  22,  22,  27,  27,  19,  10,  20, },
            new int[] { -17,  20,  32,  41,  58,  25,  30,   0, },
            new int[] { -20,   6,   9,  49,  47,  35,  19,   9, },
            new int[] {  3,  22,  24,  45,  57,  40,  57,  36, },
            new int[] { -18,  28,  19,  47,  31,  34,  39,  23, },
            new int[] { -16, -27,  15,   6,   9,  17,  10,   5, },
            new int[] { -22, -23, -30, -16, -16, -23, -36, -32, },
            new int[] { -33, -28, -22, -43,  -5, -32, -20, -41, },
        };

        // kings
        private readonly int[][] KING_TABLE =
        {
            new int[] { -65,  23,  16, -15, -56, -34,   2,  13 },
            new int[] {  29,  -1, -20,  -7,  -8,  -4, -38, -29, },
            new int[] { -9,  24,   2, -16, -20,   6,  22, -22, },
            new int[] { -17, -20, -12, -27, -30, -25, -14, -36, },
            new int[] { -49,  -1, -27, -39, -46, -44, -33, -51, },
            new int[] { -14, -14, -22, -46, -44, -30, -15, -27, },
            new int[] {  1,   7,  -8, -64, -43, -16,   9,   8, },
            new int[] { -15,  36,  12, -54,   8, -28,  24,  14, },

            new int[] { -74, -35, -18, -18, -11,  15,   4, -17, },
            new int[] { -12,  17,  14,  17,  17,  38,  23,  11, },
            new int[] {  10,  17,  23,  15,  20,  45,  44,  13, },
            new int[] { -8,  22,  24,  27,  26,  33,  26,   3, },
            new int[] { -18,  -4,  21,  24,  27,  23,   9, -11, },
            new int[] { -19,  -3,  11,  21,  23,  16,   7,  -9, },
            new int[] { -27, -11,   4,  13,  14,   4,  -5, -17, },
            new int[] { -53, -34, -21, -11, -28, -14, -24, -43 },
        };

        #endregion
    }
}
