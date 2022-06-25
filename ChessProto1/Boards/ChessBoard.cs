using ChessProto1.Pieces;
using ChessProto1.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Boards
{
    public enum WinState
    {
        None,
        Draw,
        CheckWhite,
        CheckBlack,
        CheckmateWhite,
        CheckmateBlack
    }

    public enum PlayerColor
    {
        White,
        Black
    }

    public class Position
    {
        public int column;
        public int row;
        public Position(int col, int r)
        {
            column = col;
            row = r;
        }
    }

    public class Move
    {
        public Position positionF;
        public Position positionT;
        public Piece movingPiece;
        public Piece takenPiece;

        public Move(Position posF, Position posT, Piece mPiece, Piece tPiece)
        {
            positionF = posF;
            positionT = posT;
            movingPiece = mPiece;
            takenPiece = tPiece;
        }
    }

    public class ChessBoard
    {
        private Piece[][] board = new Piece[8][];
        public Stack<Move> moveHistory = new Stack<Move>();

        private Dictionary<int, int> pieceValues = new Dictionary<int, int>()
        {
            { 0, 1 },
            { 1, 5 },
            { 2, 3 },
            { 3, 3 },
            { 4, 9 },
            { 5, 100 }
        };

        public List<Position> selectedPieceMoves { get; private set; }

        public Position selectedCell { get; protected set; }
        public Position checkCell { get; protected set; }
        public Position previousCellFrom { get; protected set; }
        public Position previousCellTo { get; protected set; }

        public WinState winState { get; protected set; }
        public PlayerColor currentTurn { get; protected set; }

        private AI computer = new AI(6);

        public ChessBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }

            InitialiseGame();
        }

        private void InitialiseGame()
        {
            selectedPieceMoves = new List<Position>();
            selectedCell = new Position(-1, -1);
            currentTurn = PlayerColor.White;
            StandardPositions();
        }

        protected virtual void StandardPositions()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i][1] = new Pawn(PlayerColor.White);
                board[i][6] = new Pawn(PlayerColor.Black);
            }

            board[0][0] = new Rook(PlayerColor.White); board[7][0] = new Rook(PlayerColor.White);
            board[0][7] = new Rook(PlayerColor.Black); board[7][7] = new Rook(PlayerColor.Black);

            board[1][0] = new Knight(PlayerColor.White); board[6][0] = new Knight(PlayerColor.White);
            board[1][7] = new Knight(PlayerColor.Black); board[6][7] = new Knight(PlayerColor.Black);

            board[2][0] = new Bishop(PlayerColor.White); board[5][0] = new Bishop(PlayerColor.White);
            board[2][7] = new Bishop(PlayerColor.Black); board[5][7] = new Bishop(PlayerColor.Black);

            board[3][0] = new Queen(PlayerColor.White); board[3][7] = new Queen(PlayerColor.Black);
            board[4][0] = new King(PlayerColor.White); board[4][7] = new King(PlayerColor.Black);


            //board[0][0] = new King(PlayerColor.Black);
            //board[0][7] = new Queen(PlayerColor.White);
            //board[7][0] = new Queen(PlayerColor.White);
        }

        protected virtual void CustomPositions()
        {
            throw new NotImplementedException();
        }

        #region returning stuff

        public bool HasPiece(Position position)
        {
            return (board[position.column][position.row] != null);
        }

        public Piece GetPiece(Position position)
        {
            return board[position.column][position.row];
        }

        private bool IsMoveInValid(Position posT)
        {
            foreach (Position posF in selectedPieceMoves)
            {
                if (posF.column == posT.column && posF.row == posT.row)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        public void SelectCell(Position position) // returns true if a piece was selected or moved
        {
            if (HasPiece(position))  // selecting piece
            {
                if (board[position.column][position.row].color == currentTurn)    // same colour: select piece
                {
                    selectedCell = new Position(position.column, position.row);
                    selectedPieceMoves = board[position.column][position.row].GenerateValidMoves(this, position);
                }
                else // other colour, move there
                {
                    Position posF = selectedCell;
                    Position posT = new Position(position.column, position.row);
                    if (IsMoveInValid(posT)) // if move is valid
                    {
                        MakeMove(posF, posT);
                        SwitchTurns();
                        DeselectPiece();
                        computer.MakeMove(this);
                        currentTurn = PlayerColor.White;
                    }
                }
            }
            else // select empty cell
            {
                Position posF = selectedCell;
                Position posT = new Position(position.column, position.row);
                if (IsMoveInValid(posT)) // if move is valid
                {
                    MakeMove(posF, posT);
                    SwitchTurns();
                    DeselectPiece();
                    computer.MakeMove(this);
                    currentTurn = PlayerColor.White;
                }
            }
        }

        protected virtual string GetFENString()
        {
            return string.Empty;
        }

        #region MoveMaking

        public void MakeMove(Position posF, Position posT)
        {
            // get taken/moving pieces
            Piece movingPiece = GetPiece(posF);
            Piece takenPiece = GetPiece(posT);
            Move move = new Move(posF, posT, movingPiece, takenPiece);

            AddPiece(posT, movingPiece);    // put moving piece in new spot
            RemovePiece(posF);  // remove piece from old spot

            moveHistory.Push(move); // add move to history
            SwitchTurns();
        }

        public void UndoLastMove()
        {
            if (moveHistory.Count != 0)
            {
                Move move = moveHistory.First();

                AddPiece(move.positionF, move.movingPiece); // put moving piece back
                AddPiece(move.positionT, move.takenPiece); // put taken piece back

                moveHistory.Pop();
                SwitchTurns();
            }
        }

        public void SwitchTurns()
        {
            currentTurn = (currentTurn == PlayerColor.White) ? PlayerColor.Black : PlayerColor.White;
        }

        private void DeselectPiece()
        {
            selectedCell = new Position(-1, -1);
            selectedPieceMoves.Clear();
        }

        #endregion
        #region BoardLogistics
        public void AddPiece(Position position, Piece piece)
        {
            board[position.column][position.row] = piece;
        }

        public void RemovePiece(Position position)
        {
            board[position.column][position.row] = null;
        }

        #endregion

        #region THISISFORTHEAIIGUESS

        public int GetBoardValue()
        {
            int value = 0;

            // material
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i][j] != null)
                    {
                        Piece p = board[i][j];
                        value += (pieceValues[p.type]) * ((p.color == PlayerColor.White) ? 1 : -1);
                    }
                }
            }

            return value;
        }

        public List<(Position, Position)> AllPossibleMoves(PlayerColor color)
        {
            List<(Position, Position)> possibleMoves = new List<(Position, Position)>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i][j] != null)
                    {
                        if (board[i][j].color == color)
                        {
                            Position posF = new Position(i, j);
                            foreach (Position posT in board[i][j].GenerateValidMoves(this, posF))
                            {
                                possibleMoves.Add((posF, posT));
                            }
                        }
                    }
                }
            }
            return possibleMoves;
        }

        #endregion
    }
}
