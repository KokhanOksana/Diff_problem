using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy
{
    class Adams_Bashford:Cauchy_Solver
    {
        public override double [ ] Solve( Func<double, double [ ], double> [ ] right_funcs, Value[] prev_value, double x )
        {
            int dim = prev_value[3].U.Length;
            double h = x - prev_value[3].X;

            double [ ] res = new double [ dim ];
            for ( int p = 0; p < dim; ++p )
                res [ p ] = prev_value[3].U[ p ]
                    + h
                        * ( 55 * right_funcs [ p ]( prev_value [ 3 ].X, prev_value[ 3 ].U )
                        - 59 * right_funcs [ p ]( prev_value [ 2 ].X, prev_value [ 2 ].U )
                        + 37 * right_funcs [ p ]( prev_value [ 1 ].X, prev_value [ 1 ].U )
                        - 9 * right_funcs [ p ]( prev_value [ 0 ].X, prev_value [ 0 ].U ) )
                    / 24;
            return res;
        }
    }
}
