using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype6.Boards
{
    internal class Chess960 : ChessBoard
    {
        public Chess960(UpdateBoardGraphicsCallBack updateGraphicsCallback) : base(updateGraphicsCallback)
        {
        }

        // override standard positions method from base board class
        public override void StandardPositions()
        {
            string posPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "/Tablebases/Chess960Positions.pgn";
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
