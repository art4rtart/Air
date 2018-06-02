using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class Icon : GameObject
    {
        private int frameCount;
        private int frameIndex;
        private float framesPerSecond;
        private int millisecondsElapsed;

        public int index
        {
            get { return frameIndex; }
            set
            {
                frameIndex = value % frameCount;

                srcRect.X = frameIndex * srcRect.Width;
            }
        }

        public Icon(Bitmap bitmap, int frameCount, float framesPerSecond, Rectangle rect, RectangleF srcRect) : base(bitmap)
        {
            this.frameCount = frameCount;
            this.rect.Width = this.rect.Width / frameCount;

            this.rect = rect;
            this.srcRect = srcRect;

            this.frameIndex = 0;
            this.framesPerSecond = framesPerSecond;
            this.millisecondsElapsed = 0;
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
