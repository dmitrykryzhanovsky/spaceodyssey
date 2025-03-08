namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        protected double _p;

        private double _e;

        protected double _amin;

        public double P
        {
            get => _p;
        }

        public double E
        {
            get => _e;
        }

        public double Amin
        {
            get => _amin;
        }

        protected KeplerOrbit (double p, double e, double amin)
        {
            _p    = p;
            _e    = e;
            _amin = amin;
        }

        public virtual double Radius (double trueAnomaly)
        {
            return _p / (1.0 + _e * double.Cos (trueAnomaly));
        }

        public virtual double TrueAnomaly (double r)
        {
            return double.Acos ((_p / r - 1.0) / _e);
        }
    }
}