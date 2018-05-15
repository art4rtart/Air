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
        public static Player player = new Player();

        // GameObject
        Background title = new Background();
        Background sky = new Background();
        Background rock = new Background();
        Background field = new Background();
        Airtank airtank = new Airtank();
        Item star = new Item();

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
        PictureBox kpu = new PictureBox();

        // time variables
        private DateTime updateFlag;
        private DateTime timeFlag;
        bool checkTime = true;
        float waitForSeconds = 1.5f;

        // framework variables
        private string sceneName = "InGame";
        private string logoName = "daydream";

        // update variables
        bool gameUpdate = false;
        bool canPickUp = false;

        // opacity variables
        private float fadingSpeed = 0.02f;
        private float fadeDir = 1;
        private float opacity = 0;

        // developermode variables
        bool developerMode = false;      // change it to false when playing
        bool playing = false;

        // etc
        bool firstChanged = true;
        bool secondChanged = true;
        bool initialization = true;
        bool pressToStart = false;
        bool firstTime = true;                 // shit value


        // score
        public static double score;

        #endregion

        // recent added variables
        Bitmap bar;
        Bitmap titleImage;
        Bitmap gameName;

        Point gameNameOffset = new Point(3, 0);


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
            timerFunction.Interval = 30;
            timerFunction.Start();

            // start position setting
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(220, 70);

            // double buffering
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            // resource load
            bar = Air.Properties.Resources.bar;
            titleImage = Air.Properties.Resources.title;
            gameName = Air.Properties.Resources.gameName;

            // bgm play
            //SoundPlayer bgm = new SoundPlayer(Air.Properties.Resources.bgm);
            //bgm.Play();
        }

        bool drawGameName = false;

        private void timerFunction_Tick(object sender, EventArgs e)
        {
            TimeSpan deltaTime = DateTime.Now - updateFlag;
            int frames = (int)(deltaTime.Milliseconds / 10);

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
                            //canvas.SizeMode = PictureBoxSizeMode.StretchImage;

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
                            opacity += (fadingSpeed * frames) * fadeDir;

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

                            // background setting
                            title.init(0, 720, 0, 0, Air.Properties.Resources.title);

                            // UI location settings
                            clickToStart.Location = new Point((canvas.Width / 2 - clickToStart.Size.Width / 2), clickToStart.Location.Y);
                            play.Location = new Point((canvas.Width / 2 - play.Size.Width / 2), play.Location.Y);
                            shop.Location = new Point((canvas.Width / 2 - shop.Size.Width / 2), shop.Location.Y);
                            board.Location = new Point((canvas.Width / 2 - board.Size.Width / 2), board.Location.Y);

                            // UI font settings
                            playgameButton.init(570, 280, 150, 70, "play game", play, new Font("Agency FB", 20, distance.Font.Style), canvas);
                            shopButton.init(570, 370, 150, 70, "shop", shop, new Font("Agency FB", 20, distance.Font.Style), canvas);
                            boardButton.init(570, 460, 150, 70, "board", board, new Font("Agency FB", 20, distance.Font.Style), canvas);
                            clickToStart.Font = new Font("Agency FB", 15, distanceValue.Font.Style);

                            // UI visible settings
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);

                            initialization = false;
                        }

                        if (opacity < 1)
                        {
                            opacity += fadingSpeed * frames * fadeDir;
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
                                    kpu.Visible = true;
                                }

                                if (currentTime.TotalSeconds > waitForSeconds)
                                {
                                    if (!clickToStart.IsDisposed)
                                        clickToStart.Visible = true;
                                }
                            }

                            else
                            {
                                kpu.Visible = true;
                                playgameButton.visible(true);
                                shopButton.visible(true);
                                boardButton.visible(true);
                            }

                            // button settings
                            play.Location = new Point(playgameButton.x, playgameButton.y);
                            play.Size = new Size(shopButton.sizeX, shopButton.sizeY);

                            shop.Location = new Point(shopButton.x, shopButton.y);
                            shop.Size = new Size(shopButton.sizeX, shopButton.sizeY);

                            board.Location = new Point(boardButton.x, boardButton.y);
                            board.Size = new Size(boardButton.sizeX, boardButton.sizeY);
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

                        playgameButton.draw();
                        shopButton.draw();
                        boardButton.draw();

                        title.update(this);
                    }
                    break;
                    #endregion

                case "InGame":
                    #region
                    {
                        // initialization
                        if (initialization)
                        {
                            // unvisible
                            playgameButton.visible(false);
                            shopButton.visible(false);
                            boardButton.visible(false);
                            kpu.Visible = false;                    // temporary settings

                            // time settings
                            checkTime = true;
                            waitForSeconds = 0.5f;

                            player.init(100, 200, generateRandomNumber("double", 1.0, 2.0), plane, canvas);

                            sky.init(0, 720, 0, 0, Air.Properties.Resources.sky);
                            rock.init(0, 200, 0, 390, Air.Properties.Resources.rock);
                            field.init(0, 200, 0, 520, Air.Properties.Resources.field);
                            

                            airtank.init(290, 640, artk, canvas);
                            star.init("Star", canvas);
                            airtank.draw();

                            // text init
                            distanceText.init((this.Width / 2) - (distanceValue.Size.Width / 2), 55, distanceValue, new Font("Agency FB", 20, distance.Font.Style), canvas);                // set this value
                            velocityText.init(610, 593, velocity, new Font("Agency FB", 18, velocity.Font.Style), canvas);                   // set this value
                            airPercentageText.init(935, 590, airTankPercent, new Font("Agency FB", 20, airTankPercent.Font.Style), canvas);       // set this value

                            // visible game objects
                            player.visible(true);
                            distanceText.visible(true);
                            velocityText.visible(true);
                            airPercentageText.visible(true);
                            airtank.visible(true);

                            // visible static text UI
                            distance.Location = new Point((this.Width / 2) - (distance.Size.Width / 2), distance.Location.Y);
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
                            if (playing)
                            {
                                // "after throwing" code
                                if (gameUpdate)
                                {
                                    // draw
                                    player.draw();
                                    airtank.draw();
                                    star.draw();

                                    // update
                                    player.update(frames, player.speed, player.fly, airtank.value, airtank.minimum, (int)player.gravity);

                                    sky.update(this);
                                    rock.update(this);
                                    field.update(this);

                                    airtank.update(frames, player.fly);
                                    star.update(frames, player.speed, plane, player);

                                    distanceText.update(Math.Round(player.flightDistance, 2).ToString() + " M");
                                    velocityText.update(player.speed.ToString() + " M/S");
                                    airPercentageText.update(Math.Round((double)(airtank.value / airtank.maximum) * 100, 0).ToString() + " %");

                                    // speed update : UI
                                    if (player.speed > player.maxSpeed)
                                        player.speed -= 1;
                                }

                                // gameover update
                                gameOver();
                            }

                            else
                            {
                                // "pick it up and throw" code
                                if (!player.getGrounded())
                                    plane.Top += ((int)player.gravity + 3);        // set this value please :(

                                if (plane.Location.Y > this.Height - 180)            // this is onGround value
                                {
                                    player.setGrounded(true);
                                    canPickUp = player.getGrounded() ? true : false;
                                }

                                if (canPickUp)
                                {
                                    if (player.getPicked())
                                        plane.Location = new Point(PointToClient(MousePosition).X - (player.getOffset('x') / 2), PointToClient(MousePosition).Y - (player.getOffset('y') / 2));
                                }
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
            player.setGrounded(plane.Location.Y > this.Height - 180 ? true : false);

            if (player.getGrounded())
            {
                gameUpdate = false;

                if (player.speed > 0)
                {
                    player.speed -= (int)((player.airResistance + 1) / player.slidingValue);
                    plane.Left += player.speed;
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
                        timerFunction.Stop();
                        scoreForm scoreForm = new scoreForm();

                        scoreForm.StartPosition = FormStartPosition.Manual;
                        scoreForm.Location = new Point(this.Width / 2 - (scoreForm.Size.Width / 10), ((this.Height / 2) - scoreForm.Size.Height / 3));
                        scoreForm.ShowDialog();    // this is modeless
                    }
                }
            }
        }
        #endregion

        // generate methods
        #region
        private double generateRandomNumber(string type, double minimum, double maximum)
        {
            Random random = new Random();

            if (type == "double")
                return Math.Round((double)(random.NextDouble() * (maximum - minimum) + minimum), 1);

            else
                return random.Next((int)minimum, (int)maximum);
        }
        #endregion

        // control methods
        #region
        private void player_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playing)
            {
                player.startPosition = new Point(plane.Location.X, plane.Location.Y);
                player.setPicked(true);
            }
        }

        private void player_MouseUp(object sender, MouseEventArgs e)
        {
            if (!playing)
            {
                player.endPositoin = new Point(plane.Location.X, plane.Location.Y);
                player.setPicked(false);
                player.setGrounded(false);
                player.speed = player.startVelocity();
                gameUpdate = playing = true;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            player.fly = true;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            player.fly = false;
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
                player.speed += 5;

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
                player.visible(false);
                distanceText.visible(false);
                velocityText.visible(false);
                airPercentageText.visible(false);
                airtank.visible(false);
                initialization = true;
            }
        }
        #endregion

        // drawing methods
        #region
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

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (sceneName == "Title")
            {
                title.draw(sender, e);

                if (drawGameName)
                {
                    e.Graphics.DrawImage(gameName, ((canvas.Width / 2) - (gameName.Size.Width / 2) - gameNameOffset.X), 170 + gameNameOffset.Y, 128, 128);

                    if(gameNameOffset.Y + 170 > 110 && clickToStart.IsDisposed)
                        gameNameOffset.Y -= 5;
                }
            }

            else if (sceneName == "InGame")
            {
                sky.draw(sender, e);
                rock.draw(sender, e);
                field.draw(sender, e);

                e.Graphics.DrawImage(bar, artk.Location.X - 2, artk.Location.Y - 2, 705, 25);

            }
        }
    }
}

