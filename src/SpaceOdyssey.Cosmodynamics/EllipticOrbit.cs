using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        protected double _aux1me2;     // Вспомогательная величина 1 - e^2.
        protected double _auxsqrt1me2; // Вспомогательная величина sqrt (1 - e^2).

        protected double _b;
        protected double _ra;

        protected double _T;
        protected double _va;
        protected double _vmean;

        protected double _M0;

        /// <summary>
        /// Малая полуось.
        /// </summary>
        public double B
        {
            get => _b;
        }

        /// <summary>
        /// Расстояние в апоцентре.
        /// </summary>
        public double RA
        {
            get => _ra;
        }

        /// <summary>
        /// Отношение расстояния в апоцентре к расстоянию в перицентре.
        /// </summary>
        public virtual double RatioAP
        {
            get => _aux1pe / _aux1me;
        }

        /// <summary>
        /// Отношение расстояния в апоцентре к среднему расстоянию.
        /// </summary>
        public virtual double RatioAMean
        {
            get => _aux1pe;
        }

        /// <summary>
        /// Отношение расстояния среднего расстояния к расстоянию в перицентре.
        /// </summary>
        public virtual double RatioMeanP
        {
            get => 1.0 / _aux1me;
        }

        /// <summary>
        /// Период обращения.
        /// </summary>
        public double T
        {
            get => _T;
        }

        /// <summary>
        /// Скорость в апоцентре.
        /// </summary>
        public double VA
        {
            get => _va;
        }

        /// <summary>
        /// Средняя скорость на данной орбите.
        /// </summary>
        public double VMean
        {
            get => _vmean;
        }

        /// <summary>
        /// Средняя аномалия в момент времени J2000.
        /// </summary>
        public double M0
        {
            get => _M0;
        }

        #region Constructors

        protected EllipticOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        private void ComputeOrbitBySemiMajorAxis (double e, double a, double t0)
        {
            SetParametersBySemiMajorAxis (e, a, t0);

            ComputeAuxiliariesByEccentricity ();
            ComputeShapeBySemiMajorAxis ();
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityBySemiMajorAxis ();
        }

        private void ComputeOrbitByApsides (double rp, double ra, double t0)
        {
            SetParametersByApsides (rp, ra, t0);

            double plus;

            ComputeAuxiliariesByApsides (out plus);
            ComputeShapeByApsides (plus);
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityByApsides ();
        }

        protected override void SetParametersByPeriapsis (double e, double rp, double t0)
        {
            base.SetParametersByPeriapsis (e, rp, t0);

            _M0 = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, _t0 - Time.J2000);
        }

        protected void SetParametersBySemiMajorAxis (double e, double a, double t0)
        {
            _e  = e;
            _a  = a;
            _t0 = t0;

            _M0 = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, _t0 - Time.J2000);
        }

        private void SetParametersByApsides (double rp, double ra, double t0)
        {
            _rp = rp;
            _ra = ra;
            _t0 = t0;

            _M0 = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, _t0 - Time.J2000);
        }

        protected override void ComputeAuxiliariesByEccentricity ()
        {
            base.ComputeAuxiliariesByEccentricity ();

            _aux1me2     = 1.0 - _e * _e;
            _auxsqrt1me2 = double.Sqrt (_aux1me2);
        }

        private void ComputeAuxiliariesByApsides (out double plus)
        {
            plus  = _ra + _rp;

            _aux1pe      = 2.0 * _ra / plus;
            _aux1me      = 2.0 * _rp / plus;
            _aux1me2     = _aux1pe * _aux1me;
            _auxsqrt1me2 = double.Sqrt (_aux1me2);
        }

        protected override void ComputeShapeByPeriapsis ()
        {
            base.ComputeShapeByPeriapsis ();

            _b  = _rp * double.Sqrt (_aux1pe / _aux1me);
            _ra = _rp * _aux1pe / _aux1me;
        }

        protected virtual void ComputeShapeBySemiMajorAxis ()
        {
            _p  = _a * _aux1me2;
            _b  = _a * _auxsqrt1me2;
            _rp = _a * _aux1me;
            _ra = _a * _aux1pe;
        }

        private void ComputeShapeByApsides (double plus)
        {
            _e = (_ra - _rp) / plus;
            _p = 2.0 * _ra * _rp / plus;
            _a = plus / 2.0;
            _b = double.Sqrt (_ra * _rp);
        }

        protected override void ComputeMotionBySemiMajorAxis ()
        {
            base.ComputeMotionBySemiMajorAxis ();

            _T = double.Tau / _n;
        }

        protected override void ComputeVelocityByPeriapsis ()
        {
            base.ComputeVelocityByPeriapsis ();

            _va    = _mu * _aux1me * _aux1me / (_rp * _aux1pe);
            _vmean = Formulae.Motion.Ellipse.SpeedMean (_a, _auxsqrt1me2, _T);
        }

        private void ComputeVelocityBySemiMajorAxis ()
        {
            _vp = double.Sqrt (-_h * _aux1pe / _aux1me);
            _va = double.Sqrt (-_h * _aux1me / _aux1pe);

            _vmean = Formulae.Motion.Ellipse.SpeedMean (_a, _auxsqrt1me2, _T);
        }

        private void ComputeVelocityByApsides ()
        {
            _vp = double.Sqrt (-_h * _ra / _rp);
            _va = double.Sqrt (-_h * _rp / _ra);

            _vmean = Formulae.Motion.Ellipse.SpeedMean (_a, _auxsqrt1me2, _T);
        }
    }
}