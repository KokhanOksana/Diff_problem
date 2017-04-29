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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.iteration_data = new System.Windows.Forms.DataGridView();
            this.result_data = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.a_tb = new System.Windows.Forms.TextBox();
            this.b_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.a0_tb = new System.Windows.Forms.TextBox();
            this.a1_tb = new System.Windows.Forms.TextBox();
            this.b0_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.b1_tb = new System.Windows.Forms.TextBox();
            this.alpha_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.betha_tb = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.So_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.eps_tb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.x_tb = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_data)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(12, 70);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(798, 405);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // iteration_data
            // 
            this.iteration_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iteration_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iteration_data.Location = new System.Drawing.Point(818, 12);
            this.iteration_data.Name = "iteration_data";
            this.iteration_data.Size = new System.Drawing.Size(244, 134);
            this.iteration_data.TabIndex = 1;
            // 
            // result_data
            // 
            this.result_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.result_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_data.Location = new System.Drawing.Point(816, 152);
            this.result_data.Name = "result_data";
            this.result_data.Size = new System.Drawing.Size(246, 323);
            this.result_data.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "a =";
            // 
            // a_tb
            // 
            this.a_tb.Location = new System.Drawing.Point(40, 6);
            this.a_tb.Name = "a_tb";
            this.a_tb.Size = new System.Drawing.Size(93, 20);
            this.a_tb.TabIndex = 4;
            this.a_tb.Text = "1";
            // 
            // b_tb
            // 
            this.b_tb.Location = new System.Drawing.Point(40, 32);
            this.b_tb.Name = "b_tb";
            this.b_tb.Size = new System.Drawing.Size(93, 20);
            this.b_tb.TabIndex = 6;
            this.b_tb.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "b =";
            // 
            // a0_tb
            // 
            this.a0_tb.Location = new System.Drawing.Point(232, 6);
            this.a0_tb.Name = "a0_tb";
            this.a0_tb.Size = new System.Drawing.Size(30, 20);
            this.a0_tb.TabIndex = 8;
            this.a0_tb.Text = "1";
            this.a0_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // a1_tb
            // 
            this.a1_tb.Location = new System.Drawing.Point(232, 32);
            this.a1_tb.Name = "a1_tb";
            this.a1_tb.Size = new System.Drawing.Size(30, 20);
            this.a1_tb.TabIndex = 10;
            this.a1_tb.Text = "0";
            this.a1_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // b0_tb
            // 
            this.b0_tb.Location = new System.Drawing.Point(313, 6);
            this.b0_tb.Name = "b0_tb";
            this.b0_tb.Size = new System.Drawing.Size(25, 20);
            this.b0_tb.TabIndex = 12;
            this.b0_tb.Text = "0";
            this.b0_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(268, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "* u(a)";
            // 
            // b1_tb
            // 
            this.b1_tb.Location = new System.Drawing.Point(313, 32);
            this.b1_tb.Name = "b1_tb";
            this.b1_tb.Size = new System.Drawing.Size(25, 20);
            this.b1_tb.TabIndex = 14;
            this.b1_tb.Text = "1";
            this.b1_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // alpha_tb
            // 
            this.alpha_tb.Location = new System.Drawing.Point(402, 5);
            this.alpha_tb.Name = "alpha_tb";
            this.alpha_tb.Size = new System.Drawing.Size(82, 20);
            this.alpha_tb.TabIndex = 16;
            this.alpha_tb.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(344, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "* u\'(a) =";
            // 
            // betha_tb
            // 
            this.betha_tb.Location = new System.Drawing.Point(402, 32);
            this.betha_tb.Name = "betha_tb";
            this.betha_tb.Size = new System.Drawing.Size(82, 20);
            this.betha_tb.TabIndex = 18;
            this.betha_tb.Text = "2,71828182846";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button.Location = new System.Drawing.Point(738, 5);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(62, 54);
            this.button.TabIndex = 19;
            this.button.Text = "Solve";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // So_tb
            // 
            this.So_tb.Location = new System.Drawing.Point(591, 10);
            this.So_tb.Name = "So_tb";
            this.So_tb.Size = new System.Drawing.Size(40, 20);
            this.So_tb.TabIndex = 23;
            this.So_tb.Text = "0,3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(564, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "So = ";
            // 
            // eps_tb
            // 
            this.eps_tb.Location = new System.Drawing.Point(591, 39);
            this.eps_tb.Name = "eps_tb";
            this.eps_tb.Size = new System.Drawing.Size(130, 20);
            this.eps_tb.TabIndex = 21;
            this.eps_tb.Text = "0,001";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "eps";
            // 
            // x_tb
            // 
            this.x_tb.Location = new System.Drawing.Point(664, 10);
            this.x_tb.Name = "x_tb";
            this.x_tb.Size = new System.Drawing.Size(57, 20);
            this.x_tb.TabIndex = 25;
            this.x_tb.Text = "0,5";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(646, 13);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(12, 13);
            this.label90.TabIndex = 24;
            this.label90.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(344, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "* u\'(b) =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(268, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "* u(a)";
            // 
            // Boundary_problem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 487);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.x_tb);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.So_tb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.eps_tb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button);
            this.Controls.Add(this.betha_tb);
            this.Controls.Add(this.alpha_tb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.b1_tb);
            this.Controls.Add(this.b0_tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.a1_tb);
            this.Controls.Add(this.a0_tb);
            this.Controls.Add(this.b_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.a_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result_data);
            this.Controls.Add(this.iteration_data);
            this.Controls.Add(this.chart);
            this.Name = "Boundary_problem";
            this.Text = "Boundary_problem";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView iteration_data;
        private System.Windows.Forms.DataGridView result_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox a_tb;
        private System.Windows.Forms.TextBox b_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox a0_tb;
        private System.Windows.Forms.TextBox a1_tb;
        private System.Windows.Forms.TextBox b0_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox b1_tb;
        private System.Windows.Forms.TextBox alpha_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox betha_tb;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox So_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox eps_tb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox x_tb;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}