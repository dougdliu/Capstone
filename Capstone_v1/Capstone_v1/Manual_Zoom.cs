/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * Manual_Zoom Version 1
 * Developed By: Alisha Geis, Ashley Krueger
 * Modified from: Code originally developed by MFC Systems, Matt Dion
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
using System.Windows.Forms.DataVisualization.Charting;

/*-----------------------Manual Zoom-------------------------*/

namespace Capstone_v1
{
    /* This page shows four textboxes for the user to input values to manually zoom into the graph.
     * The graph could either be Gain results or phase change results.
     * Once the user inputs four valid numbers for min and max values for x-axis and y-axis, the 
	 * graph will update the graph according to the inputted values.
     */
 public partial class Manual_Zoom : Form
    {
        //A “Chart” value called Graph; refers to the chart for Gain / phase change to make proper adjustments
        Chart Graph;
        //Default constructor, takes in Graph as a parameter to use “this” graph contained in Gain or phase change
		//code; initializes the form’s content
        public Manual_Zoom(Chart Graph)
        {
            this.Graph = Graph;
            InitializeComponent();
            //New method created below; to affect graph properly after the user inputs values
            View_Current_Axes();
            
        }

        //For individual text boxes to properly display results when user inputs numbers
        public void View_Current_Axes()
        {
            textBox2.Text = Graph.ChartAreas[0].AxisX.ScaleView.ViewMinimum.ToString();
            textBox1.Text = Graph.ChartAreas[0].AxisX.ScaleView.ViewMaximum.ToString();
            textBox4.Text = Graph.ChartAreas[0].AxisY.ScaleView.ViewMinimum.ToString();
            textBox3.Text = Graph.ChartAreas[0].AxisY.ScaleView.ViewMaximum.ToString();
        }

        //“zoomAxis” properly displays results when user inputs numbers; for zooming graph manually
        private void zoomAxis(System.Windows.Forms.DataVisualization.Charting.Axis mAxis, double _newMin, double _newMax)
        {
			//takes two double variables, uses Math for min and max values; positions and scales the size
            double newMax = Math.Max(_newMax, _newMin);
            double newMin = Math.Min(_newMax, _newMin);
            mAxis.Minimum = Math.Min(mAxis.Minimum, newMin);
            mAxis.Maximum = Math.Min(mAxis.Maximum, newMax);
            mAxis.ScaleView.Position = newMin;
            mAxis.ScaleView.Size = newMax - newMin;
        }


        //"OK" button; once clicked, manual zoom operations will be performed
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
				//Each zoom axis function properly converts and applies the values for x-axis and y-axis separately, min and max
				//values for each axis
                zoomAxis(Graph.ChartAreas[0].AxisX, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text));
                zoomAxis(Graph.ChartAreas[0].AxisY, Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox3.Text));

                Close();
            }
			//Will catch fault and display error message if an issue arises
            catch (Exception)
            {
                MessageBox.Show("Invalid Entry");
            }
        }

        //"Cancel" button; will simply close the window, will not perform manual zoom operations
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}