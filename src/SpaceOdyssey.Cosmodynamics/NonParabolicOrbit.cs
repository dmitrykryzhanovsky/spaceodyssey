using System.Reflection.Metadata;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        protected double _aux1pe;   // Вспомогательная величина 1 + e.
        protected double _aux1me;   // Вспомогательная величина 1 - e.
        protected double _auxsqrth; // Вспомогательная величина sqrt (mu / abs (a)) = sqrt (abs (h)).

        protected double _a;

        /// <summary>
        /// Большая полуось.
        /// </summary>
        public double A
        {
            get => _a;
        }

        #region Constructors

        protected NonParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        protected override void ComputeOrbitByPeriapsis (double e, double rp, double t0)
        {
            base.ComputeOrbitByPeriapsis (e, rp, t0);

            _aux1pe = 1.0 + e;
            _aux1me = 1.0 - e;

            _p = _rp * _aux1pe;
            _a = _rp / _aux1me;

            ComputeIntegrals ();
            ComputeMotion ();

            _vp = _mu * _aux1pe / _rp;
        }

        private void ComputeIntegrals ()
        {
            _h        = Formulae.Integrals.NonParabola.EnergyIntegral (_mu, _a);
            _auxsqrth = double.Sqrt (double.Abs (_h));
        }

        private void ComputeMotion ()
        {
            _n = Formulae.Motion.NonParabola.MeanMotion (_auxsqrth, _a);
        }
    }
}