using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Helper
{
    public class Value
    {
        public double X { get; set; }
        public double [ ] U { get; set; }

        public Value( double x, double [ ] u )
        {
            X = x;
            U = u;
        }
    }
}
