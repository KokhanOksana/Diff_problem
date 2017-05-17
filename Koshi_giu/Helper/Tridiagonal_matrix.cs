using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Helper
{
    public static class Tridiagonal_matrix
    {
        public static decimal[] Right(decimal[][] vectors, decimal[] f)
        {
            int count = f.Length;
            decimal[] res = new decimal [ count ];

            decimal [ ] alpha = new decimal [ count];
            decimal [ ] betha = new decimal [ count];
            alpha [ 0 ] = - vectors [ 2 ] [ 0 ];
            betha [ 0 ] = f [ 0 ];

            for ( int i = 0; i < count - 1; ++i )
            {
                alpha [ i + 1 ] = vectors [ 2 ] [ i ] / ( -vectors [ 1 ] [ i ] - alpha [ i ] * vectors [ 0 ] [ i ] );
                betha[i+1] = (vectors[0][i]*betha[i] - f[i]) / ( -vectors [ 1 ] [ i ] - alpha [ i ] * vectors [ 0 ] [ i ] );
            }
            res [ count - 1 ] = ( f [ count - 1 ] - vectors [ 0 ] [ count - 1 ] * betha [ count - 1 ] )
                              / ( 1 + vectors [ 0 ] [ count - 1 ] * alpha [ count - 1 ] );

            for ( int i = count - 2; i >=0; --i )
            {
                res [ i ] = alpha [ i + 1 ] * res [ i + 1 ] + betha [ i + 1 ];
            }
                return res;
        } 
    }
}
