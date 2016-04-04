/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * Manual_Zoom_PhaseChange Version 1
 * Developed By: Alisha Geis
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_v1
{
    public partial class ManualZoomP : Form
    {
        public Phase_Change_Results ownerGraph2; //connects to Phase_Change_Results.cs, for "Manual Zoom" button

        public ManualZoomP()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // "ManualZoomP" window
        }

        /*for individual text boxes to properly display results when user inputs numbers*/
        public void Phase_Change_Results_Shown()
        {
            textBox2.Text = ownerGraph2.Phase_Change_Chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum.ToString();
            textBox1.Text = ownerGraph2.Phase_Change_Chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum.ToString();
            textBox4.Text = ownerGraph2.Phase_Change_Chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum.ToString();
            textBox3.Text = ownerGraph2.Phase_Change_Chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum.ToString();
        }

        /*zoomAxis - to properly display results when user inputs numbers, for zooming graph manually*/
        private void zoomAxis(System.Windows.Forms.DataVisualization.Charting.Axis mAxis, double _newMin, double _newMax)
        {
            double newMax = Math.Max(_newMax, _newMin);
            double newMin = Math.Min(_newMax, _newMin);
            mAxis.Minimum = Math.Min(mAxis.Minimum, newMin);
            mAxis.Maximum = Math.Min(mAxis.Maximum, newMax);
            mAxis.ScaleView.Position = newMin;
            mAxis.ScaleView.Size = newMax - newMin;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // x-axis min value
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // x-axis max value
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // y-axis min value
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // y-axis max value
        }

        /*"OK" button - once clicked, manual zoom operations will be performed*/
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                zoomAxis(ownerGraph2.Phase_Change_Chart.ChartAreas[0].AxisX, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text));
                zoomAxis(ownerGraph2.Phase_Change_Chart.ChartAreas[0].AxisY, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox3.Text));

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Entry");
            }
        }

        /*"Cancel" button - will simply close the window; will not perform manual zoom operations*/
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}