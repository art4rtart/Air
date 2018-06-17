using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Air
{
    public partial class SettingForm : Form
    {        
        Text settingText = new Text();
        Text volumeText = new Text();
        Text likeText = new Text();
        Text creditText = new Text();
        Text homepageText = new Text();

        Button onButton = new Button();
        Button offButton = new Button();

        Icon goBackIcon = new Icon(Air.Properties.Resources.icon_back,1, 1.0f, new Rectangle(405, 15, 30, 30), new RectangleF(0, 0, 64, 64));
        Icon soundIcon = new Icon(Air.Properties.Resources.icon_sound, 4, 1.0f, new Rectangle(91, 70, 40, 40), new RectangleF(0, 0, 64, 64));
        Icon likeIcon = new Icon(Air.Properties.Resources.icon_heart, 1, 1.0f, new Rectangle(89, 185, 40, 40), new RectangleF(0, 0, 70, 70));
        Icon creditIcon = new Icon(Air.Properties.Resources.icon_puzzle, 4, 1.0f, new Rectangle(209, 185, 40, 40), new RectangleF(0, 0, 70, 70));
        Icon homePageIcon = new Icon(Air.Properties.Resources.icon_home, 1, 1.0f, new Rectangle(332, 188, 40, 40), new RectangleF(0, 0, 70, 70));

        private int soundValue;
        public static int sValue = 20;
        private int previousSoundValue;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            likeIcon.isChecked = GameForm.settings.likeChecked;
            creditIcon.isChecked = GameForm.settings.creditChecked;
            homePageIcon.isChecked = GameForm.settings.homepageChecked;

            onButton.isChecked = GameForm.settings.onButtonCheck;
            offButton.isChecked = GameForm.settings.offButtonCheck;
            soundValue = GameForm.settings.soundValue;
            previousSoundValue = soundValue;
            soundBar.Value = 2;

            settingText.init(this.Width / 2 - (setting.Size.Width / 2) - 5, 2, setting, new Font("Agency FB", 20, setting.Font.Style));
            volumeText.init(62, 110, volume, new Font("Agency FB", 11, volume.Font.Style));
            likeText.init(62, 220, like, new Font("Agency FB", 11, like.Font.Style));
            creditText.init(181, 220, credit, new Font("Agency FB", 11, credit.Font.Style));
            homepageText.init(304, 220, homepage, new Font("Agency FB", 11, homepage.Font.Style));

            likeIcon.colorImage = Air.Properties.Resources.icon_cheart;
            creditIcon.colorImage = Air.Properties.Resources.icon_cpuzzle;
            homePageIcon.colorImage = Air.Properties.Resources.icon_chome;
            goBackIcon.colorImage = Air.Properties.Resources.icon_cback;

            onButton.init(on, new Point(303, 120), Color.DimGray, Color.OrangeRed, new Font("Agency FB", 15, on.Font.Style));
            offButton.init(off, new Point(345, 120), Color.DimGray, Color.OrangeRed, new Font("Agency FB", 15, off.Font.Style));
            and.Font = new Font("Agency FB", 15, and.Font.Style);
            isButton.Font = new Font("Agency FB", 12, and.Font.Style);

            and.Location = new Point(327, 120);
            isButton.Location = new Point(200, 124);

            hyperlink.Location = new Point(325, 180);
            hyperlink.Parent = this.Parent;
        }

        private void SettingForm_Paint(object sender, PaintEventArgs e)
        {
            goBackIcon.draw(e.Graphics);
            soundIcon.draw(e.Graphics);
            likeIcon.draw(e.Graphics);
            creditIcon.draw(e.Graphics);
            homePageIcon.draw(e.Graphics);
        }

        private void soundBar_ValueChanged(object sender, EventArgs e)
        {
            soundValue = soundBar.Value;
            sValue = soundValue * 10;
            if (!onButton.isChecked && !offButton.isChecked)
                previousSoundValue = soundValue;
        }

        private void settingTimer_Tick(object sender, EventArgs e)
        {
            onButton.update(PointToClient(MousePosition));
            offButton.update(PointToClient(MousePosition));

            if (soundBar.Value > 0)
                offButton.isChecked = false;

            if (soundValue == 0)
                soundIcon.index = 0;

            if (soundValue > 0)
                soundIcon.index = 1;

            if (soundValue > 3)
                soundIcon.index = 2;

            if (soundValue > 6)
                soundIcon.index = 3;

            if (onButton.isChecked)
                onButton.button.ForeColor = Color.OrangeRed;

            if (offButton.isChecked)
                offButton.button.ForeColor = Color.OrangeRed;

            Invalidate();
        }


        private void SettingForm_MouseMove(object sender, MouseEventArgs e)
        {
            likeIcon.handleMouseMoveEvent(e.Location);
            creditIcon.handleMouseMoveEvent(e.Location);
            homePageIcon.handleMouseMoveEvent(e.Location);
            goBackIcon.handleMouseMoveEvent(e.Location);
        }

        private void SettingForm_Click(object sender, EventArgs e)
        {
            if (likeIcon.active)
            {
                like.Text = "thank you :)";
                like.ForeColor = Color.OrangeRed;
                likeIcon.isChecked = true;
            }

            if (creditIcon.active)
            {
                CreditForm creditForm = new CreditForm();
                creditForm.StartPosition = FormStartPosition.Manual;
                creditForm.Location = new Point(this.Width - (creditForm.Size.Width / 20) + 55, ((this.Height / 2) - creditForm.Size.Height / 3) + 155);
                creditForm.ShowDialog();
                credit.Text = "thank you :)";
                credit.ForeColor = Color.OrangeRed;
                creditIcon.isChecked = true;
            }

            if (homePageIcon.active)
            {
                Process.Start("https://github.com/wj-choi/windowprogramming");
                homepage.Text = "thank you :)";
                homepage.ForeColor = Color.OrangeRed;
                homePageIcon.isChecked = true;
            }

            if (goBackIcon.active)
            {
                saveData();
                Close();
            }
        }

        private void on_Click(object sender, EventArgs e)
        {
            if (!onButton.isChecked)
            {
                onButton.isChecked = true;
                offButton.isChecked = false;

                soundBar.Value = previousSoundValue;
            }
        }

        private void off_Click(object sender, EventArgs e)
        {
            if (!offButton.isChecked)
            {
                offButton.isChecked = true;
                onButton.isChecked = false;
                previousSoundValue = soundBar.Value;
                soundBar.Value = 0;
            }
        }

        private void settingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveData();
        }

        private void saveData()
        {
            GameForm.developerMode = false;
            GameForm.settings.likeChecked = likeIcon.isChecked;
            GameForm.settings.creditChecked = creditIcon.isChecked;
            GameForm.settings.homepageChecked = homePageIcon.isChecked;
            GameForm.settings.onButtonCheck = onButton.isChecked;
            GameForm.settings.offButtonCheck = offButton.isChecked;
            GameForm.settings.soundValue = soundValue;
        }
    }
}
