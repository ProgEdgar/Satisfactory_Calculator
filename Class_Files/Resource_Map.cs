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
        public char Type;
        public int Quantity;

        public Resource_Map() { }
        public Resource_Map(string Resource, char Type, int Quantity)
        {
            this.Resource = Resource;
            this.Type = Type;
            this.Quantity = Quantity;
        }
    }
}
