using Koshi_giu.Boundary_solver;
using Koshi_giu.Helper;
using Koshi_giu.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koshi_giu
{
    using Cauchy;
    using Cauchy.Helper;
    using System.Windows.Forms.DataVisualization.Charting;
    using Function = Func<decimal, decimal [ ], decimal>;
    
    public partial class KMDS : Form
    {
        DataTable data;
        Cauchy task;
        Lateness_Solver solver;
        decimal [ ] max_err;

        public KMDS()
        {
            InitializeComponent();

            const int equal_count =1;

            Function [ ] right_func = new Function [ equal_count ]
                { ( xx, uu ) => 0};
            Value [ ] start_values = new Value [ 1 ]
                { new Value( 0, new decimal [ equal_count ]
                    { 1 } )
                };
            Func<decimal, decimal [ ]> [ ] solution = new Func<decimal, decimal [ ]> [ 4 ]
                { x => new decimal[] { 1 - x},
                  x => new decimal[] { (x * x)/2 - 2*x + 1.5M},
                  x => new decimal[] { -0.1666667M*x*x*x + 1.5M*x*x - 4*x +2.83333M},
                  x => new decimal[] { 0.0416662M*x*x*x*x - 0.666667M*x*x*x + 3.75M*x*x - 8.5M*x + 6.20731M}};

            decimal [ ] lateness = new decimal [ equal_count ] { 1 };
            decimal [ ] lateness_val = new decimal [ equal_count ] { 1 };
            Func<decimal, decimal> [ ] lateness_func = new Func<decimal, decimal> [ equal_count ]
                {(x) => -x};
            Func<decimal, decimal> [ ] lateness_start_func = new Func<decimal, decimal> [ equal_count ]
                {(x) => 1};

            max_err = new decimal [ equal_count ];

            //Function [ ] right_func = new Function [ equal_count ]
            //     { ( x, u ) => u[0],
            //       ( x, u ) => u[0] + u[1]};
            //Value [ ] start_values = new Value [ 1 ]
            //    { new Value( 0, new decimal [ equal_count ]
            //        { 1, 1 } )
            //    };
            //Func<decimal, decimal [ ]> [ ] solution = new Func<decimal, decimal [ ]> [ equal_count ]
            //    { x => new decimal[] { 2 * Math.Exp(x) - 1,
            //                        ( 2 * x + x * Math.Exp(-x) + 1) * Math.Exp(x) },
            //      x => new decimal[] {2 * Math.Exp(x-1) * x - 4 * Math.Exp(x-1) + 2 * Math.Exp(x) + 1,
            //                         Math.Exp(x-1) * ( 2*x*x - 5*x +6 ) + Math.Exp(x)*( 2*x + 1 ) - x - 1} };
            //decimal [ ] lateness = new decimal [ equal_count ] { 1, 1 };
            //decimal [ ] lateness_val = new decimal [ equal_count ] { 1, 1 };
            //Func<decimal, decimal> [ ] lateness_func = new Func<decimal, decimal> [ equal_count ]
            //    {x => x,
            //     x => x};
            //Func<decimal, decimal> [ ] lateness_start_func = new Func<decimal, decimal> [ equal_count ]
            //    { x => 1,
            //      x => 1 - x};

            Cauchy_Solver cauchy_solver = new Eiler_Cauchy();
            task = new Cauchy( right_func, solution, start_values, cauchy_solver, lateness,lateness_val, lateness_func ,lateness_start_func);
            solver = new Lateness_Solver( task, new Func<Value, bool> [ 2 ] { Plot_point, Display_value }, null );
            

            data = new DataTable();
            data.Columns.Add( new DataColumn( "X", typeof( string ) ) );
            for ( int i = 0; i < equal_count; ++i )
            {
                data.Columns.Add( new DataColumn( "U" + i.ToString(), typeof( string ) ) );
                data.Columns.Add( new DataColumn( "U_real" + i.ToString(), typeof( string ) ) );
                data.Columns.Add( new DataColumn( "ERR" + i.ToString(), typeof( string ) ) );
            }

            value_data.DataSource = data;

        }

        private void button_Click( object sender, EventArgs e )
        {

            if ( chart.Series.Count != 0 )
                chart.Series.Clear();

            for ( int i = 0; i < task.Right_funcs.Length; ++i )
            {
                chart.Series.Add( "u" + i.ToString() );
                chart.Series [ "u" + i.ToString() ].ChartType = SeriesChartType.Line;
                chart.Series [ "u" + i.ToString() ].BorderWidth = 2;

                chart.Series.Add( "U_real" + i.ToString() );
                chart.Series [ "U_real" + i.ToString() ].ChartType = SeriesChartType.Line;
                chart.Series [ "U_real" + i.ToString() ].BorderWidth = 1;
                max_err [ i ] = 0;
            }

            decimal x = decimal.Parse( x_tb.Text );


            solver.Solve( x, 20 );

            string [ ] row = new string [ 3 * task.Right_funcs.Length + 1 ];
            row [ 0 ] = "MAX ERROR";
            for ( int i = 1, j = 3; i <= task.Right_funcs.Length; ++i, j += 2 )
                row [ j ] = max_err [ i-1 ].ToString();
            data.Rows.Add( row );


            //Plot_solution();

        }

        public bool Display_value(Value sv)
        {
            string [ ] row = new string [ 3*task.Right_funcs.Length + 1 ];
            row [ 0 ] = sv.X.ToString();
            decimal [ ] real = task.Real_Solution( sv.X );
            for ( int i = 1, j = 1; i <= task.Right_funcs.Length; ++i, ++j )
            {
                row [ j ]  =    sv.U [ i - 1 ].ToString();
                row [ ++j ] =  real [ i - 1 ].ToString();
                row [ ++j ] = (Math.Abs( sv.U [ i - 1 ] - real [ i - 1 ] )).ToString();
                if ( max_err [ i - 1 ] < Math.Abs( sv.U [ i - 1 ] - real [ i - 1 ] ) )
                    max_err [ i - 1 ] = Math.Abs( sv.U [ i - 1 ] - real [ i - 1 ] );
            }
            data.Rows.Add( row );
            return true;
        }

       

        public bool Plot_point(Value point)
        {
            decimal [ ] real = task.Real_Solution( point.X );

            for ( int i = 0; i < task.Right_funcs.Length; ++i )
            {
                chart.Series [ "u" + i.ToString() ].Points.AddXY( point.X, point.U [ i ] );
                chart.Series [ "U_real" + i.ToString() ].Points.AddXY( point.X, real[i] );
            }
            return true;
        }

        private void KMDS_Load( object sender, EventArgs e )
        {
            button_Click(new object(), new EventArgs());
        }
    }
}
