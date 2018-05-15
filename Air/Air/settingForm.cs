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
    public partial class settingForm : Form
    {
        public settingForm()
        {
            InitializeComponent();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {

        }

        private void settingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameForm.developerMode = false;
        }
    }
}
