namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        protected double _aux1me2;        // Вспомогательная величина 1 - e^2.
        protected double _auxsqrt1me2;    // Вспомогательная величина sqrt (1 - e^2).
        protected double _auxsqrtmu1me2a; // Вспомогательная величина sqrt (μ * (1 - e^2) / a).

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
        public static EllipticOrbit CreateByPeriapsis (Mass center, Mass orbiting, double e, double rp)
        {
            Checkers.CheckEForEllipse (e);
            Checkers.CheckRPositive (rp);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitByPeriapsis (e, rp);

            return orbit;
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя большую полуось a, эксцентриситет e и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e < 0 или e >= 1 или</item>
        /// <item>a <= 0.</item></list></exception>
        public static EllipticOrbit CreateBySemiMajorAxis (Mass center, Mass orbiting, double e, double a)
        {
            Checkers.CheckEForEllipse (e);
            Checkers.CheckRPositive (a);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitBySemiMajorAxis (e, a);

            return orbit;
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя расстояние в перицентре rp, расстояние в апоцентре ra и момент прохождения 
        /// перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>rp <= 0 или</item>
        /// <item>ra < rp.</item></list></exception>
        public static EllipticOrbit CreateByApsides (Mass center, Mass orbiting, double rp, double ra)
        {
            Checkers.CheckRPositive (rp);
            Checkers.CheckRGreaterEqualPeriapsis (ra, rp);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitByApsides (rp, ra);

            return orbit;
        }

        protected override void ComputeOrbitByPeriapsis (double e, double rp)
        {
            base.ComputeOrbitByPeriapsis (e, rp);
        }

        private void ComputeOrbitBySemiMajorAxis (double e, double a)
        {
            SetParametersBySemiMajorAxis (e, a);

            ComputeAuxiliariesByEccentricity ();
            ComputeShapeBySemiMajorAxis ();
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityBySemiMajorAxis ();
        }

        private void ComputeOrbitByApsides (double rp, double ra)
        {
            SetParametersByApsides (rp, ra);

            ComputeAuxiliariesByApsides (out double plus);
            ComputeShapeByApsides (plus);
            ComputeIntegrals ();
            ComputeMotionBySemiMajorAxis ();
            ComputeVelocityByApsides ();
        }

        #region Set parameters

        protected void SetParametersBySemiMajorAxis (double e, double a)
        {
            _e  = e;
            _a  = a;
        }

        private void SetParametersByApsides (double rp, double ra)
        {
            _rp = rp;
            _ra = ra;            
        }

        public override void SetPeriapsisTimeInJD (double t0)
        {
            base.SetPeriapsisTimeInJD (t0);

            _M0 = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, Time.J2000 - _t0);
        }

        public void SetMeanAnomalyForJ2000 (double M0)
        {
            _M0 = M0;
            _t0 = Time.J2000 - _M0 / _n;            
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
            plus = _ra + _rp;

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

        #region Integrals

        protected override void ComputeIntegrals ()
        {
            base.ComputeIntegrals ();

            _auxsqrtmu1me2a = _auxsqrth * _auxsqrt1me2;
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

        #endregion

        /// <summary>
        /// Проверяет, что расстояние r соответствует ограничениям, накладываемым формой орбиты, а именно что r лежит на интервале 
        /// [rp; ra].
        /// </summary>
        protected override void CheckR (double r)
        {
            Checkers.CheckRBetweenPeriapsisAndApoapsis (r, _rp, _ra);
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            double M = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, t - _t0);
            double E = Formulae.KeplerEquation.Ellipse.Solve (M, _e);

            // Вычисление положения в плоскости орбиты.
            (double sinE, double cosE) = double.SinCos (E);
            double eccentric = 1.0 - _e * cosE;
            
            double x = _a * (cosE - _e);
            double y = _a * _auxsqrt1me2 * sinE;
            double r = _a * eccentric;
            double trueAnomaly = double.Atan2 (y, x);

            // Вычисление скорости в плоскости орбиты.
            double vx = -_auxsqrth * sinE / eccentric;
            double vy =  _auxsqrtmu1me2a * cosE / eccentric;

            return new OrbitalPosition (this, t, M, E, x, y, r, trueAnomaly, vx, vy);
        }

        //public OrbitalPosition ComputePositionNearParabolic (double t)
        //{
        //    double M = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, t - _t0);
        //    double E = Formulae.KeplerEquation.NearParabolic.Solve (M, _e, _aux1me);

        //    double c1   = 0.0, c2 = 0.0, c3 = 0.0;
        //    double n    = 1.0, sqrE = E * E;
        //    double term = 1.0;

        //    for (int i = 0; i < 7; i++)
        //    {
        //        c1   += term;
        //        term /= ++n;
        //        c2   += term;
        //        term /= ++n;
        //        c3   += term;

        //        term *= -sqrE;
        //    }

        //    // Вычисление положения в плоскости орбиты.
        //    (double sinE, double cosE) = double.SinCos (E);
        //    double eccentric = 1.0 - _e * cosE;

        //    double x = _a * (cosE - _e);
        //    double y = _a * _auxsqrt1me2 * sinE;
        //    double r = _a * eccentric;
        //    double trueAnomaly = double.Atan2 (y, x);

        //    // Вычисление скорости в плоскости орбиты.
        //    double vx = -_auxsqrth * sinE / eccentric;
        //    double vy = _auxsqrtmu1me2a * cosE / eccentric;

        //    return new OrbitalPosition (t, M, E, x, y, r, trueAnomaly, vx, vy);
        //}
    }
}