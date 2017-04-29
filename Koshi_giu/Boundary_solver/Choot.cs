using Cauchy;
using Cauchy.Helper;
using Koshi_giu.Helper;
using Koshi_giu.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Boundary_solver
{
    using Function = Func<decimal, decimal [ ], decimal>;
    class Choot// : Step_Solver
    {
        public event Func<Value, bool> Iteration_changed;
        private  Func<Value, bool> Iteration_value_observer;
        public   Func<Value, bool> Result_Value_observer;
        int dim;
        decimal S;
        Step_solver cauchy;

        public Choot( Func<Value, bool> iteration_observer, Func<Value, bool> result_observer, Func<Value, bool> iteration_value_observer ) //: base( iteration_observer, result_observer, iteration_value_observer )
        {
            Iteration_changed += iteration_observer;
            Result_Value_observer = result_observer;
            Iteration_value_observer = iteration_value_observer;
        }

        public void Form_Cauchy( Boundary task, decimal x, Function [ ] funcs_diffs, Cauchy_Solver solver )
        {
            //Function [ ] right_funcs = Form_right_funcs( task.Equal.Right_func, funcs_diffs );
            //Value [ ] start_value = Form_start_values( task.Values [ 0 ], task.Boundary_funcs [ 0 ] );

            //cauchy = new Regular_step(
            //    new Cauchy.Cauchy( right_funcs, null, start_value, solver ),
            //    new Func<Value, bool> [ ] { Iteration_value_observer, Result_Value_observer }, null );   
        }
        
        private Function [ ] Form_right_funcs(Function task_func,  Function [ ] funcs_diffs )
        {
            Function [ ] right_funcs = new Function [ 4 ];
            right_funcs [ 0 ] = ( xx, u ) => u [ 1 ];
            right_funcs [ 1 ] = task_func;
            right_funcs [ 2 ] = ( xx, u ) => u [ 3 ];
            right_funcs [ 3 ] = ( xx, u ) => funcs_diffs [ 0 ]( xx, u ) * u [ 2 ] + funcs_diffs [ 1 ]( xx, u ) * u [ 3 ];
            return right_funcs;
        }

        private Value [ ] Form_start_values( Value task_start_value , Func<decimal [ ], decimal> task_start_boundary_func)
        {
            Value [ ] start_value = new Value [ 1 ]
                            {new Value(task_start_value.X,
                             new decimal [ ]{
                                            0,//task_start_value.U[0], //alpha
                                            0, //Sn
                                            0,0
                                            } )
                            };
            if ( task_start_boundary_func( new decimal [ ] { 0, 1 } ) != 0 )
            {
                 start_value [ 0 ].U [ 2 ] = 1;
                start_value [ 0 ].U [ 0 ] = task_start_value.U [ 0 ];

            }
            else                
            {
                  start_value [ 0 ].U [ 3 ] = 1;

                  start_value [ 0 ].U [ 1 ] = task_start_value.U [ 0 ];
               
            }

            return start_value;
        }

        //public override decimal [ ] Solve( Boundary task, decimal x, decimal So, Function [ ] funcs_diff, Cauchy_Solver cauchy_solver )
        //{
        //    decimal h = 0.01;
        //    decimal eps = 0.00001;

        //    S = So;
        //    dim = task.Values [ 0 ].U.Length;
        //    int cauchy_point_count = (int)( ( task.Values[1].X - task.Values[0].X ) / h );

        //    Form_Cauchy( task, x, funcs_diff, cauchy_solver );

        //    decimal S_next = S;
        //    decimal [ ] cauchy_res = new decimal[4];
        //    task.Values [ 0 ].U.CopyTo( cauchy_res, 0 );
        //    do
        //    {

        //        S = S_next;
        //        Iteration_changed( new Value( S, cauchy_res ) );

        //        if ( task.Boundary_funcs [ 0 ]( new decimal [ ] { 0, 1 } ) != 0 )
        //        {
        //            cauchy.Task.Start_value [ 0 ].U [ 1 ] =  S - 1;
        //        }
        //        else
        //            cauchy.Task.Start_value [ 0 ].U [ 0 ] = 1 - S;



        //        cauchy_res = cauchy.Solve( task.Values [ 1 ].X, cauchy_point_count );
        //        Form_Cauchy( task, x, funcs_diff, cauchy_solver );

        //        S_next = S - ( task.Boundary_funcs [ 1 ]( new decimal [ ] { cauchy_res [ 0 ], cauchy_res [ 1 ] } ) - task.Values [ 1 ].U [ 0 ] )
        //                     / task.Boundary_funcs [ 1 ]( new decimal [ ] { cauchy_res [ 2 ], cauchy_res [ 3 ] } );

        //    } while ( Math.Abs( S_next - S ) > eps || Math.Abs( cauchy_res [ 0 ] - task.Values [ 1 ].U [ 0 ] ) > eps );
        //    S = S_next;
        //    cauchy.Disconect( Iteration_value_observer );
        //    Iteration_changed( new Value( S, cauchy_res ) );
        //    cauchy.Task.Start_value [ 0 ].U [ 1 ] = S;
          
        //    cauchy_res = cauchy.Solve( x, cauchy_point_count );
        //    return cauchy_res;
        //}

    }
}
