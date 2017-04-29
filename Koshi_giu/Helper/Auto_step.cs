using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cauchy.Helper
{
    static class Auto_step
    {
        public static double H { get; set; }
        static double fac = 0.8;
        static double facmin = 0.1;
        static double facmax = 5;

        public static void Start_step( Cauchy task, double [ ] points, double [ ] [ ] func_values, double eps, double method_rank )
        {
            double [ ] d = new double [ 2 ];
            double [ ] h = new double [ 2 ];
            double [ ] [ ] fun = new double [ 2 ] [ ] { func_values [ 0 ], new double [ func_values [ 0 ].Length ] };
            for ( int i = 0; i < 2; ++i )
            {
                d [ i ] = Math.Pow( ( 1 / Math.Max( points [ i ], points [ 1 ] ) ), method_rank + 1 )
                     + Math.Pow( Norm( fun [ i ] ), method_rank + 1 );
                h [ i ] = Math.Pow( eps / d [ i ], 1 / ( method_rank + 1 ) );

                for ( int p = 0; p < task.U0 [ 0 ].Length; ++p )
                    fun [ 1 ] [ p ] = fun [ 0 ] [ p ] + h [ 0 ] * task.Right_funcs [ p ]( points [ 0 ], fun [ 0 ] );
            }
            H = Math.Min( h [ 0 ], h [ 1 ] );
        }

        public static bool New_step( double [ ] [ ] func_values, double eps, double method_rank )
        {
            double err = ( ( Norm( Difference( func_values [ 1 ], func_values [ 0 ] ) )
                              / Math.Max( Norm( func_values [ 1 ] ), Math.Max( Norm( func_values [ 0 ] ), 1 ) ) ) )
                         / ( Math.Pow( 2, method_rank ) - 1 );
            double h = H * Math.Max( facmin, fac * Math.Pow( eps / err, 1 / ( method_rank + 1 ) ) );
            if ( err <= eps )
            {
                H = Math.Min( facmax * H, h );
                return false;
            }
            else
            {
                H = h;
                return true;
            }


        }




    }
}
