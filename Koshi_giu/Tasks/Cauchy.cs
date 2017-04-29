using Cauchy.Helper;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy
{
    using Functions = Func<double, double [ ], double>;
    class Cauchy
    {
        public Functions [ ] Right_funcs { get; set; }
        public Value[] Start_value { get; set; }

        Func<double , double[]> [ ] Solution { get; set; }
        public Cauchy_Solver solver; 
        
        public double[] Lateness{ get; set; }
        public double [ ] Lateness_val { get; set; }
        public Func<double, double> [ ] Lateness_start_func { get; set;}
        Func<double, double> [ ] Lateness_func { get; set; }


        public Cauchy( Functions [ ] right_funcs, Func<double, double[]> [ ] solution, Value [ ] start_value, Cauchy_Solver solver,
                        double [ ] lateness = null, double [ ] lateness_val = null, Func<double, double> [ ] lateness_func = null, Func<double, double>[] lateness_start_func = null )
        {
            this.Start_value = start_value;

            this.Lateness = lateness;
            this.Lateness_val = lateness_val;
            this.Lateness_func = lateness_func;
            this.Lateness_start_func = lateness_start_func;

            this.Solution = solution;
            if ( Lateness != null )
                this.Right_funcs = Right_funcs_lateness( right_funcs );
            else
                this.Right_funcs = right_funcs;
      
            this. solver = solver;
            
        }
        private Functions [ ] Right_funcs_lateness( Functions [ ] right_funcs )
        {
            Functions [ ] res = new Functions [ right_funcs.Length ];
            for ( int j = 0; j < Lateness.Length; ++j )
            {
                int i = j;
                res [ i ] = ( x, u ) => right_funcs [ i ]( x, u ) + Lateness_func [ i ]( Lateness_val [ i ] );
            }
            return res;
        }

        public double [ ] Solve( Value[] prev_value, double x)
        {
            return solver.Solve( Right_funcs, prev_value, x );
        }

        public double[] Real_Solution(double x)
        {
            double ff = Math.Truncate( (x-0.005) / Lateness [ 0 ] );
            int interval = Convert.ToInt32( Math.Truncate( ( x - 0.005 ) / Lateness[0]));
            return Solution [ interval ]( x );
        }
    }


}
