using Cauchy.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cauchy;
using Koshi_giu.Tasks;
using Koshi_giu.Helper;

namespace Koshi_giu.Boundary_solver
{
     static class Finite_difference
    {

        public static decimal [ ]  Solve(Boundary task, decimal x, decimal eps)
        {
            decimal [ ] res;
            int interval_count = 6;
            decimal h = ( x - task.Edge_conditions.Start ) / interval_count;
            decimal error = 0;

            decimal [ ] [ ] vectors_h = new decimal [ 3 ] [ ];
            decimal [ ] [ ] vectors_2h = new decimal [ 3 ] [ ];
            for ( int i = 0; i < 3; ++i )
                vectors_2h [ i ] = new decimal [ interval_count + 1 ];

            decimal [ ] f_2h = new decimal [ interval_count + 1 ];
            Init( vectors_2h, f_2h, task, x );

            do
            {
                h /= 2;
                interval_count *= 2;

                for ( int i = 0; i < 3; ++i )
                {
                    vectors_h [ i ] = new decimal [ interval_count / 2 + 1 ];
                    vectors_2h [ i ].CopyTo( vectors_h[i], 0 );
                    vectors_2h [ i ] = new decimal [ interval_count + 1 ];
                }
                decimal [ ] f_h = new decimal [ interval_count / 2 + 1 ];
                f_2h.CopyTo( f_h, 0 );
                f_2h = new decimal [ interval_count + 1 ];

                Init( vectors_2h, f_2h, task ,x);

                decimal [ ] res_h = Tridiagonal_matrix.Right( vectors_h, f_h );
                decimal [ ] res_2h = Tridiagonal_matrix.Right( vectors_2h, f_2h );
                res = res_2h;
                error = Max_error( res_h, res_2h );
            } while ( error > eps );

            return res;
        }

        static void Init( decimal [ ] [ ] vectors_h, decimal [ ] f_h, Boundary task, decimal x )
        {
            int node_count = f_h.Length;
            decimal h = ( x - task.Edge_conditions.Start ) / ( node_count - 1 );

            vectors_h [ 1 ] [ 0 ] = 1;
            decimal denominator = task.Edge_conditions.Coef_start_fun * h - task.Edge_conditions.Coef_start_diff;
            vectors_h [ 2 ] [ 0 ] = task.Edge_conditions.Coef_start_diff / denominator;
            f_h [ 0 ] = (task.Edge_conditions.Val_start * h) / denominator;

            for ( int i = 1; i < node_count - 1; ++i )
            {
                decimal current_x = task.Edge_conditions.Start + i * h;
                vectors_h [ 0 ] [ i ] =  2 - h * task.Equal.Diff_coef( current_x );
                vectors_h [ 1 ] [ i ] = -4 + 2 * h * h * task.Equal.Func_coef( current_x );
                vectors_h [ 2 ] [ i ] =  2 + h * task.Equal.Diff_coef( current_x );

                f_h [ i ] = task.Equal.Right_func( current_x ) * 2 * h * h ;
            }

            vectors_h [ 1 ] [ node_count - 1 ] = 1;
            denominator = task.Edge_conditions.Coef_end_fun * h + task.Edge_conditions.Coef_end_diff;
            vectors_h [ 0 ] [ node_count - 1 ] = -task.Edge_conditions.Coef_end_diff / denominator;
            f_h [ node_count - 1 ] = task.Edge_conditions.Val_end * h / denominator;
        }

        static decimal Max_error(decimal[] vect_1, decimal[] vect_2)
        {
            decimal [ ] errors = new decimal [ vect_1.Length ];
            for ( int i1 = 0, i2 = 0; i1 < vect_1.Length; ++i1, i2 += 2 )
                errors [ i1 ] = Math.Abs( vect_1 [ i1 ] - vect_2 [ i2 ] );
            return errors.Max();
        }

    }
}
