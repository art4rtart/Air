using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    public partial class scoreForm : Form
    {
        Text flyText = new Text();
        Text scoreText = new Text();
        Text commentText = new Text();

        double scoreValue = 0;         // start score
        double playerScore;

        public scoreForm()
        {
            InitializeComponent();
        }

        private void scoreForm_Load(object sender, EventArgs e)
        {
            playerScore = GameManager.score;

            flyText.init((this.Width / 2) - (youflight.Size.Width / 2), -15, youflight, new Font("Agency FB", 25, youflight.Font.Style)); // 5
            scoreText.init((this.Width / 2) - (distance.Size.Width / 2), 70, distance, new Font("Agency FB", 20, distance.Font.Style));  // 70
            commentText.init((this.Width / 2) - (comment.Size.Width / 2), 130, comment, new Font("Agency FB", 20, comment.Font.Style));


            retry.Location = new Point((this.Width / 2) - (retry.Size.Width / 2) - 60, 220);
            gotomenu.Location = new Point(retry.Location.X + 120, retry.Location.Y);

            scoreText.visible(false);
            commentText.visible(false);

            this.BackgroundImage = Air.Properties.Resources.scoreboard;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void scoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameForm gF = new GameForm();
        }

        private void timerFunction_Tick(object sender, EventArgs e)
        {
            // update
            flyText.update("you flight");
            scoreText.update(Math.Round(scoreValue,2) + " M");

            // animation
            if (youflight.Location.Y < 5)
                youflight.Top += 1;

            else
            {
                scoreText.visible(true);

                if (scoreValue < playerScore)
                    scoreValue += 0.01;                // add 1 point

                else
                {
                    commentText.visible(true);

                    if(playerScore < 5)
                        commentText.update("that means you fucked up :(");

                    else if (playerScore < 10 && playerScore > 5)
                        commentText.update("not bad, but you should practice more :P");

                    else if (playerScore < 15 && playerScore > 10)
                        commentText.update("nice, still not better than me :-)");

                    else
                        commentText.update("are you developer? your awesome :-D");
                }
            }
        }
    }
}


