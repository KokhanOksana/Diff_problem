namespace Koshi_giu
{
    partial class Boundary_problem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.result_data = new System.Windows.Forms.DataGridView();
            this.button = new System.Windows.Forms.Button();
            this.eps_tb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.x_tb = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_data)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 2);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart.Size = new System.Drawing.Size(820, 483);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // result_data
            // 
            this.result_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.result_data.BackgroundColor = System.Drawing.SystemColors.Control;
            this.result_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_data.Location = new System.Drawing.Point(829, 86);
            this.result_data.Name = "result_data";
            this.result_data.Size = new System.Drawing.Size(243, 399);
            this.result_data.TabIndex = 2;
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button.Location = new System.Drawing.Point(1011, 12);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(51, 54);
            this.button.TabIndex = 19;
            this.button.Text = "Solve";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // eps_tb
            // 
            this.eps_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eps_tb.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eps_tb.Location = new System.Drawing.Point(875, 41);
            this.eps_tb.Name = "eps_tb";
            this.eps_tb.Size = new System.Drawing.Size(130, 25);
            this.eps_tb.TabIndex = 21;
            this.eps_tb.Text = "0,001";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(835, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 22);
            this.label10.TabIndex = 20;
            this.label10.Text = "eps";
            // 
            // x_tb
            // 
            this.x_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.x_tb.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x_tb.Location = new System.Drawing.Point(875, 12);
            this.x_tb.Name = "x_tb";
            this.x_tb.Size = new System.Drawing.Size(130, 25);
            this.x_tb.TabIndex = 25;
            this.x_tb.Text = "0,5";
            // 
            // label90
            // 
            this.label90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label90.Location = new System.Drawing.Point(847, 15);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(22, 22);
            this.label90.TabIndex = 24;
            this.label90.Text = "X";
            // 
            // Boundary_problem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 487);
            this.Controls.Add(this.x_tb);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.eps_tb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button);
            this.Controls.Add(this.result_data);
            this.Controls.Add(this.chart);
            this.Name = "Boundary_problem";
            this.Text = "Boundary_problem";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView result_data;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox eps_tb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox x_tb;
        private System.Windows.Forms.Label label90;
    }
}