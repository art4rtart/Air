using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class PineWheel
    {
        public List<Item> objects = new List<Item>();
        RectangleF rect;
        RectangleF srcRect;

        bool generate = true;
        float generateTime;

        bool startTimer = false;
        DateTime timeFlag;
        TimeSpan currentTime;

        public float setGenerateTime { set { generateTime = value; } }

        public PineWheel(RectangleF rect, RectangleF srcRect, float generateTime)
        {
            this.rect = rect;
            this.srcRect = srcRect;
            this.generateTime = generateTime;
        }

        public void draw(Graphics g)
        {
            foreach (var obj in objects)
                obj.draw(g);
        }

        public void update(int speed, int msec)
        {
            while (objects.Count > 0)
            {
                Item first = objects[0];

                var bounds = first.bounds;

                if (bounds.Right < 0)
                {
                    objects.RemoveAt(0);
                }

                else
                {
                    break;
                }
            }

            float x = 1280;

            if (objects.Count > 0)
            {
                var obj = objects[objects.Count - 1];
                var bounds = obj.bounds;
                x = bounds.Right;
            }

            if (x > 0 && generate)
            {
                appendObject(x);
                generate = false;
            }

            int dx = -speed * msec;

            foreach (var Obj in objects)
            {
                Obj.move(dx, 0);
                Obj.updateFrame(msec);

                if (Obj.bounds.Right < 0)
                {
                    startTimer = true;
                    timeFlag = DateTime.Now;
                }
            }

            if (startTimer)
            {
                currentTime = DateTime.Now - timeFlag;

                if (currentTime.TotalSeconds > generateTime)
                {
                    timeFlag = DateTime.Now;
                    generate = true;
                    startTimer = false;
                }
            }
        }

        private void appendObject(float x)
        {
            Item obj = new Item(Air.Properties.Resources.pinewheel, 3, 3.0f, rect, srcRect);
            obj.position(x, obj.bounds.Y);
            obj.tagName = "PineWheel";
            objects.Add(obj);
        }

        public string checkCollision(Player player)
        {
            //GameObject removedCoin = null;

            foreach (Item obj in objects)
            {
                if (obj.tagName == "PineWheel")
                {
                    if (obj.collides(player))
                    {
                        //removedCoin = obj;
                        return "PineWheel";
                    }
                }
            }

            return "Nothing";
            //if (removedCoin != null) {
            //    //playSOUnd();
            //}
        }
    }
}
