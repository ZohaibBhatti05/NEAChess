﻿using Prototype2.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prototype2.Boards
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
        DrawFifty,
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
    }

    public class ChessBoard
    {
        protected UpdateBoardGraphicsCallBack graphicsCallBack;

        public PlayerColour currentTurn { get; private set; }

        public Position selectedCell { get; private set; }
        public Position checkCell { get; private set; }

        public List<Move> selectedMoves { get; private set; }

        private Stack<Move> moveHistory;
        private Stack<Position> checkCellHistory;
        private Stack<WinStatus> winStatusHistory;
        private Stack<bool> castleChangeHistory;

        public Piece[][] board { get; private set; }

        private Player whitePlayer;
        private Player blackPlayer;

        private int fiftyMoveCounter = 0;

        public WinStatus winStatus { get; private set; }

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
            checkCellHistory = new Stack<Position>();
            checkCellHistory.Push(null);
            winStatusHistory = new Stack<WinStatus>();
            winStatusHistory.Push(WinStatus.None);
            currentTurn = PlayerColour.White;
            selectedMoves = new List<Move>();
            castleChangeHistory = new Stack<bool>();
            winStatus = WinStatus.None;

            // initialise players
            InitialisePlayers();

            // change later to allow custom positions
            StandardPositions();
        }

        private void InitialisePlayers()
        {
            whitePlayer = new Human();
            blackPlayer = new AI(4, PlayerColour.Black); // hardcoded ply depth
            //blackPlayer = new Human();
        }

        // function loads standard positions :: override if child classes are implemented
        private void StandardPositions()
        {
            // fen for standard position
            //PositionFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");

            // custom fen for testing
            PositionFromFEN("7k/8/1r6/8/8/1P6/2P5/7K");

            // empty for analysis setup boards: 8/8/8/8/8/8/8/8 w - - 0 1
        }

        // places pieces from a FEN string
        // error checking should be added if user inputted FEN is implemented
        private void PositionFromFEN(string FEN)
        {
            int file = 0; int rank = 7; // program displays from bottom up, FEN goes from top to bottom, so rank goes from 7 to 0
            foreach (char c in FEN)
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
            }
            return null;
        }

        // returns the FEN char of a given piece
        private char CharFromPiece(Piece piece)
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
                    graphicsCallBack.Invoke();
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
                        graphicsCallBack.Invoke();
                        return;
                    }

                    // of a different colour: try to make a move
                    else
                    {
                        foreach(Move move in selectedMoves) // if position is in a valid move, make the move
                        {
                            if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                            {
                                MakeMove(move);
                                AfterMove(move);
                                graphicsCallBack.Invoke();
                                return;
                            }
                        }
                    }
                }

                // if selecting an empty square
                else
                {
                    foreach(Move move in selectedMoves) // if position is in a valid move, make the move
                    {
                        if ((position.column == move.positionTo.column) && (position.row == move.positionTo.row))
                        {
                            MakeMove(move);
                            AfterMove(move);
                            graphicsCallBack.Invoke();
                            return;
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
                UndoMove(move); // undo the move
                graphicsCallBack.Invoke();
                // switch back to player who made move
                currentTurn = (currentTurn == PlayerColour.White) ? PlayerColour.Black : PlayerColour.White;

                // unselect cell
                selectedCell = null;
                graphicsCallBack.Invoke();

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
            }
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

            // update draw conditions BEFORE win status
            bool draw = UpdateDrawConditions(move);

            if (!draw)
            {
                // update win status for check/mate/draw
                UpdateWinStatus();
            }

            // add move to history
            moveHistory.Push(move);
            checkCellHistory.Push(checkCell);
            winStatusHistory.Push(winStatus);

            graphicsCallBack.Invoke();

            // if other player is an AI, make an AI move
            UpdatePlayers();
        }

        // method allows computer players to make moves
        private void UpdatePlayers()
        {
            graphicsCallBack.Invoke();

            if ((winStatus == WinStatus.None || winStatus == WinStatus.BlackCheck || winStatus == WinStatus.WhiteCheck))
            {

                if (currentTurn == PlayerColour.White && whitePlayer is AI)
                {
                    Move move = (whitePlayer as AI).MakeMove(this);
                    MakeMove(move);
                    AfterMove(move);
                    graphicsCallBack.Invoke();
                }

                else if (currentTurn == PlayerColour.Black && blackPlayer is AI)
                {
                    Move move = (blackPlayer as AI).MakeMove(this);
                    MakeMove(move);
                    AfterMove(move);
                    graphicsCallBack.Invoke();
                }
            }
        }

        // check for draw by insufficiency, 50 move and threefold repetition
        private bool UpdateDrawConditions(Move move)
        {
            // 50 move rule
            if (move.takenPiece is null && !(move.movingPiece is Pawn)) // if no piece taken / pawn moved
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
            if (move.takenPiece != null || (move.movingPiece is Pawn && (move.positionTo.row % 7 == 0)))
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
            for(int x = 0; x < 8; x++)
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
                    if (ContainsPiece(i , j))
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
            // test for other draw types here
        }

        #region board value

        public int BoardValue(bool max, int depth)
        {
            // winstatus
            switch (winStatus)
            {
                case WinStatus.WhiteMate:
                    return int.MinValue + depth;
                case WinStatus.BlackMate:
                    return int.MaxValue - depth;
                case WinStatus.Stalemate:
                    return (max ? (int.MaxValue / 2) : (int.MinValue / 2)); // HEAVILY discourage a stalemate
                default:
                    break;
            }

            int value = 0;

            // collate pieces on the board // material block
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ContainsPiece(i, j))
                    {
                        Piece piece = GetPiece(i, j);

                        value += ((piece.colour == PlayerColour.White) ? 1 : -1) * MaterialValue(piece.type);

                        value += ((piece.colour == PlayerColour.White) ? 1 : -1) * PositionalValue(i, j, piece.colour, piece.type);
                        // if white, add value, if black, subtract value
                    }
                }
            }

            return value + (max ? -depth : depth); // add very slight penalty for later moves
        }

        // MATERIAL

        private int MaterialValue(int type)
        {
            return PIECE_MATERIAL_VALUES[type];
        }

        private readonly int[] PIECE_MATERIAL_VALUES = { 100, 500, 330, 350, 900, 10000 };

        // PIECE TABLES
        // positive is good and negative is bad for either side. usually reflections

        // function returns position value of a given piece
        private int PositionalValue(int column, int row, PlayerColour colour, int type)
        {
            // white
            if (colour == PlayerColour.White)
            {
                switch (type)
                {
                    case 0: // pawn
                        return PAWN_TABLE[7 - row][column]; // board starts at bottom left, array starts at top left and goes row->column
                    case 1: // rook
                        return ROOK_TABLE[7 - row][column];
                    case 2: // knight
                        return KNIGHT_TABLE[7 - row][column];
                    case 3: // bishop
                        return BISHOP_TABLE[7 - row][column];
                    case 4: // queen
                        return QUEEN_TABLE[7 - row][column];
                    case 5: // king
                        return KING_TABLE[7 - row][column];
                }
            }
            // black
            else
            {
                switch (type)
                {
                    case 0: // pawn
                        return PAWN_TABLE[row][column];
                    case 1: // rook
                        return ROOK_TABLE[row][column];
                    case 2: // knight
                        return KNIGHT_TABLE[row][column];
                    case 3: // bishop
                        return BISHOP_TABLE[row][column];
                    case 4: // queen
                        return QUEEN_TABLE[row][column];
                    case 5: // king
                        return KING_TABLE[row][column];
                }
            }

            return 0;
        }

        // MIDGAME

        // pawns: advance, if in middle prioritise controlling the center
        private readonly sbyte[][] PAWN_TABLE =
        {
            new sbyte[] { 60, 60, 60,  60,  60,  60,  60, 60 },
            new sbyte[] { 50, 50, 50,  50,  50,  50,  50, 50 },
            new sbyte[] { 10, 10, 20,  30,  30,  20,  10, 10 },
            new sbyte[] { 5,  5,  10,  25,  25,  10,  5,  5  },
            new sbyte[] { 0,  0,  0,   20,  20,  0,   0,  0  },
            new sbyte[] { 5, -5, -10,  0,   0,  -10, -5,  5  },
            new sbyte[] { 5,  10, 10, -20, -20,  10,  10, 5  },
            new sbyte[] { 0,  0,  0,   0,   0,   0,   0,  0  },
        };

        // rooks: not really any good/bad places to be, but avoid harsh edges a bit unless on a corner
        private readonly sbyte[][] ROOK_TABLE =
        {
            new sbyte[] {  0, 0, 0, 0, 0, 0, 0, 0, },
            new sbyte[] {  5, 5, 5, 5, 5, 5, 5, 5, },
            new sbyte[] { -5, 0, 0, 0, 0, 0, 0, -5 },
            new sbyte[] { -5, 0, 0, 0, 0, 0, 0, -5 },
            new sbyte[] { -5, 0, 0, 0, 0, 0, 0, -5 },
            new sbyte[] { -5, 0, 0, 0, 0, 0, 0, -5 },
            new sbyte[] { -5, 0, 0, 0, 0, 0, 0, -5 },
            new sbyte[] { -5, 0, 0, 0, 0, 0, 0, -5 },
        };

        // knights: the closer to the center, the better, the closer to the corner, the worse
        private readonly sbyte[][] KNIGHT_TABLE =
        {
            new sbyte[] { -50, -40, -35, -30, -30, -35, -40, -50 },
            new sbyte[] { -40, -25, -5,   0,   0,  -5,  -25, -40 },
            new sbyte[] { -35,  0,   5,   15,  15,  5,   0,  -35 },
            new sbyte[] { -30,  0,   15,  30,  30,  15,  0,  -30 },
            new sbyte[] { -30,  0,   15,  30,  30,  15,  0,  -30 },
            new sbyte[] { -35,  0,   5,   15,  15,  5,   0,  -35 },
            new sbyte[] { -40, -25, -5,   0,   0,  -5,  -25, -40 },
            new sbyte[] { -50, -40, -35, -30, -30, -35, -40, -50 },
        };

        // bishops: avoid corners and edges, center is better for further ranks and vice versa for black
        // discourage positions allowing opposite side to attack/develop pawns
        private readonly sbyte[][] BISHOP_TABLE =
        {
            new sbyte[] { -30, -20, -20, -20, -20, -20, -20, -30 },
            new sbyte[] { -20,  0,   0,   0,   0,   0,   0,  -20 },
            new sbyte[] { -10,  0,   0,   5,   5,   0,   0,  -10 },
            new sbyte[] { -10,  0,   0,   5,   5,   0,   0,  -10 },
            new sbyte[] { -10,  0,   5,   10,  10,  5,   0,  -10 },
            new sbyte[] { -10,  5,   10,  10,  10,  10,  5,  -10 },
            new sbyte[] { -20,  5,   0,   0,   0,   0,   5,  -20 },
            new sbyte[] { -30, -20, -20, -20, -20, -20, -20, -30 },
        };

        // queens: avoid the opposite rank, avoid the very middle of the board, but encourage coverage
        private readonly sbyte[][] QUEEN_TABLE =
        {
            new sbyte[] { -15, -20, -30, -20, -40, -30, -20, -15 },
            new sbyte[] { -20, -10, -20, -5,  -5,  -5,  -10, -20 },
            new sbyte[] { -5,   0,   0,   5,   5,   0,   0,   0  },
            new sbyte[] {  0,   0,   5,   5,   5,   5,   0,  -5  },
            new sbyte[] { -5,   0,   5,   0,   0,   0,   0,   0  },
            new sbyte[] { -5,   5,   0,   0,   5,   0,   0,  -5  },
            new sbyte[] { -10, -5,   5,   5,   0,   0,   0,  -10 },
            new sbyte[] { -15, -10, -10, -5,  -5,  -10, -10, -15 },
        };

        // kings: encourage castling, discourage advancing
        private readonly sbyte[][] KING_TABLE =
        {
            new sbyte[] { -60, -60, -60, -60, -60, -60, -60, -60 },
            new sbyte[] { -50, -50, -50, -50, -50, -50, -50, -50 },
            new sbyte[] { -40, -40, -40, -40, -40, -40, -40, -40 },
            new sbyte[] { -30, -30, -30, -30, -30, -30, -30, -30 },
            new sbyte[] { -20, -20, -30, -40, -40, -30, -20, -20 },
            new sbyte[] { -10, -10, -20, -20, -20, -20, -10, -10 },
            new sbyte[] {  10,  10,  0,   0,   0,   0,   10,  10 },
            new sbyte[] {  20,  30,  30,  0,   0,   30,  30,  20 },
        };

        // ENDGAME



        #endregion
    }
}
