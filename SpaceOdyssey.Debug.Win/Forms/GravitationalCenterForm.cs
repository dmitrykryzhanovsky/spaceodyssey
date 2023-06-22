using System;
using System.Windows.Forms;

namespace SpaceOdyssey.Debug.Win
{
    public partial class GravitationalCenterForm : Form, IChooseGravitationalCenterView
    {
        public event Action<int> SelectGravitationalCenter_EventHandler;

        public GravitationalCenterForm ()
        {
            InitializeComponent ();            
        }

        private void GravitationalCenterForm_Load (object sender, EventArgs e)
        {
            _celestialObjectComboBox.SelectedIndex = 0;
        }

        public void ShowView ()
        {
            ShowDialog ();
        }

        public void ShowData (GravitationalCenterData data)
        {
            _gravitationalParameterTextBox.Text = data.K.ToString ("E");
            _radiusTextBox.Text = data.R.ToString ();
            _v1TextBox.Text = data.V1.ToString ("F4");
            _v2TextBox.Text = data.V2.ToString ("F4");
        }

        private void CelestialObject_ComboBox_SelectedIndexChanged (object sender, EventArgs e)
        {
            SelectGravitationalCenter_EventHandler (_celestialObjectComboBox.SelectedIndex);
        }
    }
}