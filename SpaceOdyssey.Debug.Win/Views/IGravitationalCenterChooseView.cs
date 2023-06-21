using System;

namespace SpaceOdyssey.Debug.Win.Views
{
    internal interface IGravitationalCenterChooseView
    {
        event Action<int> SelectGravitationalCenterEventHandler;

        void ShowView ();
    }
}