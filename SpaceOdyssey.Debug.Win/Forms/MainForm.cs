using System;
using System.Windows.Forms;

namespace SpaceOdyssey.Debug.Win
{
    public partial class MainForm : Form
    {
        internal event Action GravitationalCenter_ToolStripMenuItemClick_EventHandler;

        public MainForm ()
        {
            InitializeComponent ();
        }

        private void GravitationalCenter_ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            GravitationalCenter_ToolStripMenuItemClick_EventHandler ();
        }
    }
}
