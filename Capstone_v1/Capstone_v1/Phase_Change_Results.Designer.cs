namespace Capstone_v1
{
    partial class Phase_Change_Results
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Phase_Change_Data = new System.Windows.Forms.RichTextBox();
            this.Phase_Change_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Phase_Change_Chart_Button = new System.Windows.Forms.Button();
            this.Phase_Change_Data_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Phase_Change_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Phase_Change_Data
            // 
            this.Phase_Change_Data.Location = new System.Drawing.Point(49, 37);
            this.Phase_Change_Data.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Phase_Change_Data.Name = "Phase_Change_Data";
            this.Phase_Change_Data.Size = new System.Drawing.Size(218, 264);
            this.Phase_Change_Data.TabIndex = 8;
            this.Phase_Change_Data.Text = "";
            // 
            // Phase_Change_Chart
            // 
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.Phase_Change_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Phase_Change_Chart.Legends.Add(legend1);
            this.Phase_Change_Chart.Location = new System.Drawing.Point(323, 37);
            this.Phase_Change_Chart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Phase_Change_Chart.Name = "Phase_Change_Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Phase_Change_Chart.Series.Add(series1);
            this.Phase_Change_Chart.Size = new System.Drawing.Size(385, 263);
            this.Phase_Change_Chart.TabIndex = 9;
            this.Phase_Change_Chart.Text = "chart1";
            this.Phase_Change_Chart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            this.Phase_Change_Chart.Click += new System.EventHandler(this.Phase_Change_Chart_Click);
            // 
            // Phase_Change_Chart_Button
            // 
            this.Phase_Change_Chart_Button.Location = new System.Drawing.Point(514, 310);
            this.Phase_Change_Chart_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Phase_Change_Chart_Button.Name = "Phase_Change_Chart_Button";
            this.Phase_Change_Chart_Button.Size = new System.Drawing.Size(148, 27);
            this.Phase_Change_Chart_Button.TabIndex = 10;
            this.Phase_Change_Chart_Button.Text = "Plot Phase Change Results";
            this.Phase_Change_Chart_Button.UseVisualStyleBackColor = true;
            this.Phase_Change_Chart_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Phase_Change_Data_Button
            // 
            this.Phase_Change_Data_Button.Location = new System.Drawing.Point(75, 307);
            this.Phase_Change_Data_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Phase_Change_Data_Button.Name = "Phase_Change_Data_Button";
            this.Phase_Change_Data_Button.Size = new System.Drawing.Size(149, 27);
            this.Phase_Change_Data_Button.TabIndex = 11;
            this.Phase_Change_Data_Button.Text = "View Phase Change Results";
            this.Phase_Change_Data_Button.UseVisualStyleBackColor = true;
            this.Phase_Change_Data_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 27);
            this.button1.TabIndex = 12;
            this.button1.Text = "Manual Zoom";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Phase_Change_Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Phase_Change_Data_Button);
            this.Controls.Add(this.Phase_Change_Chart_Button);
            this.Controls.Add(this.Phase_Change_Chart);
            this.Controls.Add(this.Phase_Change_Data);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Phase_Change_Results";
            this.Text = "Phase_Change_Results";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Phase_Change_Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Phase_Change_Data;
        private System.Windows.Forms.Button Phase_Change_Chart_Button;
        private System.Windows.Forms.Button Phase_Change_Data_Button;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataVisualization.Charting.Chart Phase_Change_Chart;
    }
}