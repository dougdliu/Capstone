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
                    label5.Text = "Value Received";
                }
            }
            
        }
    }
}
