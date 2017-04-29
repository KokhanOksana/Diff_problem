using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cauchy
{
    public partial class Form1 : Form
    {
        //Dictionary<string, Method> methods = new Dictionary<string, Method>();
        DataTable data;
        Cauchy task;

        public Form1()
        {
            const int equation_count = 2;
            //task = new Koshi (
            //    new Func<double , double [ ] , double> [ equation_count ] 
            //        { ( x , y ) => -2 * x * y [ 0 ] * y [ 0 ] } ,
            //    new Func<double , double> [ equation_count ] 
            //        { x => 1 / ( 1 + x * x ) } ,
            //    new double [ 1 ] [ ] 
            //        { new double [ equation_count ] { 1 } } );

            task = new Cauchy(
                new Func<double, double [ ], double> [ equation_count ]
                    { ( x , y ) => y[0] - y[1],
                      ( x , y ) => y[1] - 4 * y[0]},
                new Func<double, double> [ equation_count ]
                    { x => - Math.Exp(-x) + Math.Exp(3*x),
                      x => - 2 * Math.Exp(-x) -2 * Math.Exp(3*x)},
                new double [ 1 ] [ ]
                    { new double [ equation_count ] { 1, -4} } );

            InitializeComponent();
            methods.Add( "Eiler", new Eiler_method() );
            methods.Add( "Rynge_Kytt", new Rynge_Kyt() );
            methods.Add( "Adams_Bashford", new Adams_Bashford_method() );
            ////////////////////////////////////////methods . Add ( "Real" ,           task );


        }

        private void Form1_Load( object sender, EventArgs e )
        {
            data = new DataTable();
            data.Columns.Add( new DataColumn( "X", typeof( string ) ) );
            for ( int i = 0; i < task.U0 [ 0 ].Length; ++i )
                data.Columns.Add( new DataColumn( "U" + i.ToString(), typeof( string ) ) );
            for ( int i = 0; i < task.U0 [ 0 ].Length; ++i )
                data.Columns.Add( new DataColumn( "ERR_U" + i.ToString(), typeof( string ) ) );
            dataGrid.DataSource = data;
        }

        private void button_Click( object sender, EventArgs e )
        {
            if ( chart.Series.Count != 0 )
                chart.Series.Clear();
            double x0 = Double.Parse( textBox_x0.Text );
            double x1 = Double.Parse( textBox_x.Text );
            int n = ( int ) number_of_equals.Value + 1;
            double h = ( x1 - x0 ) / ( n - 1 );

            Adams_Bashford_Solve( "Real", x0, x1, n, h );
            Adams_Bashford_Solve( "Eiler", x0, x1, n, h );
            Adams_Bashford_Solve( "Rynge_Kytt", x0, x1, n, h );
            Real( x0, x1, n, h );

        }
        void Adams_Bashford_Solve( string method_name, double x0, double x1, int n, double h )
        {
           // methods [ method_name ].Solve( task.Right_funcs, task.U0, x0, x0 + h * 3, 4 );
            double [ ] [ ] u0_method = methods [ method_name ].U;

            methods [ "Adams_Bashford" ].Solve( task.Right_funcs, u0_method, x0, x1, n );
            Plot( methods [ "Adams_Bashford" ].X, methods [ "Adams_Bashford" ].U, method_name + "_start_points" );

            ////////////////////////task . Solve ( task . Right_funcs , u0_method , x0 , x1 , n );
            data.Rows.Add( method_name );
            for ( int i = 0; i < methods [ "Adams_Bashford" ].X.Length; ++i )
                for ( int j = 0; j < methods [ "Adams_Bashford" ].U [ 0 ].Length; ++j )
                    data.Rows.Add( methods [ "Adams_Bashford" ].X [ i ],
                        methods [ "Adams_Bashford" ].U [ i ] [ j ],
                        methods [ "Adams_Bashford" ].U [ i ] [ j ] - task.U [ i ] [ j ] );


        }

        void Real( double x0, double x1, int n, double h )
        {
            /////////////////////////task . Solve ( task . Right_funcs , new double [ 1 ] [ ] , x0 , x1 , n );
            //( task.X, task.U, "U(X)" );
        }

        void Plot( double [ ] x, double [ ] [ ] u, string name )
        {
            for ( int i = 0; i < u [ 0 ].Length; ++i )
            {
                chart.Series.Add( name + i.ToString() );
                chart.Series [ name + i.ToString() ].ChartType = SeriesChartType.Line;
                chart.Series [ name + i.ToString() ].BorderWidth = 3;
                chart.ChartAreas [ 0 ].AxisX.Minimum = x [ 0 ];
                chart.ChartAreas [ 0 ].AxisX.Maximum = x [ x.Length - 1 ];

            }

            for ( int j = 0; j < u [ 0 ].Length; ++j )
                for ( int i = 0; i < x.Length; ++i )
                    chart.Series [ name + j.ToString() ].Points.Add( new DataPoint( x [ i ], u [ i ] [ j ] ) );

        }


    }
}
