namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : NonClosedOrbit
    {
        public override double Asymptote
        {
            get => double.Pi;
        }

        private ParabolicOrbit () : base ()
        {
        }
    }
}