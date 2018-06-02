using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    public partial class SettingForm : Form
    {
        Text volumeText = new Text();
        Text likeText = new Text();
        Text creditText = new Text();
        Text serachText = new Text();

        Icon goBackIcon = new Icon(Air.Properties.Resources.icon_back, 1, 1.0f, new Rectangle(400, 15, 35, 35), new RectangleF(0, 0, 64, 64));
        Icon soundIcon = new Icon(Air.Properties.Resources.icon_sound, 4, 1.0f, new Rectangle(85, 70, 50, 50), new RectangleF(0, 0, 64, 64));

        Icon likeIcon = new Icon(Air.Properties.Resources.icon_heart, 1, 1.0f, new Rectangle(79, 180, 40, 40), new RectangleF(0, 0, 64, 64));
        Icon creditIcon = new Icon(Air.Properties.Resources.icon_puzzle, 4, 1.0f, new Rectangle(199, 180, 40, 40), new RectangleF(0, 0, 64, 64));
        Icon searchIcon = new Icon(Air.Properties.Resources.icon_search, 1, 1.0f, new Rectangle(319, 180, 40, 40), new RectangleF(0, 0, 64, 64));

        private int soundValue;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            volumeText.init(62, 110, volume, new Font("Agency FB", 10, volume.Font.Style));

            likeText.init(52, 215, like, new Font("Agency FB", 10, volume.Font.Style));
            creditText.init(172, 215, credit, new Font("Agency FB", 10, volume.Font.Style));
            serachText.init(292, 215, search, new Font("Agency FB", 10, volume.Font.Style));

            soundValue = 7;
        }

        private void settingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameForm.developerMode = false;
        }

        private void SettingForm_Paint(object sender, PaintEventArgs e)
        {
            goBackIcon.draw(e.Graphics);
            soundIcon.draw(e.Graphics);
            likeIcon.draw(e.Graphics);
            creditIcon.draw(e.Graphics);
            searchIcon.draw(e.Graphics);
        }

        private void soundBar_ValueChanged(object sender, EventArgs e)
        {
            soundValue = soundBar.Value;
        }

        private void settingTimer_Tick(object sender, EventArgs e)
        {
            if(soundValue == 0)
                soundIcon.index = 0;

            if (soundValue > 0)
                soundIcon.index = 1;

            if (soundValue > 3)
                soundIcon.index = 2;

            if (soundValue > 6)
                soundIcon.index = 3;

            Invalidate();
        }
    }
}
