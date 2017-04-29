using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Helper
{
    public class Value
    {
        public decimal X { get; set; }
        public decimal [ ] U { get; set; }

        public Value( decimal x, decimal [ ] u )
        {
            X = x;
            U = u;
        }
    }
}
