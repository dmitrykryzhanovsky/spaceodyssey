using System;
using System.Windows.Forms;

using SpaceOdyssey.Debug.Win.Views;

namespace SpaceOdyssey.Debug.Win.Forms
{
    public partial class GravitationalCenterForm : Form, IGravitationalCenterChooseView
    {
        public event Action<int> SelectGravitationalCenterEventHandler;

        public GravitationalCenterForm ()
        {
            InitializeComponent ();            
        }

        private void GravitationalCenterForm_Load (object sender, EventArgs e)
        {
            celestialObject_ComboBox.SelectedIndex = 0;
        }

        public void ShowView ()
        {
            ShowDialog ();
        }

        private void CelestialObject_ComboBox_SelectedIndexChanged (object sender, EventArgs e)
        {
            SelectGravitationalCenterEventHandler (celestialObject_ComboBox.SelectedIndex);
        }
    }
}