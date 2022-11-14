using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Media;


namespace FrozenCandy
{
    class Main
    {
        public static int start;
        public static int X, Y;
        public static Game gm;
        Timer t = new Timer();
        int sit;
        bool sit5= false;
        public static Top5Score tp;
        SoundPlayer sp=new SoundPlayer(Resource1.Interstellar___Main_Theme___Hans_Zimmer__online_audio_converter_com_);
        public static bool flagsound;


        public Main()
        {
            start = 1;
            tp = new Top5Score("yamen");
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 200;
            t.Start();
            sit = 0;
            flagsound = false;
        }
        public void Sound()
        {
            if (flagsound == true)
            {
                flagsound = false;
                sp.Stop();
            }
            else if (flagsound == false)
            {
                flagsound = true;
                sp.PlayLooping();
            }
        }


        void t_Tick(object sender, EventArgs e)
        {
            sit++;
            if (sit == 3)
            {
                sit=0;
            }
        
        }
        public void drawmovep(Graphics g)
        {
            g.DrawImage(Resource1._null,
                 new Rectangle(325, 160, 230,120),
                 new Rectangle(sit *280,0,280, 120),
                 GraphicsUnit.Pixel);
        }
        public void drawmoveh(Graphics g)
        {
            g.DrawImage(Resource1._null,
                 new Rectangle(55, 160, 230, 120),
                 new Rectangle(sit * 280, 0, 280, 120),
                 GraphicsUnit.Pixel);
        }


        public void StartGame()
        {
            gm = new Game();
            tp = new Top5Score(Game.name);

        }

        public void draw(Graphics g)
        {

            switch (start)
            {                
                case 1:
                 
                        if (Main.X > 345 && Main.X < 540 && Main.Y > 180 && Main.Y < 252)
                        {

                            g.DrawImage(Resource1.frozencandyslide, 0, 0, 890, 340);
                            g.DrawImage(Resource1.exit1, 775, 10, 75, 75);
                          
                            drawmovep(g);

                        }
                        else
                            if (Main.X > 75 && Main.X < 270 && Main.Y > 180 && Main.Y < 252)
                        {

                            g.DrawImage(Resource1.frozencandyslide, 0, 0, 890, 340);
                      
                            g.DrawImage(Resource1.exit1, 775, 10, 75, 75);
                            drawmoveh(g);
                        }
                        else
                        {
                            if (Main.X > 775 && Main.X < 860 && Main.Y > 10 && Main.Y < 95)
                            {
                                g.DrawImage(Resource1.frozencandyslide, 0, 0, 890, 340);
                                
                                g.DrawImage(Resource1.exit1, 770, 10, 85, 85);
                            }
                            else
                            {

                                g.DrawImage(Resource1.frozencandyslide, 0, 0, 890, 340);
                               
                                g.DrawImage(Resource1.exit1, 775, 10, 75, 75);
                            }
                        }


                        if (Main.X > 680 && Main.X < 730 && Main.Y > 240 && Main.Y < 310)
                        {

                            g.DrawImage(Resource1.frozencandyslide, 0, 0, 890, 340);
                            g.DrawImage(Resource1.exit1, 775, 10, 75, 75);
                            
                        }
               
                        g.DrawString("X : " + X + "\nY : " + Y, new Font("David", 12), Brushes.Red, new Point(0, 0));

                        if (flagsound == true)
                            g.DrawImage(Resource1.sound, 770, 100, 85, 85);
                        else
                            g.DrawImage(Resource1.mute, 770, 100, 85, 85);



                        if (Main.X > 720 && Main.X < 870 && Main.Y > 200 && Main.Y < 270)
                        {
                            g.DrawImage(Resource1.yellow_high_score, 720, 200, 150, 70);
                        }
                        else
                        {
                            g.DrawImage(Resource1.HighScoresButton, 720, 200, 150, 70);
                        }
                    
                    break;
                case 2:
                    gm.Draw(g);
                    break;

                case 3:
                    g.DrawImage(Resource1.message_24_help, 0, 0,640,800);
                    if (Main.X > 2 && Main.X < 27 && Main.Y > 2 && Main.Y < 27)
                    {
                        g.DrawImage(Resource1.back, 2, 2,35, 35);
                    }
                    else
                        g.DrawImage(Resource1.back, 2, 2, 30, 30);
                  
                    break;




                case 4:
                   
                    g.FillRectangle(Brushes.Gray, 0, 0, 640, 480);
                    g.DrawString(tp.GetFiveScores(),
                        new Font("algerian", 20),
                        Brushes.White,
                        new Point(100, 50));
                    if (Main.X > 2 && Main.X < 27 && Main.Y > 2 && Main.Y < 27)
                    {
                        g.DrawImage(Resource1.back, 2, 2, 35, 35);
                    }
                    else
                        g.DrawImage(Resource1.back, 2, 2, 30, 30);
                    
                    break;





                case 5 :
                    sit5 = !sit5;
                    if (sit5)
                    {
                        g.DrawImage(Resource1.GameOver, 0, 0,Game.screenX, Game.screenY);
                    }
                    else
                    {
                        g.DrawImage(Resource1.GameOver___Copy, 0, 0, Game.screenX, Game.screenY);
                    }
                    break;
            }
        }

    }
}
