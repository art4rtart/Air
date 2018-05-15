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
            this.artk = new System.Windows.Forms.PictureBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.artk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // timerFunction
            // 
            this.timerFunction.Tick += new System.EventHandler(this.timerFunction_Tick);
            // 
            // distance
            // 
            this.distance.BackColor = System.Drawing.Color.Transparent;
            this.distance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.distance.Location = new System.Drawing.Point(570, 20);
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
            this.distanceValue.Location = new System.Drawing.Point(600, 48);
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
            this.clickToStart.Location = new System.Drawing.Point(423, 375);
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
            this.airTankPercent.AutoSize = true;
            this.airTankPercent.BackColor = System.Drawing.Color.Transparent;
            this.airTankPercent.Location = new System.Drawing.Point(889, 574);
            this.airTankPercent.Name = "airTankPercent";
            this.airTankPercent.Size = new System.Drawing.Size(37, 12);
            this.airTankPercent.TabIndex = 16;
            this.airTankPercent.Text = "100 %";
            this.airTankPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.airTankPercent.Visible = false;
            // 
            // velocity
            // 
            this.velocity.AutoSize = true;
            this.velocity.BackColor = System.Drawing.Color.Transparent;
            this.velocity.Location = new System.Drawing.Point(642, 574);
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(39, 12);
            this.velocity.TabIndex = 18;
            this.velocity.Text = "0 m/s";
            this.velocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.velocity.Visible = false;
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.Location = new System.Drawing.Point(620, 181);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(38, 12);
            this.play.TabIndex = 20;
            this.play.Text = "label1";
            this.play.Visible = false;
            this.play.Click += new System.EventHandler(this.playButton_Click);
            // 
            // shop
            // 
            this.shop.BackColor = System.Drawing.Color.Transparent;
            this.shop.Location = new System.Drawing.Point(620, 221);
            this.shop.Name = "shop";
            this.shop.Size = new System.Drawing.Size(38, 12);
            this.shop.TabIndex = 21;
            this.shop.Text = "label2";
            this.shop.Visible = false;
            this.shop.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Transparent;
            this.board.Location = new System.Drawing.Point(620, 264);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(38, 12);
            this.board.TabIndex = 22;
            this.board.Text = "label3";
            this.board.Visible = false;
            this.board.Click += new System.EventHandler(this.boardButton_Click);
            // 
            // artk
            // 
            this.artk.BackColor = System.Drawing.Color.SkyBlue;
            this.artk.Location = new System.Drawing.Point(267, 613);
            this.artk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.artk.Name = "artk";
            this.artk.Size = new System.Drawing.Size(813, 21);
            this.artk.TabIndex = 23;
            this.artk.TabStop = false;
            this.artk.Visible = false;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Transparent;
            this.canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1280, 720);
            this.canvas.TabIndex = 24;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.artk);
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.airTankPercent);
            this.Controls.Add(this.distanceValue);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.clickToStart);
            this.Controls.Add(this.play);
            this.Controls.Add(this.board);
            this.Controls.Add(this.shop);
            this.Controls.Add(this.canvas);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Air.";
            this.TransparencyKey = System.Drawing.Color.Sienna;
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.artk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerFunction;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Label distanceValue;
        private System.Windows.Forms.Label clickToStart;
        private System.Windows.Forms.Label airTankPercent;
        private System.Windows.Forms.Label velocity;
        private System.Windows.Forms.Label play;
        private System.Windows.Forms.Label shop;
        private System.Windows.Forms.Label board;
        private System.Windows.Forms.PictureBox artk;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label label1;
    }
}

