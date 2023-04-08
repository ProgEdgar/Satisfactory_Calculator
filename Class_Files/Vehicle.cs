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

        public Vehicle(string Vehicle_Name, string Fuel, float Quantity, float Extra_Quantity, float Power_Min, float Power_Max)
        {
            this.Vehicle_Name = Vehicle_Name;
            this.Fuel = Fuel;
            this.Quantity = Quantity;
            this.Extra_Quantity = Extra_Quantity;
            this.Power_Min = Power_Min;
            this.Power_Max = Power_Max;
        }
    }
}
