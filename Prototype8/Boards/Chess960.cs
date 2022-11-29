using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Prototype8.Boards
{
    internal class Chess960 : ChessBoard
    {
        public Chess960(UpdateBoardGraphicsCallBack updateGraphicsCallback) : base(updateGraphicsCallback)
        {
        }

        // override standard positions method from base board class
        public override void StandardPositions()
        {
            string posPath =
                "C:/Users/Zobear/source/repos/NEAChess/" +
                 //"C:/Users/Zohaib/source/repos/NEAChess/" +
                 "/Tablebases/Chess960Positions.pgn";
            StreamReader reader = new StreamReader(posPath); // open file of FEN strings

            string FEN = string.Empty; // position to load

            Random random = new Random();
            int pos = random.Next(0, 960);

            for (int i = 0; i <= pos; i++)
            {
                FEN = reader.ReadLine(); // get position in file of randomly selected position
            }

            base.PositionFromFEN(FEN); // load position
        }
    }
}