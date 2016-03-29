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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Gain_Data = new System.Windows.Forms.RichTextBox();
            this.Gain_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Gain_Chart_Button = new System.Windows.Forms.Button();
            this.Gain_Data_Button = new System.Windows.Forms.Button();
            this.txtChartValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtChartSelect = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Gain_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Gain_Data
            // 
            this.Gain_Data.Location = new System.Drawing.Point(49, 37);
            this.Gain_Data.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gain_Data.Name = "Gain_Data";
            this.Gain_Data.Size = new System.Drawing.Size(218, 264);
            this.Gain_Data.TabIndex = 8;
            this.Gain_Data.Text = "";
            // 
            // Gain_Chart
            // 
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.ScrollBar.IsPositionedInside = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.Gain_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Gain_Chart.Legends.Add(legend1);
            this.Gain_Chart.Location = new System.Drawing.Point(323, 37);
            this.Gain_Chart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gain_Chart.Name = "Gain_Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Gain_Chart.Series.Add(series1);
            this.Gain_Chart.Size = new System.Drawing.Size(385, 263);
            this.Gain_Chart.TabIndex = 9;
            this.Gain_Chart.Text = "chart1";
            this.Gain_Chart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            this.Gain_Chart.Click += new System.EventHandler(this.Gain_Chart_Click);
            // 
            // Gain_Chart_Button
            // 
            this.Gain_Chart_Button.Location = new System.Drawing.Point(512, 309);
            this.Gain_Chart_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gain_Chart_Button.Name = "Gain_Chart_Button";
            this.Gain_Chart_Button.Size = new System.Drawing.Size(148, 27);
            this.Gain_Chart_Button.TabIndex = 10;
            this.Gain_Chart_Button.Text = "Plot Gain Results";
            this.Gain_Chart_Button.UseVisualStyleBackColor = true;
            this.Gain_Chart_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Gain_Data_Button
            // 
            this.Gain_Data_Button.Location = new System.Drawing.Point(107, 307);
            this.Gain_Data_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Gain_Data_Button.Name = "Gain_Data_Button";
            this.Gain_Data_Button.Size = new System.Drawing.Size(105, 27);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 27);
            this.button1.TabIndex = 12;
            this.button1.Text = "Manual Zoom";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Gain_Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Gain_Data_Button);
            this.Controls.Add(this.Gain_Chart_Button);
            this.Controls.Add(this.Gain_Chart);
            this.Controls.Add(this.Gain_Data);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Gain_Results";
            this.Text = "Gain_Results";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gain_Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Gain_Data;
        private System.Windows.Forms.Button Gain_Chart_Button;
        private System.Windows.Forms.Button Gain_Data_Button;
        private System.Windows.Forms.ToolStripStatusLabel txtChartValue;
        private System.Windows.Forms.ToolStripStatusLabel txtChartSelect;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataVisualization.Charting.Chart Gain_Chart;
    }
}