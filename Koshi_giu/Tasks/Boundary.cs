using Cauchy;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Tasks
{
    using Function = Func<decimal, decimal [ ], decimal>;
    class Boundary
    {
        public Boundary_equal  Equal { get; set; }
        public Edge Edge_conditions { get; set; }

        public Func<decimal, decimal>  Solution { get; set; }
        //public Step_Solver solver;

        public Boundary(Boundary_equal equal,
                        Edge edge, 
                        Func<decimal, decimal> solution,
                        Step_Solver solver)
        {
            this.Equal = equal;
            this.Edge_conditions = edge; 
            this.Solution = solution;
            //this.solver = solver;
        }

        //public decimal [ ] Solve( decimal x , decimal So, Function[] funcs_diffs, Cauchy_Solver cauchy_solver )
        //{
        //    return solver.Solve( this, x );
        //}

        public decimal[] Real( decimal x )
        {
            return new decimal [ ] { Solution( x ) };
        }
    }

    public class Edge
    {
        public decimal Coef_start_fun { get; set; }
        public decimal Coef_end_fun { get; set; }
        public decimal Coef_start_diff { get; set; }
        public decimal Coef_end_diff { get; set; }
        public decimal Start { get; set; }
        public decimal End { get; set; }

        public decimal Val_start { get; set; }
        public decimal Val_end { get; set; }

        public Func<decimal, decimal> Start_func { get; set; }
        public Func<decimal, decimal> End_func { get; set; }
    }

    public class Boundary_equal
    {
        public Func<decimal, decimal> Func_coef { get; set; }
        public Func<decimal, decimal> Diff_coef { get; set; }
        public Func<decimal, decimal> Right_func { get; set; }

    }
}
