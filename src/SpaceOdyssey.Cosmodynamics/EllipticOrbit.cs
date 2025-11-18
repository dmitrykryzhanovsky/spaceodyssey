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

        private double _M0;

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

        protected override void ComputeAuxiliariesByEccentricity ()
        {
            base.ComputeAuxiliariesByEccentricity ();

            _aux1me2     = 1.0 - _e * _e;
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

        protected virtual void ComputeVelocityBySemiMajorAxis ()
        {
            _vp = double.Sqrt (-_h * _aux1pe / _aux1me);
            _va = double.Sqrt (-_h * _aux1me / _aux1pe);

            _vmean = Formulae.Motion.Ellipse.SpeedMean (_a, _auxsqrt1me2, _T);
        }
    }
}