namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : NonClosedOrbit
    {
        public override double Asymptote
        {
            get => double.Pi;
        }

        private ParabolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }
    }
}