public class Player
{
    // member variables
    private Panel plane = new Panel();
    private Point offset = new Point(90, 50);
    private int x, y;
    private bool grounded, picked;

    public Point startPosition = new Point();
    public Point endPositoin = new Point();
    public int speed = 40;              // max speed is 30
    public int maxSpeed = 40;          // temp value
    public double gravity = 1;          // please calculate this value
    public double airResistance = 2;    // bigger is slower
    public double slidingValue = 0;
    public double flightDistance;       // records variables
    public bool fly = false;

    // methods
    public void init(int x, int y, double slidingValue, Panel panel, PictureBox canvas)
    {
        this.x = x; this.y = y;
        this.slidingValue = slidingValue;
        plane = panel;

        plane.Parent = canvas;
    }

    public void draw()
    {
        this.x = plane.Location.X; this.y = plane.Location.Y;
        plane.Location = new Point(x, y);
    }

    public void update(int frames, int speed, bool fly, double airValue, double airMin, int gravity)
    {
        if (x > 150)
            this.plane.Location = new Point(x - (speed / 2), y);
        else if (x < 150)
            this.plane.Location = new Point(150, y);

        if (fly && airValue > airMin)
            this.plane.Top -= (gravity + 2) * frames;
        else
            this.plane.Top += (gravity) * frames;

        flightDistance += 0.01;     // calculate this value please
    }

