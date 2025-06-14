using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        public double Asymptote
        {
            get => Formulae.Asymptote (_e);
        }

        private HyperbolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        public static HyperbolicOrbit CreateByPeriapsis (Mass center, Mass probe, double rp, double e)
        {
            Checkers.CheckPeriapsis (rp);
            Checkers.CheckEccentricityForHyperbola (e);

            HyperbolicOrbit orbit = new HyperbolicOrbit (center, probe);

            orbit._rp = rp;
            orbit._e  = e;

            orbit.ComputeOrbit ();

            return orbit;
        }

        protected override void ComputeShapeParameters ()
        {
            _p = _rp * _1pe;
            _a = _rp / _1me;
        }

        protected override void ComputeMotionParameters ()
        {
            _muasqrt = Formulae.GMASqrt (-_mua);

            _n       = Formulae.MeanMotion (-_a, _muasqrt);
            _vp      = _muasqrt * double.Sqrt (-_1pe / _1me);
        }

        protected override void ComputeArealVelocity ()
        {
            _arealVelocity = Formulae.ArealVelocity (_mu, -_a);
        }
    }
}