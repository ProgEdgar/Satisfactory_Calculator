using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Vehicle
    {
        public string Vehicle_Name, Fuel;
        public float Quantity, Extra_Quantity, Power_Min, Power_Max;

        private const int MAX_PRODUCTION_ITEMS = 10000;
        private static bool[] usedIds = new bool[MAX_PRODUCTION_ITEMS];
        private static bool[] usedPersonalIds = new bool[MAX_PRODUCTION_ITEMS];
        public int Id { get; set; }
        public int PersonalId { get; set; }

        public Vehicle(string Vehicle_Name, string Fuel, float Quantity, float Extra_Quantity, float Power_Min, float Power_Max)
        {
            this.Vehicle_Name = Vehicle_Name;
            this.Fuel = Fuel;
            this.Quantity = Quantity;
            this.Extra_Quantity = Extra_Quantity;
            this.Power_Min = Power_Min;
            this.Power_Max = Power_Max;
        }

        public Vehicle(Vehicle vehicle)
        {
            this.Id = vehicle.Id;
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Vehicle_Name = vehicle.Vehicle_Name;
            this.Fuel = vehicle.Fuel;
            this.Quantity = vehicle.Quantity;
            this.Extra_Quantity = vehicle.Extra_Quantity;
            this.Power_Min = vehicle.Power_Min;
            this.Power_Max = vehicle.Power_Max;
        }

        public Vehicle(dynamic vehicle)
        {
            this.Id = GetFirstIdUnused();
            this.PersonalId = GetFirstPersonalIdUnused();
            this.Vehicle_Name = vehicle.Vehicle_Name;
            this.Fuel = vehicle.Fuel;
            this.Quantity = vehicle.Quantity;
            this.Extra_Quantity = vehicle.Extra_Quantity;
            this.Power_Min = vehicle.Power_Min;
            this.Power_Max = vehicle.Power_Max;
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
