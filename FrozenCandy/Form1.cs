using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrozenCandy
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        Main m = new Main();

        public Form1()
        {
            InitializeComponent();

 
            ClientSize = new Size(640, 480);
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 50;
            t.Start();
        }

        private void t_Tick(object sender, System.EventArgs e)
        {
            if (Main.start==1)
            {
                 ClientSize = new Size(890, 340);
                 WindowState = FormWindowState.Normal;
                 FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            }
            Invalidate();
             if (Main.start==5)
            {
                   WindowState = FormWindowState.Maximized;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    BackColor = Color.Black;
            }
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            m.draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            

            if (Main.X > 770 && Main.X < 855&& Main.Y > 100 && Main.Y < 190)
            {
                m.Sound();
            }
            if (Main.start == 2)
            {
                Game.b.Start();
                if (Main.X > 0 && Main.X <100&& Main.Y > 00 && Main.Y < 100)
                {
                    Main.start = 1;
                }
            }
            if (Main.start == 1)
            {
                if (Main.X > 345 && Main.X < 540 && Main.Y > 180 && Main.Y < 252)
                {
                    m.StartGame();
                
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    BackColor = Color.Black;
                    Main.start = 2;
                }
                else if (Main.X > 75 && Main.X <270 && Main.Y > 180 && Main.Y < 252)
                {

                    Main.start = 3;
                    ClientSize = new Size(640,800);
                }
                    else
                    if (Main.X > 680 && Main.X < 730 && Main.Y > 240 && Main.Y < 310)
                    {
                        Main.start = 4;
                    }




                    else if (Main.X > 775 && Main.X < 850 && Main.Y > 10 && Main.Y < 85)
                    {
                        if (MessageBox.Show("are you sure?", "ExitGame", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                    }
                if (Main.X > 720 && Main.X < 870 && Main.Y > 200 && Main.Y < 270)
                {
                    Main.start = 4;
                }
               
            }
            if (Main.start == 4)
            {
                ClientSize = new Size(640, 480);
                if (Main.X > 2 && Main.X < 27 && Main.Y > 2 && Main.Y < 27)
                {
                    Main.start = 1;
                }

            }

            if (Main.X > 2 && Main.X <27 && Main.Y > 2 && Main.Y < 27)
            {
                Main.start = 1;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Main.X = e.X;
            Main.Y = e.Y;
            if (Main.start == 2)
            {
                Game.b.Rotate(e.X, e.Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Name n = new Name();
            n.ShowDialog();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Main.start==5)
            {
                Main.start = 1;
                return;
            }
        }

    }
}