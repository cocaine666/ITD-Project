using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITD
{
    public partial class Form1 : Form
    {

        public int loading_time = 0;
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loading_time++;
            if(loading_time == 2)
            {
                Form f2 = new Form2();
                f2.Show();
                this.Hide();
                // Application.Exit();
            }
        }
    }
}
