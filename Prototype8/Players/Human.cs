using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototype8.Players
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