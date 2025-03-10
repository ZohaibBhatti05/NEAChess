﻿using Prototype2.Boards;
using Prototype2.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype2
{
    public class Move
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

    class EnPassant : Move
    {
        public Position takenPosition { get; private set; }
        public EnPassant(Position from, Position to, Piece moving, Piece taken, Position takenPos) : base(from, to, moving, taken)
        {
            takenPosition = takenPos;
        }
    }

    class Castle : Move
    {
        public Position rookFrom { get; private set; }
        public Position rookTo { get; private set; }
        public Piece rook { get; private set; }

        public Castle(Position from, Position to, Piece king,
            Position rookFrom, Position rookTo, Piece rook) : base(from, to, king)
        {
            this.rookFrom = rookFrom;
            this.rookTo = rookTo;
            this.rook = rook;
        }
    }

    //class Promote : Move
    //{
    //    public char promotionPiece { get; private set; }
    //    public Promote(Position from, Position to, Piece moving, Piece taken, char promotion) : base(from, to, moving, taken)
    //    {
    //        promotionPiece = promotion;
    //    }
    //}
}
