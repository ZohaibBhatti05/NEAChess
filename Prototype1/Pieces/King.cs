using Prototype1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1.Pieces
{
    class King : Piece
    {
        private readonly (int, int)[] moveArray =
        {
            (0, 1), (1, 1), (1, 0), (1, -1),
            (0, -1), (-1, -1), (-1, 0), (-1, 1),
        };  // readonly because const throws an error

        private readonly (int, int)[] knightMoveArray = // used in check calculations
        {
            (-1, 2), (1, 2), (2, 1), (2, -1),
            (1, -2), (-1, -2), (-2, -1), (-2, 1),
        };  // readonly because const throws an error

        public King(PlayerColour colour) : base(colour)
        {
            base.type = 5;
        }

        public override List<Move> GenerateLegalMoves(ChessBoard board, Position position)
        {
            return base.GenerateArrayMoves(board, position, moveArray);
        }

        public bool IsInCheck(ChessBoard board, Position position)
        {
            int x = position.column; int y = position.row;

            #region ROOK / QUEEN
            for (int i = x - 1; i >= 0; i--)
            {
                if (board.ContainsPiece(i, y))
                {
                    Piece piece = board.GetPiece(i, y); // if no space betwen king and opposing rook / queen, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Rook)) { return true; }
                    else { break; } // piece blocking check
                }
            }
            for (int i = x + 1; i <= 7; i++)
            {
                if (board.ContainsPiece(i, y))
                {
                    Piece piece = board.GetPiece(i, y); // if no space betwen king and opposing rook / queen, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Rook)) { return true; }
                    else { break; } // piece blocking check
                }
            }
            for (int i = y - 1; i >= 0; i--)
            {
                if (board.ContainsPiece(x, i))
                {
                    Piece piece = board.GetPiece(x, i); // if no space betwen king and opposing rook / queen, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Rook)) { return true; }
                    else { break; } // piece blocking check
                }
            }
            for (int i = y + 1; i <= 7; i++)
            {
                if (board.ContainsPiece(x, i))
                {
                    Piece piece = board.GetPiece(x, i); // if no space betwen king and opposing rook / queen, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Rook)) { return true; }
                    else { break; } // piece blocking check
                }
            }
            #endregion

            #region BISHOP / QUEEN
            for (int offset = 1; offset <= Math.Min(x, y); offset++)
            { // down left
                if (board.ContainsPiece(x - offset, y - offset))
                {
                    Piece piece = board.GetPiece(x - offset, y - offset);   // if empty space between king / opposing bishop, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Bishop)) { return true; }
                    else { break; }
                }
            }
            for (int offset = 1; offset <= Math.Min(7 - x, y); offset++)
            { // down right
                if (board.ContainsPiece(x + offset, y - offset))
                {
                    Piece piece = board.GetPiece(x + offset, y - offset);   // if empty space between king / opposing bishop, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Bishop)) { return true; }
                    else { break; }
                }
            }
            for (int offset = 1; offset <= Math.Min(x, 7 - y); offset++)
            { // up left
                if (board.ContainsPiece(x - offset, y + offset))
                {
                    Piece piece = board.GetPiece(x - offset, y + offset);   // if empty space between king / opposing bishop, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Bishop)) { return true; }
                    else { break; }
                }
            }
            for (int offset = 1; offset <= Math.Min(7 - x, 7 - y); offset++)
            { // up right
                if (board.ContainsPiece(x + offset, y + offset))
                {
                    Piece piece = board.GetPiece(x + offset, y + offset);   // if empty space between king / opposing bishop, return true
                    if (piece.colour != this.colour && (piece is Queen || piece is Bishop)) { return true; }
                    else { break; }
                }
            }

            #endregion

            #region KING / KNIGHT 

            foreach ((int x, int y) offset in moveArray) // king
            {
                if ((x + offset.x) >= 0 && (x + offset.x) <= 7 && (y + offset.y) >= 0 && (y + offset.y) <= 7) // prevent out of bounds
                // simulate reversed move position, if has opposing king, return true
                {
                    if (board.ContainsPiece(x + offset.x, y + offset.y))
                    {
                        Piece piece = board.GetPiece(x + offset.x, y + offset.y);
                        if (piece.colour != this.colour && piece is King) { return true; }
                    }
                }
            }

            foreach ((int x, int y) offset in knightMoveArray) // knight
            {
                if ((x + offset.x) >= 0 && (x + offset.x) <= 7 && (y + offset.y) >= 0 && (y + offset.y) <= 7) // prevent out of bounds
                // simulate reversed move position, if has opposing knight, return true
                {
                    if (board.ContainsPiece(x + offset.x, y + offset.y))
                    {
                        Piece piece = board.GetPiece(x + offset.x, y + offset.y);
                        if (piece.colour != this.colour && piece is Knight) { return true; }
                    }
                }
            }

            #endregion

            #region PAWNS

            int vertOffset = (this.colour == PlayerColour.White) ? 1 : -1; // use -1 or 1 instead of seperate code for black white
            // if white check above for black pawns and vice versa

            if ((y + vertOffset) > 0 && (y + vertOffset) < 7) // remember that kings CAN be on the top/bottom of board, check y coords
            {
                if (x > 0)  // prevent out of bounds check 
                {
                    if (board.ContainsPiece(x - 1, y + vertOffset))  // if position/s contains opposing pawn, return true
                    {
                        Piece piece = board.GetPiece(x - 1, y + vertOffset);
                        if (piece is Pawn && piece.colour != this.colour) { return true; }
                    }
                }
                if (x < 7)
                {

                    if (board.ContainsPiece(x + 1, y + vertOffset))  // if position/s contains opposing pawn, return true
                    {
                        Piece piece = board.GetPiece(x + 1, y + vertOffset);
                        if (piece is Pawn && piece.colour != this.colour) { return true; }
                    }
                }
            }
            #endregion

            return false; // no threats found
        }
    }
}
