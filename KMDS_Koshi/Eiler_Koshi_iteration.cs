using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Koshi_giu
{
    class Eiler_Koshi_iteration :Method
    {
        public double [ ] X { get; set; }
        public double [ ] [ ] U { get; set; }

        public double [ ] Solve ( Func<double , double [ ] , double> [ ] right_funcs , double [ ] [ ] u0 , double x0 , double x , int n )
        {
            double h = Initialise ( u0 [ 0 ] , x0 , x , n );
            Form_u ( u0 );

            int i = 1;
            for ( double x_current = x0 + h ; x_current <= x ; x_current += h, ++i )
            {
                X [ i ] = x_current;
                Calculate_u ( right_funcs , h , i );
            }
            return U [ n - 1 ];
        }

        private double Initialise ( double [ ] u0 , double x0 , double x , int n )
        {
            double h = ( x - x0 ) / ( n - 1 );
            X = new double [ n ];
            U = new double [ n ] [ ];
            for ( int j = 0 ; j < n ; ++j )
                U [ j ] = new double [ u0 . Length ];

            return h;
        }

        private double [ ] [ ] Form_u ( double [ ] [ ] u0 )
        {
            for ( int i = 0 ; i < u0 [ 0 ] . Length ; ++i )
                U [ 0 ] [ i ] = u0 [ 0 ] [ i ];
            return U;
        }

        private void Calculate_u ( Func<double , double [ ] , double> [ ] right_funcs , double h , int current_i )
        {
            for ( int p = 0 ; p < U [ 0 ] . Length ; ++p )
                U [ current_i ] [ p ] = U [ current_i - 1 ] [ p ] + h * right_funcs [ p ] ( X [ current_i - 1 ] , U [ current_i - 1 ] );
        }
    }
}
