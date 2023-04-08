using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Fuel
    {
        public string Item, Used_For;
        public int Energy;

        public Fuel(string Item, int Energy, string Used_For)
        {
            this.Item = Item;
            this.Energy = Energy;
            this.Used_For = Used_For;
        }
    }
}
