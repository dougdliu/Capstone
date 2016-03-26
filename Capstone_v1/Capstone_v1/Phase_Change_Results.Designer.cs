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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Phase_Change_Data = new System.Windows.Forms.RichTextBox();
            this.Phase_Change_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Phase_Change_Chart_Button = new System.Windows.Forms.Button();
            this.Phase_Change_Data_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Phase_Change_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Phase_Change_Data
            // 
            this.Phase_Change_Data.Location = new System.Drawing.Point(73, 57);
            this.Phase_Change_Data.Name = "Phase_Change_Data";
            this.Phase_Change_Data.Size = new System.Drawing.Size(325, 404);
            this.Phase_Change_Data.TabIndex = 8;
            this.Phase_Change_Data.Text = "";
            // 
            // Phase_Change_Chart
            // 
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.Phase_Change_Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Phase_Change_Chart.Legends.Add(legend2);
            this.Phase_Change_Chart.Location = new System.Drawing.Point(484, 57);
            this.Phase_Change_Chart.Name = "Phase_Change_Chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Phase_Change_Chart.Series.Add(series2);
            this.Phase_Change_Chart.Size = new System.Drawing.Size(578, 404);
            this.Phase_Change_Chart.TabIndex = 9;
            this.Phase_Change_Chart.Text = "chart1";
            this.Phase_Change_Chart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // Phase_Change_Chart_Button
            // 
            this.Phase_Change_Chart_Button.Location = new System.Drawing.Point(673, 472);
            this.Phase_Change_Chart_Button.Name = "Phase_Change_Chart_Button";
            this.Phase_Change_Chart_Button.Size = new System.Drawing.Size(222, 41);
            this.Phase_Change_Chart_Button.TabIndex = 10;
            this.Phase_Change_Chart_Button.Text = "Plot Phase Change Results";
            this.Phase_Change_Chart_Button.UseVisualStyleBackColor = true;
            this.Phase_Change_Chart_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Phase_Change_Data_Button
            // 
            this.Phase_Change_Data_Button.Location = new System.Drawing.Point(113, 472);
            this.Phase_Change_Data_Button.Name = "Phase_Change_Data_Button";
            this.Phase_Change_Data_Button.Size = new System.Drawing.Size(223, 41);
            this.Phase_Change_Data_Button.TabIndex = 11;
            this.Phase_Change_Data_Button.Text = "View Phase Change Results";
            this.Phase_Change_Data_Button.UseVisualStyleBackColor = true;
            this.Phase_Change_Data_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Phase_Change_Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 534);
            this.Controls.Add(this.Phase_Change_Data_Button);
            this.Controls.Add(this.Phase_Change_Chart_Button);
            this.Controls.Add(this.Phase_Change_Chart);
            this.Controls.Add(this.Phase_Change_Data);
            this.Name = "Phase_Change_Results";
            this.Text = "Phase_Change_Results";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Phase_Change_Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Phase_Change_Data;
        private System.Windows.Forms.DataVisualization.Charting.Chart Phase_Change_Chart;
        private System.Windows.Forms.Button Phase_Change_Chart_Button;
        private System.Windows.Forms.Button Phase_Change_Data_Button;
    }
}