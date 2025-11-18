namespace SpaceOdyssey.Cosmodynamics
{
    public class CircularOrbit : EllipticOrbit
    {
        /// <summary>
        /// Эксцентриситет окружности = 0.
        /// </summary>
        private const double CircularEccentricity = 0.0;

        public override double RatioAP
        {
            get => 1.0;
        }

        public override double RatioAMean
        {
            get => 1.0;
        }

        public override double RatioMeanP
        {
            get => 1.0;
        }

        #region Constructors

        private CircularOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        private void ComputeOrbitBySemiMajorAxis (double a, double t0)
        {
            SetParametersBySemiMajorAxis (CircularEccentricity, a, t0);

            ComputeAuxiliaries ();
            ComputeShapeBySemiMajorAxis ();
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityBySemiMajorAxis ();
        }

        private void ComputeAuxiliaries ()
        {
            _aux1pe      = 1.0;
            _aux1me      = 1.0;
            _aux1me2     = 1.0;
            _auxsqrt1me2 = 1.0;
        }

        protected override void ComputeShapeBySemiMajorAxis ()
        {
            _p  = _a;
            _b  = _a;
            _rp = _a;
            _ra = _a;
        }

        protected override void ComputeVelocityBySemiMajorAxis ()
        {
            _vp    = _auxsqrth;
            _va    = _auxsqrth;
            _vmean = _auxsqrth;
        }
    }
}