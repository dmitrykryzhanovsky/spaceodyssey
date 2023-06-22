using System;

namespace SpaceOdyssey.Debug.Win
{
    internal interface IChooseGravitationalCenterView
    {
        event Action<int> SelectGravitationalCenter_EventHandler;

        void ShowView ();

        void ShowData (GravitationalCenterData data);
    }
}