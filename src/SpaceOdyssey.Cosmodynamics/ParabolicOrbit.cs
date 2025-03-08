namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        private const double ParabolicEccentricity = 1.0;

        private const double ParabolicAsymptote = double.Pi;

        public double Asymptote
        {
            get => ParabolicAsymptote;
        }

        private ParabolicOrbit (double amin) : base (FocalParameter (amin), ParabolicEccentricity, amin)
        {
        }

        public static ParabolicOrbit Create (double amin)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();

            return new ParabolicOrbit (amin);
        }

        private static double FocalParameter (double amin)
        {
            return 2.0 * amin;
        }

        public override double Radius (double trueAnomaly)
        {
            return _p / (1.0 + double.Cos (trueAnomaly));
        }

        public override double TrueAnomaly (double r)
        {
            return double.Acos (_p / r - 1.0);
        }
    }
}