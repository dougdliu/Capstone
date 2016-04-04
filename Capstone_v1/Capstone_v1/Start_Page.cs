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
    public partial class Start_Page : Form
    {
        int selected_action;
        public Start_Page()
        {
            selected_action = -1;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Action_Type.SelectedIndex==0)
            {
                selected_action = 0;
            }
            else if(Action_Type.SelectedIndex==1)
            {
                selected_action = 1;
            }
            else
            {
                selected_action = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selected_action == 0)
            {
                Error_Label.Text = "";
                Set_Workspace frm = new Set_Workspace();
                frm.Show();
            }
            else if (selected_action == 1)
            {
                Error_Label.Text = "";
                View_Test frm = new View_Test();
                frm.Show();
            }
            else
            {
                Error_Label.ForeColor = System.Drawing.Color.Red;
                Error_Label.Text = "Please Select an Action First";
            }

        }
    }
}
