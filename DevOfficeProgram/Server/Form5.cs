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
    public partial class Form5 : Form
    {
        bool moving;
        Point offset;
        Point original;

        public Form5()
        {
            InitializeComponent();
            pictureBox10.Parent = panel1;
            pictureBox10.BackColor = Color.Transparent;
            if (Form2.dark_mode)
            {
                panel1.BackColor = Form2.main_bar;
                this.BackColor = Form2.panel_bg;
                panel2.BackColor = Form2.panel_bg;
                panel3.BackColor = Form2.panel_bg;
                panel4.BackColor = Form2.panel_bg;
                button1.BackColor = Form2.main_bar;
                button2.BackColor = Form2.main_bar;
                button3.BackColor = Form2.main_bar;
            }
            else
            {
                panel1.BackColor = Form2.main_bar_l;
                this.BackColor = Form2.panel_bg_l;
                panel2.BackColor = Form2.panel_bg_l;
                panel3.BackColor = Form2.panel_bg_l;
                panel4.BackColor = Form2.panel_bg_l;
                button1.BackColor = Form2.main_bar_l;
                button2.BackColor = Form2.main_bar_l;
                button3.BackColor = Form2.main_bar_l;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            panel1.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;

            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;

            this.Location = new Point(x, y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            panel1.Capture = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Form2.projb = false;
            
            this.Close();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.min_h;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.min;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close_h;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
