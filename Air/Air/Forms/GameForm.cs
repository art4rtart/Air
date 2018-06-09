using System;
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

        List<Background> backgrounds = new List<Background>();
        Background title = new Background(Air.Properties.Resources.background_title, new Point(0, 0));
        Background sky = new Background(Air.Properties.Resources.background_sky, new Point(0, 0));
        Background ss = new Background(Air.Properties.Resources.background_atmosphere, new Point(0, -720));
        Background space = new Background(Air.Properties.Resources.background_space, new Point(0, -1440));
        Background rock = new Background(Air.Properties.Resources.background_rock, new Point(150, 390));
        Background field = new Background(Air.Properties.Resources.background_field, new Point(150, 520));
        Background cloud = new Background(Air.Properties.Resources.background_shop, new Point(0, 0));
        Background paper = new Background(Air.Properties.Resources.background_paper, new Point(0, 0));

        Airtank airtank = new Airtank(Air.Properties.Resources.airtank_gage, new Point(270, 675));

        Item pineWheel = new Item(Air.Properties.Resources.item_pinewheel, 3, 3.0f, new RectangleF(1280, 500, 70, 100), new RectangleF(0, 0, 350, 505), "PineWheel", 5.0f);
        Item star = new Item(Air.Properties.Resources.item_star, 1, 1.0f, new RectangleF(1280, 0, 150, 150), new RectangleF(0, 0, 150, 150), "Star", 1.0f);
        Item airup = new Item(Air.Properties.Resources.item_airup, 1, 1.0f, new RectangleF(1280, 0, 50, 75), new RectangleF(0, 0, 50, 75), "AirUp", 3.0f);
        Item airdown = new Item(Air.Properties.Resources.item_airdown, 1, 1.0f, new RectangleF(1280, 0, 50, 75), new RectangleF(0, 0, 50, 75), "AirDown", 3.0f);

        GameObject kpu = new GameObject(Air.Properties.Resources.logo_kputext);
        GameObject frame = new GameObject(Air.Properties.Resources.object_frame);

        List<GameObject> itemFrames = new List<GameObject>();
        GameObject[] itemFrame = new GameObject[6];

        GameObject name = new GameObject(Air.Properties.Resources.gameName);
        GameObject plane = new GameObject(Air.Properties.Resources.plane);
        GameObject starIcon = new GameObject(Air.Properties.Resources.item_star);

        Text distanceText = new Text();
        Text velocityText = new Text();
        Text airPercentageText = new Text();
        Text starCountText = new Text();
        Text presstostartText = new Text();

        Text itemNameText = new Text();
        Text purchaseText = new Text();
        Text currentValueText = new Text();
        Text upgradeValueText = new Text();
        Text arrowText = new Text();

        Button playgameButton = new Button();
        Button shopButton = new Button();
        Button boardButton = new Button();

        Icon settingIcon = new Icon(Air.Properties.Resources.icon_setting, 4, 1.0f, new Rectangle(1200, 20, 54, 54), new RectangleF(0, 0, 132, 132));
        Icon arrowIcon = new Icon(Air.Properties.Resources.icon_arrow, 1, 1.0f, new Rectangle(0, 0, 30, 30), new RectangleF(0, 0, 60, 60));
        Icon goBackIcon = new Icon(Air.Properties.Resources.icon_back, 1, 1.0f, new Rectangle(1200, 20, 45, 45), new RectangleF(0, 0, 64, 64));
        Icon checkedIcon = new Icon(Air.Properties.Resources.icon_check, 1, 1.0f, new Rectangle(0, 0, 45, 45), new RectangleF(0, 0, 64, 64));

        Icon starAnimation = new Icon(Air.Properties.Resources.animation_star, 6, 1.0f, new Rectangle(0, 0, 100, 100), new RectangleF(0, 0, 300, 300));
        Icon pumpAnimation = new Icon(Air.Properties.Resources.animation_pump, 6, 1.0f, new Rectangle(0, 0, 200, 200), new RectangleF(0, 0, 300, 300));

        public static Settings settings = new Settings();

        #endregion

        // variables
        #region
        // opacity variables
        private float fadingSpeed = 0.01f;
        private float fadeDir = 1;
        private float opacity = 1;

        // etc
        bool pressToStart = false;
        bool firstTime = true;                 // shit value

        // static variables
        public static double score;
        public static bool developerMode = false;      // change it to false when playing
        #endregion

        // recent added variables
        Bitmap[] logoImage = new Bitmap[4];
        int logoImageIndex;
        //Bitmap arrow = Air.Properties.Resources.icon_arrow;
        //Bitmap cost = Air.Properties.Resources.item_star;

        Point gameNameOffset = new Point(3, 0);
        bool showGameName = false;
        bool gameMode = true;
        bool settingMode = false;
        SoundPlayer bgm = new SoundPlayer(Air.Properties.Resources.sound_bgm);
        int goupspeed = 0;
        bool setGoUpSpeed = true;
        bool goUp = false;
        bool isGoingUp = false;
        bool goingDown = false;
        bool heightTrim = false;
        bool throwPlane = true;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, 30);
            this.ClientSize = new Size(1280, 720);
            gameManager.updateFlag = DateTime.Now;
            name.position((this.Width / 2) - (name.size.Width / 2) - 3, 180);
            kpu.position((this.Width / 2) - (kpu.size.Width / 2) - 5, 670);
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
                        if (gameManager.initialization)
                        {
                            logoImage[0] = Air.Properties.Resources.logo_kpu;
                            logoImage[1] = Air.Properties.Resources.logo_window;
                            logoImage[2] = Air.Properties.Resources.logo_polymorphism;
                            gameManager.initialization = false;
                        }

                        this.BackgroundImage = ChangeOpacity(logoImage[logoImageIndex], opacity);

                        if (gameManager.checkTime)
                        {
                            gameManager.timeFlag = DateTime.Now;
                            gameManager.checkTime = false;
                        }

                        TimeSpan currentTime = DateTime.Now - gameManager.timeFlag;

                        if (currentTime.TotalSeconds > gameManager.waitForSeconds)
                        {
                            opacity -= fadingSpeed * fadeDir * msec;

                            if (opacity < 0)
                            {
                                if (logoImageIndex < logoImage.Length - 1)
                                    logoImageIndex++;
                                fadeDir *= -1;
                            }

                            else if (opacity > 1)
                            {
                                gameManager.checkTime = true;
                                fadeDir *= -1;
                                opacity = 1;
                            }

                            if (logoImageIndex == 3)
                            {
                                this.BackgroundImage = null;
                                gameManager.sceneName = "Title";
                                gameManager.initialization = true;
                            }
                        }

                        break;
                    }
                #endregion

                case "Title":
                    #region
                    {
                        if (gameManager.initialization)
                        {
                            // time setting
                            gameManager.waitForSeconds = 2.8f;
                            gameManager.checkTime = true;

                            // UI location settings
                            clickToStart.Location = new Point((this.Width / 2 - clickToStart.Size.Width / 2) - 4, clickToStart.Location.Y + 150);

                            // UI font settings
                            playgameButton.init(play, new Point(595, 300), Color.DimGray, Color.WhiteSmoke, new Font("Agency FB", 20, play.Font.Style));
                            shopButton.init(shop, new Point(615, 380), Color.DimGray, Color.WhiteSmoke, new Font("Agency FB", 20, shop.Font.Style));
                            boardButton.init(board, new Point(611, 460), Color.DimGray, Color.WhiteSmoke, new Font("Agency FB", 20, board.Font.Style));
                            clickToStart.Font = new Font("Agency FB", 15, clickToStart.Font.Style);

                            // UI visible settings
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);
                            multiple.Visible = false;
                            shopFrame.Visible = false;

                            itemNameText.visible(false);
                            purchaseText.visible(false);
                            purchaseText.visible(false);
                            currentValueText.visible(false);
                            upgradeValueText.visible(false);
                            to.Visible = false;

                            distance.Visible = false;
                            starCount.Visible = false;
                            distanceText.visible(false);

                            velocityText.visible(false);
                            airPercentageText.visible(false);

                            if (firstTime)
                                bgm.Play();

                            gameManager.initialization = false;
                        }

                        if (gameManager.checkTime && firstTime)
                        {
                            gameManager.timeFlag = DateTime.Now;
                            gameManager.checkTime = false;
                        }

                        if (firstTime)
                        {
                            TimeSpan currentTime = DateTime.Now - gameManager.timeFlag;

                            if (currentTime.TotalSeconds > gameManager.waitForSeconds - 1)
                            {
                                showGameName = true;
                            }

                            if (currentTime.TotalSeconds > gameManager.waitForSeconds + 0.7)
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

                        if (pressToStart && firstTime)
                        {
                            clickToStart.Dispose();

                            if (name.bounds.Y <= 110)
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
                        if (gameManager.initialization)
                        {
                            bgm.Stop();

                            // unvisible menus
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);

                            player.slidingVelocity = Math.Round((double)(new Random().NextDouble() * (2.0 - 1.0) + 1.0), 1);
                            player.position(150, 200);

                            // text init
                            starCountText.init(-21, 11, starCount, new Font("Agency FB", 15, starCount.Font.Style));                // set this value
                            distanceText.init((this.Width / 2) - (distanceValue.Size.Width / 2) - 7, 57, distanceValue, new Font("Agency FB", 20, distance.Font.Style));                // set this value
                            velocityText.init((this.Width / 2) - (velocity.Size.Width / 2), 628, velocity, new Font("Agency FB", 18, velocity.Font.Style));                   // set this value
                            airPercentageText.init(965, 625, airTankPercent, new Font("Agency FB", 20, airTankPercent.Font.Style));       // set this value

                            starIcon.position(30, 20);
                            starCount.ForeColor = Color.DimGray;

                            // visible game objects
                            starCountText.visible(true);
                            distanceText.visible(true);
                            velocityText.visible(true);
                            airPercentageText.visible(true);

                            // time settings
                            gameManager.checkTime = true;
                            gameManager.waitForSeconds = 0.3f;

                            // visible static text UI
                            distance.Location = new Point((this.Width / 2) - (distance.Size.Width / 2) - 7, 22);
                            distance.Font = new Font("Agency FB", 17, distance.Font.Style);
                            distance.Parent = this;
                            distance.Visible = true;

                            backgrounds.Add(sky);
                            backgrounds.Add(ss);
                            backgrounds.Add(space);
                            backgrounds.Add(rock);
                            backgrounds.Add(field);

                            player.gravity = 0;
                            settings.soundValue = 7;

                            gameManager.initialization = false;
                        }

                        else
                        {
                            if (developerMode)
                            {
                                // this is developer mode
                            }

                            else
                            {
                                player.update(msec);

                                if (gameManager.playing)
                                {
                                    if (gameManager.update)
                                    {
                                        player.airtankValue = airtank.value;
                                        airtank.value = player.airtankValue;
                                        player.airtankMin = airtank.minimum;
                                        airtank.isFlying = player.isFlying;

                                        pineWheel.generatePositionY = field.location.Y;
                                        star.generatePositionY = field.location.Y;
                                        star.setGenerateTime = 0.1f;
                                        airup.generatePositionY = field.location.Y;
                                        airup.generatePositionY = field.location.Y;

                                        pineWheel.update((int)player.speed / 8, msec);
                                        star.update((int)player.speed / 8, msec);
                                        airup.update((int)player.speed / 8, msec);
                                        airdown.update((int)player.speed / 8, msec);

                                        sky.update((int)player.speed / 20, msec);
                                        ss.update((int)player.speed / 20, msec);
                                        space.update((int)player.speed / 20, msec);
                                        rock.update((int)player.speed / 15, msec);
                                        field.update((int)player.speed / 8, msec);
                                        airtank.update(msec);

                                        if (!player.isGrounded)
                                        {
                                            player.checkCollision(pineWheel.obj, pineWheel);
                                            player.checkCollision(star.obj, star);
                                            player.checkCollision(airup.obj, airup);
                                            player.checkCollision(airdown.obj, airdown);
                                        }

                                        if (throwPlane)
                                        {
                                            if (sky.location.Y > 0)
                                                foreach (Background background in backgrounds)
                                                    background.location.Y -= 2;

                                            else if (sky.location.Y <= 0)
                                            {
                                                player.gravity = 2;
                                                sky.location.Y = 0;
                                                throwPlane = false;
                                                goingDown = true;
                                            }
                                        }

                                        if (goingDown)
                                        {
                                            if (player.location.Y > 100)
                                                heightTrim = true;

                                            if (player.location.Y < 100 && heightTrim)
                                            {
                                                if (!isGoingUp)
                                                    player.location.Y = 100;

                                                goUp = true;

                                                foreach (Background background in backgrounds)
                                                    background.location.Y += (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed;

                                                foreach (AnimObject pineWheel in pineWheel.obj)
                                                    pineWheel.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                                foreach (AnimObject star in star.obj)
                                                    star.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                                foreach (AnimObject airup in airup.obj)
                                                    airup.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                                foreach (AnimObject airdown in airdown.obj)
                                                    airdown.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);


                                            }

                                            else
                                            {
                                                isGoingUp = false;
                                                foreach (Background background in backgrounds)
                                                {
                                                    background.location.Y -= (int)((player.gravity) * msec);

                                                    if (background.location.Y > background.y)
                                                    {
                                                        player.location.Y = 100;
                                                    }

                                                    else
                                                    {
                                                        background.location.Y = background.y;
                                                        goUp = false;
                                                    }
                                                }

                                                if (goUp)
                                                {
                                                    if (sky.location.Y > 0)
                                                    {
                                                        foreach (AnimObject pineWheel in pineWheel.obj)
                                                            pineWheel.move(0, -(int)((player.gravity) * msec));

                                                        foreach (AnimObject star in star.obj)
                                                            star.move(0, -(int)((player.gravity) * msec));

                                                        foreach (AnimObject airup in airup.obj)
                                                            airup.move(0, -(int)((player.gravity) * msec));

                                                        foreach (AnimObject airdown in airdown.obj)
                                                            airdown.move(0, -(int)((player.gravity) * msec));
                                                    }
                                                }
                                            }
                                        }

                                        // item effect
                                        if (pineWheel.effect)
                                        {
                                            isGoingUp = true;
                                            if (setGoUpSpeed)
                                            {
                                                goupspeed = 25;     // go up power
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

                                        if (airup.effect)
                                        {
                                            airtank.value += 10;
                                            airup.effect = false;
                                        }

                                        if (airdown.effect)
                                        {
                                            airtank.value -= 200;
                                            airdown.effect = false;
                                        }
                                    }

                                    else
                                    {
                                        if (!player.temp)
                                        {
                                            foreach (Background background in backgrounds)
                                                background.move((int)player.speed / 5, 5);

                                            foreach (AnimObject pineWheel in pineWheel.obj)
                                                pineWheel.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                            foreach (AnimObject star in star.obj)
                                                star.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                            foreach (AnimObject airup in airup.obj)
                                                airup.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);

                                            foreach (AnimObject airdown in airdown.obj)
                                                airdown.move(0, (int)((player.gravity + (int)(player.gravity / 2)) * msec) + goupspeed);
                                        }

                                        else
                                        {
                                            gameManager.update = true;
                                        }
                                    }

                                    if (sky.location.Y == 0)
                                        gameManager.gameOver(player, msec);
                                }

                                else
                                {
                                    player.pickUp(PointToClient(MousePosition));
                                }

                                if (PointToClient(MousePosition).X > 1200 && PointToClient(MousePosition).X < 1255 && PointToClient(MousePosition).Y > 20 && PointToClient(MousePosition).Y < 70)
                                {
                                    settingIcon.updateFrame(msec);
                                    gameMode = false;
                                    settingMode = true;
                                }
                                else
                                {
                                    gameMode = true;
                                    settingMode = false;
                                }

                                distanceText.update(Math.Round(player.flightDistance, 0).ToString() + " M");
                                starCountText.update(star.count.ToString());
                                velocityText.update(Math.Round((player.speed / 100), 0).ToString() + " M/S");
                                airPercentageText.update(Math.Round((double)(airtank.value / airtank.maximum) * 100, 0).ToString() + " %");
                            }
                        }
                    }
                    break;
                #endregion

                case "Shop":
                    #region
                    // code here
                    if (gameManager.initialization)
                    {
                        

                        // unvisible game objects
                        multiple.Visible = true;
                        shopFrame.Visible = true;
                        playgameButton.visible(false);
                        shopButton.visible(false);
                        boardButton.visible(false);

                        multiple.Font = new Font("Agency FB", 25, distance.Font.Style);
                        multiple.Parent = this;
                        multiple.Visible = true;
                        starCount.Visible = true;

                        shopFrame.ClientSize = new Size(338, 290);
                        shopFrame.Location = new Point(150, 150);
                        multiple.Location = new Point(308, 488);
                        plane.position(105, 100);
                        starIcon.position(197, 490);
                        checkedIcon.position(200, 200); // hide on bush

                        starCount.ForeColor = Color.OrangeRed;
                        arrowIcon.colorImage = Air.Properties.Resources.icon_carrow;
                        goBackIcon.colorImage = Air.Properties.Resources.icon_cback;
                        arrowIcon.position(1065, 544);
                        starAnimation.position(641, 155);
                        pumpAnimation.position(783, 115);


                        starCountText.init(343, 482, starCount, new Font("Agency FB", 20, starCount.Font.Style));
                        itemNameText.init(785, 480, itemName, new Font("Agency FB", 20, itemName.Font.Style));
                        purchaseText.init(674, 540, purchase, new Font("Agency FB", 20, purchase.Font.Style));
                        currentValueText.init(195, 5, currentValue, new Font("Agency FB", 20, currentValue.Font.Style));
                        upgradeValueText.init(300, 5, upgradeValue, new Font("Agency FB", 20, upgradeValue.Font.Style));
                        arrowText.init(265, 0, to, new Font("Agency FB", 22, to.Font.Style));
                        
                        itemNameText.visible(true);
                        purchaseText.visible(true);
                        purchaseText.visible(true);
                        currentValueText.visible(true);
                        upgradeValueText.visible(true);
                        to.Visible = true;

                        currentValue.Parent = purchase;
                        upgradeValue.Parent = purchase;
                        to.Parent = purchase;

                        frame.position(shopFrame.Location.X - 5, shopFrame.Location.Y - 5);

                        int xAddValue = 120;
                        for (int i = 0; i < itemFrame.Length / 2; i++)
                        {
                            itemFrame[i] = new GameObject(Air.Properties.Resources.object_itemframe);
                            itemFrame[i].bounds = new RectangleF(0, 0, 120, 120);
                            itemFrame[i].position(510 + xAddValue, 150);
                            itemFrame[i].index = i;
                            itemFrames.Add(itemFrame[i]);
                            xAddValue += 190;
                        }
                        xAddValue = 120;
                        for (int i = 3; i < itemFrame.Length; i++)
                        {
                            itemFrame[i] = new GameObject(Air.Properties.Resources.object_itemframe);
                            itemFrame[i].bounds = new RectangleF(0, 0, 120, 120);
                            itemFrame[i].position(510 + xAddValue, 320);
                            itemFrame[i].index = i;
                            itemFrames.Add(itemFrame[i]);
                            xAddValue += 190;
                        }

                        gameManager.initialization = false;
                    }

                    else
                    {
                        cloud.update(1, msec);

                        int moveY = 1 * (int)fadeDir;

                        plane.move(0, moveY);

                        if (plane.bounds.Y > 140)
                            fadeDir = -1;

                        if (plane.bounds.Y < 80)
                            fadeDir = 1;

                        starCountText.update(star.count.ToString());
                        itemNameText.update("seletected item name");
                        purchaseText.update("upgrade your item :)");
                        currentValueText.update("30%");
                        upgradeValueText.update("100%");

                        arrowIcon.updateFrame(msec);

                        if (itemFrame[0].isChecked)
                        {
                            tempIndex = 0;
                            for (int i = 0; i < itemFrame.Length; i++)
                            {
                                if (i != tempIndex)
                                    itemFrame[i].isChecked = false;
                            }
                            starAnimation.updateFrame(msec);
                        }

                        if (itemFrame[1].isChecked)
                        {
                            tempIndex = 1;
                            for (int i = 0; i < itemFrame.Length; i++)
                            {
                                if (i != tempIndex)
                                    itemFrame[i].isChecked = false;
                            }
                            pumpAnimation.updateFrame(msec);
                        }
                    }
                    break;
                #endregion

                case "Board":
                    if (gameManager.initialization)
                    {
                        gameManager.initialization = false;
                    }
                    break;
            }

            gameManager.updateFlag = DateTime.Now;
            Invalidate();
        }
        #endregion
        int tempIndex;
        // draw
        #region
        private void inGameCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (gameManager.sceneName == "Title")
            {
                title.draw(e.Graphics);

                if (showGameName)
                {

                    name.draw(e.Graphics);
                    kpu.draw(e.Graphics);

                    if (name.bounds.Y > 110 && clickToStart.IsDisposed)
                        name.move(0, -2);
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
                airup.draw(e.Graphics);
                airdown.draw(e.Graphics);
                player.draw(e.Graphics);
                settingIcon.draw(e.Graphics);
                starIcon.draw(e.Graphics);
            }

            else if (gameManager.sceneName == "Shop")
            {
                paper.draw(e.Graphics);
                frame.draw(e.Graphics);

                foreach (GameObject itemFrame in itemFrames)
                    itemFrame.draw(e.Graphics);

                kpu.draw(e.Graphics);
                starIcon.draw(e.Graphics);
                arrowIcon.draw(e.Graphics);
                goBackIcon.draw(e.Graphics);
                checkedIcon.draw(e.Graphics);

                starAnimation.draw(e.Graphics);
                pumpAnimation.draw(e.Graphics);
            }
        }

        private void shopCanvas_Paint(object sender, PaintEventArgs e)
        {
            cloud.draw(e.Graphics);
            plane.draw(e.Graphics);
        }

        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
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
                    settingForm.Location = new Point(this.Width / 2 - (settingForm.Size.Width / 10) - 40, ((this.Height / 2) - settingForm.Size.Height / 3) - 60);
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
                gameManager.playing = true;
            }

            else
            {
                player.isFlying = false;
            }
        }

        Point clickPoint = new Point();
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameManager.sceneName == "Shop")
            {
                arrowIcon.handleMouseMoveEvent(e.Location);
                goBackIcon.handleMouseMoveEvent(e.Location);

                foreach (GameObject itemFrame in itemFrames)
                {
                    if (e.Location.X > itemFrame.bounds.X && e.Location.X < itemFrame.bounds.X + itemFrame.bounds.Width)
                    {
                        if (e.Location.Y > itemFrame.bounds.Y && e.Location.Y < itemFrame.bounds.Y + itemFrame.bounds.Height)
                        {
                            clickPoint = e.Location;
                            itemFrame.isCheckable = true;
                        }
                    }
                    else
                    {
                        itemFrame.isCheckable = false;
                    }
                }
            }
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            if (gameManager.sceneName == "Title")
            {
                if (pressToStart is false)
                    pressToStart = true;
            }

            else if (gameManager.sceneName == "Shop")
            {
                if (arrowIcon.active is true)
                {
                    star.count -= 10;
                    //PurchaseForm purchaseForm = new PurchaseForm();
                    //purchaseForm.StartPosition = FormStartPosition.Manual;
                    //purchaseForm.Location = new Point(this.Width / 2 - (purchaseForm.Size.Width / 10) - 40, ((this.Height / 2) - purchaseForm.Size.Height / 3) - 70);
                    //purchaseForm.ShowDialog();    // this is modeless
                }

                if (goBackIcon.active is true)
                {
                    gameManager.sceneName = "Title";
                    firstTime = false;
                    gameManager.init();
                    player.init();
                    airtank.init();
                    developerMode = false;
                }

                foreach (GameObject itemFrame in itemFrames)
                {
                    if (itemFrame.isCheckable is true)
                    {
                        checkedIcon.position(itemFrame.bounds.X + itemFrame.bounds.Width - 20, itemFrame.bounds.Y);
                        itemFrames[itemFrame.index].isChecked = true;
                    }
                }
            }
        }
        #endregion

        // menu change methods
        #region
        private void playButton_Click(object sender, EventArgs e)
        {
            gameManager.sceneName = "InGame";
            gameManager.init();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            gameManager.sceneName = "Shop";
            gameManager.init();
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            gameManager.sceneName = "Board";
            gameManager.init();
        }
        #endregion

        // developer mode methods
        #region
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && gameManager.sceneName == "InGame")
            {
                player.minSpeed += 10;
                player.speed += 10;
            }

            if (e.KeyCode == Keys.P && gameManager.sceneName == "InGame")
                timerFunction.Start();

            if (e.KeyCode == Keys.S && gameManager.sceneName == "InGame")
                developerMode = false;

            if (e.KeyCode == Keys.M)
            {

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