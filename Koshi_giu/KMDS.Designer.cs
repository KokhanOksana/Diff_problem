namespace Koshi_giu
{
    partial class KMDS
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
            this.value_data = new System.Windows.Forms.DataGridView();
            this.button = new System.Windows.Forms.Button();
            this.x_tb = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_data)).BeginInit();
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
            this.chart.Location = new System.Drawing.Point(12, 42);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart.Size = new System.Drawing.Size(681, 433);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // value_data
            // 
            this.value_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.value_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.value_data.Location = new System.Drawing.Point(699, 9);
            this.value_data.Name = "value_data";
            this.value_data.Size = new System.Drawing.Size(351, 466);
            this.value_data.TabIndex = 1;
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button.Location = new System.Drawing.Point(109, 9);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(62, 33);
            this.button.TabIndex = 19;
            this.button.Text = "Solve";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // x_tb
            // 
            this.x_tb.Location = new System.Drawing.Point(33, 16);
            this.x_tb.Name = "x_tb";
            this.x_tb.Size = new System.Drawing.Size(57, 20);
            this.x_tb.TabIndex = 25;
            this.x_tb.Text = "200";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(15, 19);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(12, 13);
            this.label90.TabIndex = 24;
            this.label90.Text = "x";
            // 
            // KMDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 487);
            this.Controls.Add(this.x_tb);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.button);
            this.Controls.Add(this.value_data);
            this.Controls.Add(this.chart);
            this.Name = "KMDS";
            this.Text = "Boundary_problem";
            this.Load += new System.EventHandler(this.KMDS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView value_data;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox x_tb;
        private System.Windows.Forms.Label label90;
    }
}