using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FrozenCandy
{
    class Ball
    {
        double alpha;
        int x, y;
        int rx, ry;
        int c;

        int xp, yp;

        bool flag;
        Timer t = new Timer();


        int centerX, centerY;

        public bool F
        {
            get
            {
                return flag;
            }
        }

        public Ball()
        {
            y = Matrix.dy + 600 - 50;
            x = Game.screenX / 2;

            c = Game.r.Next(1, 5);
            centerX = x;
            centerY = y;
            flag = false;
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 20;
            t.Start();
            alpha = Math.PI / 2;
            rx = 20;
            ry = 20;

        }

        public void Move(int x)
        {
            if (x > 50 && x < 450 && !flag)
                this.x = x;
        }

        public void Draw(Graphics g)
        {
            float aa = (float)(alpha * 180 / Math.PI);

            Bitmap b = Images.RotateImage(Resource1.madfa, new Point(160,160), -aa );

            g.DrawImage(b, centerX - 50, centerY - 50, 100, 100);
            
            g.DrawEllipse(Pens.Black, centerX - 50, centerY - 50, 100, 100);
            switch (c)
            {
                case 1: g.DrawImage(Resource1.b1, x - 15, y - 15, 30, 30); break;
                case 2: g.DrawImage(Resource1.b2, x - 15, y - 15, 30, 30); break;
                case 3: g.DrawImage(Resource1.b3, x - 15, y - 15, 30, 30); break;
                case 4: g.DrawImage(Resource1.b4, x - 15, y - 15, 30, 30); break;

            }
        }

        private void Reset()
        {
            flag = false;
            alpha = Math.PI / 2;
            rx = 20;
            ry = 20;
            y = centerY;
            x = centerX;
            c = Game.r.Next(1, 5);
        }
        void t_Tick(object sender, EventArgs e)
        {
            
            if (flag)
            {



                if (x < Matrix.dx + 15 || x > Game.screenX - Matrix.dx - 15)
                    rx = -rx;
                if (y < Matrix.dy + 15)
                    ry = -ry;

                if (y > Game.screenY - Matrix.dy)
                {
                    Reset();
                }

                  x += (int)(rx * Math.Cos(alpha));
                  y -= (int)(ry * Math.Sin(alpha));

              

                if (y < Matrix.dy + 600)
                {
                    xp = (x - Matrix.dx) / 30;
                    yp = (y - Matrix.dy + (int)(ry * Math.Sin(alpha))) / 30;

                    if (Game.m.GetValue(xp, yp) != 0)
                    {

                        Game.m.SetValue(xp + 1, yp, c);

                        Main.gm.trytoclear(xp + 1, yp, c);
                        Reset();
                    }

                    xp = (x - Matrix.dx - (int)(rx * Math.Cos(alpha))) / 30;
                    yp = (y - Matrix.dy) / 30;

                    if (Game.m.GetValue(xp, yp) != 0)
                    {

                        Game.m.SetValue(xp, yp + 1, c);

                        Main.gm.trytoclear(xp, yp + 1, c);
                        Reset();
                    }
                }

            }

            
        }




        public void Start()
        {
            flag = true;

        }

        public void STop()
        {
            flag = false;

        }


        public void Rotate(int x, int y)
        {
            if (flag == false )
            {
                double dx, dy;
                dx = x - centerX;
                dy = centerY - y;

                if (dx != 0)
                {
                    double delta = dy / dx;

                    alpha = (float)(Math.Atan(delta));

                    if (dx < 0)
                        alpha += 135;


                    this.x = centerX + (int)(50 * Math.Cos(alpha));
                    this.y = centerY - (int)(50 * Math.Sin(alpha));
                }


            }
            /*
             
                double dx, dy;
                dx = x - this.x;
                dy = y - this.y;

                if (dx != 0)
                {


                    double delta = dy / dx;

                    alpha = (float)(Math.Atan(delta));
                    if (dx < 0)
                        alpha += 135;
                }
                else
                {


                }
                img = Images.RotateImage(Resource1.Player, new Point(54, 54), alpha * (float)(180 / Math.PI));
             */
        }



    }
}
