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
using System.IO;

namespace Air
{
    public partial class GameForm : Form
    {
        // GameObject
        #region
        GameManager gameManager = new GameManager();
        Player player = new Player(Air.Properties.Resources.plane, new Point(150, 200));
        Airtank airtank = new Airtank(Air.Properties.Resources.airtank_gage, new Point(270, 675));

        List<Background> backgrounds = new List<Background>();
        Background title = new Background(Air.Properties.Resources.background_title, new Point(0, 0));
        Background sky = new Background(Air.Properties.Resources.background_sky, new Point(0, 0));
        Background ss = new Background(Air.Properties.Resources.background_atmosphere, new Point(0, -720));
        Background space = new Background(Air.Properties.Resources.background_space, new Point(0, -1440));
        Background rock = new Background(Air.Properties.Resources.background_rock, new Point(150, 390));
        Background field = new Background(Air.Properties.Resources.background_field, new Point(150, 520));
        Background cloud = new Background(Air.Properties.Resources.background_shop, new Point(0, 0));
        Background paper = new Background(Air.Properties.Resources.background_paper, new Point(0, 0));

        Item pineWheel = new Item(Air.Properties.Resources.item_pinewheel, 3, 3.0f, new RectangleF(1280, 500, 70, 100), new RectangleF(0, 0, 350, 505), "PineWheel", 5.0f);
        Item star = new Item(Air.Properties.Resources.item_star, 1, 1.0f, new RectangleF(1280, 0, 150, 150), new RectangleF(0, 0, 150, 150), "Star", 1.0f);
        Item airup = new Item(Air.Properties.Resources.item_airup, 1, 1.0f, new RectangleF(1280, 0, 50, 75), new RectangleF(0, 0, 50, 75), "AirUp", 5.0f);
        Item airdown = new Item(Air.Properties.Resources.item_airdown, 1, 1.0f, new RectangleF(1280, 0, 50, 75), new RectangleF(0, 0, 50, 75), "AirDown", 2.0f);

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

        Text sceneNameText = new Text();
        Text flightTimeText = new Text();
        Text maxVelocityText = new Text();

        Button playgameButton = new Button();
        Button shopButton = new Button();
        Button boardButton = new Button();

        Icon settingIcon = new Icon(Air.Properties.Resources.icon_setting, 4, 1.0f, new Rectangle(1200, 20, 54, 54), new RectangleF(0, 0, 132, 132));
        Icon arrowIcon = new Icon(Air.Properties.Resources.icon_arrow, 1, 1.0f, new Rectangle(0, 0, 30, 30), new RectangleF(0, 0, 60, 60));
        Icon goBackIcon = new Icon(Air.Properties.Resources.icon_back, 1, 1.0f, new Rectangle(1200, 20, 45, 45), new RectangleF(0, 0, 64, 64));
        Icon checkedIcon = new Icon(Air.Properties.Resources.icon_check, 1, 1.0f, new Rectangle(0, 0, 45, 45), new RectangleF(0, 0, 64, 64));

        // shop items
        Icon starAnimation = new Icon(Air.Properties.Resources.animation_star, 6, 1.0f, new Rectangle(0, 0, 100, 100), new RectangleF(0, 0, 300, 300));
        Icon pumpUpAnimation = new Icon(Air.Properties.Resources.animation_pumpup, 6, 1.0f, new Rectangle(0, 0, 200, 200), new RectangleF(0, 0, 300, 300));
        Icon pumpDownAnimation = new Icon(Air.Properties.Resources.animation_pumpdown, 6, 1.0f, new Rectangle(0, 0, 200, 200), new RectangleF(0, 0, 300, 300));
        Icon airtankAnimation = new Icon(Air.Properties.Resources.animation_airtank, 6, 1.0f, new Rectangle(0, 0, 160, 160), new RectangleF(0, 0, 300, 300));
        Icon pinewheelAnimation = new Icon(Air.Properties.Resources.item_pinewheel, 3, 1.0f, new Rectangle(0, 0, 55, 80), new RectangleF(0, 0, 350, 505));
        Icon resistanceAnimation = new Icon(Air.Properties.Resources.animation_resistance, 6, 1.0f, new Rectangle(0, 0, 160, 160), new RectangleF(0, 0, 300, 300));

        public static Settings settings = new Settings();

        Label[,] mylabel;
        #endregion

        // variables
        #region

        // opacity variables
        private float fadingSpeed = 0.01f;
        private float fadeDir = 1;
        private float opacity = 1;

