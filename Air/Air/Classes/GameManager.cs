using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    class GameManager
    {
        public DateTime updateFlag;
        public DateTime timeFlag;
        public bool checkTime = true;
        public float waitForSeconds = 4.5f;

        public string sceneName = "Shop";

        public bool update = false;
        public bool playing = false;
        public bool initialization = true;
        public static double score;

        public void init()
        {
            update = false;
            playing = false;
            initialization = true;
            score = 0;
        }

        public void gameOver(Player player, int msec)
        {
            player.isGrounded = player.location.Y > 720 - 150 ? true : false;

            if (player.isGrounded)
            {
                score = Math.Round(player.flightDistance, 0);
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
