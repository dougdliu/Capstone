/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * Start_Page Version 1
 * Developed By: Ashley Krueger
 */

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
    /* The start_page is the first page that opens when the user runs this code.
     * The user selects whether it wants to run a new test or view an old test.
     * It opens the appropriate next form based on what the user selects.
     */
    public partial class Start_Page : Form
    {
        //The class level variables: the user selected action's index
        int selected_action;

        //The constructor for the start page
        public Start_Page()
        {
            selected_action = -1;
            InitializeComponent();
        }

        //when the user selects an action in the combo box, this stores the index
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //new test
            if(Action_Type.SelectedIndex==0)
            {
                selected_action = 0;
            }
            //view an old tes
            else if(Action_Type.SelectedIndex==1)
            {
                selected_action = 1;
            }
            //no action selected (error case)
            else
            {
                selected_action = -1;
            }
        }

        //Enter button
        private void button1_Click(object sender, EventArgs e)
        {
            //opens the set_workspace form if the user chose to start a new test
            if (selected_action == 0)
            {
                Error_Label.Text = "";
                Set_Workspace frm = new Set_Workspace();
                frm.Show();
            }
            //opens the view_test form if the user chose to view an old test
            else if (selected_action == 1)
            {
                Error_Label.Text = "";
                View_Test frm = new View_Test();
                frm.Show();
            }
            //sets the label to an error if no action was selected
            else
            {
                Error_Label.ForeColor = System.Drawing.Color.Red;
                Error_Label.Text = "Please Select an Action First";
            }

        }
    }
}
