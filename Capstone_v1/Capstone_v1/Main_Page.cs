/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * Main_Page Version 1
 * Developed By: Ashley Krueger
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_v1
{
    /* Reads in user input.
     * Connects to the Edison to run the test (WHEN debug (line 64) IS SET TO FALSE).
     * Runs the test and allows the user to view the results.
     */ 

    //The main input page for making new tests
    public partial class Main_Page : Form
    {
        //class level instance variables
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
        float amplitude;
        float frequency_start;
        float frequency_end;
        float sweep;
        float offset;

        //Strings
        string frequency_str_start;
        string frequency_str_end;
        string amplitude_str;
        string sweep_rate_str;
        string offset_str;

        //Make the communications object
        private Communications com;
        bool debug;

        public Main_Page(String ws)
        {
            /*Set to true when testing software without edison, 
             * false when testing software with edison
             */
            debug = true;
            this.workspace = ws;
            this.test_complete = false;
            this.combo_ready = false;
            this.sweep_type = true;
            this.amplitude_ready = false;
            this.frequency_start_ready = false;
            this.sweep_ready = false;
            this.offset_ready = false;
            //this.output_ready = false;
            this.frequency_start = 0.0F;
            this.amplitude = 0.0F;
            this.sweep = 0.0F;
            this.offset = 0.0F;
            InitializeComponent();

            this.frequency_str_start="";
            this.frequency_str_end="";
            this.amplitude_str="";
            this.sweep_rate_str="";
            this.offset_str="";
            if (!debug)
            {
                this.com = new Communications();
            }
            
        }

        /*------------------------FREQUENCY---------------------------------*/

        //Frequency Start Text Box Handling
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //reset the button since an input value was changed
            run_test_button.BackColor = System.Drawing.Color.Green;
            run_test_button.Text = "Start Test";

            //try to read in the input and parse it to a float
            try
            {
                //read in input
                frequency_str_start = f_start_val.Text;
                //if the input is not empty
                if(frequency_str_start != "")
                {
                    //convert the input to float
                    this.frequency_start = Convert.ToSingle(frequency_str_start);
                    //if it is not in the valid range, this value is not ready and print out invalid message
                    if (frequency_start < 1 || frequency_start > 400000)
                    {
                        f_unit.ForeColor = System.Drawing.Color.Red;
                        f_unit.Text = "Invalid";
                        frequency_start_ready = false;
                    }
                    //the value is in the valid range, this value is ready, and print out valid message
                    else
                    {
                        f_unit.ForeColor = System.Drawing.Color.Green;
                        f_unit.Text = "Valid";
                        frequency_start_ready = true;

                        if (frequency_str_end != "")
                        {
                            float temp = Convert.ToSingle(frequency_str_end);
                            if (temp <= frequency_start)
                            {
                                frequency_ready = false;
                                f_unit.ForeColor = System.Drawing.Color.Red;
                                f_unit.Text = "Invalid";
                            }
                        }
                    }
                }
                //If the input is still empty
                else
                {
                    frequency_start_ready = false;
                    f_unit.ForeColor = System.Drawing.Color.Red;
                    f_unit.Text = "Invalid";
                }
            }
            //catch when a float value was not able to be converted
            catch (Exception)
            {
                //the value is not ready, print out invalid message
                f_unit.ForeColor = System.Drawing.Color.Red;
                f_unit.Text = "Invalid";
                frequency_start_ready = false;
            }
        }

        //Frequency End Text Box Handling
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //reset the button since an input value was changed
            run_test_button.BackColor = System.Drawing.Color.Green;
            run_test_button.Text = "Start Test";

            //try to read in the input and parse it to a float
            try
            {
                //read in input
                frequency_str_end = f_end_val.Text;
                //if the input is not empty
                if (frequency_str_end != "")
                {
                    //convert the input to float
                    this.frequency_end = Convert.ToSingle(frequency_str_end);
                    //if it is not in the valid range, this value is not ready and print out invalid message
                    if (frequency_end < 1 || frequency_end > 400000)
                    {
                        f_unit.ForeColor = System.Drawing.Color.Red;
                        f_unit.Text = "Invalid";
                        frequency_end_ready = false;
                    }
                    //the value is in the valid range, this value is ready, and print out valid message
                    else
                    {
                        f_unit.ForeColor = System.Drawing.Color.Green;
                        f_unit.Text = "Valid";
                        frequency_end_ready = true;

                        if (frequency_str_start != "")
                        {
                            float temp = Convert.ToSingle(frequency_str_start);
                            if (temp >= frequency_end)
                            {
                                frequency_ready = false;
                                f_unit.ForeColor = System.Drawing.Color.Red;
                                f_unit.Text = "Invalid";
                            }
                        }
                    }
                }
                //If the input is still empty
                else
                {
                    frequency_end_ready = false;
                    f_unit.ForeColor = System.Drawing.Color.Red;
                    f_unit.Text = "Invalid";
                }
            }
            //catch when a float value was not able to be converted
            catch (Exception)
            {
                //the value is not ready, print out invalid message
                f_unit.ForeColor = System.Drawing.Color.Red;
                f_unit.Text = "Invalid";
                frequency_end_ready = false;
            }
        }

        /*-----------------------AMPLITUDE---------------------------------*/

        //Amplitude Text Box Handling
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //reset the button since an input value was changed
            run_test_button.BackColor = System.Drawing.Color.Green;
            run_test_button.Text = "Start Test";

            //try to read in the input and parse it to a float
            try
            {
                //read in input
                amplitude_str = amp_val.Text;
                //if the input is not empty
                if (amplitude_str != "")
                {
                    //convert the input to float
                    this.amplitude = Convert.ToSingle(amplitude_str);
                    //if it is not in the valid range, this value is not ready and print out invalid message
                    if (amplitude < 0.005 || amplitude > 2)
                    {
                        amp_unit.ForeColor = System.Drawing.Color.Red;
                        amp_unit.Text = "Invalid";
                        amplitude_ready = false;
                    }
                    //the value is in the valid range, this value is ready, and print out valid message
                    else
                    {
                        amp_unit.ForeColor = System.Drawing.Color.Green;
                        amp_unit.Text = "Valid";
                        amplitude_ready = true;
                    }
                }
                //If the input is still empty
                else
                {
                    amp_unit.ForeColor = System.Drawing.Color.Red;
                    amp_unit.Text = "Invalid";
                    amplitude_ready = false;
                }
            }
            //catch when a float value was not able to be converted
            catch (Exception)
            {
                //the value is not ready, print out invalid message
                amp_unit.ForeColor = System.Drawing.Color.Red;
                amp_unit.Text = "Invalid";
                amplitude_ready = false;
            }
        }

        /*-----------------------SWEEP_RATE--------------------------------*/

        //Sweep Rate Combo Box Handling
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reset the button since an input value was changed
            run_test_button.BackColor = System.Drawing.Color.Green;
            run_test_button.Text = "Start Test";

            //The selected index is linear
            if(rate_type.SelectedIndex == 1)
            {
                //set the correct unit and range label
                rate_unit.ForeColor = System.Drawing.Color.Black;
                rate_unit.Text = "Hz/s";
                rate_range.Text = "0-1000 Hz/s";
                //set the ready flag to true
                combo_ready = true;
                //make the text box not read only
                rate.ReadOnly = false;
                //set the sweep type
                this.sweep_type = true;
            }
            //The selected index is logarithmic
            else if(rate_type.SelectedIndex == 0)
            {
                //set the correct unit and range label
                rate_unit.ForeColor = System.Drawing.Color.Black ;
                rate_unit.Text = "decades/s";
                rate_range.Text = "0-1 decades/s";
                //set the ready flag to true
                combo_ready = true;
                //make the text box not read only
                rate.ReadOnly = false;
                //set the sweep type
                this.sweep_type = false;
            }
            //if an index is still not selected
            else
            {
                //print an invalid label
                rate.ReadOnly = true;
                rate_unit.ForeColor = System.Drawing.Color.Red;
                rate_unit.Text = "Please select a type";
            }
        }

        //Sweep Rate Text Box Handling
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //reset the button since an input value was changed
            run_test_button.BackColor = System.Drawing.Color.Green;
            run_test_button.Text = "Start Test";

            //if a type was selected and it is linear and the text box is not empty
            if(combo_ready == true && sweep_type==true && rate.Text != "")
            {
                //try to read in the input and parse it to a float
                try
                {
                    //read in input
                    sweep_rate_str = rate.Text;
                    //convert the input to float
                    this.sweep = Convert.ToSingle(rate.Text);
                    //if it is not in the valid range, this value is not ready and print out invalid message
                    if (sweep <= 0 || sweep > 1000)
                    {
                        rate_unit.ForeColor = System.Drawing.Color.Red;
                        rate_unit.Text = "Invalid";
                        sweep_ready = false;
                    }
                    //the value is in the valid range, this value is ready, and print out valid message
                    else
                    {
                        rate_unit.ForeColor = System.Drawing.Color.Green;
                        rate_unit.Text = "Valid";
                        sweep_ready = true;
                    }
                }
                //catch when a float value was not able to be converted
                catch (Exception)
                {
                    //the value is not ready, print out invalid message
                    rate_unit.ForeColor = System.Drawing.Color.Red;
                    rate_unit.Text = "Invalid";
                    sweep_ready = false;
                }
               
            }
            //if a type was selected and it is linear and the text box is not empty
            else if(combo_ready == true && sweep_type==false && rate.Text != "")
            {
                //try to read in the input and parse it to a float
                try
                {
                    //read in input
                    //convert the input to float
                    this.sweep = Convert.ToSingle(rate.Text);
                    //if it is not in the valid range, this value is not ready and print out invalid message
                    if (sweep <= 0 || sweep > 1)
                    {
                        rate_unit.ForeColor = System.Drawing.Color.Red;
                        rate_unit.Text = "Invalid";
                        sweep_ready = false;
                    }
                    //the value is in the valid range, this value is ready, and print out valid message
                    else
                    {
                        rate_unit.ForeColor = System.Drawing.Color.Green;
                        rate_unit.Text = "Valid";
                        sweep_ready = true;
                    }
                }
                //catch when a float value was not able to be converted
                catch (Exception)
                {
                    rate_unit.ForeColor = System.Drawing.Color.Red;
                    rate_unit.Text = "Invalid";
                    sweep_ready = false;
                }
            }
            //The combo was not selected or it is empty
            else
            {
                //print an invalid label
                rate_unit.ForeColor = System.Drawing.Color.Red;
                rate_unit.Text = "Invalid";
                sweep_ready = false;
            }  
        }

        /*-----------------------DC_OFFSET---------------------------------*/

        //DC Offset Text Box Handling
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //reset the button since an input value was changed
            run_test_button.BackColor = System.Drawing.Color.Green;
            run_test_button.Text = "Start Test";

            //try to read in the input and parse it to a float
            try
            {
                //read in input
                offset_str = dc_val.Text;
                //if the input is not empty
                if (offset_str != "")
                {
                    //convert the input to float
                    this.offset = float.Parse(offset_str, NumberStyles.AllowLeadingSign);
                    //if it is not in the valid range, this value is not ready and print out invalid message
                    if (offset < -10 || offset > 10)
                    {
                        dc_unit.ForeColor = System.Drawing.Color.Red;
                        dc_unit.Text = "Invalid";
                        offset_ready = false;
                    }
                    //the value is in the valid range, this value is ready, and print out valid message
                    else
                    {
                        dc_unit.ForeColor = System.Drawing.Color.Green;
                        dc_unit.Text = "Valid";
                        offset_ready = true;
                    }
                }
                //If the input is still empty
                else
                {
                    dc_unit.ForeColor = System.Drawing.Color.Red;
                    dc_unit.Text = "Invalid";
                    offset_ready = false;
                }
            }
            //catch when a float value was not able to be converted
            catch (Exception)
            {
                //the value is not ready, print out invalid message
                dc_unit.ForeColor = System.Drawing.Color.Red;
                dc_unit.Text = "Invalid";
                offset_ready = false;
            }
        }

        /*-----------------------START_TEST-------------------------------*/

        //Start Test Button Handling COMMUNICATION HAPPENS HERE
        private void button1_Click(object sender, EventArgs e)
        {
            //The button says pause test so a test has already been started
            if (run_test_button.Text == "Pause Test")
            {
                //change the button to a neutral color and say resume test
                run_test_button.BackColor = System.Drawing.Color.Blue;
                run_test_button.Text = "Resume Test";
            }
            //The button says resume test because a test has already been started and paused and no values have been channged since then
            else if (run_test_button.Text == "Resume Test")
            {
                //send some form of restart signal to the edison
            }
            //The button says start test so it is starting a new test
            else
            {
                //If the frequency start and end are ready and the start is less than the end value
                if (frequency_start_ready == true && frequency_end_ready == true && frequency_end > frequency_start)
                {
                    frequency_ready = true;
                }
                //The frequency start and end are not ready or the start is not less than the end value
                else
                {
                    frequency_ready = false;
                }
                //All the values are ready and the file name is not empty
                if (amplitude_ready == true && frequency_ready == true && sweep_ready == true && offset_ready == true && file_name_val.Text != "")
                {
                    String fileName = file_name_val.Text;
                    //Default to .csv
                    fileName += ".csv";
                    //reset the label
                    file_name_label.ForeColor = System.Drawing.Color.Black;
                    file_name_label.Text = "Output File Name:";
                    //get invalid file name characters
                    char[] invalid = Path.GetInvalidFileNameChars();
                    bool contains_invalid = false;
                    //check if the filename has invalid characters
                    for (int i = 0; i < invalid.Length; i++)
                    {
                        String c = invalid[i].ToString();
                        if (fileName.Contains(c))
                        {
                            contains_invalid = true;
                        }
                    }
                    //The file name does not have any invalid characters
                    if (contains_invalid == false)
                    {
                        //reset the label
                        file_name_label.ForeColor = System.Drawing.Color.Black;
                        file_name_label.Text = "Output File Name:";
                        //set the path name
                        String pathString = System.IO.Path.Combine(workspace, fileName);
                        //if the file doesn't already exist
                        if (!File.Exists(pathString))
                        {

                            //reset the label
                            file_name_label.ForeColor = System.Drawing.Color.Black;
                            file_name_label.Text = "Output File Name:";

                            bool handshake_success;
                            if (!debug)
                            {
                                handshake_success = com.HandShake("HI");
                            }
                            else
                            {
                                handshake_success = true;
                            }

                            if (handshake_success)
                            {
                                int i = 0;
                                bool start = true, end = true, rate = true, sw = true, amp = true, off = true;
                                if (!debug)
                                {
                                    //communication stuff: transmit the user input to the Edison
                                    start = com.Transmit((i++) + "" + frequency_str_start);
                                    end = com.Transmit((i++) + "" + frequency_str_end);
                                    rate = com.Transmit((i++) + "" + sweep_rate_str);
                                    string type;
                                    if (sweep_type)
                                    {
                                        type = "0";
                                    }
                                    else
                                    {
                                        type = "1";
                                    }

                                    sw = com.Transmit((i++) + "" + type);
                                    amp = com.Transmit((i++) + "" + amplitude_str);
                                    off = com.Transmit((i++) + "" + offset_str);
                                }


                                if (start && end && rate && sw && amp && off)
                                {

                                    //reset the button (will need to be moved to a different location later)
                                    run_test_button.BackColor = System.Drawing.Color.Red;
                                    run_test_button.Text = "Pause Test";

                                    this.path = pathString;

                                    if (!debug)
                                    {
                                        //Edison communication
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@pathString))
                                        {

                                            //initialize the file with the user inputs
                                            file.WriteLine("Start Frequency: " + frequency_start);
                                            file.WriteLine("End Frequency: " + frequency_end);
                                            file.WriteLine("Amplitude: " + amplitude);
                                            if (sweep_type)
                                            {
                                                file.WriteLine("Linear Sweep Rate: " + this.sweep);
                                            }
                                            else
                                            {
                                                file.WriteLine("Logarithmic Sweep Rate: " + this.sweep);
                                            }
                                            file.WriteLine("DC Offset: " + offset);
                                            file.WriteLine("Frequency Gain Phase Change");
                                            test_output_label.Text = "Test in Progress";
                                            //read the output from the Edison
                                            com.ReadIn();
                                            String output = com.output;
                                            //While we have not reached the end of the output
                                            while (output[0] != 'E')
                                            {
                                                //write the output to the file
                                                file.WriteLine(output);

                                                /* Multithreading should be added here in the future. */
                                                //System.Threading.Thread newThread =new System.Threading.Thread(com.ReadIn);
                                                //newThread.Start();
                                                //while(output==com.output)
                                                //{
                                                    
                                                //}
                                                
                                                //Read in the next output
                                                com.ReadIn();
                                                output = com.output;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //dummy data is being written to a file
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@pathString))
                                        {
                                            //write the user inputs to the file
                                            file.WriteLine("Start Frequency: " + frequency_start);
                                            file.WriteLine("End Frequency: " + frequency_end);
                                            file.WriteLine("Amplitude: " + amplitude);
                                            if (sweep_type)
                                            {
                                                file.WriteLine("Linear Sweep Rate: " + this.sweep);
                                            }
                                            else
                                            {
                                                file.WriteLine("Logarithmic Sweep Rate: " + this.sweep);
                                            }
                                            file.WriteLine("DC Offset: " + offset);
                                            file.WriteLine("Frequency Gain Phase Change");

                                            //Write random data to the file at each of the intervals for frequency
                                            Random test = new Random();
                                            float f = frequency_start;
                                            for (i = 1; f <= frequency_end; i++)
                                            {
                                                file.WriteLine(f + "," + Math.Round((test.NextDouble()*amplitude*i),3) + "," + Math.Round((test.NextDouble()*Math.Abs(offset*i)),3));
                                                f = (frequency_start + (i * sweep));

                                            }
                                        }
                                    }

                                    //set the test to complete (will need to be moved to a different location later)
                                    test_complete = true;

                                    run_test_button.BackColor = System.Drawing.Color.Green;
                                    run_test_button.Text = "Start Test";

                                    //reset the output label (will need to be moved to a different location later)
                                    test_output_label.ForeColor = System.Drawing.Color.Green;
                                    test_output_label.Text = "Test Complete";
                                }
                                //Output an error when the data transmission fails
                                else
                                {
                                    test_output_label.ForeColor = System.Drawing.Color.Red;
                                    test_output_label.Text = "Data Transmission Failed";
                                }
                            }
                            //Output an error when the communication fails
                            else 
                            {
                                test_output_label.ForeColor = System.Drawing.Color.Red;
                                test_output_label.Text = "Communication Failure";
                            }
                        }
                        //The file name already exists, set the label to invalid
                        else
                        {
                            file_name_label.ForeColor = System.Drawing.Color.Red;
                            file_name_label.Text = "File name already exists";
                        }
                    }
                    //The file name has invalid characters, set the label to invalid
                    else
                    {
                        file_name_label.ForeColor = System.Drawing.Color.Red;
                        file_name_label.Text = "Invalid File Name";
                    }

                }
                //one of the values has not been set or is still not valid
                else
                {
                    test_output_label.ForeColor = System.Drawing.Color.Red;
                    test_output_label.Text = "One or more values not set or valid";
                }
            }
        }

        /*-----------------------DISPLAY_OUTPUT--------------------------*/

        //View Gain Results Button Handling
        private void button2_Click(object sender, EventArgs e)
        {
                //Open up the gain results form
                Gain_Results frm = new Gain_Results(path, sweep_type);
                frm.Show();
        }

        //View Phase Change Results Button Handling
        private void button3_Click(object sender, EventArgs e)
        {
                //Open up the phase change results form
                Phase_Change_Results frm = new Phase_Change_Results(path, sweep_type);
                frm.Show();
        }

    }
}
