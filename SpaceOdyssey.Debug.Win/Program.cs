using System;
using System.Windows.Forms;

using SpaceOdyssey.Debug.Win.Controllers;

namespace SpaceOdyssey.Debug.Win
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main ()
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);

            ApplicationController appController = new ApplicationController ();

            Application.Run (appController.MainForm);
        }
    }
}