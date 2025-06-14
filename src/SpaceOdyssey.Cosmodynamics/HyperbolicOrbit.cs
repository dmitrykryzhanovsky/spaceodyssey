namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonClosedOrbit
    {
        private double _a;

        public override double Asymptote
        {
            get => Formulae.Asymptote (_e);
        }

        private HyperbolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }
    }
}