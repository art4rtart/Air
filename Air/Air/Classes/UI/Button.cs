using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air
{
    class Button
    {
        // member variables
        public Label button = new Label();
        Color activeColor;
        Color deactiveColor;
        public bool active;
        public bool isChecked;

        // methods
        public void init(Label button, Point location, Color deactiveColor, Color activeColor, Font font)
        {
            this.button = button;
            this.button.TextAlign = ContentAlignment.MiddleCenter;
            this.deactiveColor = deactiveColor;
            this.activeColor = activeColor;
            button.Font = font;
            button.Location = location;
            button.BackColor = Color.Transparent;
            button.AutoSize = true;
        }

        public void update(Point MousePosition)
        {
            if (MousePosition.X > button.Location.X && MousePosition.X < button.Location.X + button.Size.Width && MousePosition.Y > button.Location.Y && MousePosition.Y < button.Location.Y + button.Size.Height)
            {
                button.ForeColor = activeColor;
                active = true;
            }

            else
            {
                button.ForeColor = deactiveColor;
                active = false;
            }
        }

        public void visible(bool isVisible)
        {
            if (isVisible)
                button.Visible = true;
            else
            {
                button.ForeColor = Color.Transparent;
                button.BackColor = Color.Transparent;
                button.Visible = false;
            }
        }
    }
}
