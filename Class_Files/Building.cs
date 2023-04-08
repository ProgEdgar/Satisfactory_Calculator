using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Building
    {
        public string Building_Name, Type, Fuel;
        public float Power_Min, Power_Max; 
        
        private const int MAX_BUILDINGS = 10000;
        private static bool[] usedIds = new bool[MAX_BUILDINGS];
        public int Id { get; set; }

        public Building(string Building_Name, string Type, string Fuel, float Power_Min, float Power_Max)
        {
            this.Id = GetFirstUnused();
            this.Building_Name = Building_Name;
            this.Type = Type;
            this.Fuel = Fuel;
            this.Power_Min = Power_Min;
            this.Power_Max = Power_Max;
        }
        private static int GetFirstUnused()
        {
            int foundId = -1;
            for (int i = 0; i < MAX_BUILDINGS; i++)
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
    }
}
