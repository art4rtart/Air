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
            this.shopFrame = new System.Windows.Forms.PictureBox();
            this.starCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.clickToStart.Location = new System.Drawing.Point(420, 375);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1124, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.multiple);
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.airTankPercent);
            this.Controls.Add(this.distanceValue);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.clickToStart);
            this.Controls.Add(this.shopFrame);
            this.Controls.Add(this.play);
            this.Controls.Add(this.shop);
            this.Controls.Add(this.board);
            this.Controls.Add(this.starCount);
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
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Timer timerFunction;
    }
}

