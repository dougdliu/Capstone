﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        bool combo_ready;
        bool sweep_type;
        bool amplitude_ready;
        bool frequency_ready;
        bool frequency_start_ready;
        bool frequency_end_ready;
        bool sweep_ready;
        bool offset_ready;
        //bool output_ready;
        double amplitude;
        double frequency_start;
        double frequency_end;
        double sweep;
        double offset;

        public Form1(String ws)
        {
            this.workspace = ws;
            this.test_complete = false;
            this.combo_ready = false;
            this.sweep_type = true;
            this.amplitude_ready = false;
            this.frequency_start_ready = false;
            this.sweep_ready = false;
            this.offset_ready = false;
            //this.output_ready = false;
            this.frequency_start = 0.0;
            this.amplitude = 0.0;
            this.sweep = 0.0;
            this.offset = 0.0;
            InitializeComponent();
            
        }

        /*------------------------FREQUENCY---------------------------------*/

        //Frequency Start Text Box Handling
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string frequency_str = textBox1.Text;
                if(frequency_str != "")
                {
                    this.frequency_start = Convert.ToDouble(frequency_str);
                    if (frequency_start < 1 || frequency_start > 400000)
                    {
                        label5.ForeColor = System.Drawing.Color.Red;
                        label5.Text = "Invalid";
                        frequency_start_ready = false;
                    }
                    else
                    {
                        label5.ForeColor = System.Drawing.Color.Green;
                        label5.Text = "Valid";
                        frequency_start_ready = true;
                    }
                }
                else
                {
                    frequency_start_ready = false;
                    label5.ForeColor = System.Drawing.Color.Red;
                    label5.Text = "Invalid";
                }
            }
            catch (Exception)
            {
                label5.ForeColor = System.Drawing.Color.Red;
                label5.Text = "Invalid";
                frequency_start_ready = false;
            }
        }

        //Frequency End Text Box Handling
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string frequency_str = textBox4.Text;
                if (frequency_str != "")
                {
                    this.frequency_end = Convert.ToDouble(frequency_str);
                    if (frequency_end < 1 || frequency_end > 400000)
                    {
                        label5.ForeColor = System.Drawing.Color.Red;
                        label5.Text = "Invalid";
                        frequency_end_ready = false;
                    }
                    else
                    {
                        label5.ForeColor = System.Drawing.Color.Green;
                        label5.Text = "Valid";
                        frequency_end_ready = true;
                    }
                }
                else
                {
                    frequency_end_ready = false;
                    label5.ForeColor = System.Drawing.Color.Red;
                    label5.Text = "Invalid";
                }
            }
            catch (Exception)
            {
                label5.ForeColor = System.Drawing.Color.Red;
                label5.Text = "Invalid";
                frequency_end_ready = false;
            }
        }

        /*-----------------------AMPLITUDE---------------------------------*/

        //Amplitude Text Box Handling
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
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
                else
                {
                    label6.ForeColor = System.Drawing.Color.Red;
                    label6.Text = "Invalid";
                    amplitude_ready = false;
                }
            }
            catch (Exception)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                label6.Text = "Invalid";
                amplitude_ready = false;
            }
        }

        /*-----------------------SWEEP_RATE--------------------------------*/

        //Sweep Rate Combo Box Handling
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                label7.ForeColor = System.Drawing.Color.Black;
                label7.Text = "kHz/s";
                label15.Text = "0-1000 kHz/s";
                combo_ready = true;
                this.sweep_type = true;
            }
            else if(comboBox1.SelectedIndex == 0)
            {
                label7.ForeColor = System.Drawing.Color.Black ;
                label7.Text = "decades/s";
                label15.Text = "0-1 decades/s";
                combo_ready = true;
                this.sweep_type = false;
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "Please select a type";
            }
        }

        //Sweep Rate Text Box Handling
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(combo_ready == true && sweep_type==true && textBox3.Text != "")
            {
                try
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
                catch (Exception)
                {
                    label7.ForeColor = System.Drawing.Color.Red;
                    label7.Text = "Invalid";
                    sweep_ready = false;
                }
               
            }
            else if(combo_ready == true && sweep_type==false && textBox3.Text != "")
            {
                try
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
                catch (Exception)
                {
                    label7.ForeColor = System.Drawing.Color.Red;
                    label7.Text = "Invalid";
                    sweep_ready = false;
                }
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "Invalid";
                sweep_ready = false;
            }  
        }

        /*-----------------------DC_OFFSET---------------------------------*/

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string offset_str = textBox2.Text;
                if (offset_str != "")
                {
                    this.offset = Double.Parse(offset_str, NumberStyles.AllowLeadingSign);
                    if (offset < -10 || offset > 10)
                    {
                        label12.ForeColor = System.Drawing.Color.Red;
                        label12.Text = "Invalid";
                        offset_ready = false;
                    }
                    else
                    {
                        label12.ForeColor = System.Drawing.Color.Green;
                        label12.Text = "Valid";
                        offset_ready = true;
                    }
                }
                else
                {
                    label12.ForeColor = System.Drawing.Color.Red;
                    label12.Text = "Invalid";
                    offset_ready = false;
                }
            }
            catch (Exception)
            {
                label12.ForeColor = System.Drawing.Color.Red;
                label12.Text = "Invalid";
                offset_ready = false;
            }
        }

        /*-----------------------START_TEST-------------------------------*/

        //Start Test Button Handling
        private void button1_Click(object sender, EventArgs e)
        {

            if (frequency_start_ready == true && frequency_end_ready == true && frequency_end > frequency_start)
            {
                frequency_ready = true;
            }
            else
            {
                frequency_ready = false;
            }

            if (amplitude_ready == true && frequency_ready == true && sweep_ready == true && offset_ready == true)
            {
                String fileName = "results.txt";
                String pathString = System.IO.Path.Combine(workspace, fileName);
                this.path = pathString;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@pathString))
                {
                    //file.WriteLine(frequency_start + ", " + frequency_end + ", " + amplitude + ", " + sweep + ", " + offset);
                    file.WriteLine("Frequency Gain Phase Change");
                    for (int i = 0; i < 100; i++)
                    {
                        file.WriteLine(i + "\t" + i * i + "\t" + i * i * i);

                    }
                }
                test_complete = true;

                button1.BackColor = System.Drawing.Color.Red;
                button1.Text = "Stop Test";

                label8.ForeColor = System.Drawing.Color.Green;
                label8.Text = "Test Complete";
            }
            else
            {
                label8.ForeColor = System.Drawing.Color.Red;
                label8.Text = "One or more values not set or valid";
            }
        }

        /*-----------------------DISPLAY_OUTPUT--------------------------*/

        //View Gain Results Button Handling
        private void button2_Click(object sender, EventArgs e)
        {
            if (test_complete == true)
            {
                Form3 frm = new Form3(path);
                frm.Show();
            }
        }

        //View Phase Change Results Button Handling
        private void button3_Click(object sender, EventArgs e)
        {
            if (test_complete == true)
            {
                Form4 frm = new Form4(path);
                frm.Show();
            }
        }

    }
}
