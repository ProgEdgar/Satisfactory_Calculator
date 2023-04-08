using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Extractor
    {
        public string Building, Building_Code;
        public char Purity, Type;
        public int Item_Quantity, Percentage;

        public Extractor(string Building, string Building_Code, int Item_Quantity, char Type, char Purity)
        {
            this.Type = Type;
            this.Building = Building;
            this.Building_Code = Building_Code;
            this.Item_Quantity = Item_Quantity;
            this.Purity = Purity;
        }
        public Extractor(dynamic resource_Map)
        {
            this.Type = resource_Map.Type;
            this.Building = resource_Map.Building;
            this.Building_Code = resource_Map.Building_Code;
            this.Item_Quantity = resource_Map.Item_Quantity;
            this.Purity = resource_Map.Purity;
        }
    }
}
