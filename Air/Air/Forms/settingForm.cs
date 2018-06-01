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
        public SettingForm()
        {
            InitializeComponent();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Air.Properties.Resources.background_paper;
        }

        private void settingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameForm.developerMode = false;
        }

        private void SettingForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
