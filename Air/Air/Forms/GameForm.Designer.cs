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
            this.shopText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerFunction
            // 
            this.timerFunction.Interval = 1000;
            this.timerFunction.Tick += new System.EventHandler(this.timerFunction_Tick);
            // 
            // distance
            // 
            this.distance.BackColor = System.Drawing.Color.Transparent;
            this.distance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.distance.Location = new System.Drawing.Point(651, 25);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(160, 50);
            this.distance.TabIndex = 6;
            this.distance.Text = "flight distance";
            this.distance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.distance.Visible = false;
            // 
            // distanceValue
            // 
            this.distanceValue.BackColor = System.Drawing.Color.Transparent;
            this.distanceValue.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.distanceValue.Location = new System.Drawing.Point(686, 60);
            this.distanceValue.Name = "distanceValue";
            this.distanceValue.Size = new System.Drawing.Size(114, 49);
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
            this.clickToStart.Location = new System.Drawing.Point(480, 469);
            this.clickToStart.Name = "clickToStart";
            this.clickToStart.Size = new System.Drawing.Size(509, 88);
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
            this.airTankPercent.Location = new System.Drawing.Point(1016, 718);
            this.airTankPercent.Name = "airTankPercent";
            this.airTankPercent.Size = new System.Drawing.Size(47, 15);
            this.airTankPercent.TabIndex = 16;
            this.airTankPercent.Text = "100 %";
            this.airTankPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.airTankPercent.Visible = false;
            // 
            // velocity
            // 
            this.velocity.AutoSize = true;
            this.velocity.BackColor = System.Drawing.Color.Transparent;
            this.velocity.Location = new System.Drawing.Point(734, 718);
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(45, 15);
            this.velocity.TabIndex = 18;
            this.velocity.Text = "0 m/s";
            this.velocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.velocity.Visible = false;
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.ForeColor = System.Drawing.Color.DimGray;
            this.play.Location = new System.Drawing.Point(650, 372);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(170, 50);
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
            this.shop.Location = new System.Drawing.Point(650, 472);
            this.shop.Name = "shop";
            this.shop.Size = new System.Drawing.Size(170, 50);
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
            this.board.Location = new System.Drawing.Point(650, 572);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(170, 50);
            this.board.TabIndex = 22;
            this.board.Text = "board";
            this.board.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.board.Visible = false;
            this.board.Click += new System.EventHandler(this.boardButton_Click);
            // 
            // shopText
            // 
            this.shopText.AutoSize = true;
            this.shopText.BackColor = System.Drawing.Color.Transparent;
            this.shopText.ForeColor = System.Drawing.Color.Black;
            this.shopText.Location = new System.Drawing.Point(61, 114);
            this.shopText.Name = "shopText";
            this.shopText.Size = new System.Drawing.Size(40, 15);
            this.shopText.TabIndex = 23;
            this.shopText.Text = "shop";
            this.shopText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1445, 851);
            this.Controls.Add(this.shopText);
            this.Controls.Add(this.play);
            this.Controls.Add(this.shop);
            this.Controls.Add(this.board);
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.airTankPercent);
            this.Controls.Add(this.distanceValue);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.clickToStart);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Air.";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Click += new System.EventHandler(this.canvas_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
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
        private System.Windows.Forms.Label shopText;
    }
}

