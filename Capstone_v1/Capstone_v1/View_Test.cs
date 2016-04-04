/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * View_Test Version 1
 * Developed By: Ashley Krueger
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

namespace Capstone_v1
{
    /* This is the form used when the user chooses to view an old test in the start_page.
     * It allows the user to select a file and then it validates that file.
     * Once the file is validated, the user can view the results from that file.
     */
    public partial class View_Test : Form
    {
        //class level variables: the file path, and the sweep rate type
        String path;
        Boolean type;

        //The contstructor for this page
        public View_Test()
        {
            //initailize theclass level variables
            path = "";
            type = true;//defaults to linear
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
            //Get the file path
            path = file_path.Text;

            //if the file path is empty
            if (path == "")
            {
                Output_Label.ForeColor = System.Drawing.Color.Red;
                Output_Label.Text = "Must Enter a Path Name First";
            }
            //the file path is not empty
            else
            {
                //if the path exists
                if (File.Exists(path))
                {
                    //If the file is of a valid type (only .csv)
                    if (path.EndsWith(".csv"))
                    {
                        //read in the file data
                        string[] data = System.IO.File.ReadAllLines(@path);

                        //if the data meets the minimum length requirement for a valid file
                        if (data.Length > 6)
                        {
                            //arrays for the frequency, gain, and phase change
                            double[] data1 = new double[data.Length - 6];
                            double[] data2 = new double[data.Length - 6];
                            double[] data3 = new double[data.Length - 6];

                            //if the data meets the correct starting condition
                            if (data[0].StartsWith("Start Frequency:"))
                            {
                                //try to convert the data to doubles
                                try
                                {
                                    //loop through to convert all the data
                                    for (int i = 0; i < data.Length - 6; i++)
                                    {
                                        data1[i] = Convert.ToDouble(data[i + 6].Split(',')[0]);
                                        data2[i] = Convert.ToDouble(data[i + 6].Split(',')[1]);
                                        data3[i] = Convert.ToDouble(data[i + 6].Split(',')[2]);
                                    }

                                    //set the sweep rate type
                                    if (data[3].StartsWith("Linear"))
                                    {
                                        type = true;
                                    }
                                    else
                                    {
                                        type = false;
                                    }

                                    //make the results buttons visible so the user can view the results
                                    gain_button.Visible = true;
                                    phase_change_button.Visible = true;
                                    Output_Label.ForeColor = System.Drawing.Color.Green;
                                    Output_Label.Text = "View Results By Clicking on the Buttons Below:";

                                }
                                //The data is not numeric so therefore not valid
                                catch (Exception)
                                {
                                    Output_Label.ForeColor = System.Drawing.Color.Red;
                                    Output_Label.Text = "Data in File not valid";
                                    gain_button.Visible = false;
                                    phase_change_button.Visible = false;
                                }

                            }
                            //The file does not meet the correct starting condition
                            else
                            {
                                Output_Label.ForeColor = System.Drawing.Color.Red;
                                Output_Label.Text = "Data in File not valid";
                                gain_button.Visible = false;
                                phase_change_button.Visible = false;
                            }
                        }
                        //The file is too short to be valid
                        else
                        {
                            Output_Label.ForeColor = System.Drawing.Color.Red;
                            Output_Label.Text = "Data in File not valid";
                            gain_button.Visible = false;
                            phase_change_button.Visible = false;
                        }
                    }
                    //The file is not a valid type (not .csv)
                    else
                    {
                        Output_Label.ForeColor = System.Drawing.Color.Red;
                        Output_Label.Text = "File Not Valid Type";
                        gain_button.Visible = false;
                        phase_change_button.Visible = false;
                    }
                }
                //The path does not exist
                else
                {
                    Output_Label.ForeColor = System.Drawing.Color.Red;
                    Output_Label.Text = "File Path Not Valid";
                    gain_button.Visible = false;
                    phase_change_button.Visible = false;
                }
            }
        }

        //Opens the gain_results
        private void button3_Click(object sender, EventArgs e)
        {
            Gain_Results frm = new Gain_Results(path, type);
            frm.Show();
        }

        //Opens the phase_change_results
        private void button4_Click(object sender, EventArgs e)
        {
            Phase_Change_Results frm = new Phase_Change_Results(path, type);
            frm.Show();
        }
    }
}
