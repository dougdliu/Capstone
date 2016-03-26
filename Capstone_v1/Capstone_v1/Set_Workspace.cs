using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*------------------------Workspace Handling---------------------------*/

namespace Capstone_v1
{
    public partial class Set_Workspace : Form
    {
        public Set_Workspace()
        {
            InitializeComponent();
        }

        //Enter Button Handling
        private void button1_Click(object sender, EventArgs e)
        {
            //If the workspace text is empty
            if (Workspace_Text.Text == "")
            {
                //Set label to invalid
                label2.ForeColor = System.Drawing.Color.Red;
                label2.Text = "Please enter a valid workspace";
            }
            //The workspace is not empty
            else
            {
                //If the directory exists
                if(Directory.Exists(Workspace_Text.Text))
                {
                    //Reset the label
                    label2.Text = "";
                    //Open up the main page
                    Main_Page frm = new Main_Page(Workspace_Text.Text);
                    frm.Show();
                }
                
                else
                {
                    //Set the label to invalid
                    label2.ForeColor = System.Drawing.Color.Red;
                    label2.Text = "Please enter a valid workspace";
                }
                
            }
            
        }

        //Browse Button Handling
        private void button2_Click(object sender, EventArgs e)
        {
            //Make a folder browser and open it
            FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            //When a folder is selected
            if (result == DialogResult.OK)
            {
                //reset the label and set the textbox to the selected path
                label2.Text = "";
                Workspace_Text.Text = folderBrowserDialog1.SelectedPath; // for the name and path of the file to be read
            }
            
        }
    }
}
