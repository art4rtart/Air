using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    class GameManager
    {
        public TimeSpan playTime;

        public DateTime updateFlag;
        public DateTime timeFlag;
        public DateTime playTimeFlag;

        public bool checkTime = true;
        public float waitForSeconds = 4.5f;
        public string sceneName = "Logo";

        public bool update = false;
        public bool playing = false;
        public bool initialization = true;
        public static double score;
        public static double time;
        public static double maxVelocity;

        public static int scoreIndex = 0;

        public void init()
        {
            update = false;
            playing = false;
            initialization = true;
            score = 0;
            time = 0;
            maxVelocity = 0;
        }

        public void gameOver(Player player, int msec)
        {
            player.isGrounded = player.location.Y > 720 - 150 ? true : false;

            if (player.isGrounded)
            {
                score = Math.Round(player.flightDistance, 1);
                time = Math.Round(playTime.TotalSeconds, 2);
                maxVelocity = Math.Round((player.maxSpeed / 10), 0);

                player.gameStart = false;

                if (player.speed > 0)
                {
                    if (player.speed < 0)
                        player.speed = 0;

                    if (player.speed < player.minSpeed)
                    {
                        player.location.X += (int)player.speed;
                    }

                    player.speed -= ((player.airResistance) / 10) * msec;
                    if (player.speed < 0)
                        player.speed = 0;

                    player.airResistance += 0.1f;
                }

                else
                {
                    if (checkTime)
                    {
                        timeFlag = DateTime.Now;
                        checkTime = false;
                    }

                    TimeSpan currentTime = DateTime.Now - timeFlag;

                    if (currentTime.TotalSeconds > waitForSeconds)
                    {
                        playing = false;

                        if (scoreIndex < GameForm.scores.Length)
                        {
                            GameForm.scores[scoreIndex] = new Score(score, time, maxVelocity, scoreIndex);
                            GameForm.boardScore.Add(GameForm.scores[scoreIndex]);
                            scoreIndex++;
                        }

                        scoreForm scoreForm = new scoreForm();
                        scoreForm.StartPosition = FormStartPosition.Manual;
                        scoreForm.Location = new Point(1280 / 2 - (scoreForm.Size.Width / 10) - 55, ((720 / 2) - scoreForm.Size.Height / 3) - 45);
                        scoreForm.ShowDialog();    // this is modeless
                    }
                }
            }
        }
    }
}
