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
        protected double h;
        public abstract double [ ] Solve ( Func<double, double [ ], double> [ ] right_funcs, Value[] prev_value ,double x );
    }
}
