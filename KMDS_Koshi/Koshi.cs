using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Koshi_giu
{
    class Koshi:Method
    {
        public Func<double , double [ ] , double> [ ] Right_funcs { get; set; }
        public Func<double , double> [ ] Funcs { get; set; }
        public double [ ] [ ] U0 { get; set; }

        public double [ ] X { get; set; }
        public double [ ] [ ] U { get; set; }

        public Koshi( Func<double , double [ ] , double> [ ] right_funcs, Func<double , double> [ ] funcs , double [ ] [ ] u0)
        {
            this . Right_funcs = right_funcs;
            this . Funcs = funcs;
            this . U0 = u0;
        }

        public double [ ] Solve ( Func<double , double [ ] , double> [ ] right_funcs , double [ ] [ ] u0 , double x0 , double x , int n )
        {
            double h = Initialise ( u0 [ 0 ] , x0 , x , n );

            int i = 0;
            for ( double x_current = x0 ; x_current <= x ; x_current += h, ++i )
            {
                X [ i ] = x_current;
                for ( int j = 0 ; j < U [ 0 ].Length ; ++j )
                    U [ i ] [ j ] =  Funcs [ j ] ( X [ i ] );
            }
            return U [ n - 1 ];
        }

        private double Initialise ( double [ ] u0 , double x0 , double x , int n )
        {
            double h = ( x - x0 ) / ( n - 1 );
            X = new double [ n ];
            U = new double [ n ] [ ];
            for ( int j = 0 ; j < n ; ++j )
                U [ j ] = new double [ U0[0] . Length ];
            return h;
        }
    }
}
