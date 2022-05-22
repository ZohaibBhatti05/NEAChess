using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor color) : base(color)
        {
            base.type = 4;
        }

        public override List<Position> GenerateValidMoves(ChessBoard board, Position pos)
        {
            List<Position> moves = new List<Position>();
            foreach(Position position in base.GetHorizontalMoves(board, pos))
            {
                moves.Add(position);
            }
            foreach (Position position in base.GetDiagonalMoves(board, pos))
            {
                moves.Add(position);
            }


            return moves;
        }
    }
}
