using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air
{
    class Text
    {
        // member variables
        Label text = new Label();
        int x, y;

        // methods
        public void init(int x, int y, Label label, Font font)
        {
            this.x = x; this.y = y;
            this.text = label;
            text.Font = font;
            text.Location = new Point(x, y);
        }


        public void update(string value)
        {
            text.Text = value;
        }

        public void visible(bool isVisible)
        {
            if (isVisible)
                text.Visible = true;

            else
                text.Visible = false;
        }
    }
}
