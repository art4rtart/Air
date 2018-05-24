﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Media;
using System.Drawing.Drawing2D;

namespace Air
{
    public partial class GameForm : Form
    {
        // GameObject
        #region
        GameManager gameManager = new GameManager();

        Player player = new Player(Air.Properties.Resources.plane, new Point(150, 200));

        Background title = new Background(Air.Properties.Resources.title, new Point(0, 0));
        Background sky = new Background(Air.Properties.Resources.sky, new Point(0, 0));
        Background ss = new Background(Air.Properties.Resources.atmosphere, new Point(0, -720));
        Background space = new Background(Air.Properties.Resources.space, new Point(0, -1440));
        Background rock = new Background(Air.Properties.Resources.rock, new Point(150, 390));
        Background field = new Background(Air.Properties.Resources.field, new Point(150, 520));

        Airtank airtank = new Airtank(Air.Properties.Resources.airgage, new Point(270, 675));

        Item pineWheel = new Item(Air.Properties.Resources.pinewheel, 3, 3.0f, new RectangleF(1280, 500, 70, 100), new RectangleF(0, 0, 350, 505), "PineWheel", 5.0f);
        Item star = new Item(Air.Properties.Resources.star, 1, 1.0f, new RectangleF(1280, 0, 150, 150), new RectangleF(0, 0, 150, 150), "Star", 1.0f);

        Text distanceText = new Text();
        Text velocityText = new Text();
        Text airPercentageText = new Text();
        Text presstostartText = new Text();

        Button playgameButton = new Button();
        Button shopButton = new Button();
        Button boardButton = new Button();

        AnimUI setting = new AnimUI(Air.Properties.Resources.setting, 4, 1.0f, new Rectangle(1200, 20, 54, 54), new RectangleF(0, 0, 132, 132));

        List<Background> backgrounds = new List<Background>();
        #endregion

        // variables
        #region
        // opacity variables
        private float fadingSpeed = 0.1f;
        private float fadeDir = 1;
        private float opacity = 0;

        // etc
        bool firstChanged = true;
        bool secondChanged = true;
        bool initialization = true;
        bool pressToStart = false;
        bool firstTime = true;                 // shit value

        // static variables
        public static double score;
        public static bool developerMode = false;      // change it to false when playing
        #endregion

        // recent added variables
        Bitmap titleImage;
        Bitmap gameName;
        Point gameNameOffset = new Point(3, 0);
        bool showGameName = false;
        bool gameMode = true;
        bool settingMode = false;
        SoundPlayer bgm = new SoundPlayer(Air.Properties.Resources.bgm);
        int goupspeed = 0;
        bool setGoUpSpeed = true;
        bool goUp;
        bool isGoingUp;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // size settings
            this.ClientSize = new Size(1280, 720);

            // game time setting
            gameManager.updateFlag = DateTime.Now;
            timerFunction_Tick(sender, e);
            timerFunction.Interval = 10;
            timerFunction.Start();

            // start position setting
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(220, 70);

            // double buffering
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            // resource load
            titleImage = Air.Properties.Resources.title;
            gameName = Air.Properties.Resources.gameName;

            // bgm play
            if (firstTime)
                bgm.Play();
        }

