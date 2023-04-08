using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Resource_Map
    {
        public string Resource;
        public char Type, Purity;
        public int Quantity;

        public Resource_Map(string Resource, char Type, char Purity, int Quantity)
        {
            this.Resource = Resource;
            this.Type = Type;
            this.Purity = Purity;
            this.Quantity = Quantity;
        }
    }
}
