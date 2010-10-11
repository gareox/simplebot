using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleBot.Forms
{
    public partial class Extras : Form
    {
        public Extras()
        {
            InitializeComponent();
        }

        private void Extras_Load(object sender, EventArgs e)
        {
            this.FormClosing += delegate(object fsender, FormClosingEventArgs fe)
            {
                fe.Cancel = true;
                this.Hide();
            };
        }

        private void uxCheckEatFood_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.EatFood = uxCheckEatFood.Checked;
        }

        private void uxCheckFullLight_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.FullLight = uxCheckFullLight.Checked;
        }

        private void uxCheckXRay_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.XRay = uxCheckXRay.Checked;
        }

        private void uxCheckFramerateControl_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Extras.FramerateControl = uxCheckFramerateControl.Checked;
        }

        private void uxReplaceTrees_Click(object sender, EventArgs e)
        {
            Program.Client.Map.ReplaceTrees();
        }
    }
}
