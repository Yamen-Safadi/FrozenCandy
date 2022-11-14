using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FrozenCandy
{
    class Game
    {
        public static Matrix m;
        public static int level;
        public static Random r = new Random();
        public static int screenX, screenY;
        public static Ball b;
        public static MyTime mt;
        Timer t = new Timer();
        Timer t2 = new Timer();
        public static string name;
       

        public Game()
        {
            level = 1;
            screenX = Screen.PrimaryScreen.Bounds.Width;
            screenY = Screen.PrimaryScreen.Bounds.Height;
            StartGame();
         
            t.Tick += new EventHandler(t_Tick);
            t.Interval=250;
            t.Start();

            t2.Tick += new EventHandler(t2_Tick);
            t2.Interval = 30000;
            t2.Start();

        }

        void t2_Tick(object sender, EventArgs e)
        {
            for (int i = 14; i >=0; i--)
            {
                for (int j = 20; j >0; j--)
                {
                    m.SetValue(i, j + 1, m.GetValue(i, j));
                }
                
            }
            for (int i = 0; i < 14; i++)
            {
                m.SetValue(i, 1, r.Next(1, 5));

            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (checkgameover())
            {
                Main.start = 5;
                t.Stop();
                return;

            }
            
            if (MyTime.flag == true)
            {
              /*  Main.tp.CheckForNewHighScore(mt.getcounter());
                Main.tp.SaveHighScores();
                t.Stop();
                if (MessageBox.Show("game over","frozencandy",MessageBoxButtons.OK)==DialogResult.OK)
                {
                    Main.start = 1;
                }
               */
                Main.start = 5;
                t.Stop();
            }

            if (CheckFinish()==true)
            {
                Main.tp.CheckForNewHighScore(mt.getcounter());
                Main.tp.SaveHighScores();
                t.Stop();
                if (MessageBox.Show("winner , do you want to play again ? ",Game.name,MessageBoxButtons.OK )==DialogResult.OK)
                {
                 Main.start=1;   
                }
                else
                Application.Exit();
            }
        }



        bool CheckFinish()
        {
            bool f = true;
            for (int i = 0; i < 14; i++)
            {
                for (int j= 0; j <20; j++)
                {
                    if (m.GetValue(i, j) != 0)
                        f = false;
                }
                
            }
            return f;
        }
        

        public int count(int x, int y, int v)
        {
            if (m.GetValue(x, y) != v) return 0;

            else
            {
                m.SetValue(x, y, 100);
                return 1 + count(x - 1, y, v)
                         + count(x + 1, y, v)
                         + count(x, y - 1, v)
                         + count(x, y + 1, v);
            }

        }
        public void clear(int x, int y, int v)
        {
            if (m.GetValue(x, y) != v) return;

            else
            {
                m.SetValue(x, y, 0);
                clear(x - 1, y, v);
                clear(x + 1, y, v);
                clear(x, y - 1, v);
                clear(x, y + 1, v);
            }
        }



        public void trytoclear(int x, int y, int v)
        {
           // System.Threading.Thread.Sleep(500);
            int c = count(x, y, v);
            if (c >= 3)
            {
                clear(x, y, 100);
                TryToClearNotHang();
            }
            else
                for (int i = 0; i < 14; i++)
                {
                    for (int j = 0; j < 20 ; j++)
                    {
                        if (m.GetValue(i, j) == 100)
                            m.SetValue(i, j, v);
                    }

                }
        }


        bool TryToGetUp(int x, int y)
        {
            if (y == 0) return true;
            if (m.GetValue(x, y) <= 0) return false;
            else
            {
                m.SetValue(x, y, -1);
                return TryToGetUp(x + 1, y) || TryToGetUp(x - 1, y) || TryToGetUp(x, y + 1) || TryToGetUp(x, y - 1);
            }
        }


        void ClearNotHang(int x, int y)
        {
            
            if (m.GetValue(x, y) <= 0) return;
            else
            {
                m.SetValue(x, y, 0);
                ClearNotHang(x + 1, y);
                ClearNotHang(x - 1, y);
                ClearNotHang(x, y + 1);
                ClearNotHang(x, y - 1);
            }
        }

        public void TryToClearNotHang()
        {
            Matrix tmp = new Matrix(m);

            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (m.GetValue(i, j) > 0)
                    {
                        if (TryToGetUp(i, j) == false)
                        {
                            m = new Matrix(tmp);
                            ClearNotHang(i, j);
                            tmp = new Matrix(m);
                            //return;
                        }
                        else
                            m = new Matrix(tmp);


                    }
                }
            }
        }
        

        public void StartGame()
        {
            switch (level)
            {
                case 1: Level1(); break;
                case 2: Level2(); break;
                case 3: Level3(); break;                
            }
        }
        public static bool checkgameover()
        {
            bool f = false;
            for (int i = 0; i < 14; i++)
            {
                if (m.GetValue(i,13)!=0)
                {
                    f =true ;
                }   

                
            }
            return f;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Resource1.b7, Matrix.dx, Matrix.dy,420,600);

            m.Draw(g);
            b.Draw(g);
            mt.Draw(g,screenX-Matrix.dx +20,screenY-Matrix.dy-50 ,20);
            g.DrawString("player name : " + name,
                new Font("Comic Sans MS", 20),
                Brushes.Blue,
                new Point(screenX - 300,100));
            if (Main .X>0 &&Main.X<100 && Main.Y>0&&Main.Y<100)
            {
                 g.DrawImage(Resource1.back2, 0, 0, 130, 130);
            }
            else
                  g.DrawImage(Resource1.back2, 0, 0, 120, 120);

        }

        void Level1()
        {
            int dx, dy;
            dx = (screenX - 420) / 2;
            dy = (screenY - 600) / 2;
       
            m = new Matrix(14, 20, 30, 30,dx,dy);
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j <5; j++)
                {
                    m.SetValue(i, j, r.Next(1, 5));
                }
            }
            b = new Ball();

            mt = new MyTime(600);

        }
        void Level2()
        {
        }
        void Level3()
        {
        }
    }
}
