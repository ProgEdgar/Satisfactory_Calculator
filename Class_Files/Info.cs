using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Calculator.Class_Files
{
    internal class Info
    {
        public string Item, Type;
        public float Produced_Total, Actual_Produced, Needed, Leftover;

        public Info(string Item, string Type)
        {
            this.Item = Item;
            this.Type = Type;
            this.Produced_Total = 0;
            this.Actual_Produced = 0;
            this.Needed = 0;
            this.Leftover = 0;
        }
    }
}
