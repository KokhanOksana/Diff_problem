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
    using System.Linq.Expressions;
    using System.Windows.Forms.DataVisualization.Charting;
    using Function = Func<decimal, decimal [ ], decimal>;

    public partial class Boundary_problem : Form
    {
        DataTable data;
        int iterations;
        Boundary task;

        public Boundary_problem()
        {
            InitializeComponent();

            data = new DataTable();
            data.Columns.Add( new DataColumn( "Xi", typeof( string ) ) );
            data.Columns.Add( new DataColumn( "Yi", typeof( string ) ) );
            data.Columns.Add( new DataColumn( "Yi_real", typeof( string ) ) );
            data.Columns.Add( new DataColumn( "error", typeof( string ) ) );
            result_data.DataSource = data;

            //Boundary_equal bound_equal = new Boundary_equal()
            //{
            //    Right_func = x => 2 / ( x * x * x ) - 2,
            //    Diff_coef = x => 0,
            //    Func_coef = x => -2 * x
            //};
            //Edge edge = new Edge()
            //{
            //    Start = 1,
            //    End = 2,
            //    Coef_start_fun = 1,
            //    Coef_start_diff = 0,
            //    Coef_end_fun = 1,
            //    Coef_end_diff = 0,
            //    Val_start = 1,
            //    Val_end = 0.5M,
            //    Start_func = x => 1,
            //    End_func = x => 0.5M
            //};
            //Func<decimal, decimal> solution = new Func<decimal, decimal>( x => 1 / x );

            Boundary_equal bound_equal = new Boundary_equal()
            {
                Right_func = x => ( decimal ) Math.Exp( ( double ) x ) * ( x * x + x + 2 ),
                Diff_coef = x => x,
                Func_coef = x => -1
            };
            Edge edge = new Edge()
            {
                Start = 0,
                End = 1,
                Coef_start_fun = 0,
                Coef_start_diff = 1,
                Coef_end_fun = 1,
                Coef_end_diff = 0,
                Val_start = 1,
                Val_end = ( decimal ) Math.E,
                Start_func = x => 1,
                End_func = x => ( decimal ) Math.E
            };
            Func<decimal, decimal> solution = new Func<decimal, decimal>( x => x * ( decimal ) Math.Exp( ( double ) x ) );


            //Boundary_equal bound_equal = new Boundary_equal()
            //{
            //    Right_func = x => -6 * x * x + 5 * x + 6,
            //    Diff_coef = x => 2,
            //    Func_coef = x => -3
            //};
            //Edge edge = new Edge()
            //{
            //    Start = 0,
            //    End = 1,
            //    Coef_start_fun = 1,
            //    Coef_start_diff = 1,
            //    Coef_end_fun = 0,
            //    Coef_end_diff = 1,
            //    Val_start = 1,
            //    Val_end = 5,
            //    Start_func = x => 1,
            //    End_func = x => 5
            //};
            //Func<decimal, decimal> solution = new Func<decimal, decimal>( x => 2 * x * x + x );

            //Boundary_equal bound_equal = new Boundary_equal()
            //{
            //    Right_func = x => -2 * ( decimal ) Math.Exp( ( double ) x ),
            //    Diff_coef = x => -1,
            //    Func_coef = x => -2
            //};
            //Edge edge = new Edge()
            //{
            //    Start = 0,
            //    End = 1,
            //    Coef_start_fun = 0,
            //    Coef_start_diff = 1,
            //    Coef_end_fun = 2,
            //    Coef_end_diff = -1,
            //    Val_start = 3,
            //    Val_end = ( decimal ) Math.E,
            //    Start_func = x => 3,
            //    End_func = x => ( decimal ) Math.E
            //};
            //Func<decimal, decimal> solution = new Func<decimal, decimal>( x => ( decimal ) Math.Exp( ( double ) x ) + ( decimal ) Math.Exp( 2 * ( double ) x ) );

            task = new Boundary( bound_equal, edge, solution, null );
            
        }

        private void button_Click( object sender, EventArgs e )
        {
            if ( chart.Series.Count != 0 )
                chart.Series.Clear();
            chart.Series.Add( "Y" );
            chart.Series [ "Y" ].ChartType = SeriesChartType.Line;
            chart.Series [ "Y" ].BorderWidth = 1;
            chart.Series.Add( "Y_real" );
            chart.Series [ "Y_real" ].ChartType = SeriesChartType.Line;
            chart.Series [ "Y_real" ].BorderWidth = 1;

            decimal eps = decimal.Parse( eps_tb.Text );

            decimal[] result =  Finite_difference.Solve( task, task.Edge_conditions.End, eps );

            decimal h = ( task.Edge_conditions.End - task.Edge_conditions.Start ) / ( result.Length - 1 );
            n_txt.Text = "n = " + result.Length.ToString();
            for ( int i = 0; i< result.Length; ++i )
            {
                chart.Series [ "Y" ].Points.AddXY( task.Edge_conditions.Start + i * h, result[i] );
                chart.Series [ "Y_real" ].Points.AddXY( task.Edge_conditions.Start + i * h, task.Solution( task.Edge_conditions.Start + i * h) );
                string [ ] row = new string [ 4 ];
                row [ 0 ] = (task.Edge_conditions.Start + i*h).ToString();
                row [ 1 ] = result [ i ].ToString();
                row [ 2 ] = task.Solution( task.Edge_conditions.Start + i * h ).ToString();
                row [ 3 ] = Math.Abs( result [ i ] - task.Solution( task.Edge_conditions.Start + i * h ) ).ToString();
                data.Rows.Add( row );
            }
        }

        public bool Display_res( Value new_val )
        {
            string [ ] row = new string [ 4 ];
            row [ 0 ] = new_val.X.ToString();
            row [ 1 ] = new_val.U [ 0 ].ToString();
           // row [ 2 ] = task.Solution( new_val.X).ToString();
           // row [ 3 ] = Math.Abs( new_val.U [ 0 ] - task.Solution( new_val.X ) ).ToString();
            data.Rows.Add( row );
            return true;
        }

        public bool Plot_point(Value point)
        {
            chart.Series [ "Y" ].Points.AddXY( point.X, point.U [ 0 ] );
            //chart.Series [ "Y_real" ].Points.AddXY( point.X, task.Solution(point.X));
            return true;
        }

        private void Boundary_problem_Load( object sender, EventArgs e )
        {
          
        }
    }
}
