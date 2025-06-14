namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        public double Asymptote
        {
            get => double.Pi;
        }

        private ParabolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }
    }
}