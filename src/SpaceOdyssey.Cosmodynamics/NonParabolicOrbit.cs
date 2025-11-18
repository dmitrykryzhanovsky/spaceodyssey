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

        protected virtual void ComputeOrbitByPeriapsis (double e, double rp, double t0)
        {
            SetParametersByPeriapsis (e, rp, t0);

            ComputeAuxiliariesByEccentricity ();
            ComputeShapeByPeriapsis ();
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityByPeriapsis ();            
        }

        protected virtual void ComputeAuxiliariesByEccentricity ()
        {
            _aux1pe = 1.0 + _e;
            _aux1me = 1.0 - _e;
        }

        protected virtual void ComputeShapeByPeriapsis ()
        {
            _p = _rp * _aux1pe;
            _a = _rp / _aux1me;
        }

        protected void ComputeIntegrals ()
        {
            _h        = Formulae.Integrals.NonParabola.EnergyIntegral (_mu, _a);
            _auxsqrth = double.Sqrt (double.Abs (_h));
        }

        protected virtual void ComputeMotionBySemiMajorAxis ()
        {
            _n = Formulae.Motion.NonParabola.MeanMotion (_auxsqrth, _a);
        }

        protected virtual void ComputeVelocityByPeriapsis ()
        {
            _vp = double.Sqrt (_mu * _aux1pe / _rp);
        }
    }
}