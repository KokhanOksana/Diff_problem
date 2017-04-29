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
        }

        private void button_Click( object sender, EventArgs e )
        {
            if ( chart.Series.Count != 0 )
                chart.Series.Clear();
            chart.Series.Add( "Y" );
            chart.Series [ "Y" ].ChartType = SeriesChartType.Line;
            chart.Series [ "Y" ].BorderWidth = 2;
            chart.Series.Add( "Y_real" );
            chart.Series [ "Y_real" ].ChartType = SeriesChartType.Line;
            chart.Series [ "Y_real" ].BorderWidth = 2;

            decimal eps = decimal.Parse( eps_tb.Text );
            decimal x = decimal.Parse( x_tb.Text );



        }

        public bool Display_res( Value new_val )
        {
            string [ ] row = new string [ 4 ];
            row [ 0 ] = new_val.X.ToString();
            row [ 1 ] = new_val.U [ 0 ].ToString();
            row [ 2 ] = task.Solution( new_val.X).ToString();
            row [ 3 ] = Math.Abs( new_val.U [ 0 ] - task.Solution( new_val.X ) ).ToString();
            data.Rows.Add( row );
            return true;
        }

        public bool Plot_point(Value point)
        {
            chart.Series [ "Y" ].Points.AddXY( point.X, point.U [ 0 ] );
            chart.Series [ "Y_real" ].Points.AddXY( point.X, task.Solution(point.X));
            return true;
        }
    }
}
