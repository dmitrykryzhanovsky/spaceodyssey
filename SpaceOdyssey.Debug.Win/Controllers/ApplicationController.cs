using SpaceOdyssey.Debug.Win;
using SpaceOdyssey.Debug.Win.Forms;
using SpaceOdyssey.Debug.Win.Views;

namespace SpaceOdyssey.Debug.Win.Controllers
{
    internal class ApplicationController
    {
        private MainForm _mainForm;

        private IGravitationalCenterChooseView _gravitationalCenterChooseView;

        internal MainForm MainForm { get => _mainForm; }

        internal ApplicationController ()
        {
            _mainForm = new MainForm ();

            _gravitationalCenterChooseView = new GravitationalCenterForm ();

            _mainForm.GravitationalCenterToolStripMenuItemClickEventHandler += MainForm_GravitationalCenterToolStripMenuItemClickEventHandler;

            _gravitationalCenterChooseView.SelectGravitationalCenterEventHandler += GravitationalCenterChooseView_SelectGravitationalCenterEventHandler;
        }

        private void MainForm_GravitationalCenterToolStripMenuItemClickEventHandler ()
        {
            _gravitationalCenterChooseView.ShowView ();
        }

        private void GravitationalCenterChooseView_SelectGravitationalCenterEventHandler (int index)
        {
            
        }
    }
}