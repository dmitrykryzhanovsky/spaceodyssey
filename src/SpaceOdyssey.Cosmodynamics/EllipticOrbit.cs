namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : KeplerOrbit
    {
        protected double _a;
        private   double _amax;

        public double A
        {
            get => _a;
        }

        public double Amax
        {
            get => _amax;
        }

        protected EllipticOrbit (double p, double e, double a, double amin, double amax) : base (p, e, amin)
        {
            _a    = a;
            _amax = amax;
        }

        public static EllipticOrbit CreateAE (double a, double e)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException ();
            if ((e < 0.0) || (e >= 1.0)) throw new ArgumentOutOfRangeException ();

            double ep1  = 1.0 + e;
            double amin = a * (1.0 - e);
            double amax = a * ep1;
            double p    = amin * ep1;

            return new EllipticOrbit (p, e, a, amin, amax);
        }

        public static EllipticOrbit CreateAminAmax (double amin, double amax)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();
            if (amax < amin) throw new ArgumentOutOfRangeException ();

            double major = amax + amin;
            double a     = major / 2.0;
            double e     = (amax - amin) / major;
            double p     = amin * (1.0 + e);

            return new EllipticOrbit (p, e, a, amin, amax);
        }
    }
}
