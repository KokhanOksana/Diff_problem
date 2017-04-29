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
        public override double [ ] Solve( Func<double, double [ ], double> [ ] right_funcs, Value[] prev_value, double x )
        {
            dim = prev_value[0].U.Length;
            h = x - prev_value[0].X;

            double [ ] res = new double [ dim ];
            double [ ] [ ] k = Calculate_k( right_funcs, prev_value[0], x );
            for ( int p = 0; p < dim; ++p )
                res [ p ] = prev_value[0].U [ p ] + h * ( k [ 1 ] [ p ] + 2 * k [ 2 ] [ p ] + 2 * k [ 3 ] [ p ] + k [ 4 ] [ p ] ) / 6;
            return res;
        }

        private double [ ] [ ] Calculate_k ( Func<double , double [ ] , double> [ ] right_funcs ,Value prev_value, double x )
        {
            double [ ] [ ] k = new double [ 5 ] [ ];
            for ( int i = 0; i <= 4; ++i )
                k [ i ] = new double [ dim ];
            
            for ( int i = 0 ; i < dim ; ++i )
            {
                k [ 1 ] [ i ] = right_funcs [ i ] ( prev_value.X , Vector_u ( k [ 0 ] ,prev_value,x) );
                for ( int j = 2 ; j <= 4 ; ++j )
                    k [ j ] [ i ] = right_funcs [ i ] ( prev_value.X + h / 2 , Vector_u ( k [ j - 1 ] , prev_value, x ) );
            }
            return k;
        }

       private double [ ] Vector_u (  double [ ] k , Value prev_value, double x )
        {
            double [ ] u_vector = new double [ dim];
            for ( int t = 0 ; t < dim ; ++t )
                u_vector [ t ] = prev_value.U [ t ] + k[ t ] * h / 2;
            return u_vector;
        }


    }
}
