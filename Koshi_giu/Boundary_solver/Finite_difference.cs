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
    class Finite_difference
    {

        decimal[] Solve(Boundary task, decimal x, decimal eps)
        { 
            int interval_count = 5;
            decimal h = ( x - task.Edge_conditions.A ) / interval_count;
            decimal error = 0;
            do
            {
                h /= 2;
                interval_count *= 2;

                decimal [ ] [ ] vectors_2h = new decimal [ 3 ] [ ];
                decimal [ ] [ ] vectors_h = new decimal [ 3 ] [ ];

                for ( int i = 0; i < 3; ++i )
                {
                    vectors_h [ i ] = new decimal [ interval_count / 2 + 1 ];
                    vectors_2h [ i ] = new decimal [ interval_count + 1 ];
                }
                decimal [ ] f_h = new decimal [ interval_count / 2 + 1 ];
                decimal [ ] f_2h = new decimal [ interval_count + 1 ];

                Init( vectors_h, vectors_2h, f_h, f_2h, task );

                decimal [ ] res_h = Tridiagonal_matrix.Right( vectors_h, f_h );
                decimal [ ] res_2h = Tridiagonal_matrix.Right( vectors_2h, f_2h );

                error = Max_error( res_h, res_2h );
            } while ( error > eps );

            throw new NotImplementedException();
        }

        void Init(decimal[][] vectors_h, decimal[][] vectors_2h, decimal[] f_h, decimal[] f_2h, Boundary task)
        {
            throw new NotImplementedException();
        }

        decimal Max_error(decimal[] vect_1, decimal[] vect_2)
        {
            throw new NotImplementedException();
        }

    }
}
