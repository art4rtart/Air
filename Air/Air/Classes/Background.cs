using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class Background
    {
        Bitmap image;
        Point bgOffset, location;

        public Background(Bitmap bitmap, Point location)
        {
            this.image = bitmap;
            Size size = image.Size;
            this.location = location;
        }

        public void draw(Graphics g)
        {
            for (int x = bgOffset.X; x < image.Size.Width; x += image.Size.Width)
            {
                g.DrawImage(image, x, this.location.Y, image.Size.Width, image.Size.Height);
            }
        }

        public void update(int speed, int msec)
        {
            bgOffset.X -= speed * msec;

            if (bgOffset.X < -image.Size.Width)
            {
                bgOffset.X += image.Size.Width;
            }
        }
    }
}
