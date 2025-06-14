using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : KeplerOrbit
    {
        protected double _a;
        protected double _ra;

        private double _1me;
        private double _1pe;
        private double _1me2;

        protected double _T;
        protected double _vmean;
        protected double _va;

        public double A
        {
            get => _a;
        }

        public double RApo
        {
            get => _ra;
        }

        public virtual double RangeARp
        {
            get => Formulae.RangeARp (_1me);
        }

        public virtual double RangeRaA
        {
            get => Formulae.RangeRaA (_1pe);
        }

        public virtual double RangeRaRp
        {
            get => Formulae.RangeRaRp (_1me, _1pe);
        }

        public double T
        {
            get => _T;
        }

        public double VMean
        {
            get => _vmean;
        }

        public double VApo
        {
            get => _va;
        }        

        protected EllipticOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        public static EllipticOrbit CreateBySemiMajorAxis (Mass center, Mass probe, double a, double e)
        {
            ArgumentOutOfRangeCheckers.CheckPositive (a);
            ArgumentOutOfRangeCheckers.CheckInLeftSemiInterval (e, 0.0, 1.0);

            EllipticOrbit orbit = new EllipticOrbit (center, probe);

            orbit._a = a;
            orbit._e = e;

            orbit.ComputeShape ();
            orbit.ComputeMotion ();
            orbit.ComputeIntegrals ();

            return orbit;
        }

        private void ComputeShape ()
        {
            _1me  = 1.0 - _e;
            _1pe  = 1.0 + _e;
            _1me2 = _1me * _1pe;

            _p    = _a * _1me2;
            _rp   = _a * _1me;
            _ra   = _a * _1pe;
        }

        protected void ComputeMotion ()
        {
            _mua     = Formulae.GMA (_mu, _a);
            _muasqrt = Formulae.GMASqrt (_mua);

            _n       = Formulae.MeanMotion (_a, _muasqrt);
            _T       = Formulae.OrbitalPeriod (_a, _muasqrt);
            _vmean   = _muasqrt;

            ComputeVelocityPA ();
        }

        protected virtual void ComputeVelocityPA ()
        {
            _vp = _vmean * double.Sqrt (_1pe / _1me);
            _va = _vmean * double.Sqrt (_1me / _1pe);
        }

        protected void ComputeIntegrals ()
        {
            _energyIntegral = -_mua;
            _arealVelocity  = Formulae.ArealVelocity (_mu, _a);
        }
    }
}