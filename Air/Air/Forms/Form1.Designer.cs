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
            this.clickToReplay = new System.Windows.Forms.Label();
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
            this.distance.Size = new System.Drawing.Size(172, 79);
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
            this.youflight.Size = new System.Drawing.Size(172, 79);
            this.youflight.TabIndex = 3;
            this.youflight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comment
            // 
            this.comment.BackColor = System.Drawing.Color.Transparent;
            this.comment.ForeColor = System.Drawing.Color.Crimson;
            this.comment.Location = new System.Drawing.Point(0, 0);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(509, 79);
            this.comment.TabIndex = 4;
            this.comment.Text = "you screwed up :)";
            this.comment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clickToReplay
            // 
            this.clickToReplay.BackColor = System.Drawing.Color.Transparent;
            this.clickToReplay.Location = new System.Drawing.Point(0, 0);
            this.clickToReplay.Name = "clickToReplay";
            this.clickToReplay.Size = new System.Drawing.Size(172, 45);
            this.clickToReplay.TabIndex = 8;
            this.clickToReplay.Text = "click to replay !";
            this.clickToReplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clickToReplay.Visible = false;
            // 
            // scoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 298);
            this.Controls.Add(this.clickToReplay);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.youflight);
            this.Controls.Add(this.distance);
            this.DoubleBuffered = true;
            this.Name = "scoreForm";
            this.Text = "scoreForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.scoreForm_FormClosed);
            this.Load += new System.EventHandler(this.scoreForm_Load);
            this.Click += new System.EventHandler(this.scoreForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.scoreForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerFunction;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Label youflight;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.Label clickToReplay;
    }
}