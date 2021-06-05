using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ITD
{
    public partial class Form4 : Form
    {

        bool moving;
        Point offset;
        Point original;

        public Form4()
        {
            InitializeComponent();
            string pattern = "*.png";
            var dirInfo = new DirectoryInfo("C:/WorkCheckServer/Screenshots");
            var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).First();
            label5.Text = label5.Text + " " + file.CreationTime.ToString();

            label9.Parent = pictureBox2;
            label9.BackColor = Color.Transparent;

            comboBox1.SelectedIndex = 0;

            if (Form2.dark_mode)
            {
                panel1.BackColor = Form2.main_bar;
                this.BackColor = Form2.panel_bg;
                panel2.BackColor = Form2.panel_bg;
                comboBox1.BackColor = Color.DarkGray;
            }
            else
            {
                panel1.BackColor = Form2.main_bar_l;
                this.BackColor = Form2.panel_bg_l;
                panel2.BackColor = Form2.panel_bg_l;
                comboBox1.BackColor = Color.WhiteSmoke;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;

            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;

            this.Location = new Point(x, y);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            panel1.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            panel1.Capture = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2.ssb = false;
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close_h;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.min_h;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.min;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // maybe explorer process..?
            if(Directory.Exists("C:/WorkCheckServer")) {
                Process folder_preview = new Process
                {
                    StartInfo =
                    {
                        Arguments = "C:\\WorkCheckServer\\Screenshots\\",
                        FileName = "explorer.exe"
                    }
                };
                folder_preview.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = "*.png";
            var dirInfo = new DirectoryInfo("C:/WorkCheckServer/Screenshots");
            var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).First();
            pictureBox2.Image = Image.FromFile(file.FullName);
        }
    }
}
