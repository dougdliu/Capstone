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

/*-----------------------Gain Results-------------------------*/

namespace Capstone_v1
{
    public partial class Gain_Results : Form
    {
        String path;
        bool type;

        public Gain_Results(String ws, bool type)
        {
            this.path = ws;
            this.type = type;
            InitializeComponent();

            /*IGNORE THIS: JUST FOR TESTING A CHART EXTENSION*/
            //AttachChartControl();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(type==false)
            {
                Gain_Chart.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = true;
            }
            string[] data = System.IO.File.ReadAllLines(@path); // read all lines in the file
            double[] data2 = new double[data.Length-6]; // make the data from the text file doubles (convert string)
            double[] data3 = new double[data.Length-6];

            for (int i = 0; i < data.Length-6; i++)
            {
                data2[i] = Convert.ToDouble(data[i+6].Split(',')[0]);
                data3[i] = Convert.ToDouble(data[i+6].Split(',')[1]);
            }

            for (int i = 0; i < data2.Length; i++)
            {
                Gain_Chart.Series["Series1"].Points.AddXY(data2[i], data3[i]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            StreamReader streamReader = new StreamReader(@path);
            Gain_Data.Text = streamReader.ReadToEnd(); // large empty space, for displaying contents inside file
            streamReader.Close();
        }

        private void AttachChartControl()
        {
            //Enable Extension Functions and Context Menu
            Gain_Chart.EnableZoomAndPanControls(ChartCursorSelected, ChartCursorMoved);
        }

        /*IGNORE THIS: JUST FOR TESTING A CHART EXTENSION*/
        private void ChartCursorSelected(double x, double y)
        {
            txtChartSelect.Text = x.ToString("F4") + ", " + y.ToString("F4");
        }
        private void ChartCursorMoved(double x, double y)
        {
            txtChartValue.Text = x.ToString("F4") + ", " + y.ToString("F4");
        }

        /*"Manual Zoom" button - to manually select parameters to zoom the produced results on graph*/
        private void button1_Click_1(object sender, EventArgs e)
        {
            ManualZoomG zoom = new ManualZoomG();
            zoom.ownerGraph1 = this;
            zoom.ShowDialog();
        }

        private void Gain_Chart_Click(object sender, EventArgs e)
        {

        }
    }
}
