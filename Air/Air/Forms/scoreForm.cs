using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Air
{
    public partial class scoreForm : Form
    {
        Icon replayAnimation = new Icon(Air.Properties.Resources.animation_replay, 6, 1.0f, new Rectangle(0, 0, 65, 65), new RectangleF(0, 0, 300, 300));
        Icon goBackIcon = new Icon(Air.Properties.Resources.icon_back, 1, 1.0f, new Rectangle(300, 214, 35, 35), new RectangleF(0, 0, 64, 64));

        Text flyText = new Text();
        Text scoreText = new Text();
        Text commentText = new Text();

        double scoreValue = 0;         // start score
        double playerScore;

        bool isVisible;

        public scoreForm()
        {
            InitializeComponent();
        }

        private void scoreForm_Load(object sender, EventArgs e)
        {
            isVisible = false;
            playerScore = GameManager.score;

            flyText.init((this.Width / 2) - (youflight.Size.Width / 2), -15, youflight, new Font("Agency FB", 25, youflight.Font.Style)); // 5
            scoreText.init((this.Width / 2) - (distance.Size.Width / 2), 70, distance, new Font("Agency FB", 20, distance.Font.Style));  // 70
            commentText.init((this.Width / 2) - (comment.Size.Width / 2), 120, comment, new Font("Agency FB", 20, comment.Font.Style));

            scoreText.visible(false);
            commentText.visible(false);

            replayAnimation.position(170, 200);
            goBackIcon.colorImage = Air.Properties.Resources.icon_cback;

            clickToReplay.Location = new Point(119, 245);
            clickToReplay.Font = new Font("Agency FB", 13, comment.Font.Style);

            back.Font = new Font("Agency FB", 13, back.Font.Style);
            back.Location = new Point(267, 245);

            this.BackgroundImage = Air.Properties.Resources.background_scoreboard;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void scoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameForm.scoreBoardClosed = true;
        }

        private void timerFunction_Tick(object sender, EventArgs e)
        {
            // update
            flyText.update("you flight");
            scoreText.update(scoreValue + " M");
            replayAnimation.updateFrame(2);
            clickToReplay.Visible = back.Visible = isVisible;

            // animation
            if (youflight.Location.Y < 5)
                youflight.Top += 1;

            else
            {
                scoreText.visible(true);

                if (scoreValue < playerScore)
                {
                    scoreValue += 1;

                    for(int i = 1; i < 10; i++)
                    {
                        if (playerScore - scoreValue > 10 * i)
                            scoreValue += 5 * i;
                    }
                }

                else
                {
                    commentText.visible(true);
                    isVisible = true;

                    if (playerScore < 100)
                        commentText.update("you screwed up :(");

                    else if (playerScore < 1000 && playerScore > 100)
                        commentText.update("not bad, but you should practice more :P");

                    else if (playerScore < 2000 && playerScore > 1000)
                        commentText.update("nice, still not better than me :-)");

                    else
                        commentText.update("are you developer? your awesome :-D");
                }
            }

            Invalidate();
        }

        private void scoreForm_Paint(object sender, PaintEventArgs e)
        {
            if (isVisible)
            {
                replayAnimation.draw(e.Graphics);
                goBackIcon.draw(e.Graphics);
            }
        }

        private void scoreForm_Click(object sender, EventArgs e)
        {
            if (isVisible)
            {
                GameForm.scoreBoardClosed = true;
                Close();
            }

            if (goBackIcon.active is true)
            {
                GameForm.goBackToTitle = true;
                Close();
            }
        }

        private void scoreForm_MouseMove(object sender, MouseEventArgs e)
        {
            goBackIcon.handleMouseMoveEvent(e.Location);
        }
    }
}


