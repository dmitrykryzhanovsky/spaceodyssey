using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class CircularOrbit : EllipticOrbit
    {
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

        #region Init and compute orbit

        /// <summary>
        /// Создаёт круговую орбиту, инициализируя большую полуось a и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если a <= 0.</exception>
        public static CircularOrbit CreateBySemiMajorAxis (Mass center, Mass orbiting, double a)
        {
            Checkers.CheckRPositive (a);

            CircularOrbit orbit = new CircularOrbit (center, orbiting);

            orbit.ComputeOrbitBySemiMajorAxis (a);

            return orbit;
        }

        /// <summary>
        /// Создаёт круговую орбиту, инициализируя период обращения T и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если T <= 0.</exception>
        public static CircularOrbit CreateByOrbitingPeriod (Mass center, Mass orbiting, double T)
        {
            Checkers.CheckTPositive (T);

            CircularOrbit orbit = new CircularOrbit (center, orbiting);

            orbit.ComputeOrbitByOrbitingPeriod (T);

            return orbit;
        }

        private void ComputeOrbitBySemiMajorAxis (double a)
        {
            SetParametersBySemiMajorAxis (CircularEccentricity, a);

            ComputeAuxiliaries ();
            ComputeShapeBySemiMajorAxis ();
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocity ();
        }

        private void ComputeOrbitByOrbitingPeriod (double T)
        {
            SetParametersByOrbitingPeriod (T);

            ComputeAuxiliaries ();
            ComputeShapeByOrbitingPeriod ();
            ComputeIntegrals ();
            ComputeMotionByOrbitingPeriod ();
            ComputeVelocity ();
        }

        #region Set parameters

        private void SetParametersByOrbitingPeriod (double T)
        {
            _e = CircularEccentricity;
            _T = T;
        }

        #endregion

        #region Auxiliaries

        private void ComputeAuxiliaries ()
        {
            _aux1pe      = 1.0;
            _aux1me      = 1.0;
            _aux1me2     = 1.0;
            _auxsqrt1me2 = 1.0;
        }

        #endregion

        #region Shape

        protected override void ComputeShapeBySemiMajorAxis ()
        {
            _p  = _a;
            _b  = _a;
            _rp = _a;
            _ra = _a;
        }

        private void ComputeShapeByOrbitingPeriod ()
        {
            _a  = double.Cbrt (_mu * _T * _T / MathConst.M4_PI_SQR);
            _p  = _a;
            _b  = _a;
            _rp = _a;
            _ra = _a;
        }

        #endregion

        #region Motion

        private void ComputeMotionByOrbitingPeriod ()
        {
            _n = double.Tau / _T;
        }

        #endregion

        #region Velocity

        private void ComputeVelocity ()
        {
            _vp    = _auxsqrth;
            _va    = _auxsqrth;
            _vmean = _auxsqrth;
        }

        #endregion

        #endregion

        public override OrbitalPosition ComputePosition (double t)
        {
            double M = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, t - _t0);

            // Вычисление положения в плоскости орбиты.
            (double sinV, double cosV) = double.SinCos (M);
            double x = _a * cosV;
            double y = _a * sinV;

            // Вычисление скорости в плоскости орбиты.
            double vx = -_auxsqrth * sinV;
            double vy =  _auxsqrth * cosV;

            return new OrbitalPosition (this, t, M, M, x, y, _a, M, vx, vy);
        }
    }
}