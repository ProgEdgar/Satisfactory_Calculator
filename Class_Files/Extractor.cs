using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Extractor
    {
        public string Building;
        public char Purity, Type;
        public int Item_Quantity, Percentage;

        private const int MAX_PRODUCTION_ITEMS = 10000;
        private static bool[] usedIds = new bool[MAX_PRODUCTION_ITEMS];
        private static bool[] usedPersonalIds = new bool[MAX_PRODUCTION_ITEMS];
        public int Id { get; set; }
        public int PersonalId { get; set; }

        public Extractor(string Building, int Item_Quantity, char Type, char Purity)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Type = Type;
            this.Building = Building;
            this.Item_Quantity = Item_Quantity;
            this.Purity = Purity;
            this.Percentage = 100;
        }

        public Extractor(Extractor raw_Item)
        {
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Type = raw_Item.Type;
            this.Building = raw_Item.Building;
            this.Item_Quantity = raw_Item.Item_Quantity;
            this.Purity = raw_Item.Purity;
            this.Percentage = raw_Item.Percentage;
        }

        public Extractor(dynamic raw_Item)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Type = raw_Item.Type;
            this.Building = raw_Item.Building;
            this.Item_Quantity = raw_Item.Item_Quantity;
            this.Purity = raw_Item.Purity;
            this.Percentage = raw_Item.Percentage;
        }

        private static int GetFirstIdUnused()
        {
            int foundId = -1;
            for (int i = 0; i < MAX_PRODUCTION_ITEMS; i++)
            {
                if (usedIds[i] == false)
                {
                    foundId = i;
                    usedIds[i] = true;
                    break;
                }
            }
            return foundId;
        }

        private static int GetFirstPersonalIdUnused()
        {
            int foundPersonalId = -1;
            for (int i = 0; i < MAX_PRODUCTION_ITEMS; i++)
            {
                if (usedPersonalIds[i] == false)
                {
                    foundPersonalId = i;
                    usedPersonalIds[i] = true;
                    break;
                }
            }
            return foundPersonalId;
        }
    }
}
