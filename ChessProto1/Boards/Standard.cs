using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProto1.Boards
{
    internal class Standard : ChessBoard
    {
        public Standard() : base()
        {

        }

        protected override void StandardPositions()
        {
            base.StandardPositions();
        }

        protected override void CustomPositions()
        {
            base.CustomPositions();
        }
    }
}
