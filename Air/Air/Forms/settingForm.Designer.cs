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
            this.search = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soundBar)).BeginInit();
            this.SuspendLayout();
            // 
            // soundBar
            // 
            this.soundBar.BackColor = System.Drawing.SystemColors.Control;
            this.soundBar.LargeChange = 2;
            this.soundBar.Location = new System.Drawing.Point(168, 86);
            this.soundBar.Name = "soundBar";
            this.soundBar.Size = new System.Drawing.Size(207, 45);
            this.soundBar.TabIndex = 1;
            this.soundBar.Value = 7;
            this.soundBar.ValueChanged += new System.EventHandler(this.soundBar_ValueChanged);
            // 
            // volume
            // 
            this.volume.BackColor = System.Drawing.Color.Transparent;
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
            this.credit.Location = new System.Drawing.Point(0, 0);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(100, 50);
            this.credit.TabIndex = 5;
            this.credit.Text = "see credit :)";
            this.credit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.Location = new System.Drawing.Point(0, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(100, 50);
            this.search.TabIndex = 6;
            this.search.Text = "go to homepage :)";
            this.search.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 291);
            this.Controls.Add(this.search);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.like);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.soundBar);
            this.DoubleBuffered = true;
            this.Name = "SettingForm";
            this.Text = "settingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.settingForm_FormClosed);
            this.Load += new System.EventHandler(this.settingForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingForm_Paint);
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
        private System.Windows.Forms.Label search;
    }
}