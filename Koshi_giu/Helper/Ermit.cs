using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Cauchy
{
    static class Ermit
    {
        public static double [ ] Solve( Func<double [ ], double> shit, double [ ] [ ] u_data, double [ ] x_data, double x )
        {
            double t0, t1;
            t0 = 0;
            t1 = 0;
            double [ ] y0 = new double [ u_data [ 0 ].Length ];

            double [ ] y1 = new double [ u_data [ 0 ].Length ];
            for ( int i = 0; i < x_data.Length - 1; ++i )
                if ( x > x_data [ i ] && x < x_data [ i + 1 ] )
                {
                    t0 = x_data [ i ];
                    t1 = x_data [ i + 1 ];
                    y0 = u_data [ i ];
                    y1 = u_data [ i + 1 ];

                }
            double h = t1 - t0;
            double teta = ( x - t0 ) / h;
            double [ ] d = new double [ u_data [ 0 ].Length ];
            for ( int i = 0; i < u_data [ 0 ].Length; ++i )
                d [ i ] = ( y1 [ i ] - y0 [ i ] ) / h;

            for ( int i = 0; i < u_data [ 0 ].Length; ++i )
            {

            }

            throw new NotImplementedException();
        }
    }
}
