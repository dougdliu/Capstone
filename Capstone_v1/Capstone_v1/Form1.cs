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
        String workspace;
        String path;
        bool test_complete;
        bool sweep_type;
        bool amplitude_ready;
        bool frequency_ready;
        bool sweep_ready;
        double amplitude;
        double frequency;
        double sweep;

        public Form1(String ws)
        {
            this.workspace = ws;
            this.test_complete = false;
            this.sweep_type = true;
            this.amplitude_ready = false;
            this.frequency_ready = false;
            this.sweep_ready = false;
            this.frequency = 0.0;
            this.amplitude = 0.0;
            this.sweep = 0.0;
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string frequency_str = textBox1.Text;
            if(frequency_str != "")
            {
                this.frequency = Convert.ToDouble(frequency_str);
                if (frequency < 1 || frequency > 400000)
                {
                    label5.ForeColor = System.Drawing.Color.Red;
                    label5.Text = "Invalid";
                    frequency_ready = false;
                }
                else
                {
                    label5.ForeColor = System.Drawing.Color.Green;
                    label5.Text = "Valid";
                    frequency_ready = true;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string[] text = System.IO.File.ReadAllLines(@"C:\Users\ashly\Desktop\testdata.txt");
            //System.IO.File.WriteAllLines(@"C:\Users\ashly\Desktop\WriteLines.txt", text);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\ashly\Desktop\WriteLines.txt"))
            {
                for (int i = 0; i < text.Length; i+=2)
                {
                    
                    
                        file.WriteLine(text[i]+","+text[i+1]);
                    
                }
            }*/
            if(amplitude_ready==true && frequency_ready==true && sweep_ready==true)
            {
                String fileName= "results.txt";
                String pathString = System.IO.Path.Combine(workspace, fileName);
                this.path = pathString;
                using (System.IO.StreamWriter file =new System.IO.StreamWriter(@pathString))
                {
                    for(int i = 0; i< 100; i++)
                    {
                        file.WriteLine(i);
                        file.WriteLine(i);
                    }
                }
                test_complete = true;
                label8.ForeColor = System.Drawing.Color.Green;
                label8.Text = "Test Complete";
            }
            else
            {
                label8.ForeColor = System.Drawing.Color.Red;
                label8.Text = "One or more values not set";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string amplitude_str = textBox2.Text;
            if (amplitude_str != "")
            {
                this.amplitude = Convert.ToDouble(amplitude_str);
                if (amplitude < 0.005 || amplitude > 2)
                {
                    label6.ForeColor = System.Drawing.Color.Red;
                    label6.Text = "Invalid";
                    amplitude_ready = false;
                }
                else
                {
                    label6.ForeColor = System.Drawing.Color.Green;
                    label6.Text = "Valid";
                    amplitude_ready = true;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                label7.ForeColor = System.Drawing.Color.Black;
                label7.Text = "kHz/s";
                this.sweep_type = true;
            }
            else if(comboBox1.SelectedIndex == 0)
            {
                label7.ForeColor = System.Drawing.Color.Black ;
                label7.Text = "decades/s";
                this.sweep_type = false;
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "Please select a type";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(test_complete==true)
            {
                Form3 frm = new Form3(path);
                frm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(sweep_type==true && textBox3.Text != "")
            {
                this.sweep = Convert.ToDouble(textBox3.Text);
                if (sweep <= 0 || sweep > 1000)
                {
                    label7.ForeColor = System.Drawing.Color.Red;
                    label7.Text = "Invalid";
                    sweep_ready = false;
                }
                else
                {
                    label7.ForeColor = System.Drawing.Color.Green;
                    label7.Text = "Valid";
                    sweep_ready = true;
                }
            }
            else if(sweep_type==false && textBox3.Text != "")
            {
                this.sweep = Convert.ToDouble(textBox3.Text);
                if (sweep <= 0 || sweep > 1)
                {
                    label7.ForeColor = System.Drawing.Color.Red;
                    label7.Text = "Invalid";
                    sweep_ready = false;
                }
                else
                {
                    label7.ForeColor = System.Drawing.Color.Green;
                    label7.Text = "Valid";
                    sweep_ready = true;
                }
            }
            else
            {

            }
        }
    }
}
