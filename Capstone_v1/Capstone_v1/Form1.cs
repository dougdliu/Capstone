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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string frequency_str = textBox1.Text;
            if(frequency_str != "")
            {
                double frequency = Convert.ToDouble(frequency_str);
                if (frequency < 1 || frequency > 400000)
                {
                    label5.ForeColor = System.Drawing.Color.Red;
                    label5.Text = "Invalid";
                }
                else
                {
                    label5.ForeColor = System.Drawing.Color.Green;
                    label5.Text = "Valid";
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\ashly\Desktop\testdata.txt");
            //System.IO.File.WriteAllLines(@"C:\Users\ashly\Desktop\WriteLines.txt", text);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\ashly\Desktop\WriteLines.txt"))
            {
                for (int i = 0; i < text.Length; i+=2)
                {
                    
                    
                        file.WriteLine(text[i]+","+text[i+1]);
                    
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string amplitude_str = textBox2.Text;
            if (amplitude_str != "")
            {
                double amplitude = Convert.ToDouble(amplitude_str);
                if (amplitude < 0.005 || amplitude > 2)
                {
                    label6.ForeColor = System.Drawing.Color.Red;
                    label6.Text = "Invalid";
                }
                else
                {
                    label6.ForeColor = System.Drawing.Color.Green;
                    label6.Text = "Valid";
                }
            }
        }
    }
}
