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

namespace ITD
{
    public partial class Form2 : Form
    {

        public int timer_pass = 0;
        bool side_panel = false;
        bool moving;
        public static bool ssb = false;
        public static bool projb = false;
        public static bool work_chkb = false;
        Point offset;
        Point original;

        public static bool dark_mode = false;
        // Light colors
        public static Color main_bar_l = Color.SteelBlue;
        public static Color side_bar_l = Color.CornflowerBlue;
        public static Color panel_bg_l = Color.WhiteSmoke;

        // Dark colors
        public static Color main_bar = Color.FromArgb(255, 23, 23, 23);
        public static Color side_bar = Color.FromArgb(255, 0, 0, 0);
        public static Color panel_bg = Color.FromArgb(255, 64, 64, 64);

        Form work_chk = new Form6();
        Form proj = new Form5();
        Form ss = new Form4();

        public Form2()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            pictureBox4.Parent = active_developers;
            pictureBox4.BackColor = Color.Transparent;
            Point loc_panel = new Point(-200, 0);
            panel2.Location = loc_panel;
            //
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static bool workcheckserver_status = false;
        Process server = new Process
        {
            StartInfo =
            {
                FileName = "WorkCheckServer.exe",
                Arguments = "TestServer"
            }
        };

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(workcheckserver_status && Process.GetProcessesByName("WorkCheckServer").Length < 1)
            {
                workcheckserver_status = false;
            }
            if (!workcheckserver_status)
            {
                if (Process.GetProcessesByName("WorkCheckServer").Length < 1)
                {
                    server.Start();
                    workcheckserver_status = true;
                }
            }
        }

      

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!side_panel)
            {
                Point loc = new Point(10, 232);
                Point loc2 = new Point(-200, 0);
                side_panel = true;
                //pictureBox4.Location = loc;
                pictureBox4.Image = Properties.Resources.slide2;

                int x1 = -190;
                int x2 = 12;
                int y2 = 0;

                while (true)
                {
                    if (x1 == 0)
                        break;
                    Point anim_var = new Point(x1, 0);
                    Point anim_var2 = new Point(x2, 232);
                    panel2.Location = anim_var;
                    pictureBox4.Location = anim_var2;
                    x1+=2;
                    x2+=2;

                }
            }
            else
            {
                Point loc = new Point(10, 232);
                Point loc2 = new Point(-200, 0);
                side_panel = false;
                //pictureBox4.Location = loc;
                pictureBox4.Image = Properties.Resources.slide;

                int x1 = 0;
                int x2 = 212;
                int y2 = 0;

                while (true)
                {
                    if (x1 == -190)
                        break;
                    Point anim_var = new Point(x1, 0);
                    Point anim_var2 = new Point(x2, 232);
                    panel2.Location = anim_var;
                    pictureBox4.Location = anim_var2;
                    x1-=2;
                    x2-=2;
                    
                }
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

        private void label2_Click(object sender, EventArgs e)
        {
            if (!ssb)
            {
                ss.Close();
                ssb = true;
                ss = new Form4();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Cannot open more instances of the same window.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (!projb)
            {
                proj.Close();
                projb = true;
                proj = new Form5();
                proj.Show();
            }
            else
            {
                MessageBox.Show("Cannot open more instances of the same window.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (!work_chkb)
            {
                work_chk.Close();
                work_chkb = true;
                work_chk = new Form6();
                work_chk.Show();
            }
            else
            {
                MessageBox.Show("Cannot open more instances of the same window.");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            if(work_chkb)
            {
                work_chk.Hide();
            }
            if(ssb)
            {
                ss.Hide();
            }
            if(projb)
            {
                proj.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
            this.Show();
            if (work_chkb)
            {
                work_chk.Show();
            }
            if (ssb)
            {
                ss.Show();
            }
            if (projb)
            {
                proj.Show();
            }
            notifyIcon1.Visible = false;
        }

        protected void show_gui(Object sender, System.EventArgs e)
        {
            this.Show();
            if (work_chkb)
            {
                work_chk.Show();
            }
            if (ssb)
            {
                ss.Show();
            }
            if (projb)
            {
                proj.Show();
            }
            notifyIcon1.Visible = false;
        }


        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.min_h;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.min;
        }

        protected void exit_program(Object sender, System.EventArgs e)
        {
           Application.Exit();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1.ContextMenu = new ContextMenu();

            notifyIcon1.ContextMenu.MenuItems.Add(0, new MenuItem("Show the GUI", new System.EventHandler(show_gui)));
            notifyIcon1.ContextMenu.MenuItems.Add(1, new MenuItem("Exit", new System.EventHandler(exit_program)));

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if(!dark_mode)
            {
                panel1.BackColor = main_bar;
                panel2.BackColor = side_bar;
                active_developers.BackColor = panel_bg;
                dark_mode = true;
            }
            else
            {
                panel1.BackColor = main_bar_l;
                panel2.BackColor = side_bar_l;
                active_developers.BackColor = panel_bg_l;
                dark_mode = false;
            }
        }
    }
}
