namespace Air
{
    partial class scoreForm
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
            this.timerFunction = new System.Windows.Forms.Timer(this.components);
            this.distance = new System.Windows.Forms.Label();
            this.youflight = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.Label();
            this.retry = new System.Windows.Forms.PictureBox();
            this.gotomenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.retry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gotomenu)).BeginInit();
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
            this.distance.ForeColor = System.Drawing.Color.Brown;
            this.distance.Location = new System.Drawing.Point(0, 0);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(197, 99);
            this.distance.TabIndex = 2;
            this.distance.Text = "10m";
            this.distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // youflight
            // 
            this.youflight.BackColor = System.Drawing.Color.Transparent;
            this.youflight.ForeColor = System.Drawing.Color.Brown;
            this.youflight.Location = new System.Drawing.Point(0, 0);
            this.youflight.Name = "youflight";
            this.youflight.Size = new System.Drawing.Size(197, 99);
            this.youflight.TabIndex = 3;
            this.youflight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comment
            // 
            this.comment.BackColor = System.Drawing.Color.Transparent;
            this.comment.ForeColor = System.Drawing.Color.Crimson;
            this.comment.Location = new System.Drawing.Point(0, 0);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(295, 99);
            this.comment.TabIndex = 4;
            this.comment.Text = "you fucked up :)";
            this.comment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retry
            // 
            this.retry.BackColor = System.Drawing.Color.Transparent;
            this.retry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.retry.Location = new System.Drawing.Point(170, 293);
            this.retry.Name = "retry";
            this.retry.Size = new System.Drawing.Size(52, 52);
            this.retry.TabIndex = 6;
            this.retry.TabStop = false;
            // 
            // gotomenu
            // 
            this.gotomenu.BackColor = System.Drawing.Color.Transparent;
            this.gotomenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gotomenu.Location = new System.Drawing.Point(290, 293);
            this.gotomenu.Name = "gotomenu";
            this.gotomenu.Size = new System.Drawing.Size(52, 52);
            this.gotomenu.TabIndex = 7;
            this.gotomenu.TabStop = false;
            // 
            // scoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 373);
            this.Controls.Add(this.gotomenu);
            this.Controls.Add(this.retry);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.youflight);
            this.Controls.Add(this.distance);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "scoreForm";
            this.Text = "scoreForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.scoreForm_FormClosed);
            this.Load += new System.EventHandler(this.scoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.retry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gotomenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerFunction;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Label youflight;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.PictureBox retry;
        private System.Windows.Forms.PictureBox gotomenu;
    }
}