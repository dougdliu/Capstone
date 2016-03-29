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

namespace Capstone_v1
{
    public partial class View_Test : Form
    {
        String path;
        Boolean type;
        public View_Test()
        {
            path = "";
            type = true;
            InitializeComponent();
        }

        //Browse Button
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            file_path.Text = openFile.FileName;
        }

        //Enter Button
        private void button2_Click(object sender, EventArgs e)
        {
            path = file_path.Text;
            if (path == "")
            {
                Output_Label.ForeColor = System.Drawing.Color.Red;
                Output_Label.Text = "Must Enter a Path Name First";
            }
            else
            {


                if (File.Exists(path))
                {
                    string[] data = System.IO.File.ReadAllLines(@path);
                    if (data.Length > 6)
                    {
                        double[] data1 = new double[data.Length - 6];
                        double[] data2 = new double[data.Length - 6];
                        double[] data3 = new double[data.Length - 6];

                        if (data[0].StartsWith("Start Frequency:"))
                        {
                            try
                            {
                                for (int i = 0; i < data.Length - 6; i++)
                                {
                                    data1[i] = Convert.ToDouble(data[i + 6].Split(',')[0]);
                                    data2[i] = Convert.ToDouble(data[i + 6].Split(',')[1]);
                                    data3[i] = Convert.ToDouble(data[i + 6].Split(',')[2]);
                                }

                                if (data[3].StartsWith("Linear"))
                                {
                                    type = true;
                                }
                                else
                                {
                                    type = false;
                                }
                                gain_button.Visible = true;
                                phase_change_button.Visible = true;
                                Output_Label.ForeColor = System.Drawing.Color.Green;
                                Output_Label.Text = "View Results By Clicking on the Buttons Below:";

                            }
                            catch (Exception)
                            {
                                Output_Label.ForeColor = System.Drawing.Color.Red;
                                Output_Label.Text = "Data in File not valid";
                                gain_button.Visible = false;
                                phase_change_button.Visible = false;
                            }

                        }
                        else
                        {
                            Output_Label.ForeColor = System.Drawing.Color.Red;
                            Output_Label.Text = "Data in File not valid";
                            gain_button.Visible = false;
                            phase_change_button.Visible = false;
                        }
                    }
                    else
                    {
                        Output_Label.ForeColor = System.Drawing.Color.Red;
                        Output_Label.Text = "Data in File not valid";
                        gain_button.Visible = false;
                        phase_change_button.Visible = false;
                    }
                }
                else
                {
                    Output_Label.ForeColor = System.Drawing.Color.Red;
                    Output_Label.Text = "File Path Not Valid";
                    gain_button.Visible = false;
                    phase_change_button.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gain_Results frm = new Gain_Results(path, type);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Phase_Change_Results frm = new Phase_Change_Results(path, type);
            frm.Show();
        }
    }
}
