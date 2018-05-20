using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class Item : GameObject
    {
        public bool col;
        public float generateTime;
        public float timer;

        public Item(Bitmap bitmap, float generateTime) : base(bitmap)
        {
            generateItem();
            this.generateTime = generateTime;
        }

        public void update(int speed, int msec)
        {
            rect.X -= speed * msec;
        }

        public void generateItem()
        {
            Random random = new Random();

            rect = new RectangleF(rect.X, rect.Y, image.Width, image.Height);
        }

        public void collide(int x, int y)
        {
            if (rect.X > x && rect.X < x + 50 && rect.Y < y && rect.Y > y - 25)
            {
                col = true;
            }
        }
    }
}
