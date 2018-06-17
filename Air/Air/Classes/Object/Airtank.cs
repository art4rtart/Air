using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    public class Airtank
    {
        Bitmap image;
        Bitmap bar = Air.Properties.Resources.airtank_bar;
        RectangleF rect;
        Size size;
        Point location;

        public double maximum;
        public double minimum = 0;
        public double value;
        public double airgage = 1;
        public int airValue = 11;

        bool fly;
        
        public bool isFlying { set { fly = value; } }

        public Airtank(Bitmap bitmap, Point location)
        {
            this.image = bitmap;
            size = bitmap.Size;
            maximum = size.Width;
            value = maximum;
            minimum = 0;
            this.location = location;
            rect = new RectangleF(this.location.X, this.location.Y, size.Width, size.Height);
        }

        public void init()
        {
            value = maximum;
            size.Width = (int)value;
            rect = new RectangleF(this.location.X, this.location.Y, size.Width, size.Height);
        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, rect);
            g.DrawImage(bar, 270, 675, 750, 20);
        }

        public void update(int msec)
        {
            rect.Size = new Size((int)value, size.Height);

            if (fly)
            {
                if (value > minimum)
                {
                    value -= airValue * msec;
                }

                if (value < minimum)
                {
                    value = minimum;
                }
            }

            else
            {
                if (value < maximum)
                {
                    value += airgage * msec;
                }

                else if (value > maximum)
                {
                    value = (int)maximum;
                }
            }
        }
    }
}
