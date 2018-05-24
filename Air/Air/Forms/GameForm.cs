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
        Player player = new Player(Air.Properties.Resources.plane, new Point(150, 200));
        Background title = new Background(Air.Properties.Resources.title, new Point(0, 0));
        Background sky = new Background(Air.Properties.Resources.sky, new Point(0, 0));
        Background rock = new Background(Air.Properties.Resources.rock, new Point(150, 390));
        Background field = new Background(Air.Properties.Resources.field, new Point(150, 520));
        Airtank airtank = new Airtank(Air.Properties.Resources.airgage, new Point(270, 675));
        Item pineWheel = new Item(Air.Properties.Resources.pinewheel, 3, 3.0f, new RectangleF(1280, 500, 70, 100), new RectangleF(0, 0, 350, 505), "PineWheel", 5.0f);
        Item star = new Item(Air.Properties.Resources.star, 1, 1.0f, new RectangleF(1280, 0, 150, 150), new RectangleF(0, 0, 150, 150), "Star", 1.0f);

        static Rectangle settingDest = new Rectangle(1200, 20, 54, 54);
        static RectangleF settingSrcDest = new RectangleF(0, 0, 132, 132);
        AnimUI setting = new AnimUI(Air.Properties.Resources.setting, 4, 1.0f, settingDest, settingSrcDest);

        // Text
        Text distanceText = new Text();
        Text velocityText = new Text();
        Text airPercentageText = new Text();
        Text presstostartText = new Text();

        // Button
        Button playgameButton = new Button();
        Button shopButton = new Button();
        Button boardButton = new Button();

        #region
        // time variables
        private DateTime updateFlag;
        private DateTime timeFlag;
        bool checkTime = true;
        float waitForSeconds = 1.5f;

        // framework variables
        private string sceneName = "Title";
        private string logoName = "daydream";

        // update variables
        bool gameUpdate = false;
        bool playing = false;

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
        bool drawGameName = false;
        bool gameMode = true;
        bool settingMode = false;
        SoundPlayer bgm = new SoundPlayer(Air.Properties.Resources.bgm);
        int goupspeed = 25;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // size settings
            this.ClientSize = new Size(1280, 720);
            canvas.ClientSize = new Size(1280, 720);

            // game time setting
            updateFlag = DateTime.Now;
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

        private void timerFunction_Tick(object sender, EventArgs e)
        {
            TimeSpan deltaTime = DateTime.Now - updateFlag;
            int msec = (int)(deltaTime.Milliseconds / 10);

            switch (sceneName)
            {
                case "Logo":
                    #region
                    {
                        if (initialization)
                        {
                            this.BackgroundImage = null;
                            logoName = null;

                            canvas.Image = Air.Properties.Resources.logo_kpu;

                            if (checkTime)
                            {
                                timeFlag = DateTime.Now;
                                checkTime = false;
                            }

                            TimeSpan currentTime = DateTime.Now - timeFlag;

                            if (currentTime.TotalSeconds > waitForSeconds)
                            {
                                initialization = false;
                                logoName = "daydream";
                                checkTime = true;
                                waitForSeconds = 6.3f;
                            }
                        }

                        else
                        {
                            opacity += (fadingSpeed * msec) * fadeDir;

                            if (opacity > 1)
                            {
                                opacity = 1;

                                if (checkTime)
                                {
                                    timeFlag = DateTime.Now;
                                    checkTime = false;
                                }

                                TimeSpan currentTime = DateTime.Now - timeFlag;

                                if (currentTime.TotalSeconds > waitForSeconds)
                                {
                                    fadeDir *= -1;
                                    checkTime = true;
                                }
                            }

                            else if (opacity < 0)
                            {
                                opacity = 0;

                                if (firstChanged && secondChanged) {
                                    logoName = "collaboration";
                                    firstChanged = false;
                                }

                                else if (secondChanged && !firstChanged) {
                                    logoName = "windowprogramming";
                                    secondChanged = false;
                                }

                                else
                                {
                                    sceneName = "Title";
                                    fadingSpeed = 0.1f;
                                    initialization = true;
                                    opacity = 0;
                                }

                                fadeDir *= -1;
                            }

                            if (logoName == "daydream")
                            {
                                canvas.Image = ChangeOpacity(Air.Properties.Resources.logo_daydream, opacity);
                            }

                            else if (logoName == "collaboration")
                            {
                                canvas.Image = ChangeOpacity(Air.Properties.Resources.logo_collaboration, opacity);
                            }

                            else if (logoName == "windowprogramming")
                            {
                                canvas.Image = ChangeOpacity(Air.Properties.Resources.logo_kpu, opacity); // windowprogramming
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
                            // parent settings
                            canvas.Parent = this;
                            clickToStart.Parent = canvas;

                            // time setting
                            waitForSeconds = 2.3f;
                            checkTime = true;

                            // UI location settings
                            clickToStart.Location = new Point((canvas.Width / 2 - clickToStart.Size.Width / 2), clickToStart.Location.Y);

                            // UI font settings
                            playgameButton.init(play, new Font("Agency FB", 20, playgameButton.Font.Style), canvas);
                            shopButton.init(shop, new Font("Agency FB", 20, shopButton.Font.Style), canvas);
                            boardButton.init(board, new Font("Agency FB", 20, boardButton.Font.Style), canvas);
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

                            if (checkTime && firstTime) // shit code
                            {
                                timeFlag = DateTime.Now;
                                checkTime = false;
                            }

                            if (firstTime)              // shit code
                            {
                                TimeSpan currentTime = DateTime.Now - timeFlag;

                                if (currentTime.TotalSeconds > waitForSeconds - 1)
                                {
                                    drawGameName = true;
                                }

                                if (currentTime.TotalSeconds > waitForSeconds)
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

                            // unvisible
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);

                            // time settings
                            checkTime = true;
                            waitForSeconds = 0;

                            // text init
                            distanceText.init((this.Width / 2) - (distanceValue.Size.Width / 2) + 10, 55, distanceValue, new Font("Agency FB", 20, distance.Font.Style), canvas);                // set this value
                            velocityText.init((this.Width / 2) - (velocity.Size.Width / 2), 628, velocity, new Font("Agency FB", 18, velocity.Font.Style), canvas);                   // set this value
                            airPercentageText.init(965, 625, airTankPercent, new Font("Agency FB", 20, airTankPercent.Font.Style), canvas);       // set this value

                            // visible game objects
                            distanceText.visible(true);
                            velocityText.visible(true);
                            airPercentageText.visible(true);

                            // visible static text UI
                            distance.Location = new Point((this.Width / 2) - (distance.Size.Width / 2) + 10, distance.Location.Y);
                            distance.Font = new Font("Agency FB", 17, distance.Font.Style);
                            distance.Parent = canvas;
                            distance.Visible = true;

                            initialization = false;
                        }


                        if (developerMode)
                        {
                            // this is developer mode
                        }

                        else
                        {
                            player.update(msec);

                            if (playing)                                    // "after throwing" code
                            {
                                if (gameUpdate)                             
                                {
                                    // properties
                                    player.airtankValue = airtank.value;
                                    player.airtankMin = airtank.minimum;
                                    airtank.isFlying = player.isFlying;

                                    // gameobject
                                    sky.update(player.speed / 15, msec);
                                    rock.update(player.speed / 10, msec);
                                    field.update(player.speed / 5, msec);

                                    pineWheel.update(player.speed / 5, msec);
                                    star.update(player.speed / 5, msec);

                                    airtank.update(msec);

                                    player.checkCollision(pineWheel.obj, pineWheel);
                                    player.checkCollision(star.obj, star);

                                    // speed update : UI
                                    if (player.speed > player.maxSpeed)
                                        player.speed -= 1;

                                    // item effects
                                    if (pineWheel.effect)
                                    {
                                        if (goupspeed > 0)
                                            player.location.Y -= goupspeed * msec;

                                        else
                                        {
                                            pineWheel.effect = false;
                                            goupspeed = 25;
                                        }

                                        goupspeed -= 1;
                                    }
                                }
                                gameOver();
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

            updateFlag = DateTime.Now;

            Invalidate();
        }

        // update methods
        #region
        private void gameOver()
        {
            player.isGrounded = player.location.Y > this.Height - 180 ? true : false;

            if (player.isGrounded)
            {
                score = player.flightDistance;
                player.gameStart = false;

                if (player.speed > 0)
                {
                    player.speed -= (int)((player.airResistance) / player.slidingValue);
                    player.location.X += player.speed;
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
                        scoreForm.Location = new Point(this.Width / 2 - (scoreForm.Size.Width / 10), ((this.Height / 2) - scoreForm.Size.Height / 3));
                        scoreForm.ShowDialog();    // this is modeless
                    }
                }
            }
        }
        #endregion

        // control methods
        #region
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameMode)
            {
                if (!playing && player.canPickUp)
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
            if (!playing && player.canPickUp && player.isPicked)
            {
                player.endPosition = new Point(player.location.X, player.location.Y);
                player.endTime = DateTime.Now;
                player.isPicked = false;
                player.isGrounded = false;
                player.speed = player.velocity();
                player.gameStart = true;
                gameUpdate = playing = true;
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
            if (sceneName == "Title" && !pressToStart)
            {
                pressToStart = true;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            sceneName = "InGame";
            initialization = true;
            opacity = 0;
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            sceneName = "Shop";
            initialization = true;
            opacity = 0;
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            sceneName = "Board";
            initialization = true;
            opacity = 0;
        }
        #endregion

        // developer mode methods
        #region
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && sceneName == "InGame")
            {
                player.maxSpeed += 10;
                player.speed += 10;
            }

            if (e.KeyCode == Keys.D && sceneName == "InGame")
                gameOver();

            if (e.KeyCode == Keys.P && sceneName == "InGame")
                timerFunction.Start();

            if (e.KeyCode == Keys.S && sceneName == "InGame")
                developerMode = false;

            if (e.KeyCode == Keys.M && sceneName == "InGame")
            {
                // please fix this dirty shit.
                timerFunction.Start();
                sceneName = "Title";
                opacity = 0.9f;
                firstTime = false;
                distance.Visible = false;
                distanceText.visible(false);
                velocityText.visible(false);
                airPercentageText.visible(false);
                initialization = true;
            }
        }
        #endregion

        // drawing methods
        #region
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (sceneName == "Title")
            {
                title.draw(e.Graphics);

                if (drawGameName)
                {
                    e.Graphics.DrawImage(gameName, ((canvas.Width / 2) - (gameName.Size.Width / 2) - gameNameOffset.X), 170 + gameNameOffset.Y, 128, 128);

                    if (gameNameOffset.Y + 170 > 110 && clickToStart.IsDisposed)
                        gameNameOffset.Y -= 5;
                }
            }

            else if (sceneName == "InGame")
            {
                sky.draw(e.Graphics);
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
    }
}

public class Text
{
    // member variables
    Label text = new Label();
    int x, y;

    // methods
    public void init(int x, int y, Label label, Font font, PictureBox canvas)
    {
        this.x = x; this.y = y;
        this.text = label;
        text.Font = font;
        text.Location = new Point(x, y);
        text.Parent = canvas;
    }


    public void update(string value)
    {
        text.Text = value;
    }

    public void visible(bool isVisible)
    {
        if (isVisible)
            text.Visible = true;

        else
            text.Visible = false;
    }
}

public class Button : Form
{
    // member variables
    private Label button = new Label();

    // methods
    public void init(Label button, Font font, PictureBox canvas)
    {
        this.button = button;
        button.Font = font;
        button.Parent = canvas;
    }

    public void update(Point MousePosition)
    {
        if (MousePosition.X > button.Location.X && MousePosition.X < button.Location.X + button.Size.Width)
        {
            if (MousePosition.Y > button.Location.Y && MousePosition.Y < button.Location.Y + button.Size.Height)
                button.ForeColor = Color.WhiteSmoke;
            else
                button.ForeColor = Color.DimGray;
        }
        else
            button.ForeColor = Color.DimGray;
    }

    public void visible(bool isVisible)
    {
        if (isVisible)
            button.Visible = true;
        else
            button.Visible = false;
    }
}