namespace Capstone_v1
{
    partial class Gain_Results
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Gain_Data = new System.Windows.Forms.RichTextBox();
            this.Gain_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Gain_Chart_Button = new System.Windows.Forms.Button();
            this.Gain_Data_Button = new System.Windows.Forms.Button();
            this.txtChartValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtChartSelect = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Gain_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Gain_Data
            // 
            this.Gain_Data.Location = new System.Drawing.Point(73, 57);
            this.Gain_Data.Name = "Gain_Data";
            this.Gain_Data.Size = new System.Drawing.Size(325, 404);
            this.Gain_Data.TabIndex = 8;
            this.Gain_Data.Text = "";
            // 
            // Gain_Chart
            // 
            chartArea2.AxisX.LabelStyle.Interval = 0D;
            chartArea2.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea2.AxisY.LabelStyle.Interval = 0D;
            chartArea2.AxisY.ScrollBar.IsPositionedInside = false;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.Gain_Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Gain_Chart.Legends.Add(legend2);
            this.Gain_Chart.Location = new System.Drawing.Point(484, 57);
            this.Gain_Chart.Name = "Gain_Chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Gain_Chart.Series.Add(series2);
            this.Gain_Chart.Size = new System.Drawing.Size(578, 404);
            this.Gain_Chart.TabIndex = 9;
            this.Gain_Chart.Text = "chart1";
            this.Gain_Chart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // Gain_Chart_Button
            // 
            this.Gain_Chart_Button.Location = new System.Drawing.Point(673, 472);
            this.Gain_Chart_Button.Name = "Gain_Chart_Button";
            this.Gain_Chart_Button.Size = new System.Drawing.Size(222, 41);
            this.Gain_Chart_Button.TabIndex = 10;
            this.Gain_Chart_Button.Text = "Plot Gain Results";
            this.Gain_Chart_Button.UseVisualStyleBackColor = true;
            this.Gain_Chart_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Gain_Data_Button
            // 
            this.Gain_Data_Button.Location = new System.Drawing.Point(161, 472);
            this.Gain_Data_Button.Name = "Gain_Data_Button";
            this.Gain_Data_Button.Size = new System.Drawing.Size(158, 41);
            this.Gain_Data_Button.TabIndex = 11;
            this.Gain_Data_Button.Text = "View Gain Results";
            this.Gain_Data_Button.UseVisualStyleBackColor = true;
            this.Gain_Data_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtChartValue
            // 
            this.txtChartValue.Name = "txtChartValue";
            this.txtChartValue.Size = new System.Drawing.Size(23, 23);
            // 
            // txtChartSelect
            // 
            this.txtChartSelect.Name = "txtChartSelect";
            this.txtChartSelect.Size = new System.Drawing.Size(23, 23);
            // 
            // Gain_Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 534);
            this.Controls.Add(this.Gain_Data_Button);
            this.Controls.Add(this.Gain_Chart_Button);
            this.Controls.Add(this.Gain_Chart);
            this.Controls.Add(this.Gain_Data);
            this.Name = "Gain_Results";
            this.Text = "Gain_Results";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gain_Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Gain_Data;
        private System.Windows.Forms.DataVisualization.Charting.Chart Gain_Chart;
        private System.Windows.Forms.Button Gain_Chart_Button;
        private System.Windows.Forms.Button Gain_Data_Button;
        private System.Windows.Forms.ToolStripStatusLabel txtChartValue;
        private System.Windows.Forms.ToolStripStatusLabel txtChartSelect;
    }
}