using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace FrozenCandy
{
    class MyTime
    {
        int min, sec, c;
        public static bool flag;
        Timer t = new Timer();


        public MyTime(int t)
        {
            c = 0;
            sec = t % 60;
            min = t / 60;
            flag = false;

            this.t.Tick += new EventHandler(t_Tick);
            this.t.Interval = 1000;
            this.t.Start();
        }


        public void Restart(int t)
        {
            sec = t % 60;
            min = t / 60;
            flag = false;

            this.t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
           
            if (flag == false)
            {
                c++;
                if (sec == 0)
                    if (min == 0)
                    {
                        flag = true;
                        t.Stop();
                    }
                    else
                    {
                        min--;
                        sec = 59;
                    }
                else
                    sec--;
            }
        }

        public string GetTime()
        {
            string s1, s2, s3;

            if (min < 10)
                s1 = "0" + min;
            else
                s1 = min.ToString();

            if (sec < 10)
                s2 = "0" + sec;
            else
                s2 = sec.ToString();

            s3 = s1 + ":" + s2;

            return s3;
        }

        public void Close()
        {
            t.Stop();
        }

        public void Draw(Graphics g, int x, int y, int size)
        {
            g.DrawString(GetTime(), new Font("algerian", size), Brushes.Red, new Point(x, y));
        }

        public int getcounter()
        {
            return c;
        }
    }
}
