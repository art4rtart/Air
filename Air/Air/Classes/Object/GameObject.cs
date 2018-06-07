using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air
{
    class GameObject
    {
        protected Bitmap image;
        protected RectangleF rect;
        protected RectangleF srcRect;
        public Size size;
        public bool isCheckable;

        public GameObject(Bitmap bitmap)
        {
            this.image = bitmap;
            size = bitmap.Size;
            rect = new RectangleF(0, 0, size.Width, size.Height);
        }

        public Bitmap getImage {  get { return image; } set { this.image = value; } }

        public RectangleF bounds { get { return rect; } set { this.rect = value; } }

        public RectangleF src { get { return srcRect; } set { this.srcRect = value; } }

        public virtual RectangleF collisionBounds { get { return rect; } }

        public virtual void draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }

        public void position(float x, float y)
        {
            rect.X = x;
            rect.Y = y;
        }

        public void move(float dx, float dy)
        {
            rect.X += dx;
            rect.Y += dy;
        }

        public virtual void handleKeyDownEvent(Keys keyCode) { }

        public virtual void updateFrame(int msec) { }

        public bool collides(Player other)
        {
            return this.collisionBounds.IntersectsWith(other.collisionBounds);
        }
    }
}
