using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype7.Boards
{
    internal class Analysis : ChessBoard
    {
        public Analysis(UpdateBoardGraphicsCallBack updateGraphicsCallback) : base(updateGraphicsCallback)
        {

        }

        private List<string> gameMoveNameHistory = new List<string>();

        public void SetupAnalysis(string FEN, string PGN)
        {
            base.PositionFromFEN(FEN);

            gameMoveNameHistory = PGN.Split(", ").ToList();
            base.moveNameHistory = gameMoveNameHistory;
        }



        public void RedoNextMove()
        {

        }
    }
}