        // update
        #region
        private void timerFunction_Tick(object sender, EventArgs e)
        {
            TimeSpan deltaTime = DateTime.Now - gameManager.updateFlag;
            int msec = (int)(deltaTime.Milliseconds / 10);

            switch (gameManager.sceneName)
            {
                case "Logo":
                    #region
                    {
                        if (initialization)
                        {
                            this.BackgroundImage = null;
                            gameManager.logoName = null;

                            this.BackgroundImage = Air.Properties.Resources.logo_kpu;

                            if (gameManager.checkTime)
                            {
                                gameManager.timeFlag = DateTime.Now;
                                gameManager.checkTime = false;
                            }

                            TimeSpan currentTime = DateTime.Now - gameManager.timeFlag;

                            if (currentTime.TotalSeconds > gameManager.waitForSeconds)
                            {
                                initialization = false;
                                gameManager.logoName = "daydream";
                                gameManager.checkTime = true;
                                gameManager.waitForSeconds = 6.3f;
                            }
                        }

                        else
                        {
                            opacity += (fadingSpeed * msec) * fadeDir;

                            if (opacity > 1)
                            {
                                opacity = 1;

                                if (gameManager.checkTime)
                                {
                                    gameManager.timeFlag = DateTime.Now;
                                    gameManager.checkTime = false;
                                }

                                TimeSpan currentTime = DateTime.Now - gameManager.timeFlag;

                                if (currentTime.TotalSeconds > gameManager.waitForSeconds)
                                {
                                    fadeDir *= -1;
                                    gameManager.checkTime = true;
                                }
                            }

                            else if (opacity < 0)
                            {
                                opacity = 0;

                                if (firstChanged && secondChanged) {
                                    gameManager.logoName = "collaboration";
                                    firstChanged = false;
                                }

                                else if (secondChanged && !firstChanged) {
                                    gameManager.logoName = "windowprogramming";
                                    secondChanged = false;
                                }

                                else
                                {
                                    gameManager.sceneName = "Title";
                                    fadingSpeed = 0.1f;
                                    initialization = true;
                                    opacity = 0;
                                }

                                fadeDir *= -1;
                            }

                            if (gameManager.logoName == "daydream")
                            {
                                this.BackgroundImage = ChangeOpacity(Air.Properties.Resources.logo_daydream, opacity);
                            }

                            else if (gameManager.logoName == "collaboration")
                            {
                                this.BackgroundImage = ChangeOpacity(Air.Properties.Resources.logo_collaboration, opacity);
                            }

                            else if (gameManager.logoName == "windowprogramming")
                            {
                                this.BackgroundImage = ChangeOpacity(Air.Properties.Resources.logo_kpu, opacity); // windowprogramming
                            }
                        }
                    }
                    break;
                    #endregion

                case "Title":
                    #region
                    {

                        if (initialization)
                        {
                            // time setting
                            gameManager.waitForSeconds = 2.3f;
                            gameManager.checkTime = true;

                            // UI location settings
                            clickToStart.Location = new Point((this.Width / 2 - clickToStart.Size.Width / 2), clickToStart.Location.Y);

                            // UI font settings
                            playgameButton.init(play, new Font("Agency FB", 20, play.Font.Style));
                            shopButton.init(shop, new Font("Agency FB", 20, shop.Font.Style));
                            boardButton.init(board, new Font("Agency FB", 20, board.Font.Style));
                            clickToStart.Font = new Font("Agency FB", 15, clickToStart.Font.Style);

                            // UI visible settings
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);

                            initialization = false;
                        }

                        if (opacity < 1)
                        {
                            opacity += fadingSpeed * msec * fadeDir;
                        }

                        else
                        {
                            opacity = 1;

                            if (gameManager.checkTime && firstTime) // shit code
                            {
                                gameManager.timeFlag = DateTime.Now;
                                gameManager.checkTime = false;
                            }

                            if (firstTime)              // shit code
                            {
                                TimeSpan currentTime = DateTime.Now - gameManager.timeFlag;

                                if (currentTime.TotalSeconds > gameManager.waitForSeconds - 1)
                                {
                                    showGameName = true;
                                }

                                if (currentTime.TotalSeconds > gameManager.waitForSeconds)
                                {
                                    if (!clickToStart.IsDisposed)
                                        clickToStart.Visible = true;
                                }
                            }

                            else
                            {
                                playgameButton.visible(true);
                                shopButton.visible(true);
                                boardButton.visible(true);
                            }
                        }

                        if (pressToStart && firstTime)
                        {
                            clickToStart.Dispose();

                            if (gameNameOffset.Y + 170 <= 110)
                            {
                                playgameButton.visible(true);
                                shopButton.visible(true);
                                boardButton.visible(true);
                            }
                        }

                        playgameButton.update(PointToClient(MousePosition));
                        shopButton.update(PointToClient(MousePosition));
                        boardButton.update(PointToClient(MousePosition));
                        title.update(1, msec);
                    }
                    break;
                    #endregion

                case "InGame":
                    #region
                    {
                        // initialization
                        if (initialization)
                        {
                            player.slidingVelocity = Math.Round((double)(new Random().NextDouble() * (2.0 - 1.0) + 1.0), 1);

                            // unvisible game objects
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);

                            // text init
                            distanceText.init((this.Width / 2) - (distanceValue.Size.Width / 2) + 10, 55, distanceValue, new Font("Agency FB", 20, distance.Font.Style));                // set this value
                            velocityText.init((this.Width / 2) - (velocity.Size.Width / 2), 628, velocity, new Font("Agency FB", 18, velocity.Font.Style));                   // set this value
                            airPercentageText.init(965, 625, airTankPercent, new Font("Agency FB", 20, airTankPercent.Font.Style));       // set this value
                            
                            // visible game objects
                            distanceText.visible(true);
                            velocityText.visible(true);
                            airPercentageText.visible(true);

                            // time settings
                            gameManager.checkTime = true;
                            gameManager.waitForSeconds = 0;

                            // visible static text UI
                            distance.Location = new Point((this.Width / 2) - (distance.Size.Width / 2) + 10, distance.Location.Y);
                            distance.Font = new Font("Agency FB", 17, distance.Font.Style);
                            distance.Parent = this;
                            distance.Visible = true;

                            backgrounds.Add(sky);
                            backgrounds.Add(ss);
                            backgrounds.Add(space);
                            backgrounds.Add(rock);
                            backgrounds.Add(field);

                            initialization = false;
                        }


                        if (developerMode)
                        {
                            // this is developer mode
                        }

                        else
                        {
                            player.update(msec);
;
                            label1.Text = goupspeed.ToString();
                            if (gameManager.playing)                                    // "after throwing" code
                            {
                                if (gameManager.update)
                                {
                                    // properties
                                    player.airtankValue = airtank.value;
                                    player.airtankMin = airtank.minimum;
                                    airtank.isFlying = player.isFlying;
                                    pineWheel.generatePositionY = field.location.Y;

                                    sky.update(player.speed / 15, msec);
                                    ss.update(player.speed / 15, msec);
                                    space.update(player.speed / 15, msec);
                                    rock.update(player.speed / 10, msec);
                                    field.update(player.speed / 5, msec);
                                    pineWheel.update(player.speed / 5, msec);
                                    star.update(player.speed / 5, msec);
                                    airtank.update(msec);

                                    player.checkCollision(pineWheel.obj, pineWheel);
                                    player.checkCollision(star.obj, star);

                                    // please update this code
                                    if (player.location.Y < 150)
                                    {
                                        if(!isGoingUp)
                                            player.location.Y = 150;

                                        goUp = true;

                                        if (space.location.Y < 0)
                                        {
                                            foreach (Background background in backgrounds)
                                                background.location.Y += (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed;

                                            foreach (AnimObject pineWheel in pineWheel.obj)
                                                pineWheel.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                            foreach (AnimObject star in star.obj)
                                                star.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);
                                        }
                                    }

                                    else
                                    {
                                        isGoingUp = false;
                                        foreach (Background background in backgrounds)
                                        {
                                            background.location.Y -= (int)((player.gravity) * msec);

                                            if (background.location.Y > background.y)
                                            {
                                                player.location.Y = 150;
                                            }

                                            else
                                            {
                                                background.location.Y = background.y;
                                                goUp = false;
                                            }
                                        }

                                        if (goUp)
                                        {
                                            foreach (AnimObject pineWheel in pineWheel.obj)
                                                pineWheel.move(0, -(int)((player.gravity) * msec));

                                            foreach (AnimObject star in star.obj)
                                                star.move(0, -(int)((player.gravity) * msec));
                                        }
                                    }

                                    // speed update : UI
                                    if (player.speed > player.maxSpeed)
                                        player.speed -= 1;

                                    // item effects
                                    if (pineWheel.effect)
                                    {
                                        isGoingUp = true;
                                        if (setGoUpSpeed)
                                        {
                                            goupspeed = 23;
                                            setGoUpSpeed = false;
                                        }

                                        goupspeed -= 1;

                                        if (goupspeed > 0)
                                            player.location.Y -= goupspeed * msec;

                                        else
                                        {
                                            pineWheel.effect = false;
                                            goupspeed = 0;
                                            setGoUpSpeed = true;
                                        }
                                    }
                                }

                                if (sky.location.Y == 0)
                                    gameManager.gameOver(player);

                                // here
                            }

                            else
                            {
                                player.pickUp(PointToClient(MousePosition));
                            }

                            // UI update
                            distanceText.update(Math.Round(player.flightDistance, 2).ToString() + " M");
                            velocityText.update(player.speed.ToString() + " M/S");
                            airPercentageText.update(Math.Round((double)(airtank.value / airtank.maximum) * 100, 0).ToString() + " %");

                            if (PointToClient(MousePosition).X > 1200 && PointToClient(MousePosition).X < 1255 && PointToClient(MousePosition).Y > 20 && PointToClient(MousePosition).Y < 70)
                            {
                                setting.updateFrame(msec);
                                gameMode = false;
                                settingMode = true;
                            }

                            else
                            {
                                gameMode = true;
                                settingMode = false;
                            }
                        }
                    }
                    break;
                    #endregion
            }

            gameManager.updateFlag = DateTime.Now;
            Invalidate();
        }
        #endregion

        // draw
        #region
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (gameManager.sceneName == "Title")
            {
                title.draw(e.Graphics);

                if (showGameName)
                {
                    e.Graphics.DrawImage(gameName, ((this.Width / 2) - (gameName.Size.Width / 2) - gameNameOffset.X), 170 + gameNameOffset.Y, 128, 128);

                    if (gameNameOffset.Y + 170 > 110 && clickToStart.IsDisposed)
                        gameNameOffset.Y -= 5;
                }
            }

            else if (gameManager.sceneName == "InGame")
            {
                sky.draw(e.Graphics);
                ss.draw(e.Graphics);
                space.draw(e.Graphics);
                rock.draw(e.Graphics);
                field.draw(e.Graphics);
                airtank.draw(e.Graphics);

                pineWheel.draw(e.Graphics);
                star.draw(e.Graphics);

                player.draw(e.Graphics);

                setting.draw(e.Graphics);
            }
        }

        public Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
            return bmp;
        }
        #endregion

        // control methods
        #region
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameMode)
            {
                if (!gameManager.playing && player.canPickUp)
                {
                    if (PointToClient(MousePosition).X > player.location.X && PointToClient(MousePosition).X < player.location.X + 100
                        && PointToClient(MousePosition).Y > player.location.Y && PointToClient(MousePosition).Y < player.location.Y + 50)
                        player.isPicked = true;
                    else
                        player.isPicked = false;

                    player.startPosition = new Point(player.location.X, player.location.Y);
                    player.startTime = DateTime.Now;
                }

                else
                {
                    player.isFlying = true;
                }
            }

            else if (settingMode)
            {
                {
                    developerMode = true;
                    SettingForm settingForm = new SettingForm();

                    settingForm.StartPosition = FormStartPosition.Manual;
                    settingForm.Location = new Point(this.Width / 2 - (settingForm.Size.Width / 10), ((this.Height / 2) - settingForm.Size.Height / 3));
                    settingForm.ShowDialog();    // this is modeless
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!gameManager.playing && player.canPickUp && player.isPicked)
            {
                player.endPosition = new Point(player.location.X, player.location.Y);
                player.endTime = DateTime.Now;
                player.isPicked = false;
                player.isGrounded = false;
                player.speed = player.velocity();
                player.gameStart = true;
                gameManager.update = gameManager.playing = true;
            }

            else
            {
                player.isFlying = false;
            }
        }
        #endregion

        // menu change methods
        #region
        private void canvas_Click(object sender, EventArgs e)
        {
            if (gameManager.sceneName == "Title" && !pressToStart)
            {
                pressToStart = true;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            gameManager.sceneName = "InGame";
            initialization = true;
            opacity = 0;
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            gameManager.sceneName = "Shop";
            initialization = true;
            opacity = 0;
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            gameManager.sceneName = "Board";
            initialization = true;
            opacity = 0;
        }
        #endregion

        // developer mode methods
        #region
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && gameManager.sceneName == "InGame")
            {
                player.maxSpeed += 10;
                player.speed += 10;
            }

            if (e.KeyCode == Keys.D && gameManager.sceneName == "InGame")
                gameManager.gameOver(player);

            if (e.KeyCode == Keys.P && gameManager.sceneName == "InGame")
                timerFunction.Start();

            if (e.KeyCode == Keys.S && gameManager.sceneName == "InGame")
                developerMode = false;

            if (e.KeyCode == Keys.M && gameManager.sceneName == "InGame")
            {
                // please fix this dirty shit.
                timerFunction.Start();
                gameManager.sceneName = "Title";
                opacity = 0.9f;
                firstTime = false;
                distance.Visible = false;
                distanceText.visible(false);
                velocityText.visible(false);
                airPercentageText.visible(false);
                initialization = true;
            }

            if (e.KeyCode == Keys.T && gameManager.sceneName == "InGame")
            {
                foreach (Background obj in backgrounds)
                    obj.location.Y += 10;
            }
        }
        #endregion
    }
}