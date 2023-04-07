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

        public Generator() { }
        public Generator(string Name, string Building, string In_Material_1, float In_Material_Quantity_1,
            string In_Material_2, float In_Material_Quantity_2, string Main_Material, float Main_Material_Quantity, float Power_Min, float Power_Max)
        {
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
        }
    }
}
