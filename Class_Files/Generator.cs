using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Generator
    {
        public string Name, Building, In_Material_1, In_Material_2, Main_Material;
        public float In_Material_Quantity_1, In_Material_Quantity_2, Main_Material_Quantity, Power_Min, Power_Max;
        public int Percentage;

        private const int MAX_PRODUCTION_ITEMS = 10000;
        private static bool[] usedIds = new bool[MAX_PRODUCTION_ITEMS];
        private static bool[] usedPersonalIds = new bool[MAX_PRODUCTION_ITEMS];
        public int Id { get; set; }
        public int PersonalId { get; set; }

        public Generator(string Name, string Building, string In_Material_1, float In_Material_Quantity_1,
            string In_Material_2, float In_Material_Quantity_2, string Main_Material, float Main_Material_Quantity, float Power_Min, float Power_Max)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Name = Name;
            this.Building = Building;
            this.In_Material_1 = In_Material_1;
            this.In_Material_Quantity_1 = In_Material_Quantity_1;
            this.In_Material_2 = In_Material_2;
            this.In_Material_Quantity_2 = In_Material_Quantity_2;
            this.Main_Material = Main_Material;
            this.Main_Material_Quantity = Main_Material_Quantity;
            this.Power_Min = Power_Min;
            this.Power_Max = Power_Max;
            this.Percentage = 100;
        }

        public Generator(Generator generator)
        {
            this.Id = generator.Id;
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Name = generator.Name;
            this.Building = generator.Building;
            this.In_Material_1 = generator.In_Material_1;
            this.In_Material_Quantity_1 = generator.In_Material_Quantity_1;
            this.In_Material_2 = generator.In_Material_2;
            this.In_Material_Quantity_2 = generator.In_Material_Quantity_2;
            this.Main_Material = generator.Main_Material;
            this.Main_Material_Quantity = generator.Main_Material_Quantity;
            this.Power_Min = generator.Power_Min;
            this.Power_Max = generator.Power_Max;
            this.Percentage = generator.Percentage;
        }

        public Generator(dynamic generator)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Name = generator.Name;
            this.Building = generator.Building;
            this.In_Material_1 = generator.In_Material_1;
            this.In_Material_Quantity_1 = generator.In_Material_Quantity_1;
            this.In_Material_2 = generator.In_Material_2;
            this.In_Material_Quantity_2 = generator.In_Material_Quantity_2;
            this.Main_Material = generator.Main_Material;
            this.Main_Material_Quantity = generator.Main_Material_Quantity;
            this.Power_Min = (generator.Power_Min != null? generator.Power_Min:0);
            this.Power_Max = (generator.Power_Max != null ? generator.Power_Max : 0);
            this.Percentage = generator.Percentage;
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
