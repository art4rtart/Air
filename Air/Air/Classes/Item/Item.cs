using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air
{
    class Item
    {
        public List<AnimObject> objects = new List<AnimObject>();

        public bool effect;
        public int count;

        bool generate = true;
        float generateTime = 0;

        public bool startTimer = false;
        DateTime timeFlag;
        TimeSpan currentTime;

        DateTime startTime;
        TimeSpan totalTime;

        Bitmap image;
        int frameCount;
        float framesPerSecond;
        RectangleF rect;
        RectangleF srcRect;
        string tagName;

        public Item(Bitmap bitmap, int frameCount, float framesPerSecond, RectangleF rect, RectangleF srcRect, string tagName, float generateTime)
        {
            this.image = bitmap;
            this.frameCount = frameCount;
            this.framesPerSecond = framesPerSecond;
            this.rect = rect;
            this.srcRect = srcRect;
            this.tagName = tagName;
            this.generateTime = generateTime;
        }

        public float setGenerateTime { set { generateTime = value; } }

        public List<AnimObject> obj { get { return objects; } }

        public void draw(Graphics g)
        {
            foreach (var obj in objects)
                obj.draw(g);
        }

        public void update(int speed, int msec)
        {
            float x = 1280;

            while (objects.Count > 0)
            {
                AnimObject first = objects[0];

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

            if (objects.Count > 0)
            {
                var obj = objects[objects.Count - 1];
                var bounds = obj.bounds;
                x = bounds.Right;
            }

            if (x > 0 && generate)
            {
                x = 1280;
                appendObject(x);
                generate = false;
            }

            int dx = -speed * msec;

            foreach (var obj in objects)
            {
                obj.move(dx, 0);
                obj.updateFrame(msec);

                if (obj.bounds.Right < 0)
                {
                    startTimer = true;
                    timeFlag = DateTime.Now;
                }
            }

            if (tagName == "Star")
            {
                totalTime = DateTime.Now - startTime;

                if (totalTime.TotalSeconds > generateTime)
                {
                    startTimer = true;
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
            if (tagName == "Star")
                this.rect.Y = new Random().Next(200, 500);

            AnimObject obj = new AnimObject(image, frameCount, framesPerSecond, rect, srcRect, tagName, generateTime);
            obj.position(x, obj.bounds.Y);
            objects.Add(obj);
        }

        public void playSound()
        {
            SoundPlayer sound = new SoundPlayer(Air.Properties.Resources.sound_item);
            sound.Play();
        }
    }
}
