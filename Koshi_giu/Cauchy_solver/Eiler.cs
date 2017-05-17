using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cauchy
{
    class Eiler_method:Cauchy_Solver
    {

        public override decimal [ ] Solve( Func<decimal, decimal [ ], decimal> [ ] right_funcs, Value [ ] prev_value, decimal x )
        {
            int dim = prev_value [ 3 ].U.Length;
            decimal h = x - prev_value [ 3 ].X;

            decimal [ ] res = new decimal [ dim ];
            for ( int p = 0; p < dim; ++p )
                res [ p ] = prev_value[0].U[ p ] + h * right_funcs [ p ](prev_value[0].X, prev_value[0].U );
            return res;
        }
    }
}
