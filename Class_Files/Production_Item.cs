using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Production_Item
    {
        public string Item_Production_Name, Building, In_Material_1, In_Material_2, In_Material_3, In_Material_4, Main_Material, Extra_Material;
        public float In_Material_Quantity_1, In_Material_Quantity_2, In_Material_Quantity_3, In_Material_Quantity_4, Main_Material_Quantity, Extra_Material_Quantity;
        public int Percentage;

        private const int MAX_PRODUCTION_ITEMS = 10000;
        private static bool[] usedIds = new bool[MAX_PRODUCTION_ITEMS];
        private static bool[] usedPersonalIds = new bool[MAX_PRODUCTION_ITEMS];
        public int Id { get; set; }
        public int PersonalId { get; set; }

        public Production_Item(string Item_Production_Name, string Building, string In_Material_1, float In_Material_Quantity_1,
            string In_Material_2, float In_Material_Quantity_2, string In_Material_3, float In_Material_Quantity_3, string In_Material_4, float In_Material_Quantity_4,
            string Main_Material, float Main_Material_Quantity, string Extra_Material, float Extra_Material_Quantity)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Item_Production_Name = Item_Production_Name;
            this.Building = Building;
            this.In_Material_1 = In_Material_1;
            this.In_Material_Quantity_1 = In_Material_Quantity_1;
            this.In_Material_2 = In_Material_2;
            this.In_Material_Quantity_2 = In_Material_Quantity_2;
            this.In_Material_3 = In_Material_3;
            this.In_Material_Quantity_3 = In_Material_Quantity_3;
            this.In_Material_4 = In_Material_4;
            this.In_Material_Quantity_4 = In_Material_Quantity_4;
            this.Main_Material = Main_Material;
            this.Main_Material_Quantity = Main_Material_Quantity;
            this.Extra_Material = Extra_Material;
            this.Extra_Material_Quantity = Extra_Material_Quantity;
            this.Percentage = 100;
        }

        public Production_Item(Production_Item production_Item)
        {
            this.Id = production_Item.Id;
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Item_Production_Name = production_Item.Item_Production_Name;
            this.Building = production_Item.Building;
            this.In_Material_1 = production_Item.In_Material_1;
            this.In_Material_Quantity_1 = production_Item.In_Material_Quantity_1;
            this.In_Material_2 = production_Item.In_Material_2;
            this.In_Material_Quantity_2 = production_Item.In_Material_Quantity_2;
            this.In_Material_3 = production_Item.In_Material_3;
            this.In_Material_Quantity_3 = production_Item.In_Material_Quantity_3;
            this.In_Material_4 = production_Item.In_Material_4;
            this.In_Material_Quantity_4 = production_Item.In_Material_Quantity_4;
            this.Main_Material = production_Item.Main_Material;
            this.Main_Material_Quantity = production_Item.Main_Material_Quantity;
            this.Extra_Material = production_Item.Extra_Material;
            this.Extra_Material_Quantity = production_Item.Extra_Material_Quantity;
            this.Percentage = production_Item.Percentage;
        }

        public Production_Item(dynamic production_Item)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Item_Production_Name = production_Item.Item_Production_Name;
            this.Building = production_Item.Building;
            this.In_Material_1 = production_Item.In_Material_1;
            this.In_Material_Quantity_1 = production_Item.In_Material_Quantity_1;
            this.In_Material_2 = production_Item.In_Material_2;
            this.In_Material_Quantity_2 = production_Item.In_Material_Quantity_2;
            this.In_Material_3 = production_Item.In_Material_3;
            this.In_Material_Quantity_3 = production_Item.In_Material_Quantity_3;
            this.In_Material_4 = production_Item.In_Material_4;
            this.In_Material_Quantity_4 = production_Item.In_Material_Quantity_4;
            this.Main_Material = production_Item.Main_Material;
            this.Main_Material_Quantity = production_Item.Main_Material_Quantity;
            this.Extra_Material = production_Item.Extra_Material;
            this.Extra_Material_Quantity = production_Item.Extra_Material_Quantity;
            this.Percentage = production_Item.Percentage;
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
