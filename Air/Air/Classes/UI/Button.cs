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
        private Label button = new Label();

        // methods
        public void init(Label button, Font font)
        {
            this.button = button;
            button.Font = font;
        }

        public void update(Point MousePosition)
        {
            if (MousePosition.X > button.Location.X && MousePosition.X < button.Location.X + button.Size.Width)
            {
                if (MousePosition.Y > button.Location.Y && MousePosition.Y < button.Location.Y + button.Size.Height)
                    button.ForeColor = Color.WhiteSmoke;
                else
                    button.ForeColor = Color.DimGray;
            }
            else
                button.ForeColor = Color.DimGray;
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
