using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cauchy
{
    class Rynge_Kyt:Cauchy_Solver
    {
        public override decimal [ ] Solve( Func<decimal, decimal [ ], decimal> [ ] right_funcs, Value[] prev_value, decimal x )
        {
            dim = prev_value[0].U.Length;
            h = x - prev_value[0].X;

            decimal [ ] res = new decimal [ dim ];
            decimal [ ] [ ] k = Calculate_k( right_funcs, prev_value[0], x );
            for ( int p = 0; p < dim; ++p )
                res [ p ] = prev_value[0].U [ p ] + h * ( k [ 1 ] [ p ] + 2 * k [ 2 ] [ p ] + 2 * k [ 3 ] [ p ] + k [ 4 ] [ p ] ) / 6;
            return res;
        }

        private decimal [ ] [ ] Calculate_k ( Func<decimal , decimal [ ] , decimal> [ ] right_funcs ,Value prev_value, decimal x )
        {
            decimal [ ] [ ] k = new decimal [ 5 ] [ ];
            for ( int i = 0; i <= 4; ++i )
                k [ i ] = new decimal [ dim ];
            
            for ( int i = 0 ; i < dim ; ++i )
            {
                k [ 1 ] [ i ] = right_funcs [ i ] ( prev_value.X , Vector_u ( k [ 0 ] ,prev_value,x) );
                for ( int j = 2 ; j <= 4 ; ++j )
                    k [ j ] [ i ] = right_funcs [ i ] ( prev_value.X + h / 2 , Vector_u ( k [ j - 1 ] , prev_value, x ) );
            }
            return k;
        }

       private decimal [ ] Vector_u (  decimal [ ] k , Value prev_value, decimal x )
        {
            decimal [ ] u_vector = new decimal [ dim];
            for ( int t = 0 ; t < dim ; ++t )
                u_vector [ t ] = prev_value.U [ t ] + k[ t ] * h / 2;
            return u_vector;
        }


    }
}
