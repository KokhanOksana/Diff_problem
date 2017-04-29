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
        public override double [ ] Solve( Func<double, double [ ], double> [ ] right_funcs, Value [ ] prev_value, double x )
        {
            dim = prev_value.Last().U.Length;
            h = x - prev_value.Last().X;

            double [ ] res = Calculate_u(right_funcs,prev_value[0],x);
            res = Correct( right_funcs,prev_value[0],new Value(x,res),0.00000001 );
            return res;
        }

        private double [ ] Calculate_u ( Func<double, double [ ], double> [ ] right_funcs, Value prev_value, double x )
        {
                            
            double [ ] res = new double [ dim ];
            for ( int p = 0 ; p < dim ; ++p )
                res [ p ] = prev_value.U [ p ] + h * right_funcs [ p ] ( prev_value.X , prev_value.U );
            return res;
        }

        private double[] Correct( Func<double, double [ ], double> [ ] right_funcs, Value prev_value, Value current_value, double eps )
        {
            double [ ] next_iteration = new double [ dim ];
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
