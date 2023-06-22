using SpaceOdyssey.Cosmodynamics;

namespace SpaceOdyssey.Debug.Win
{
    internal class ApplicationController
    {
        private MainForm _mainForm;

        private CelestialObject [] _gravitationalCenters = new CelestialObject [] { Sun.Instance, Earth.Instance, Moon.Instance, 
            Venus.Instance, Jupiter.Instance, Saturn.Instance };

        private IChooseGravitationalCenterView _chooseGravitationalCenterView;

        internal MainForm MainForm { get => _mainForm; }

        internal ApplicationController ()
        {
            _mainForm = new MainForm ();

            _chooseGravitationalCenterView = new GravitationalCenterForm ();

            _mainForm.GravitationalCenter_ToolStripMenuItemClick_EventHandler += MainForm_GravitationalCenter_ToolStripMenuItemClick_EventHandler;

            _chooseGravitationalCenterView.SelectGravitationalCenter_EventHandler += ChooseGravitationalCenterView_SelectGravitationalCenter_EventHandler;
        }

        private void MainForm_GravitationalCenter_ToolStripMenuItemClick_EventHandler ()
        {
            _chooseGravitationalCenterView.ShowView ();
        }

        private void ChooseGravitationalCenterView_SelectGravitationalCenter_EventHandler (int index)
        {
            _chooseGravitationalCenterView.ShowData (new GravitationalCenterData (_gravitationalCenters [index]));
        }
    }
}