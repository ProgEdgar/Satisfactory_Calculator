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
        public int Quantity, Percentage;

        private const int MAX_PRODUCTION_ITEMS = 10000;
        private static bool[] usedIds = new bool[MAX_PRODUCTION_ITEMS];
        private static bool[] usedPersonalIds = new bool[MAX_PRODUCTION_ITEMS];
        public int Id { get; set; }
        public int PersonalId { get; set; }

        public Resource_Map(string Resource, char Type, char Purity, int Quantity)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Resource = Resource;
            this.Type = Type;
            this.Purity = Purity;
            this.Quantity = Quantity;
            this.Percentage = 100;
        }

        public Resource_Map(Resource_Map resource_Map)
        {
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Resource = resource_Map.Resource;
            this.Type = resource_Map.Type;
            this.Purity = resource_Map.Purity;
            this.Quantity = resource_Map.Quantity;
            this.Percentage = resource_Map.Percentage;
        }

        public Resource_Map(dynamic resource_Map)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Resource = resource_Map.Resource;
            this.Type = resource_Map.Type;
            this.Purity = resource_Map.Purity;
            this.Quantity = resource_Map.Quantity;
            this.Percentage = resource_Map.Percentage;
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
