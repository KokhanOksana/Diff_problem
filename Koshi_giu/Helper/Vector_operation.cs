using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy.Helper
{
    static class Vector_operation
    {
        public static double Distant( double [ ] x, double [ ] y )
        {
            int dimension = x.Length;
            double res = 0;
            for ( int i = 0; i < dimension; ++i )
            {
                res += Math.Pow( x [ i ] - y [ i ], 2 );
            }
            return Math.Sqrt( res );
        }

        public static double Norm( double [ ] vector )
        {
            double res = 0;
            foreach ( double x in vector )
                res += x * x;
            return Math.Sqrt( res );
        }

        public static double [ ] Difference( double [ ] vector1, double [ ] vector2 )
        {
            int dim = vector1.Length;
            double [ ] res = new double [ dim ];
            for ( int i = 0; i < dim; ++i )
                res [ i ] = vector1 [ i ] - vector2 [ i ];
            return res;
        }
    }
}
