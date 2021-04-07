/*Kiril Covaliov
 ICS3U
 Space Race Summative*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Space_Race
{
    public partial class SpaceRace : Form
    {
        //Global variables
        string gameState = "waiting";

        List<int> meteorXList = new List<int>();
        List<int> meteorYList = new List<int>();
        List<int> meteorXRightList = new List<int>();
        List<int> meteorYRightList = new List<int>();
        List<int> meteorSpeedList = new List<int>();
        int meteorSize = 10;

        SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        SoundPlayer score = new SoundPlayer(Properties.Resources.score);
        SoundPlayer die = new SoundPlayer(Properties.Resources.die);

        int hero1X = 200;
        int hero1Y = 400;
        int hero2X = 600;
        int hero2Y = 400;
        int heroWidth = 15;
        int heroHeight = 15;
        int heroSpeed = 6;

        int leftPlayerScore = 0;
        int rightPlayerScore = 0;

        int finishLine = 6;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;
        public SpaceRace()
        {
            InitializeComponent();
        }
        public void GameInitialize()
        {
            winLabel.Text = "";
            subtitleLabel.Text = "";

            gameEngine.Enabled = true;
            gameState = "running";

            meteorXList.Clear();
            meteorYList.Clear();
            meteorSpeedList.Clear();

            hero1X = 200;
            hero1Y = 400;
            hero2X = 600;
            hero2Y = 400;
        }
        private void SpaceRace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }
        private void SpaceRace_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }
        }

        private void SpaceRace_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                winLabel.Text = "SPACE RACE";
                subtitleLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }

            else if (gameState == "running")
            {
                //hero 1
                e.Graphics.FillRectangle(whiteBrush, hero1X, hero1Y, heroWidth, heroHeight);
                //hero 2
                e.Graphics.FillRectangle(whiteBrush, hero2X, hero2Y, heroWidth, heroHeight);
                //meteors
                for (int i = 0; i < meteorXList.Count; i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, meteorXList[i], meteorYList[i], meteorSize, meteorSize);
                }

                for (int i = 0; i < meteorXRightList.Count; i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, meteorXRightList[i], meteorYRightList[i], meteorSize, meteorSize);
                }

                if (gameState == "over")
                {
                    winLabel.Text = "GAME OVER";
                    subtitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
                }
            }
        }
        private void GameEngine_Tick(object sender, EventArgs e)
        {
            //move hero 1
            if (wDown == true && hero1Y > 5)
            {
                hero1Y -= heroSpeed;
            }

            if (sDown == true && hero1Y < 370)
            {
                hero1Y += heroSpeed;
            }

            //move hero 2
            if (upArrowDown == true && hero2Y > 5)
            {
                hero2Y -= heroSpeed;
            }

            if (downArrowDown == true && hero2Y < 370)
            {
                hero2Y += heroSpeed;
            }

            //generating meteors
            //move meteors right
            randValue = randGen.Next(0, 15);
            if (randValue < 1)
            {
                meteorXList.Add(randGen.Next(-20, 10));
                meteorYList.Add(randGen.Next(0, 300));
                meteorSpeedList.Add(randGen.Next(2, 4));
            }

            for (int i = 0; i < meteorXList.Count(); i++)
            {
                meteorXList[i] += meteorSpeedList[i];
            }
            //move meteors left
            randValue = randGen.Next(0, 15);
            if (randValue < 1)
            {
                meteorXRightList.Add(randGen.Next(800, 830));
                meteorYRightList.Add(randGen.Next(0, 300));
                meteorSpeedList.Add(randGen.Next(2, 4));
            }

            for (int i = 0; i < meteorXRightList.Count(); i++)
            {
                meteorXRightList[i] -= meteorSpeedList[i];
            }

            //collision with finish line & hero points
            //hero 1 points
            if (hero1Y < finishLine)
            {
                hero1Y = 400;
                leftPlayerScore++;
                leftScore.Text = $"{leftPlayerScore}";
                score.Play();
            }

            if (leftPlayerScore == 3)
            {
                winLabel.Text = "Player One Wins!";
                gameEngine.Enabled = false;
                win.Play();
            }

            //hero 2 points  
            if (hero2Y < finishLine)
            {
                hero2Y = 400;
                rightPlayerScore++;
                rightScore.Text = $"{rightPlayerScore}";
                score.Play();
            }

            if (rightPlayerScore == 3)
            {
                winLabel.Text = "Player Two Wins!";
                gameEngine.Enabled = false;
                win.Play();
            }

            //collision with meteors
            Rectangle hero1Rec = new Rectangle(hero1X, hero1Y, heroWidth, heroHeight);
            Rectangle hero2Rec = new Rectangle(hero2X, hero2Y, heroWidth, heroHeight);

            for (int i = 0; i < meteorXList.Count(); i++)
            {
                Rectangle meteorLeftRec = new Rectangle(meteorXList[i], meteorYList[i], heroWidth, heroHeight);

                if (hero1Rec.IntersectsWith(meteorLeftRec))
                {
                    hero1Y = 400;
                    die.Play();
                }

                if (hero2Rec.IntersectsWith(meteorLeftRec))
                {
                    hero2Y = 400;
                    die.Play();
                }
            }

            for (int i = 0; i < meteorXRightList.Count(); i++)
            {
                Rectangle meteorRightRec = new Rectangle(meteorXRightList[i], meteorYRightList[i], heroWidth, heroHeight);

                if (hero1Rec.IntersectsWith(meteorRightRec))
                {
                    hero1Y = 400;
                    die.Play();
                }

                if (hero2Rec.IntersectsWith(meteorRightRec))
                {
                    hero2Y = 400;
                    die.Play();
                }
            }

            Refresh();
        }
    }
}
