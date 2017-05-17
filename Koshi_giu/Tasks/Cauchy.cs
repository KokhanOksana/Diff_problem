using Cauchy.Helper;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy
{
    using Functions = Func<decimal, decimal [ ], decimal>;
    class Cauchy
    {
        public Functions [ ] Right_funcs { get; set; }
        public Value[] Start_value { get; set; }

        Func<decimal , decimal[]> [ ] Solution { get; set; }
        public Cauchy_Solver solver; 
        
        public decimal[] Lateness{ get; set; }
        public decimal [ ] Lateness_val { get; set; }
        public Func<decimal, decimal> [ ] Lateness_start_func { get; set;}
        Func<decimal[], decimal> [ ] Lateness_func { get; set; }


        public Cauchy( Functions [ ] right_funcs, Func<decimal, decimal[]> [ ] solution, Value [ ] start_value, Cauchy_Solver solver,
                        decimal [ ] lateness = null, decimal [ ] lateness_val = null, Func<decimal[], decimal> [ ] lateness_func = null, Func<decimal, decimal>[] lateness_start_func = null )
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
                res [ i ] = ( x, u ) => right_funcs [ i ]( x, u ) + Lateness_func [ i ]( Lateness_val);
            }
            return res;
        }

        public decimal [ ] Solve( Value[] prev_value, decimal x)
        {
            return solver.Solve( Right_funcs, prev_value, x );
        }

        public decimal[] Real_Solution(decimal x)
        {
            int interval = Convert.ToInt32( Math.Truncate( ( x - 0.005M ) / Lateness[0]));
            return Solution [ interval ]( x );
        }
    }


}
