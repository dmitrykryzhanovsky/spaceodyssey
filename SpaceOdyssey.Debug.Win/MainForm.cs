using System;
using System.Windows.Forms;

namespace SpaceOdyssey.Debug.Win
{
    public partial class MainForm : Form
    {
        internal event Action GravitationalCenterToolStripMenuItemClickEventHandler;

        public MainForm ()
        {
            InitializeComponent ();
        }

        private void GravitationalCenter_ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            GravitationalCenterToolStripMenuItemClickEventHandler ();
        }
    }
}
