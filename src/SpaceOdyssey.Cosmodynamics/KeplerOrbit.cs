namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private Mass _center;
        private Mass _probe;

        protected double _mu;

        protected double _p;
        protected double _e;
        protected double _rp;

        protected double _n;
        protected double _vp;

        protected double _mua;
        protected double _muasqrt;

        protected double _energyIntegral;
        protected double _arealVelocity;

        public double P
        {
            get => _p;
        }

        public double E
        {
            get => _e;
        }

        public double RPeri
        {
            get => _rp;
        }

        public double N
        {
            get => _n;
        }

        public double VPeri
        {
            get => _vp;
        }

        public double EnergyIntegral
        {
            get => _energyIntegral;
        }

        public double ArealVelocity
        {
            get => _arealVelocity;
        }

        protected KeplerOrbit (Mass center, Mass probe)
        {
            InitMasses (center, probe);
        }

        private void InitMasses (Mass center, Mass probe)
        {
            _center = center;
            _probe  = probe;
            _mu     = center.GM + probe.GM;
        }

        protected static class Formulae
        {
            public static double Asymptote (double e)
            {
                return double.Acos (-1.0 / e);
            }

            public static double RangeARp (double x1me)
            {
                return 1.0 / x1me;
            }

            public static double RangeRaA (double x1pe)
            {
                return x1pe;
            }

            public static double RangeRaRp (double x1me, double x1pe)
            {
                return x1pe / x1me;
            }

            public static double GMA (double mu, double a)
            {
                return mu / a;
            }

            public static double GMASqrt (double mua)
            {
                return double.Sqrt (mua);
            }

            public static double MeanMotion (double a, double muasqrt)
            {
                return muasqrt / a;
            }

            public static double OrbitalPeriod (double a, double muasqrt)
            {
                return double.Tau * a / muasqrt;
            }

            public static double ArealVelocity (double mu, double a)
            {
                return double.Sqrt (mu * a);
            }
        }
    }
}