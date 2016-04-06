/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * Phase_Change_Results Version 1
 * Developed By: Ashley Krueger, Alisha Geis
 * Modified From: Example on CodeAbout.WordPress.com
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

/*----------------Phase Change Results------------------------*/

namespace Capstone_v1
{
    /* This page shows the plot of the results for phase change.
     * It also shows the results data in text format.
     * The user can also click on manual zoom which opens the manualzoom_phasechange form.
     */
    public partial class Phase_Change_Results : Form
    {
        //Class level variables for path and sweep type
        String path;
        bool type;

        public Phase_Change_Results(String ws, bool type)
        {
            //initialize the class level variables
            this.path = ws;
            this.type = type;

            InitializeComponent();

            //make the plots and data visible immediately.
            view_chart();
            view_data();
        }

        //When the plot button is clicked again (if the communication is multithreaded and the data
        //can be plotted while it is running) this will update the chart.
        private void button1_Click(object sender, EventArgs e)
        {
            view_chart();
        }

        //Plot the data in the file
        private void view_chart()
        {
            if (type == false)
            {
                Phase_Change_Chart.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = true;
            }
            //read in the file
            string[] data = System.IO.File.ReadAllLines(@path); // read all lines in the file
            double[] data2 = new double[data.Length - 6]; // make the data from the text file doubles (convert string)
            double[] data3 = new double[data.Length - 6];

            for (int i = 0; i < data.Length - 6; i++)
            {
                //frequency array
                data2[i] = Convert.ToDouble(data[i + 6].Split(',')[0]);
                //phase change array
                data3[i] = Convert.ToDouble(data[i + 6].Split(',')[2]);
            }

            for (int i = 1; i < data2.Length; i++)
            {
                //add the points to the chart
                Phase_Change_Chart.Series["Series1"].Points.AddXY(data2[i], data3[i]);
            }
        }

        //When the view data button is clicked again (if the communication is multithreaded and the data
        //can be plotted while it is running) this will update the text area.
        private void button2_Click(object sender, EventArgs e)
        {

            view_data();

        }

        //read to the end of the file and write it to the text area
        private void view_data()
        {
            using (StreamReader streamReader = new StreamReader(@path))
            {
                Phase_Change_Data.Text = streamReader.ReadToEnd(); // large empty space, for displaying contents inside file
                streamReader.Close();
            }
        }

        /*"Manual Zoom" button - to manually select parameters to zoom the produced results on graph*/
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Open manual zoom form
            Manual_Zoom zoom = new Manual_Zoom(Phase_Change_Chart);
            //zoom.ownerGraph1 = this;
            zoom.ShowDialog();
        }
    }
}
