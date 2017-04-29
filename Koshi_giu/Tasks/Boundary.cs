using Cauchy;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Tasks
{
    using Function = Func<double, double [ ], double>;
    class Boundary
    {
        public Function  Right_func { get; set; }
        public Func<double[], double> [ ] Boundary_funcs { get; set; }
        public Value[] Values { get; set; }

        Func<double, double>  Solution { get; set; }
        public Step_Solver solver;

        public Boundary( Function right_func,
                        Func<double [ ], double> [ ] boundary_funcs,
                        Func<double, double> solution,
                        Value[] values, 
                        Step_Solver solver)
        {
            this.Right_func = right_func;
            Boundary_funcs = boundary_funcs;
            this.Solution = solution;
            this.Values = values;
            this.solver = solver;
        }

        public double [ ] Solve( double x , double So, Function[] funcs_diffs, Cauchy_Solver cauchy_solver )
        {
            return solver.Solve( this, x, So, funcs_diffs, cauchy_solver );
        }

        public double[] Real( double x )
        {
            return new double [ ] { Solution( x ) };
        }
    }
}
