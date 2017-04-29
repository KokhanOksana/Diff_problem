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
    using System.Windows.Forms.DataVisualization.Charting;
    using Function = Func<double, double [ ], double>;

    public partial class Boundary_problem : Form
    {
        DataTable iter_data;
        DataTable res_data;
        int iterations;
        Boundary task;

        public Boundary_problem()
        {
            InitializeComponent();

            iter_data = new DataTable();
            iter_data.Columns.Add( new DataColumn( "S", typeof( string ) ) );
            iter_data.Columns.Add( new DataColumn( "V", typeof( string ) ) );
            iteration_data.DataSource = iter_data;

            res_data = new DataTable();
            res_data.Columns.Add( new DataColumn( "X", typeof( string ) ) );
            res_data.Columns.Add( new DataColumn( "V", typeof( string ) ) );
            result_data.DataSource = res_data;
        }

        private void button_Click( object sender, EventArgs e )
        {
            iterations = -1;
            if ( chart.Series.Count != 0 )
                chart.Series.Clear();
            
            double a = Double.Parse(a_tb .Text );
            double b = double.Parse(b_tb .Text );

            double a0 = Double.Parse(a0_tb .Text );
            double b0 = double.Parse(b0_tb .Text );

            double a1 = Double.Parse(a1_tb .Text );
            double b1 = double.Parse(b1_tb .Text );

            double alp = Double.Parse(alpha_tb .Text );
            double bet = double.Parse(betha_tb .Text );

            double eps = Double.Parse( eps_tb.Text );
            double So = double.Parse(So_tb.Text );

            double x = double.Parse( x_tb.Text );

            // a = 1 // b = 2 // alp = 1  // bet = 0,5
            Function right_func = ( xx, uu ) => 2 * xx * uu [ 0 ] + 2 / xx * xx * xx - 2;
            Func<double, double> solution = xx => 1 / xx;
            Function [ ] func_diffs = new Function [ 2 ]
                                    {(xx,uu) => 2 * xx,
                                    (xx,uu) => 0 };


            // a = 0 // b = 1 // alp = 1  // bet = 2.71828182846
            //Function right_func = ( xx, uu ) => uu [ 0 ] - xx * uu [ 1 ] + Math.Exp( xx ) * ( xx * xx + xx + 2 );
            //Func<double, double> solution = xx => xx * Math.Exp( xx );
            //Function [ ] func_diffs = new Function [ 2 ]
            //                        {(xx,uu) => 1,
            //                        (xx,uu) =>  -xx };

            // a = 1 // b = 0 // alp = 1 // bet = 5
            //Function right_func = ( xx, uu ) => 3 * uu [ 0 ] - 2 * uu [ 1 ] - 6 * xx * xx + 5 * xx + 6;
            //Func<double, double> solution = xx => 2 * xx + xx;
            //Function [ ] func_diffs = new Function [ 2 ]
            //                        {(xx,uu) => 3,
            //                        (xx,uu) => -2 };

            Func<double [ ], double> [ ] boundary_funcs = new Func<double [ ], double> [ 2 ]
                                    { u => a0 * u [ 0 ] + b0 * u [ 1 ],
                                      u => a1 * u [ 0 ] + b1 * u [ 1 ] };

            
            Value [ ] values = new Value [ 2 ] 
                                { new Value( a, new double [ ] { alp } ),
                                  new Value( b, new double [ ] { bet } ) };

            Step_Solver solver = new Choot(Display_iter,Display_res, Plot_point);
            task = new Boundary( right_func,boundary_funcs, solution, values, solver );
            task.Solve( x, So ,func_diffs,new Rynge_Kyt());
            Plot_solution();

        }

        public bool Display_iter(Value sv)
        {
            string [ ] row = new string [ 2 ];
            row [ 0 ] = sv.X.ToString();
            row [ 1 ] = sv.U[0].ToString();
            iter_data.Rows.Add( row );

            New_iteration();
            return true;
        }

        public bool Display_res( Value new_val )
        {
            string [ ] row = new string [ 2 ];
            row [ 0 ] = new_val.X.ToString();
            row [ 1 ] = new_val.U [ 0 ].ToString();
            res_data.Rows.Add( row );
            
            return true;
        }

        private void New_iteration()
        {
            iterations++;
            string [ ] row = new string [ 2 ];
            row [ 0 ] = "||||||||||||||| S" + iterations.ToString() + " |||||||||||||||||";
            res_data.Rows.Add( row );

            string new_chart_name = iterations.ToString();
            chart.Series.Add( new_chart_name );
            chart.Series [ new_chart_name ].ChartType = SeriesChartType.Line;
            chart.Series [ new_chart_name ].BorderWidth = 1;
        }

        public bool Plot_point(Value point)
        {
            chart.Series [ iterations.ToString() ].Points.AddXY( point.X, point.U [ 0 ] );
            return true;
        }

        private void Plot_solution()
        {
            New_iteration();
            for(double x = task.Values[0].X; x<=task.Values[1].X;x+=0.01 )
            {
                Plot_point( new Value( x, task.Real( x ) ));
            }
        }
    }
}
