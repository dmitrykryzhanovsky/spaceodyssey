namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonClosedOrbit
    {
        public override double Asymptote
        {
            get => double.Acos (-1.0 / _e);
        }

        public double RangeARp
        {
            get => 1.0 / (1.0 - _e);
        }

        private HyperbolicOrbit () : base ()
        {
        }
    }
}