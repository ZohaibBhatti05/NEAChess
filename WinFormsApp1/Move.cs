using Prototype1.Boards;
using Prototype1.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype1
{
    class Move
    {
        public Piece movingPiece { get; private set; }
        public Piece takenPiece { get; private set; }
        public Position positionFrom { get; private set; }
        public Position positionTo { get; private set; }


        // initialise a standard non-taking move
        public Move(Position from, Position to, Piece moving)
        {
            movingPiece = moving;
            takenPiece = null;
            positionFrom = from;
            positionTo = to;
        }

        // initialise a standard taking move
        public Move(Position from, Position to, Piece moving, Piece taken)
        {
            movingPiece = moving;
            takenPiece = taken;
            positionFrom = from;
            positionTo = to;
        }
    }
}
