using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class AnimObject : GameObject
    {
        protected float framesPerSecond;
        protected int frameCount;
        private int frameIndex;
        private int millisecondsElapsed;

        float generateTime = 0;
        public string tagName;

        public int index
        {
            get { return frameIndex; }
            set
            {
                frameIndex = value % frameCount;
                srcRect.X = frameIndex * srcRect.Width;
            }
        }

        public AnimObject(Bitmap bitmap, int frameCount, float framesPerSecond, RectangleF rect, RectangleF srcRect, string tagName, float generateTime) : base(bitmap)
        {
            this.frameCount = frameCount;
            this.rect.Width = this.rect.Width / frameCount;
            this.frameIndex = 0;
            this.framesPerSecond = framesPerSecond;
            this.millisecondsElapsed = 0;

            this.rect = rect;
            this.srcRect = srcRect;
            this.tagName = tagName;
            this.generateTime = generateTime;
        }

        public override void updateFrame(int msec)
        {
            millisecondsElapsed += msec;
            var msecPerFrame = 10 / framesPerSecond;
            index = (int)(millisecondsElapsed / msecPerFrame);
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(image, rect, srcRect, GraphicsUnit.Pixel);
        }
    }
}
