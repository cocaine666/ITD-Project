using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DevOfficeClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        bool start = false;
        int counter_s = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter_s++;
            if(counter_s == 5 && textBox1.Text.Length < 1)
            {
                MessageBox.Show("Please input the IP of the DevOffice server that your employer gave you!");
                counter_s = 0;
            }
            if (counter_s == 5 && textBox1.Text.Length > 1)
            {
                if (Process.GetProcessesByName("WorkCheckClient").Length < 1)
                {
                    Process client = new Process
                    {
                        StartInfo =
                    {
                        FileName = "WorkCheckClient.exe",
                        Arguments = textBox1.Text + " " + Form1.username
                    }
                    };
                    client.Start();
                    label2.Text = "Status: Running";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!start)
            {
                start = true;
            }
            if (start)
            {
                start = false;
            }

            // LOOOOOOOOOOOOOOOOOOOOOOL
        }
    }
}