        // etc
        bool pressToStart = false;
        public static bool firstTime = true;                 // shit value

        // static variables
        public static double score;
        public static bool developerMode = false;      // change it to false when playing
        public static bool scoreBoardClosed = false;
        #endregion

        public static Score[] scores = new Score[10];
        public static List<Score> boardScore = new List<Score>();

        string selectedItem = "selected item name";

        SoundPlayer bgm = new SoundPlayer(Air.Properties.Resources.sound_bgm);
        Bitmap[] logoImage = new Bitmap[4];
        Point gameNameOffset = new Point(3, 0);
        Point clickPoint = new Point();

        int logoImageIndex;
        int goupspeed = 0;
        int frameIndex = 0;
        int[] firstValue = new int[6] { 10, 10, 10, 10, 10, 10 };
        int[,] itemEffectValue = new int[6, 2];

        float starGenerateTime = 1.5f;

        bool showGameName = false;
        bool gameMode = true;
        bool settingMode = false;
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
            goBackIcon.colorImage = Air.Properties.Resources.icon_cback;
        }

        // update
        #region
        private void timerFunction_Tick(object sender, EventArgs e)
        {
            mylabel = new Label[,] {
                        { flightDistance1, flightTime1, maxVeloctiy1 },
                        { flightDistance2, flightTime2, maxVeloctiy2 },
                        { flightDistance3, flightTime3, maxVeloctiy3 },
                        { flightDistance4, flightTime4, maxVeloctiy4 },
                        { flightDistance5, flightTime5, maxVeloctiy5 }};

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
                            if (firstTime)
                                bgm.Play();

                            // time setting
                            gameManager.waitForSeconds = 2.8f;
                            gameManager.checkTime = true;

                            // UI location settings
                            clickToStart.Location = new Point((this.Width / 2 - clickToStart.Size.Width / 2) - 4, clickToStart.Location.Y + 370);

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

                            sceneName.Visible = false;
                            rank.Visible = false;
                            flightDistnace.Visible = false;
                            flightTime.Visible = false;
                            maxVelocity.Visible = false;
                            label1.Visible = false;
                            label2.Visible = false;
                            label3.Visible = false;
                            label4.Visible = false;
                            label5.Visible = false;

                            for (int i = 0; i < 3; i++)
                                for (int j = 0; j < 5; j++)
                                    mylabel[j, i].Visible = false;

                            distance.Visible = false;
                            starCount.Visible = false;
                            distanceText.visible(false);

                            velocityText.visible(false);
                            airPercentageText.visible(false);

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
                            pineWheel.obj.Clear();
                            star.obj.Clear();
                            airdown.obj.Clear();
                            airup.obj.Clear();

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
                            velocityText.init((this.Width / 2) - (velocity.Size.Width / 2), 628, velocity, new Font("Agency FB", 16, velocity.Font.Style));                   // set this value
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

                            firstTime = false;
                            throwPlane = true;
                            goingDown = false;
                            developerMode = false;
                            heightTrim = false;

                            scoreBoardClosed = false;

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
                                    gameManager.playTime = DateTime.Now - gameManager.playTimeFlag;

                                    if(player.maxSpeed < player.speed)
                                        player.maxSpeed = player.speed;
                                    
                                    if (gameManager.update)
                                    {
                                        player.airtankValue = airtank.value;
                                        airtank.value = player.airtankValue;
                                        player.airtankMin = airtank.minimum;
                                        airtank.isFlying = player.isFlying;

                                        pineWheel.generatePositionY = field.location.Y;
                                        star.generatePositionY = field.location.Y;
                                        star.setGenerateTime = starGenerateTime;
                                        airup.generatePositionY = field.location.Y;
                                        airdown.generatePositionY = field.location.Y;

                                        pineWheel.update((int)player.speed / 8, msec);
                                        star.update((int)player.speed / 8, msec);
                                        airup.update((int)player.speed / 8, msec);
                                        airdown.update((int)player.speed / 8, msec);

                                        sky.update((int)player.speed / 20, msec);
                                        ss.update((int)player.speed / 20, msec);
                                        space.update((int)player.speed / 20, msec);
                                        rock.update((int)player.speed / 15, msec);
                                        field.update((int)player.speed / 8, msec);

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
                                            airtank.update(msec);
                                            if (player.location.Y > 100)
                                                heightTrim = true;

                                            if (player.location.Y < 100 && heightTrim)
                                            {
                                                if (!isGoingUp)
                                                    player.location.Y = 100;

                                                goUp = true;

                                                if (space.location.Y <= 0)
                                                {
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
                                                            pineWheel.move(0, -((int)((player.gravity) * msec) + goupspeed));

                                                        foreach (AnimObject star in star.obj)
                                                            star.move(0, -((int)((player.gravity) * msec) + goupspeed));

                                                        foreach (AnimObject airup in airup.obj)
                                                            airup.move(0, -((int)((player.gravity) * msec) + goupspeed));

                                                        foreach (AnimObject airdown in airdown.obj)
                                                            airdown.move(0, -((int)((player.gravity) * msec) + goupspeed));
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
                                    {
                                        gameManager.gameOver(player, msec);

                                        if(scoreBoardClosed)
                                        {
                                            gameManager.sceneName = "Title";
                                            gameManager.init();
                                            player.init();
                                            airtank.init();
                                            firstTime = false;
                                        }
                                    }
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
                                velocityText.update(Math.Round((player.speed / 10), 0).ToString() + " CM/S");
                                airPercentageText.update(Math.Round((double)(airtank.value / airtank.maximum) * 100, 0).ToString() + " %");
                            }
                        }
                    }
                    break;
                #endregion

                case "Shop":
                    #region
                    if (gameManager.initialization)
                    {
                        selectedItem = null;
                        
                        starAnimation.price = 100;
                        pumpUpAnimation.price = 100;

                        // unvisible game objects
                        sceneName.Visible = true;
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
                        arrowIcon.position(1065, 544);
                        starAnimation.position(641, 160);
                        pumpUpAnimation.position(783, 115);
                        pumpDownAnimation.position(972, 114);
                        airtankAnimation.position(612, 307);
                        pinewheelAnimation.position(855,340);
                        resistanceAnimation.position(990, 300);
                        sceneNameText.init(575, 20, sceneName, new Font("Agency FB", 30, sceneName.Font.Style));
                        sceneName.Text = "shop";

                        starCountText.init(343, 482, starCount, new Font("Agency FB", 20, starCount.Font.Style));
                        itemNameText.init(785, 473, itemName, new Font("Agency FB", 20, itemName.Font.Style));
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
                        itemNameText.update(selectedItem);
                        purchaseText.update("upgrade your item :)");

                        if (itemEffectValue[frameIndex, 0] == 100)
                            firstValue[frameIndex] = 0;

                        currentValueText.update(itemEffectValue[frameIndex, 0] + "%");
                        upgradeValueText.update(itemEffectValue[frameIndex, 1] + firstValue[frameIndex] + "%");

                        if (selectedItem == "star generator")
                            starAnimation.updateFrame(msec);

                        else if (selectedItem == "air up")
                            pumpUpAnimation.updateFrame(msec);

                        else if (selectedItem == "air down")
                            pumpDownAnimation.updateFrame(msec);

                        else if (selectedItem == "airtank")
                            airtankAnimation.updateFrame(msec);

                        else if (selectedItem == "pine wheel")
                            pinewheelAnimation.updateFrame(msec);

                        else if (selectedItem == "air resistance")
                            resistanceAnimation.updateFrame(msec);

                        arrowIcon.updateFrame(msec);
                    }
                    break;
                #endregion

                case "Board":
                    #region
                    if (gameManager.initialization)
                    {
                        List<double> scoreList = new List<double>();
                        int scoreIndex = 0;

                        if (GameManager.scoreIndex > 0)
                        {
                            StreamWriter writer = new StreamWriter("Score.txt");
                            foreach (Score score in boardScore)
                            {
                                string str = score.flightDistance + " " + score.flightTime + " " + score.velocity;
                                writer.WriteLine(str);
                            }
                            writer.Close();

                            StreamReader reader = new StreamReader("Score.txt");
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                string[] str = line.Split();
                                if (scoreIndex < GameManager.scoreIndex)
                                {
                                    scores[scoreIndex] = new Score(Convert.ToDouble(str[0]), Convert.ToDouble(str[1]), Convert.ToDouble(str[2]), scoreIndex);
                                    scoreList.Add(scores[scoreIndex].flightDistance);
                                    scoreIndex++;
                                }
                            }

                            scoreList.Sort();

                            int[] savedScoreIndex = new int[scores.Length];

                            for (int j = 0; j < scoreIndex; j++)
                            {
                                for (int i = 0; i < scoreIndex; i++)
                                {
                                    if (scores[j].flightDistance == scoreList[i])
                                        savedScoreIndex[j] = scores[i].index;
                                }
                            }

                            for (int i = 0; i < scoreIndex; i++)
                            {
                                mylabel[i, 0].Text = scores[savedScoreIndex[scoreIndex - i - 1]].flightDistance + " m";
                                mylabel[i, 1].Text = scores[savedScoreIndex[scoreIndex - i - 1]].flightTime.ToString() + " seconds";
                                mylabel[i, 2].Text = scores[savedScoreIndex[scoreIndex - i - 1]].velocity.ToString() + " cm/s";
                            }
                        }

                        #region
                        sceneNameText.init(565, 20, sceneName, new Font("Agency FB", 30, sceneName.Font.Style));
                        sceneName.Text = "board";

                        rank.Font = new Font("Agency FB", 25, flightDistnace.Font.Style);
                        rank.Location = new Point(150, 130);
                        flightDistnace.Font = new Font("Agency FB", 25, flightDistnace.Font.Style);
                        flightDistnace.Location = new Point(rank.Location.X + 240, rank.Location.Y);
                        maxVelocity.Font = new Font("Agency FB", 25, flightDistnace.Font.Style);
                        maxVelocity.Location = new Point(flightDistnace.Location.X + 270, rank.Location.Y);
                        flightTime.Font = new Font("Agency FB", 25, flightDistnace.Font.Style);
                        flightTime.Location = new Point(flightDistnace.Location.X + 540, rank.Location.Y);

                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                mylabel[i, j].Font = new Font("Agency FB", 18, flightTime1.Font.Style);
                                mylabel[i, j].Visible = true;
                            }
                        }

                        label1.Location = new Point(rank.Location.X + 15, rank.Location.Y + 100);
                        label1.Font = new Font("Agency FB", 18, label1.Font.Style);
                        flightDistance1.Location = new Point(label1.Location.X + 220, label1.Location.Y);
                        maxVeloctiy1.Location = new Point(label1.Location.X + 493, label1.Location.Y);
                        flightTime1.Location = new Point(label1.Location.X + 765, label1.Location.Y);

                        label2.Location = new Point(rank.Location.X + 15, rank.Location.Y + 190);
                        label2.Font = new Font("Agency FB", 18, label2.Font.Style);
                        flightDistance2.Location = new Point(label2.Location.X + 220, label2.Location.Y);
                        maxVeloctiy2.Location = new Point(label2.Location.X + 493, label2.Location.Y);
                        flightTime2.Location = new Point(label2.Location.X + 765, label2.Location.Y);

                        label3.Location = new Point(rank.Location.X + 15, rank.Location.Y + 280);
                        label3.Font = new Font("Agency FB", 18, label3.Font.Style);
                        flightDistance3.Location = new Point(label3.Location.X + 220, label3.Location.Y);
                        maxVeloctiy3.Location = new Point(label3.Location.X + 493, label3.Location.Y);
                        flightTime3.Location = new Point(label3.Location.X + 765, label3.Location.Y);

                        label4.Location = new Point(rank.Location.X + 15, rank.Location.Y + 370);
                        label4.Font = new Font("Agency FB", 18, label4.Font.Style);
                        flightDistance4.Location = new Point(label4.Location.X + 220, label4.Location.Y);
                        maxVeloctiy4.Location = new Point(label4.Location.X + 493, label4.Location.Y);
                        flightTime4.Location = new Point(label4.Location.X + 765, label4.Location.Y);

                        label5.Location = new Point(rank.Location.X + 15, rank.Location.Y + 460);
                        label5.Font = new Font("Agency FB", 18, label3.Font.Style);

                        flightDistance5.Location = new Point(label5.Location.X + 240, label5.Location.Y);
                        flightTime5.Location = new Point(label5.Location.X + 515, label5.Location.Y);
                        flightDistance5.Location = new Point(label5.Location.X + 220, label5.Location.Y);
                        maxVeloctiy5.Location = new Point(label5.Location.X + 493, label5.Location.Y);
                        flightTime5.Location = new Point(label5.Location.X + 765, label5.Location.Y);


                        playgameButton.visible(false);
                        shopButton.visible(false);
                        boardButton.visible(false);

                        sceneName.Visible = true;
                        rank.Visible = true;
                        flightDistnace.Visible = true;
                        flightTime.Visible = true;
                        maxVelocity.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        #endregion

                        gameManager.initialization = false;
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
                pumpUpAnimation.draw(e.Graphics);
                pumpDownAnimation.draw(e.Graphics);
                pinewheelAnimation.draw(e.Graphics);
                airtankAnimation.draw(e.Graphics);
                resistanceAnimation.draw(e.Graphics);
            }

            else if (gameManager.sceneName == "Board")
            {
                paper.draw(e.Graphics);

                goBackIcon.draw(e.Graphics);
                kpu.draw(e.Graphics);
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
                gameManager.playTimeFlag = DateTime.Now;
            }

            else
            {
                player.isFlying = false;
            }
        }

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

            else if (gameManager.sceneName == "Board")
            {
                goBackIcon.handleMouseMoveEvent(e.Location);
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
                    if (selectedItem == "star generator")
                    {
                        if (star.count - starAnimation.price > 0)
                        {
                            star.count -= starAnimation.price;
                            if (itemEffectValue[0, 0] < 100)
                            {
                                starGenerateTime -= 0.15f;
                                itemEffectValue[0, 0] += 10;
                                itemEffectValue[0, 1] += 10;
                            }
                        }
                    }

                    if (selectedItem == "air up")
                    {
                        if (star.count - pumpUpAnimation.price > 0)
                        {
                            star.count -= pumpUpAnimation.price;
                            if (itemEffectValue[1, 0] < 100)
                            {
                                airup.generateTime -= 0.2f;
                                itemEffectValue[1, 0] += 10;
                                itemEffectValue[1, 1] += 10;
                            }
                        }
                    }

                    if (selectedItem == "air down")
                    {
                        if (star.count - pumpUpAnimation.price > 0)
                        {
                            star.count -= pumpUpAnimation.price;
                            if (itemEffectValue[2, 0] < 100)
                            {
                                airdown.generateTime += 0.2f;
                                itemEffectValue[2, 0] += 10;
                                itemEffectValue[2, 1] += 10;
                            }
                        }
                    }

                    if (selectedItem == "airtank")
                    {
                        if (star.count - pumpUpAnimation.price > 0)
                        {
                            star.count -= pumpUpAnimation.price;
                            if (itemEffectValue[3, 0] < 100)
                            {
                                airtank.airValue -= 1;
                                itemEffectValue[3, 0] += 10;
                                itemEffectValue[3, 1] += 10;
                            }
                        }
                    }

                    if (selectedItem == "pine wheel")
                    {
                        if (star.count - pumpUpAnimation.price > 0)
                        {
                            star.count -= pumpUpAnimation.price;
                            if (itemEffectValue[4, 0] < 100)
                            {
                                pineWheel.generateTime -= 0.5f;
                                itemEffectValue[4, 0] += 10;
                                itemEffectValue[4, 1] += 10;
                            }
                        }
                    }

                    if (selectedItem == "air resistance")
                    {
                        if (star.count - pumpUpAnimation.price > 0)
                        {
                            star.count -= pumpUpAnimation.price;
                            if (itemEffectValue[5, 0] < 100)
                            {
                                // adfadsf
                                itemEffectValue[5, 0] += 10;
                                itemEffectValue[5, 1] += 10;
                            }
                        }
                    }
                }

                else
                {
                    foreach (GameObject itemFrame in itemFrames)
                    {
                        if (itemFrame.isCheckable is true)
                        {
                            frameIndex = itemFrame.index;
                            if (itemFrame.index == 0)
                                selectedItem = "star generator";

                            else if (itemFrame.index == 1)
                                selectedItem = "air up";

                            else if (itemFrame.index == 2)
                                selectedItem = "air down";

                            else if (itemFrame.index == 3)
                                selectedItem = "airtank";

                            else if (itemFrame.index == 4)
                                selectedItem = "pine wheel";

                            else if (itemFrame.index == 5)
                                selectedItem = "air resistance";

                            checkedIcon.position(itemFrame.bounds.X + itemFrame.bounds.Width - 20, itemFrame.bounds.Y);
                        }
                    }
                }

                if (goBackIcon.active is true)
                {
                    gameManager.sceneName = "Title";
                    gameManager.init();
                    player.init();
                    airtank.init();
                    developerMode = false;
                    firstTime = false;
                }
            }

            else if (gameManager.sceneName == "Board")
            {
                if (goBackIcon.active is true)
                {
                    gameManager.sceneName = "Title";
                    gameManager.init();
                    player.init();
                    airtank.init();
                    developerMode = false;
                    firstTime = false;
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
                gameManager.sceneName = "Title";
                gameManager.init();
                player.init();
                airtank.init();
                firstTime = false;
            }

            if (e.KeyCode == Keys.C)
            {
                star.count = 2013180043;
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