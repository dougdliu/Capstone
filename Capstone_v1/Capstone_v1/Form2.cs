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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.ForeColor = System.Drawing.Color.Red;
                label2.Text = "Please enter a valid workspace";
            }
            else
            {
                //String fileName= "results.txt";
                //String pathString = System.IO.Path.Combine(textBox1.Text, fileName);
                //try
                if(Directory.Exists(textBox1.Text))
                {
                    
                    /*using (System.IO.StreamWriter file = new System.IO.StreamWriter(@pathString))
                    {
                        file.WriteLine("Test");
                        File.Delete(pathString);
                    }*/

                    label2.Text = "";
                    Form1 frm = new Form1(textBox1.Text);
                    frm.Show();
                }
                //catch (Exception)
                else
                {
                    label2.ForeColor = System.Drawing.Color.Red;
                    label2.Text = "Please enter a valid workspace";
                }
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                label2.Text = "";
                textBox1.Text = folderBrowserDialog1.SelectedPath; // for the name and path of the file to be read
            }
            
        }
    }
}
