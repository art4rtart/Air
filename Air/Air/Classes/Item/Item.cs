using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air
{
    class Item : AnimObject
    {
        public string tagName;

        public Item(Bitmap bitmap, int frameCount, float framesPerSecond, RectangleF rect, RectangleF srcDest) 
            : base(bitmap, frameCount, framesPerSecond)
        {
            this.rect = rect;
            this.srcRect = srcDest;
        }
    }
}
