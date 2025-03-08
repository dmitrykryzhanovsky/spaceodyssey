namespace SpaceOdyssey.Cosmodynamics
{
    public class CircularOrbit : EllipticOrbit
    {
        private const double CircularEccentricity = 1.0;

        private CircularOrbit (double a) : base (a, CircularEccentricity, a, a, a)
        {
        }

        public static CircularOrbit Create (double a)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException ();

            return new CircularOrbit (a);
        }

        public override double Radius (double trueAnomaly)
        {
            return _a;
        }

        public override double TrueAnomaly (double r)
        {
            return double.NaN;
        }
    }
}