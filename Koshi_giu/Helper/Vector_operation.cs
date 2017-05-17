using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy.Helper
{
    static class Vector_operation
    {
        public static decimal Distant( decimal [ ] x, decimal [ ] y )
        {
            int dimension = x.Length;
            decimal res = 0;
            for ( int i = 0; i < dimension; ++i )
            {
                res +=  (x [ i ] - y [ i ]) * ( x [ i ] - y [ i ] );
            }
            return ( decimal ) Math.Sqrt( ( Double ) res );
        }

        public static decimal Norm( decimal [ ] vector )
        {
            decimal res = 0;
            foreach ( decimal x in vector )
                res += x * x;
            return (decimal) Math.Sqrt((Double) res );
        }

        public static decimal [ ] Difference( decimal [ ] vector1, decimal [ ] vector2 )
        {
            int dim = vector1.Length;
            decimal [ ] res = new decimal [ dim ];
            for ( int i = 0; i < dim; ++i )
                res [ i ] = vector1 [ i ] - vector2 [ i ];
            return res;
        }
    }
}