    public int startVelocity()
    {
        // need to add time duration
        Point velocity = new Point();
        velocity.X = endPositoin.X - startPosition.X;
        velocity.Y = endPositoin.Y - startPosition.Y;

        return (int)(Math.Pow(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2), 0.5)) / 10;
    }

    public void visible(bool isVisible)
    {
        if (isVisible)
            plane.Visible = true;

        else
            plane.Visible = false;
    }

    public void setGrounded(bool grounded)
    {
        this.grounded = grounded;
    }

    public void setPicked(bool picked)
    {
        this.picked = picked;
    }

    public int getOffset(char value)
    {
        if (value == 'x')
            return offset.X;
        else
            return offset.Y;
    }

    public bool getGrounded()
    {
        return grounded;
    }

    public bool getPicked()
    {
        return picked;
    }
}

public class Background
{
    // member variables
    private PictureBox canvas = new PictureBox();
    Point bgOffset = new Point();
    Point Location = new Point();
    Bitmap image = null;
    
    // methods
    public void init(int bgoffsetX, int bgoffsetY, int locationX, int locationY, Bitmap image)
    {
        this.image = image;

        this.bgOffset.X = bgoffsetX;
        this.bgOffset.Y = bgoffsetY;

        this.Location.X = bgoffsetX;
        this.Location.Y = locationY;
    }

    public void draw(object sender, PaintEventArgs e)
    {
        for (int x = bgOffset.X; x < 2560; x += 2560)
        {
            e.Graphics.DrawImage(image, x, Location.Y, 2560, bgOffset.Y);
        }
    }

    public void update(Form form)
    {
        bgOffset.X -= 10;

        if (bgOffset.X < -2560)
            bgOffset.X += 2560;
    }
}

public class Airtank
{
    // member variables
    private PictureBox airtank = new PictureBox();
    private int x, y;

    public double maximum = 700;
    public double minimum = 0;
    public double value = 700;

    // methods
    public void init(int x, int y, PictureBox picturebox, PictureBox canvas)
    {
        this.x = x; this.y = y;
        this.airtank = picturebox;
        this.airtank.Parent = canvas;
    }

