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
    public partial class Form4 : Form
    {
        String path;
        bool type;

        public Form4(String ws, bool type)
        {
            this.path = ws;
            this.type = type;

            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == false)
            {
                chart1.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = true;
            }

            string[] data = System.IO.File.ReadAllLines(@path); // read all lines in the file
            double[] data2 = new double[data.Length-6]; // make the data from the text file doubles (convert string)
            double[] data3 = new double[data.Length-6];

            for (int i = 0; i < data.Length-6; i++)
            {
                data2[i] = Convert.ToDouble(data[i+6].Split('\t')[0]);
                data3[i] = Convert.ToDouble(data[i+6].Split('\t')[2]);
            }
            
            for (int i = 1; i < data2.Length - 1; i++)
            {
                chart1.Series["Series1"].Points.AddXY(data2[i], data3[i]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            StreamReader streamReader = new StreamReader(@path);
            richTextBox1.Text = streamReader.ReadToEnd(); // large empty space, for displaying contents inside file
            streamReader.Close();
        }
    }
}
