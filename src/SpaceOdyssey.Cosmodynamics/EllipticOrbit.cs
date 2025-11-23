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

        #region Init and compute orbit

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя расстояние в перицентре rp, эксцентриситет e и момент прохождения перицентра 
        /// t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e < 0 или e >= 1 или</item>
        /// <item>rp <= 0.</item></list></exception>
        public static EllipticOrbit CreateByPeriapsis (Mass center, Mass orbiting, double e, double rp, double t0)
        {
            Checkers.CheckEForEllipse (e);
            Checkers.CheckRPositive (rp);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitByPeriapsis (e, rp, t0);

            return orbit;
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя большую полуось a, эксцентриситет e и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e < 0 или e >= 1 или</item>
        /// <item>a <= 0.</item></list></exception>
        public static EllipticOrbit CreateBySemiMajorAxis (Mass center, Mass orbiting, double e, double a, double t0)
        {
            Checkers.CheckEForEllipse (e);
            Checkers.CheckRPositive (a);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitBySemiMajorAxis (e, a, t0);

            return orbit;
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя расстояние в перицентре rp, расстояние в апоцентре ra и момент прохождения 
        /// перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>rp <= 0 или</item>
        /// <item>ra < rp.</item></list></exception>
        public static EllipticOrbit CreateByApsides (Mass center, Mass orbiting, double rp, double ra, double t0)
        {
            Checkers.CheckRPositive (rp);
            Checkers.CheckRNotPeriapsis (ra, rp);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitByApsides (rp, ra, t0);

            return orbit;
        }

        protected override void ComputeOrbitByPeriapsis (double e, double rp, double t0)
        {
            base.ComputeOrbitByPeriapsis (e, rp, t0);

            SetMeanAnomalyForJ2000 ();
        }

        private void ComputeOrbitBySemiMajorAxis (double e, double a, double t0)
        {
            SetParametersBySemiMajorAxis (e, a, t0);

            ComputeAuxiliariesByEccentricity ();
            ComputeShapeBySemiMajorAxis ();
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityBySemiMajorAxis ();

            SetMeanAnomalyForJ2000 ();
        }

        private void ComputeOrbitByApsides (double rp, double ra, double t0)
        {
            SetParametersByApsides (rp, ra, t0);

            ComputeAuxiliariesByApsides (out double plus);
            ComputeShapeByApsides (plus);
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityByApsides ();
            
            SetMeanAnomalyForJ2000 ();
        }

        #region Set parameters

        protected override void SetParametersByPeriapsis (double e, double rp, double t0)
        {
            base.SetParametersByPeriapsis (e, rp, t0);
        }

        protected void SetParametersBySemiMajorAxis (double e, double a, double t0)
        {
            _e  = e;
            _a  = a;
            _t0 = t0;
        }

        private void SetParametersByApsides (double rp, double ra, double t0)
        {
            _rp = rp;
            _ra = ra;
            _t0 = t0;            
        }

        #endregion

        #region Auxiliaries

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

        #endregion

        #region Shape

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

        #endregion

        #region Motion

        protected override void ComputeMotionBySemiMajorAxis ()
        {
            base.ComputeMotionBySemiMajorAxis ();

            _T = double.Tau / _n;
        }

        #endregion

        #region Velocity

        protected override void ComputeVelocityByPeriapsis ()
        {
            base.ComputeVelocityByPeriapsis ();

            _va    = _aux1me * double.Sqrt (_mu / (_rp * _aux1pe));
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

        #endregion

        protected void SetMeanAnomalyForJ2000 ()
        {
            _M0 = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, _t0 - Time.J2000);
        }

        #endregion
    }
}