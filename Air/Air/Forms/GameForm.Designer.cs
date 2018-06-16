namespace Air
{
    partial class GameForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerFunction = new System.Windows.Forms.Timer(this.components);
            this.distance = new System.Windows.Forms.Label();
            this.distanceValue = new System.Windows.Forms.Label();
            this.clickToStart = new System.Windows.Forms.Label();
            this.airTankPercent = new System.Windows.Forms.Label();
            this.velocity = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Label();
            this.shop = new System.Windows.Forms.Label();
            this.board = new System.Windows.Forms.Label();
            this.multiple = new System.Windows.Forms.Label();
            this.starCount = new System.Windows.Forms.Label();
            this.currentValue = new System.Windows.Forms.Label();
            this.upgradeValue = new System.Windows.Forms.Label();
            this.purchase = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.Label();
            this.shopFrame = new System.Windows.Forms.PictureBox();
            this.to = new System.Windows.Forms.Label();
            this.flightDistnace = new System.Windows.Forms.Label();
            this.flightTime = new System.Windows.Forms.Label();
            this.maxVelocity = new System.Windows.Forms.Label();
            this.sceneName = new System.Windows.Forms.Label();
            this.rank = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flightDistance1 = new System.Windows.Forms.Label();
            this.flightTime1 = new System.Windows.Forms.Label();
            this.maxVeloctiy1 = new System.Windows.Forms.Label();
            this.flightDistance2 = new System.Windows.Forms.Label();
            this.flightTime2 = new System.Windows.Forms.Label();
            this.maxVeloctiy2 = new System.Windows.Forms.Label();
            this.flightDistance3 = new System.Windows.Forms.Label();
            this.flightTime3 = new System.Windows.Forms.Label();
            this.maxVeloctiy3 = new System.Windows.Forms.Label();
            this.flightDistance4 = new System.Windows.Forms.Label();
            this.flightTime4 = new System.Windows.Forms.Label();
            this.maxVeloctiy4 = new System.Windows.Forms.Label();
            this.flightDistance5 = new System.Windows.Forms.Label();
            this.flightTime5 = new System.Windows.Forms.Label();
            this.maxVeloctiy5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shopFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // timerFunction
            // 
            this.timerFunction.Enabled = true;
            this.timerFunction.Interval = 1;
            this.timerFunction.Tick += new System.EventHandler(this.timerFunction_Tick);
            // 
            // distance
            // 
            this.distance.BackColor = System.Drawing.Color.Transparent;
            this.distance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.distance.Location = new System.Drawing.Point(0, 0);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(140, 40);
            this.distance.TabIndex = 6;
            this.distance.Text = "flight distance";
            this.distance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.distance.Visible = false;
            // 
            // distanceValue
            // 
            this.distanceValue.BackColor = System.Drawing.Color.Transparent;
            this.distanceValue.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.distanceValue.Location = new System.Drawing.Point(0, 0);
            this.distanceValue.Name = "distanceValue";
            this.distanceValue.Size = new System.Drawing.Size(100, 39);
            this.distanceValue.TabIndex = 7;
            this.distanceValue.Text = "0 M";
            this.distanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.distanceValue.Visible = false;
            // 
            // clickToStart
            // 
            this.clickToStart.BackColor = System.Drawing.Color.Transparent;
            this.clickToStart.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.clickToStart.ForeColor = System.Drawing.Color.DimGray;
            this.clickToStart.Location = new System.Drawing.Point(0, 0);
            this.clickToStart.Name = "clickToStart";
            this.clickToStart.Size = new System.Drawing.Size(445, 70);
            this.clickToStart.TabIndex = 12;
            this.clickToStart.Text = "only mouse click :)";
            this.clickToStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clickToStart.Visible = false;
            this.clickToStart.Click += new System.EventHandler(this.canvas_Click);
            // 
            // airTankPercent
            // 
            this.airTankPercent.BackColor = System.Drawing.Color.Transparent;
            this.airTankPercent.Location = new System.Drawing.Point(0, 0);
            this.airTankPercent.Name = "airTankPercent";
            this.airTankPercent.Size = new System.Drawing.Size(87, 28);
            this.airTankPercent.TabIndex = 16;
            this.airTankPercent.Text = "100 %";
            this.airTankPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.airTankPercent.Visible = false;
            // 
            // velocity
            // 
            this.velocity.BackColor = System.Drawing.Color.Transparent;
            this.velocity.Location = new System.Drawing.Point(0, 0);
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(89, 28);
            this.velocity.TabIndex = 18;
            this.velocity.Text = "0 m/s";
            this.velocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.velocity.Visible = false;
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.ForeColor = System.Drawing.Color.DimGray;
            this.play.Location = new System.Drawing.Point(0, 0);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(149, 40);
            this.play.TabIndex = 20;
            this.play.Text = "play game";
            this.play.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.play.Visible = false;
            this.play.Click += new System.EventHandler(this.playButton_Click);
            // 
            // shop
            // 
            this.shop.BackColor = System.Drawing.Color.Transparent;
            this.shop.ForeColor = System.Drawing.Color.DimGray;
            this.shop.Location = new System.Drawing.Point(0, 0);
            this.shop.Name = "shop";
            this.shop.Size = new System.Drawing.Size(149, 40);
            this.shop.TabIndex = 21;
            this.shop.Text = "shop";
            this.shop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shop.Visible = false;
            this.shop.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Transparent;
            this.board.ForeColor = System.Drawing.Color.DimGray;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(149, 40);
            this.board.TabIndex = 22;
            this.board.Text = "board";
            this.board.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.board.Visible = false;
            this.board.Click += new System.EventHandler(this.boardButton_Click);
            // 
            // multiple
            // 
            this.multiple.AutoSize = true;
            this.multiple.BackColor = System.Drawing.Color.Transparent;
            this.multiple.ForeColor = System.Drawing.Color.Black;
            this.multiple.Location = new System.Drawing.Point(1, 1);
            this.multiple.Name = "multiple";
            this.multiple.Size = new System.Drawing.Size(12, 12);
            this.multiple.TabIndex = 23;
            this.multiple.Text = "x";
            this.multiple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.multiple.Visible = false;
            // 
            // starCount
            // 
            this.starCount.BackColor = System.Drawing.Color.Transparent;
            this.starCount.ForeColor = System.Drawing.Color.OrangeRed;
            this.starCount.Location = new System.Drawing.Point(0, 1);
            this.starCount.Name = "starCount";
            this.starCount.Size = new System.Drawing.Size(158, 67);
            this.starCount.TabIndex = 25;
            this.starCount.Text = "2013180043";
            this.starCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.starCount.Visible = false;
            // 
            // currentValue
            // 
            this.currentValue.BackColor = System.Drawing.Color.Transparent;
            this.currentValue.Location = new System.Drawing.Point(0, 0);
            this.currentValue.Name = "currentValue";
            this.currentValue.Size = new System.Drawing.Size(69, 29);
            this.currentValue.TabIndex = 26;
            this.currentValue.Text = "label1";
            this.currentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentValue.Visible = false;
            // 
            // upgradeValue
            // 
            this.upgradeValue.BackColor = System.Drawing.Color.Transparent;
            this.upgradeValue.ForeColor = System.Drawing.Color.OrangeRed;
            this.upgradeValue.Location = new System.Drawing.Point(0, 0);
            this.upgradeValue.Name = "upgradeValue";
            this.upgradeValue.Size = new System.Drawing.Size(69, 28);
            this.upgradeValue.TabIndex = 26;
            this.upgradeValue.Text = "label1";
            this.upgradeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgradeValue.Visible = false;
            // 
            // purchase
            // 
            this.purchase.BackColor = System.Drawing.Color.Transparent;
            this.purchase.Location = new System.Drawing.Point(0, 0);
            this.purchase.Name = "purchase";
            this.purchase.Size = new System.Drawing.Size(371, 40);
            this.purchase.TabIndex = 26;
            this.purchase.Text = "label1";
            this.purchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchase.Visible = false;
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.Transparent;
            this.itemName.ForeColor = System.Drawing.Color.Firebrick;
            this.itemName.Location = new System.Drawing.Point(0, 0);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(200, 41);
            this.itemName.TabIndex = 26;
            this.itemName.Text = "label1";
            this.itemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.itemName.Visible = false;
            // 
            // shopFrame
            // 
            this.shopFrame.BackColor = System.Drawing.Color.Transparent;
            this.shopFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shopFrame.Location = new System.Drawing.Point(0, 0);
            this.shopFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.shopFrame.Name = "shopFrame";
            this.shopFrame.Size = new System.Drawing.Size(296, 232);
            this.shopFrame.TabIndex = 24;
            this.shopFrame.TabStop = false;
            this.shopFrame.Visible = false;
            this.shopFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.shopCanvas_Paint);
            // 
            // to
            // 
            this.to.BackColor = System.Drawing.Color.Transparent;
            this.to.Location = new System.Drawing.Point(0, 0);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(32, 31);
            this.to.TabIndex = 27;
            this.to.Text = "→";
            this.to.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.to.Visible = false;
            // 
            // flightDistnace
            // 
            this.flightDistnace.BackColor = System.Drawing.Color.Transparent;
            this.flightDistnace.ForeColor = System.Drawing.Color.MidnightBlue;
            this.flightDistnace.Location = new System.Drawing.Point(0, 0);
            this.flightDistnace.Name = "flightDistnace";
            this.flightDistnace.Size = new System.Drawing.Size(116, 70);
            this.flightDistnace.TabIndex = 28;
            this.flightDistnace.Text = "distance";
            this.flightDistnace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightDistnace.Visible = false;
            // 
            // flightTime
            // 
            this.flightTime.BackColor = System.Drawing.Color.Transparent;
            this.flightTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.flightTime.Location = new System.Drawing.Point(0, 0);
            this.flightTime.Name = "flightTime";
            this.flightTime.Size = new System.Drawing.Size(121, 72);
            this.flightTime.TabIndex = 28;
            this.flightTime.Text = "time";
            this.flightTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightTime.Visible = false;
            // 
            // maxVelocity
            // 
            this.maxVelocity.BackColor = System.Drawing.Color.Transparent;
            this.maxVelocity.ForeColor = System.Drawing.Color.MidnightBlue;
            this.maxVelocity.Location = new System.Drawing.Point(0, 0);
            this.maxVelocity.Name = "maxVelocity";
            this.maxVelocity.Size = new System.Drawing.Size(121, 72);
            this.maxVelocity.TabIndex = 28;
            this.maxVelocity.Text = "velocity";
            this.maxVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxVelocity.Visible = false;
            // 
            // sceneName
            // 
            this.sceneName.BackColor = System.Drawing.Color.Transparent;
            this.sceneName.ForeColor = System.Drawing.Color.Black;
            this.sceneName.Location = new System.Drawing.Point(0, 0);
            this.sceneName.Name = "sceneName";
            this.sceneName.Size = new System.Drawing.Size(151, 60);
            this.sceneName.TabIndex = 28;
            this.sceneName.Text = "sceneName";
            this.sceneName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sceneName.Visible = false;
            // 
            // rank
            // 
            this.rank.BackColor = System.Drawing.Color.Transparent;
            this.rank.ForeColor = System.Drawing.Color.Firebrick;
            this.rank.Location = new System.Drawing.Point(0, 0);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(121, 72);
            this.rank.TabIndex = 28;
            this.rank.Text = "rank";
            this.rank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rank.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 41);
            this.label1.TabIndex = 28;
            this.label1.Text = "1.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 41);
            this.label2.TabIndex = 28;
            this.label2.Text = "2.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 41);
            this.label3.TabIndex = 28;
            this.label3.Text = "3.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 41);
            this.label4.TabIndex = 28;
            this.label4.Text = "4.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 41);
            this.label5.TabIndex = 28;
            this.label5.Text = "5.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // flightDistance1
            // 
            this.flightDistance1.BackColor = System.Drawing.Color.Transparent;
            this.flightDistance1.ForeColor = System.Drawing.Color.DarkRed;
            this.flightDistance1.Location = new System.Drawing.Point(0, 0);
            this.flightDistance1.Name = "flightDistance1";
            this.flightDistance1.Size = new System.Drawing.Size(124, 41);
            this.flightDistance1.TabIndex = 28;
            this.flightDistance1.Text = "0";
            this.flightDistance1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightDistance1.Visible = false;
            // 
            // flightTime1
            // 
            this.flightTime1.BackColor = System.Drawing.Color.Transparent;
            this.flightTime1.ForeColor = System.Drawing.Color.DarkRed;
            this.flightTime1.Location = new System.Drawing.Point(0, 0);
            this.flightTime1.Name = "flightTime1";
            this.flightTime1.Size = new System.Drawing.Size(124, 41);
            this.flightTime1.TabIndex = 28;
            this.flightTime1.Text = "0";
            this.flightTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightTime1.Visible = false;
            // 
            // maxVeloctiy1
            // 
            this.maxVeloctiy1.BackColor = System.Drawing.Color.Transparent;
            this.maxVeloctiy1.ForeColor = System.Drawing.Color.DarkRed;
            this.maxVeloctiy1.Location = new System.Drawing.Point(0, 0);
            this.maxVeloctiy1.Name = "maxVeloctiy1";
            this.maxVeloctiy1.Size = new System.Drawing.Size(124, 41);
            this.maxVeloctiy1.TabIndex = 28;
            this.maxVeloctiy1.Text = "0";
            this.maxVeloctiy1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxVeloctiy1.Visible = false;
            // 
            // flightDistance2
            // 
            this.flightDistance2.BackColor = System.Drawing.Color.Transparent;
            this.flightDistance2.ForeColor = System.Drawing.Color.DimGray;
            this.flightDistance2.Location = new System.Drawing.Point(0, 0);
            this.flightDistance2.Name = "flightDistance2";
            this.flightDistance2.Size = new System.Drawing.Size(124, 41);
            this.flightDistance2.TabIndex = 28;
            this.flightDistance2.Text = "0";
            this.flightDistance2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightDistance2.Visible = false;
            // 
            // flightTime2
            // 
            this.flightTime2.BackColor = System.Drawing.Color.Transparent;
            this.flightTime2.ForeColor = System.Drawing.Color.DimGray;
            this.flightTime2.Location = new System.Drawing.Point(0, 0);
            this.flightTime2.Name = "flightTime2";
            this.flightTime2.Size = new System.Drawing.Size(124, 41);
            this.flightTime2.TabIndex = 28;
            this.flightTime2.Text = "0";
            this.flightTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightTime2.Visible = false;
            // 
            // maxVeloctiy2
            // 
            this.maxVeloctiy2.BackColor = System.Drawing.Color.Transparent;
            this.maxVeloctiy2.ForeColor = System.Drawing.Color.DimGray;
            this.maxVeloctiy2.Location = new System.Drawing.Point(0, 0);
            this.maxVeloctiy2.Name = "maxVeloctiy2";
            this.maxVeloctiy2.Size = new System.Drawing.Size(124, 41);
            this.maxVeloctiy2.TabIndex = 28;
            this.maxVeloctiy2.Text = "0";
            this.maxVeloctiy2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxVeloctiy2.Visible = false;
            // 
            // flightDistance3
            // 
            this.flightDistance3.BackColor = System.Drawing.Color.Transparent;
            this.flightDistance3.ForeColor = System.Drawing.Color.DimGray;
            this.flightDistance3.Location = new System.Drawing.Point(0, 0);
            this.flightDistance3.Name = "flightDistance3";
            this.flightDistance3.Size = new System.Drawing.Size(124, 41);
            this.flightDistance3.TabIndex = 28;
            this.flightDistance3.Text = "0";
            this.flightDistance3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightDistance3.Visible = false;
            // 
            // flightTime3
            // 
            this.flightTime3.BackColor = System.Drawing.Color.Transparent;
            this.flightTime3.ForeColor = System.Drawing.Color.DimGray;
            this.flightTime3.Location = new System.Drawing.Point(0, 0);
            this.flightTime3.Name = "flightTime3";
            this.flightTime3.Size = new System.Drawing.Size(124, 41);
            this.flightTime3.TabIndex = 28;
            this.flightTime3.Text = "0";
            this.flightTime3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightTime3.Visible = false;
            // 
            // maxVeloctiy3
            // 
            this.maxVeloctiy3.BackColor = System.Drawing.Color.Transparent;
            this.maxVeloctiy3.ForeColor = System.Drawing.Color.DimGray;
            this.maxVeloctiy3.Location = new System.Drawing.Point(0, 0);
            this.maxVeloctiy3.Name = "maxVeloctiy3";
            this.maxVeloctiy3.Size = new System.Drawing.Size(124, 41);
            this.maxVeloctiy3.TabIndex = 28;
            this.maxVeloctiy3.Text = "0";
            this.maxVeloctiy3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxVeloctiy3.Visible = false;
            // 
            // flightDistance4
            // 
            this.flightDistance4.BackColor = System.Drawing.Color.Transparent;
            this.flightDistance4.ForeColor = System.Drawing.Color.DimGray;
            this.flightDistance4.Location = new System.Drawing.Point(0, 0);
            this.flightDistance4.Name = "flightDistance4";
            this.flightDistance4.Size = new System.Drawing.Size(124, 41);
            this.flightDistance4.TabIndex = 28;
            this.flightDistance4.Text = "0";
            this.flightDistance4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightDistance4.Visible = false;
            // 
            // flightTime4
            // 
            this.flightTime4.BackColor = System.Drawing.Color.Transparent;
            this.flightTime4.ForeColor = System.Drawing.Color.DimGray;
            this.flightTime4.Location = new System.Drawing.Point(0, 0);
            this.flightTime4.Name = "flightTime4";
            this.flightTime4.Size = new System.Drawing.Size(124, 41);
            this.flightTime4.TabIndex = 28;
            this.flightTime4.Text = "0";
            this.flightTime4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightTime4.Visible = false;
            // 
            // maxVeloctiy4
            // 
            this.maxVeloctiy4.BackColor = System.Drawing.Color.Transparent;
            this.maxVeloctiy4.ForeColor = System.Drawing.Color.DimGray;
            this.maxVeloctiy4.Location = new System.Drawing.Point(0, 0);
            this.maxVeloctiy4.Name = "maxVeloctiy4";
            this.maxVeloctiy4.Size = new System.Drawing.Size(124, 41);
            this.maxVeloctiy4.TabIndex = 28;
            this.maxVeloctiy4.Text = "0";
            this.maxVeloctiy4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxVeloctiy4.Visible = false;
            // 
            // flightDistance5
            // 
            this.flightDistance5.BackColor = System.Drawing.Color.Transparent;
            this.flightDistance5.ForeColor = System.Drawing.Color.DimGray;
            this.flightDistance5.Location = new System.Drawing.Point(0, 0);
            this.flightDistance5.Name = "flightDistance5";
            this.flightDistance5.Size = new System.Drawing.Size(124, 41);
            this.flightDistance5.TabIndex = 28;
            this.flightDistance5.Text = "0";
            this.flightDistance5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightDistance5.Visible = false;
            // 
            // flightTime5
            // 
            this.flightTime5.BackColor = System.Drawing.Color.Transparent;
            this.flightTime5.ForeColor = System.Drawing.Color.DimGray;
            this.flightTime5.Location = new System.Drawing.Point(0, 0);
            this.flightTime5.Name = "flightTime5";
            this.flightTime5.Size = new System.Drawing.Size(124, 41);
            this.flightTime5.TabIndex = 28;
            this.flightTime5.Text = "0";
            this.flightTime5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flightTime5.Visible = false;
            // 
            // maxVeloctiy5
            // 
            this.maxVeloctiy5.BackColor = System.Drawing.Color.Transparent;
            this.maxVeloctiy5.ForeColor = System.Drawing.Color.DimGray;
            this.maxVeloctiy5.Location = new System.Drawing.Point(0, 0);
            this.maxVeloctiy5.Name = "maxVeloctiy5";
            this.maxVeloctiy5.Size = new System.Drawing.Size(124, 41);
            this.maxVeloctiy5.TabIndex = 28;
            this.maxVeloctiy5.Text = "0";
            this.maxVeloctiy5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxVeloctiy5.Visible = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1124, 681);
            this.Controls.Add(this.maxVelocity);
            this.Controls.Add(this.sceneName);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.flightTime);
            this.Controls.Add(this.maxVeloctiy5);
            this.Controls.Add(this.flightTime5);
            this.Controls.Add(this.maxVeloctiy4);
            this.Controls.Add(this.flightTime4);
            this.Controls.Add(this.maxVeloctiy3);
            this.Controls.Add(this.flightTime3);
            this.Controls.Add(this.flightDistance5);
            this.Controls.Add(this.maxVeloctiy2);
            this.Controls.Add(this.flightDistance4);
            this.Controls.Add(this.flightTime2);
            this.Controls.Add(this.flightDistance3);
            this.Controls.Add(this.maxVeloctiy1);
            this.Controls.Add(this.flightDistance2);
            this.Controls.Add(this.flightTime1);
            this.Controls.Add(this.flightDistance1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flightDistnace);
            this.Controls.Add(this.to);
            this.Controls.Add(this.upgradeValue);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.currentValue);
            this.Controls.Add(this.multiple);
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.airTankPercent);
            this.Controls.Add(this.distanceValue);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.play);
            this.Controls.Add(this.shop);
            this.Controls.Add(this.board);
            this.Controls.Add(this.starCount);
            this.Controls.Add(this.shopFrame);
            this.Controls.Add(this.purchase);
            this.Controls.Add(this.clickToStart);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Air.";
            this.TransparencyKey = System.Drawing.SystemColors.MenuHighlight;
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Click += new System.EventHandler(this.canvas_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.inGameCanvas_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.shopFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Label distanceValue;
        private System.Windows.Forms.Label clickToStart;
        private System.Windows.Forms.Label airTankPercent;
        private System.Windows.Forms.Label velocity;
        private System.Windows.Forms.Label play;
        private System.Windows.Forms.Label shop;
        private System.Windows.Forms.Label board;
        private System.Windows.Forms.Label multiple;
        private System.Windows.Forms.PictureBox shopFrame;
        private System.Windows.Forms.Label starCount;
        internal System.Windows.Forms.Timer timerFunction;
        private System.Windows.Forms.Label currentValue;
        private System.Windows.Forms.Label upgradeValue;
        private System.Windows.Forms.Label purchase;
        private System.Windows.Forms.Label itemName;
        private System.Windows.Forms.Label to;
        private System.Windows.Forms.Label flightDistnace;
        private System.Windows.Forms.Label flightTime;
        private System.Windows.Forms.Label maxVelocity;
        private System.Windows.Forms.Label sceneName;
        private System.Windows.Forms.Label rank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label flightDistance1;
        private System.Windows.Forms.Label flightTime1;
        private System.Windows.Forms.Label maxVeloctiy1;
        private System.Windows.Forms.Label flightDistance2;
        private System.Windows.Forms.Label flightTime2;
        private System.Windows.Forms.Label maxVeloctiy2;
        private System.Windows.Forms.Label flightDistance3;
        private System.Windows.Forms.Label flightTime3;
        private System.Windows.Forms.Label maxVeloctiy3;
        private System.Windows.Forms.Label flightDistance4;
        private System.Windows.Forms.Label flightTime4;
        private System.Windows.Forms.Label maxVeloctiy4;
        private System.Windows.Forms.Label flightDistance5;
        private System.Windows.Forms.Label flightTime5;
        private System.Windows.Forms.Label maxVeloctiy5;
    }
}

