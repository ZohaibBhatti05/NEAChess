using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype4.Boards
{
    class Human : Player
    {
        private string name;

        public Human(string name)
        {
            this.name = name;
        }
    }
}
