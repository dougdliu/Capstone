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

namespace Capstone_v1
{
    public partial class Form3 : Form
    {
        String path;

        public Form3(String ws)
        {
            this.path = ws;
            
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = System.IO.File.ReadAllLines(@path); // read all lines in the file
            double[] data2 = new double[data.Length]; // make the data from the text file doubles (convert string)

            for (int i = 0; i < data.Length; i++)
            {
                data2[i] = Convert.ToDouble(data[i]);
            }

            for (int i = 0; i < data2.Length - 1; i = i + 2)
            {
                chart1.Series["Series1"].Points.AddXY(data[i], data[i + 1]);
            }

            chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series1"].Color = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            StreamReader streamReader = new StreamReader(@path);
            richTextBox1.Text = streamReader.ReadToEnd(); // large empty space, for displaying contents inside file
            streamReader.Close();
        }
    }
}
