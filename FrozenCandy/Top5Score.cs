using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FrozenCandy
{
    class Top5Score
    {

        string[] Top5PlayerName = new string[5];
        string[] Top5PlayerScore = new string[5];
        int highScore;
        string playersName;

        public Top5Score( string name )
        {
            this.playersName = name;
            loadScoreTable();
        }

        public void CheckForNewHighScore(int score)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Check to see if player's score has beaten any of the top 5 scores, prompt player for their name if so
            //------------------------------------------------------------------------------------------------------------------

            int i = 0;
            int j = 0;

            for (i = 0; i <= 4; i++)
            {
                if (score < Convert.ToInt32(Top5PlayerScore[i]))
                {
                    // Prompt player for their name

                    //if (frmNameEntry.ShowDialog() == Windows.Forms.DialogResult.OK)
                    //{
                    // Sort table
                    for (j = 4; j >= (i + 1); j += -1)
                    {
                        Top5PlayerName[j] = Top5PlayerName[j - 1];
                        Top5PlayerScore[j] = Top5PlayerScore[j - 1];
                    }

                    // Add new player
                    if (playersName == null)
                    {
                        playersName = "Anonymous";
                    }

                    Top5PlayerName[i] = playersName;
                    Top5PlayerScore[i] = score.ToString();

                    return;
                    //}
                }
            }
        }

        private void loadScoreTable()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Load saved high score from file, assign default values if no high scores exist
            //------------------------------------------------------------------------------------------------------------------

            string FILENAME = ("high scores.txt");

            // Get a StreamReader class that can be used to read the file  
            StreamReader objStreamReader = null;

            try
            {
                // Open file
                objStreamReader = File.OpenText(FILENAME);

                // Read player names & scores from file
                for (int i = 0; i <= 4; i++)
                {
                    Top5PlayerName[i] = objStreamReader.ReadLine();
                    Top5PlayerScore[i] = objStreamReader.ReadLine();
                }

                // Close the stream  
                objStreamReader.Close();
            }
            catch
            {
                // Load defaults, file dosen't exist 
                for (int i = 0; i <= 4; i++)
                {
                    Top5PlayerName[i] = "yamen";
                }

                for (int i = 0; i <= 4; i++)
                {
                    int j;
                    j = 500000 + (i * 10);
                    Top5PlayerScore[i] = (j.ToString());
                }

            }

            try
            {
                highScore = Convert.ToInt32(Top5PlayerScore[0]);
            }
            catch
            {
            }
        }

        public void SaveHighScores()
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Save high scores and player's names to disk
            //------------------------------------------------------------------------------------------------------------------

            string FILENAME = ("high scores.txt");

            // Get a StreamReader class that can be used to read the file  
            FileStream objFileStream = null;
            objFileStream = File.Create(FILENAME);

            System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
            string Str = null;
            byte[] buffer = null;
            int i = 0;

            try
            {
                // Write high scores to file
                for (i = 0; i <= 4; i++)
                {
                    Str = Top5PlayerName[i];
                    Str += Environment.NewLine;

                    buffer = new byte[Str.Length];
                    encoder.GetBytes(Str, 0, Str.Length, buffer, 0);
                    objFileStream.Write(buffer, 0, buffer.Length);

                    Str = Top5PlayerScore[i];
                    Str += Environment.NewLine;

                    buffer = new byte[Str.Length];
                    encoder.GetBytes(Str, 0, Str.Length, buffer, 0);
                    objFileStream.Write(buffer, 0, buffer.Length);

                }

                // Close the stream  
                objFileStream.Close();

            }
            catch
            {

            }
        }



        public string GetFiveScores()
        {
            string str = " \t Top Five Scores \t\n";

            for (int i = 0; i < 5; i++)
            {
                str += Top5PlayerName[i] + "\t" + Top5PlayerScore[i] + "\n";
                
            }
            return str;
        }
    }
}
