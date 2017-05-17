using Cauchy.Helper;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy
{
    abstract class Cauchy_Solver
    {
        protected int dim ;
        protected decimal h;
        public abstract decimal [ ] Solve ( Func<decimal, decimal [ ], decimal> [ ] right_funcs, Value[] prev_value ,decimal x );
    }
}
