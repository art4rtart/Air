namespace Air
{
    partial class CreditForm
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
            this.creditTimer = new System.Windows.Forms.Timer(this.components);
            this.canvas = new System.Windows.Forms.PictureBox();
            this.page = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // creditTimer
            // 
            this.creditTimer.Enabled = true;
            this.creditTimer.Interval = 1;
            this.creditTimer.Tick += new System.EventHandler(this.creditTimer_Tick);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.Transparent;
            this.canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.canvas.Location = new System.Drawing.Point(55, 60);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(500, 246);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreditForm_MouseMove);
            // 
            // page
            // 
            this.page.Location = new System.Drawing.Point(534, 19);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(48, 28);
            this.page.TabIndex = 1;
            this.page.Text = "1 / 3";
            this.page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Air.Properties.Resources.credit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.page);
            this.Controls.Add(this.canvas);
            this.DoubleBuffered = true;
            this.Name = "CreditForm";
            this.Text = "CreditForm";
            this.Load += new System.EventHandler(this.CreditForm_Load);
            this.Click += new System.EventHandler(this.CreditForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CreditForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreditForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer creditTimer;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label page;
    }
}