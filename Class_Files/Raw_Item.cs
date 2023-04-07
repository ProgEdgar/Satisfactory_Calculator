using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Raw_Item
    {
        public string Building;
        public char Type;
        public int Item_Quantity;

        public Raw_Item() { }
        public Raw_Item(string Building, int Item_Quantity, char Type)
        {
            this.Building = Building;
            this.Item_Quantity = Item_Quantity;
            this.Type = Type;
        }
    }
}
