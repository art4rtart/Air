using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    public partial class CreditForm : Form
    {
        Bitmap[] creditImage = new Bitmap[3];
        DateTime updateFlag;

        Icon previous = new Icon(Air.Properties.Resources.icon_previous, 1, 1.0f, new Rectangle(10, 150, 65, 65), new RectangleF(0, 0, 132, 132));
        Icon next = new Icon(Air.Properties.Resources.icon_next, 1, 1.0f, new Rectangle(560, 150, 65, 65), new RectangleF(0, 0, 132, 132));
        Text pageText = new Text();

        float opacity = 0;
        float fadingSpeed = 0.02f;

        int imageIndex = 0;
        int fadingDir = 1;

        bool changeOpacity = true;
        bool goNext;
        bool goPrevious;

        public CreditForm()
        {
            InitializeComponent();
        }

        private void CreditForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(600, 350);
            canvas.ClientSize = new Size(450, 246);
            canvas.Location = new Point(this.Width / 2 - canvas.Width / 2 - 7, canvas.Location.Y);

            creditImage[0] = Air.Properties.Resources.credit_page1;
            creditImage[1] = Air.Properties.Resources.credit_page2;
            creditImage[2] = Air.Properties.Resources.credit_page3;

            previous.colorImage = Air.Properties.Resources.icon_cprevious;
            next.colorImage = Air.Properties.Resources.icon_cnext;

            pageText.init(540, 18, page, new Font("Agency FB", 13, page.Font.Style));

            canvas.Parent = this;

            updateFlag = DateTime.Now;
        }

        private void creditTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan deltaTime = DateTime.Now - updateFlag;
            int msec = (int)(deltaTime.Milliseconds / 10);

            pageText.update((imageIndex + 1) + " / 3");

            canvas.BackgroundImage = GameForm.ChangeOpacity(creditImage[imageIndex], opacity);

            if(changeOpacity)
                opacity += fadingSpeed * fadingDir * msec;

            if (opacity < 0)
            {
                opacity = 0;

                if (goNext)
                {
                    imageIndex++;
                    goNext = false;
                }

                if (goPrevious)
                {
                    imageIndex--;
                    goPrevious = false;
                }

                fadingDir *= -1;
            }

            if (opacity > 1)
            {
                opacity = 1;
                changeOpacity = false;
            }

            updateFlag = DateTime.Now;
            Invalidate();
        }

        private void CreditForm_Paint(object sender, PaintEventArgs e)
        {
            previous.draw(e.Graphics);
            next.draw(e.Graphics);
        }

        private void CreditForm_Click(object sender, EventArgs e)
        {
            if (next.active)
            {
                if (imageIndex < 2)
                {
                    goNext = true;
                    fadingDir *= -1;
                    changeOpacity = true;
                }
            }

            if (previous.active)
            {
                if (imageIndex > 0)
                {
                    goPrevious = true;
                    fadingDir *= -1;
                    changeOpacity = true;
                }
            }
        }

        private void CreditForm_MouseMove(object sender, MouseEventArgs e)
        {
            previous.handleMouseMoveEvent(e.Location);
            next.handleMouseMoveEvent(e.Location);
        }
    }
}
