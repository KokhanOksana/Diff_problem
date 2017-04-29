using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cauchy.Helper
{
    abstract class Step_solver
    {
        public Cauchy Task { get; set; }
        public decimal H { get; set; }

        public event Func<Value, bool> Value_changed;
        public event Func<decimal, bool> Step_changed;

        public Step_solver( Cauchy task)
        {
            
            Task = task;
        }

        public abstract void Disconect( Func<Value, bool> value_observers );

        public decimal [ ] Solve( decimal x, int point_count )
        {
            int dim = Task.Start_value[0].U.Length;
            decimal [ ] result = new decimal [ dim ];
            H = ( x - Task.Start_value.Last().X ) / point_count;
            Task.Start_value.Last().U.CopyTo( result, 0 );

            decimal x_current = Task.Start_value.Last().X;
            Value [ ] current_value = new Value [ Task.Start_value.Length ];
            Task.Start_value.CopyTo( current_value, 0 );
            do                         
            {
                if ( Step_changed != null && Change_step( current_value ) )
                    Step_changed(H);
            } while ( current_value.Last().X <= x );
            return current_value.Last().U;
        }

        protected void Re_form_value( Value [ ] values )
        {
            Value tmp = values [ 0 ];
            for ( int i = 0; i < values.Length - 1; ++i )
                values [ i ] = values [ i + 1 ];
            values [ values.Length - 1 ] = tmp;
        }

        protected abstract bool Change_step( Value[] current_value );

    }

    class Regular_step:Step_solver
    {
        public Regular_step(Cauchy task,
            Func<Value, bool>[] value_observers = null, Func<decimal, bool> step_observer = null ) 
                : base(task )
        {
            foreach(var observer in value_observers)
                Value_changed += observer;
            Step_changed += step_observer;
        }

        public override void  Disconect( Func<Value, bool> value_observers )
        {
            Value_changed -= value_observers;
        }

        public event Func<Value, bool> Value_changed;

        protected override bool Change_step(Value[] current_value)
        {
            Value_changed(current_value.Last());
            current_value[0].U = Task.Solve( current_value, current_value.Last().X + H );
            current_value[0].X += H;
            Re_form_value(current_value);
            return true; 
        }
    }

    class Divided_step:Step_solver
    {
        public Divided_step( Cauchy task,
           Func<Value, bool> [ ] value_observers, Func<decimal, bool> step_observer )
                : base( task )
        {
            foreach ( var observer in value_observers )
                Value_changed += observer;
            Step_changed += step_observer;
        }

        public override void Disconect( Func<Value, bool> value_observers )
        {
            Value_changed -= value_observers;
        }

        public  event Func<Value, bool> Value_changed;

        protected override bool Change_step( Value [ ] current_value )
        {
            decimal eps = 0.0001M;
            decimal [ ] next_value_h = Task.Solve( current_value, current_value.Last().X + H );
            next_value_h = Task.Solve( new Value [ ] { new Value( current_value.Last().X + H, next_value_h ) }, current_value.Last().X + 2 * H );

            decimal [ ] next_value_2h = Task.Solve( current_value, current_value.Last().X + 2 * H );

            if ( Vector_operation.Distant( next_value_h, next_value_2h ) < eps )
            {
                current_value [ 0 ].U = next_value_h;
                current_value [ 0 ].X += 2 * H;
                Value_changed( current_value.Last() );
                Re_form_value( current_value );
                return true;
            }
            else
            {
                H /= 2;
                return false;
            }
            
        }
    }

    class Lateness_Solver : Step_solver
    {

        public event Func<Value, bool> Value_changed;

        public Lateness_Solver( Cauchy task, Func<Value, bool> [ ] value_observers , Func<decimal, bool> step_observer )
                : base( task )
        {
            foreach ( var observer in value_observers )
                Value_changed += observer;
            Step_changed += step_observer;
        }

        public override void Disconect( Func<Value, bool> value_observers )
        {
            throw new NotImplementedException();
        }

        public new  decimal [ ] Solve( decimal x, int point_count )
        {

            int dim = Task.Start_value [ 0 ].U.Length;
            H =   Task.Lateness[0]/ point_count ;
                   
            Value [ ] current_value = new Value [ Task.Start_value.Length ];
            Task.Start_value.CopyTo( current_value, 0 );

            decimal [ ] [ ] U_previous = new decimal [ point_count ] [ ];
            for ( int i = 0; i < point_count; ++i )
            {
                U_previous [ i ] = new decimal [ dim ];
                for ( int j = 0; j < dim; ++j )
                    U_previous [ i ] [ j ] = Task.Lateness_start_func [ j ]( - Task.Lateness[j] + i*H);
            }
            do
            {
                decimal [ ] [ ] U_current = new decimal [ point_count ] [ ];
                for ( int i = 0; i < point_count; ++i )
                    U_current [ i ] = new decimal [ dim ];

                for (int i = 0;i< point_count;++i )
                {
                    Task.Lateness_val =   U_previous [ i ];

                    current_value[0].U =   Task.Solve( current_value, current_value.Last().X + H );
                    current_value.Last().X += H;
                    current_value [ 0 ].U.CopyTo( U_current [ i ], 0 );
                    
                    Re_form_value( current_value );
                    Value_changed( current_value.Last() );

                }
                U_previous = U_current;
            } while ( current_value.Last().X <= x-H );
            return current_value.Last().U;
        }

        protected override bool Change_step( Value [ ] current_value )
        {
            throw new NotImplementedException();
        }
    }
}
