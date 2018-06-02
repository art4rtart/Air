namespace Air
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.soundBar = new System.Windows.Forms.TrackBar();
            this.volume = new System.Windows.Forms.Label();
            this.settingTimer = new System.Windows.Forms.Timer(this.components);
            this.like = new System.Windows.Forms.Label();
            this.credit = new System.Windows.Forms.Label();
            this.homepage = new System.Windows.Forms.Label();
            this.setting = new System.Windows.Forms.Label();
            this.off = new System.Windows.Forms.Label();
            this.on = new System.Windows.Forms.Label();
            this.and = new System.Windows.Forms.Label();
            this.isButton = new System.Windows.Forms.Label();
            this.hyperlink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.soundBar)).BeginInit();
            this.SuspendLayout();
            // 
            // soundBar
            // 
            this.soundBar.BackColor = System.Drawing.SystemColors.Control;
            this.soundBar.LargeChange = 2;
            this.soundBar.Location = new System.Drawing.Point(170, 75);
            this.soundBar.Name = "soundBar";
            this.soundBar.Size = new System.Drawing.Size(207, 45);
            this.soundBar.TabIndex = 1;
            this.soundBar.Value = 7;
            this.soundBar.ValueChanged += new System.EventHandler(this.soundBar_ValueChanged);
            // 
            // volume
            // 
            this.volume.BackColor = System.Drawing.Color.Transparent;
            this.volume.ForeColor = System.Drawing.Color.DimGray;
            this.volume.Location = new System.Drawing.Point(0, 0);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(100, 50);
            this.volume.TabIndex = 2;
            this.volume.Text = "set volume :)";
            this.volume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingTimer
            // 
            this.settingTimer.Enabled = true;
            this.settingTimer.Interval = 1;
            this.settingTimer.Tick += new System.EventHandler(this.settingTimer_Tick);
            // 
            // like
            // 
            this.like.BackColor = System.Drawing.Color.Transparent;
            this.like.ForeColor = System.Drawing.Color.DimGray;
            this.like.Location = new System.Drawing.Point(0, 0);
            this.like.Name = "like";
            this.like.Size = new System.Drawing.Size(100, 50);
            this.like.TabIndex = 4;
            this.like.Text = "like me :)";
            this.like.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // credit
            // 
            this.credit.BackColor = System.Drawing.Color.Transparent;
            this.credit.ForeColor = System.Drawing.Color.DimGray;
            this.credit.Location = new System.Drawing.Point(0, 0);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(100, 50);
            this.credit.TabIndex = 5;
            this.credit.Text = "see credit :)";
            this.credit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homepage
            // 
            this.homepage.BackColor = System.Drawing.Color.Transparent;
            this.homepage.ForeColor = System.Drawing.Color.DimGray;
            this.homepage.Location = new System.Drawing.Point(0, 0);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(100, 50);
            this.homepage.TabIndex = 6;
            this.homepage.Text = "visit homepage :)";
            this.homepage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setting
            // 
            this.setting.BackColor = System.Drawing.Color.Transparent;
            this.setting.Location = new System.Drawing.Point(12, 163);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(100, 50);
            this.setting.TabIndex = 7;
            this.setting.Text = "setting";
            this.setting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // off
            // 
            this.off.BackColor = System.Drawing.Color.Transparent;
            this.off.ForeColor = System.Drawing.Color.DimGray;
            this.off.Location = new System.Drawing.Point(0, 0);
            this.off.Name = "off";
            this.off.Size = new System.Drawing.Size(100, 50);
            this.off.TabIndex = 8;
            this.off.Text = "off";
            this.off.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.off.Click += new System.EventHandler(this.off_Click);
            // 
            // on
            // 
            this.on.BackColor = System.Drawing.Color.Transparent;
            this.on.ForeColor = System.Drawing.Color.DimGray;
            this.on.Location = new System.Drawing.Point(0, 0);
            this.on.Name = "on";
            this.on.Size = new System.Drawing.Size(100, 50);
            this.on.TabIndex = 9;
            this.on.Text = "on";
            this.on.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.on.Click += new System.EventHandler(this.on_Click);
            // 
            // and
            // 
            this.and.AutoSize = true;
            this.and.BackColor = System.Drawing.Color.Transparent;
            this.and.ForeColor = System.Drawing.Color.DimGray;
            this.and.Location = new System.Drawing.Point(0, 0);
            this.and.Name = "and";
            this.and.Size = new System.Drawing.Size(11, 12);
            this.and.TabIndex = 10;
            this.and.Text = "/";
            // 
            // isButton
            // 
            this.isButton.AutoSize = true;
            this.isButton.BackColor = System.Drawing.Color.Transparent;
            this.isButton.ForeColor = System.Drawing.Color.Black;
            this.isButton.Location = new System.Drawing.Point(0, 0);
            this.isButton.Name = "isButton";
            this.isButton.Size = new System.Drawing.Size(109, 12);
            this.isButton.TabIndex = 11;
            this.isButton.Text = "this is button !   ←";
            // 
            // hyperlink
            // 
            this.hyperlink.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.hyperlink.BackColor = System.Drawing.Color.Transparent;
            this.hyperlink.DisabledLinkColor = System.Drawing.Color.Transparent;
            this.hyperlink.ForeColor = System.Drawing.Color.Transparent;
            this.hyperlink.LinkColor = System.Drawing.Color.Transparent;
            this.hyperlink.Location = new System.Drawing.Point(0, 0);
            this.hyperlink.Name = "hyperlink";
            this.hyperlink.Size = new System.Drawing.Size(51, 45);
            this.hyperlink.TabIndex = 12;
            this.hyperlink.TabStop = true;
            this.hyperlink.Text = "＃＃＃＃＃＃＃＃＃＃＃＃＃＃＃＃";
            this.hyperlink.VisitedLinkColor = System.Drawing.Color.Transparent;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 291);
            this.Controls.Add(this.hyperlink);
            this.Controls.Add(this.isButton);
            this.Controls.Add(this.and);
            this.Controls.Add(this.on);
            this.Controls.Add(this.off);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.homepage);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.like);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.soundBar);
            this.DoubleBuffered = true;
            this.Name = "SettingForm";
            this.Text = "settingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.settingForm_FormClosed);
            this.Load += new System.EventHandler(this.settingForm_Load);
            this.Click += new System.EventHandler(this.SettingForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SettingForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.soundBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar soundBar;
        private System.Windows.Forms.Label volume;
        private System.Windows.Forms.Timer settingTimer;
        private System.Windows.Forms.Label like;
        private System.Windows.Forms.Label credit;
        private System.Windows.Forms.Label homepage;
        private System.Windows.Forms.Label setting;
        private System.Windows.Forms.Label off;
        private System.Windows.Forms.Label on;
        private System.Windows.Forms.Label and;
        private System.Windows.Forms.Label isButton;
        private System.Windows.Forms.LinkLabel hyperlink;
    }
}