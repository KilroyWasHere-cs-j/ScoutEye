using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoutEye
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            ThemeCombo.Items.Add("Light");
            ThemeCombo.Items.Add("Dark");
        }

        private void EnterBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
