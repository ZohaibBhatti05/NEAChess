﻿using ChessProto1.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Pieces
{
    internal class Bishop : Piece
    {
        public const int type = 3;
        public Bishop(PlayerColor color) : base(color)
        {
        }
    }
}
