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
        Point bgOffset;
        public Point location;
        public Point initLocation;
        public int y;

        public Background(Bitmap bitmap, Point location)
        {
            this.image = bitmap;
            Size size = image.Size;
            this.location = location;
            this.initLocation = this.location;
            y = location.Y;
        }

        public void draw(Graphics g)
        {
            for (int x = bgOffset.X; x < image.Size.Width; x += image.Size.Width)
            {
                g.DrawImage(image, x, this.location.Y, image.Size.Width, image.Size.Height);
            }
        }

        public void init()
        {
            this.location = initLocation;
            y = this.location.Y;
            bgOffset = new Point(0, 0);
        }

        public void update(int speed, int msec)
        {
            move(speed * msec, 0);
            
            if (bgOffset.X < -image.Size.Width)
            {
                bgOffset.X += image.Size.Width;
            }
        }

        public void move(int x, int y)
        {
            bgOffset.X -= x;
            this.location.Y += y;
        }
    }
}
