﻿using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Tasks
{
    using Cauchy;
    using Function = Func<double, double [ ], double>;
    abstract class Step_Solver
    {
        public event Func<Value, bool> Iteration_changed;
        protected Func<Value, bool> Iteration_value_observer;
        public event Func<Value, bool> Result_Value_changed;
        public Step_Solver( Func<Value, bool> iteration_observer, 
                                Func<Value, bool> result_observer ,
                                Func<Value, bool> iteration_value_observer )
        {
            Iteration_changed += iteration_observer;
            Result_Value_changed += result_observer;
           Iteration_value_observer = iteration_value_observer;
        }

        public abstract double [ ] Solve( Boundary task, double x, double So, Function [ ] funcs_diff, Cauchy_Solver cauchy_solver);
    }
}
