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

        protected CircularOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        #region Init and compute orbit

        /// <summary>
        /// Создаёт круговую орбиту, инициализируя большую полуось a и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если a <= 0.</exception>
        public static CircularOrbit CreateBySemiMajor (Mass center, Mass orbiting, double a, double t0)
        {
            CheckRPositive (a);

            CircularOrbit orbit = new CircularOrbit (center, orbiting);

            orbit.ComputeOrbitByA (a, t0);

            return orbit;
        }

        protected void ComputeOrbitByA (double a, double t0)
        {
            _a = a;
            _e = 0.0;

            ComputeAuxiliary ();
            ComputeShapeByA ();
            ComputeIntegrals ();
            ComputeMotionByA ();
            
            SetMeanAnomalyForT0 (t0);
        }

        protected override void ComputeAuxiliary ()
        {
            _aux1pe      = 1.0;
            _aux1me      = 1.0;
            _aux1me2     = 1.0;
            _auxsqrt1me2 = 1.0;
        }

        private void ComputeShapeByA ()
        {
            _p  = _a;
            _b  = _a;
            _rp = _a;
            _ra = _a;
        }

        protected void ComputeMotionByA ()
        {
            _n     = Formulae.Motion.NonParabola.MeanMotion (_sqrtmu, _a);
            _T     = Formulae.Motion.NonParabola.Ellipse.OrbitalPeriodByMeanMotion (_n);
            _vmean = _auxsqrth;
            _vp    = _vmean;
            _va    = _vmean;
        }

        #endregion

        public override double Radius (double trueAnomaly)
        {
            return _a;
        }

        protected override void CheckR (double r)
        {
            ArgumentOutOfRangeCheckers.CheckEqual (r, _a);
        }

        protected override double ConicSectionInverseEquation (double r)
        {
            return double.NaN;
        }
    }
}