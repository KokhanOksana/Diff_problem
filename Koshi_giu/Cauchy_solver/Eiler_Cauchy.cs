using Cauchy.Helper;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy
{
    class Eiler_Cauchy :Cauchy_Solver
    {
        public override decimal [ ] Solve( Func<decimal, decimal [ ], decimal> [ ] right_funcs, Value [ ] prev_value, decimal x )
        {
            dim = prev_value.Last().U.Length;
            h = x - prev_value.Last().X;

            decimal [ ] res = Calculate_u(right_funcs,prev_value[0],x);
            res = Correct( right_funcs,prev_value[0],new Value(x,res),0.00000001M );
            return res;
        }

        private decimal [ ] Calculate_u ( Func<decimal, decimal [ ], decimal> [ ] right_funcs, Value prev_value, decimal x )
        {
                            
            decimal [ ] res = new decimal [ dim ];
            for ( int p = 0 ; p < dim ; ++p )
                res [ p ] = prev_value.U [ p ] + h * right_funcs [ p ] ( prev_value.X , prev_value.U );
            return res;
        }

        private decimal[] Correct( Func<decimal, decimal [ ], decimal> [ ] right_funcs, Value prev_value, Value current_value, decimal eps )
        {
            decimal [ ] next_iteration = new decimal [ dim ];
            current_value. U . CopyTo ( next_iteration , 0 );
            do
            {
                next_iteration.CopyTo( current_value.U, 0 );
                for ( int p = 0 ; p < dim ; ++p )
                    next_iteration[ p ] = prev_value. U  [ p ] 
                        + h 
                            * ( right_funcs [ p ] ( current_value. X ,current_value.U ) 
                                + right_funcs [ p ] ( prev_value. X , prev_value.U ) )
                        /2;


            } while ( Vector_operation.Distant ( next_iteration , current_value.U ) > eps );

            return next_iteration;
        }
    }
}
