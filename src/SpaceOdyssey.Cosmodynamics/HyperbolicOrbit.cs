namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : KeplerOrbit
    {
        private double _a;

        private double _asymptote;

        public double A
        {
            get => _a;
        }

        public double Asymptote
        {
            get => _asymptote;
        }

        private HyperbolicOrbit (double p, double e, double a, double amin) : base (p, e, amin)
        {
            _a         = a;
            _asymptote = double.Acos (-1.0 / e);
        }

        public static HyperbolicOrbit CreateAminP (double amin, double p)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();
            if (p <= amin) throw new ArgumentOutOfRangeException ();

            double Q = p / amin;
            double e = Q - 1.0;
            double a = p / (Q * (2.0 - Q));

            return new HyperbolicOrbit (p, e, a, amin);
        }

        public static HyperbolicOrbit CreateAminE (double amin, double e)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();
            if (e <= 1.0) throw new ArgumentOutOfRangeException ();

            double p = amin * (1.0 + e);
            double a = amin / (1.0 - e);

            return new HyperbolicOrbit (p, e, a, amin);
        }
    }
}