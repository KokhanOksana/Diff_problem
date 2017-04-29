using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Koshi_giu
{
    static  class Iteration_methot_NLS
    {
        public static double[] Solve(Func<double[] , double >[] F, double[] x0, double eps)
        {
            double [ ] x = new double [ x0 . Length ];
            double [ ] x_previous = new double [ x0 . Length ];
            x0 . CopyTo ( x_previous , 0 );
            do{
                x = Vector_Function_Calculate ( x_previous , F );
            } while ( Norm ( x , x_previous ) > eps );

            return x;
        }

        private static double[] Vector_Function_Calculate (double[] x , Func<double[] , double> [ ] F )
        {
            int dimension = x . Length;
            double[] res = new double [ dimension ];
            for ( int i = 0 ; i < dimension ; ++i ){
                res [ i ] = F [ i ] ( x );
            }
            return res;
        }

        private static double Norm(double[] x, double[] y)
        {
            int dimension = x . Length;
            double res = 0;
            for ( int i = 0 ; i < dimension ; ++i ){
                res += Math . Pow ( x [ i ] - y [ i ] , 2 );
            }
            return Math.Sqrt( res);
        }
    }
}