    public void draw()
    {
        airtank.Location = new Point(x, y);
        airtank.Size = new Size((int)value, airtank.Height);
    }

    public void update(int frames, bool fly)
    {
        if (fly)
        {
            if (value > minimum)
                value -= 2 * frames;

            else if (value < minimum)
                value = minimum;
        }

        else
        {
            if (value < maximum)
                value += 1 * frames;

            else if (value > maximum)
                value = maximum;
        }
    }

    public void visible(bool isVisible)
    {
        if (isVisible)
            airtank.Visible = true;

        else
            airtank.Visible = false;
    }
}

public class Item
{
    // member variables
    private PictureBox item;
    private PictureBox canvas;
    private Random random = new Random();
    private int generatePeriod = 3;
    private int itemCount = 0;
    private bool generate = false;
    private string collideTagName;
    private string itemName;

    // methods
    public void init(string itemName, PictureBox canvas)
    {
        this.itemName = itemName;
        this.canvas = canvas;
    }

    public void draw()
    {
        if (item != null)
            item.Location = new Point(item.Location.X, item.Location.Y);
    }

    public void update(int frames, int speed, Panel plane, Player player)
    {
        generate = (DateTime.Now.Second % generatePeriod == 0 && item == null) ? true : false;

        if (generate && item == null)
        {
            generateItem(1120, random.Next(100, 500));          // item generate position
            generate = false;
        }

        else if (item != null)
        {
            item.Left -= speed * frames;

            if (item.Location.X < -50)
            {
                item.Dispose();
                item = null;
                collideTagName = null;
            }

            // star : collision with player
            else if (item.Location.X > plane.Location.X - player.getOffset('x') && item.Location.X < plane.Location.X + player.getOffset('x') &&
                item.Location.Y > plane.Location.Y - player.getOffset('y') && item.Location.Y < plane.Location.Y + player.getOffset('y'))
                collideTagName = itemName;
        }

        collisionUpdate();
    }

    public void generateItem(int x, int y)
    {
        item = new PictureBox();
        item.Image = Air.Properties.Resources.star;
        item.SizeMode = PictureBoxSizeMode.StretchImage;
        item.BackColor = Color.Transparent;
        item.Parent = canvas;
        item.Size = new Size(50, 50);
        item.Location = new Point(x, y);
    }

    private void collisionUpdate()
    {
        if (collideTagName == "Star")
        {
            itemCount++;

            item.Dispose();
            item = null;
            collideTagName = null;
        }

        else if (collideTagName == "Air")
        {
            // Airtank Gage ++
        }

        else if (collideTagName == "AirResistanceUP")
        {
            // Air Resistance ++
        }

        else if (collideTagName == "AirResistanceDown")
        {
            // Air Resistance --
        }

        else if (collideTagName == "Wall")
        {
            // destroy player
        }
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

    public int x, y, sizeX, sizeY;

    // methods
    public void init(int x, int y, int sizeX, int sizeY, string buttonText, Label button, Font font, PictureBox canvas)
    {
        this.button = button;
        this.x = x; this.y = y;
        this.sizeX = sizeX; this.sizeY = sizeY;
        button.Location = new Point(x, y);
        button.Size = new Size(sizeX, sizeY);
        button.ForeColor = Color.DimGray;
        button.BackColor = Color.Transparent;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Text = buttonText;
        button.Font = font;
        button.Parent = canvas;
    }

    public void draw()
    {
        if (MousePosition.X > button.Location.X + 250 && MousePosition.X < button.Location.X + 350)
        {
            if (button.Text == "play game")
            {
                if (MousePosition.Y > 405 && MousePosition.Y < 435)
                    button.ForeColor = Color.WhiteSmoke;
                else
                    button.ForeColor = Color.DimGray;
            }

            else if (button.Text == "shop")
            {
                if (MousePosition.Y > 490 && MousePosition.Y < 520)
                    button.ForeColor = Color.WhiteSmoke;
                else
                    button.ForeColor = Color.DimGray;
            }

            else if (button.Text == "board")
            {
                if (MousePosition.Y > 580 && MousePosition.Y < 610)
                    button.ForeColor = Color.WhiteSmoke;
                else
                    button.ForeColor = Color.DimGray;
            }
        }
        else
            button.ForeColor = Color.DimGray;
    }

    public void update()
    {

    }

    public void visible(bool isVisible)
    {
        if (isVisible)
            button.Visible = true;
        else
            button.Visible = false;
    }
}