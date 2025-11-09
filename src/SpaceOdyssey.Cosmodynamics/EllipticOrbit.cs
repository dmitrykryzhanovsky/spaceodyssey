using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        protected double _aux1me2;     // Вспомогательная величина 1 - e^2.
        protected double _auxsqrt1me2; // Вспомогательная величина sqrt(1 - e^2).

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

        #region Init and compute orbit

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя расстояние в перицентре rp, эксцентриситет e и момент прохождения перицентра 
        /// t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e < 0 или e >= 1 или</item>
        /// <item>rp <= 0.</item></list></exception>
        public static EllipticOrbit CreateByRPeriapsis (Mass center, Mass orbiting, double rp, double e, double t0)
        {
            CheckEForEllipse (e);
            CheckRPositive (rp);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitByRPE (rp, e, t0);

            return orbit;
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту, инициализируя большую полуось a, эксцентриситет e и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e < 0 или e >= 1 или</item>
        /// <item>a <= 0.</item></list></exception>
        public static EllipticOrbit CreateBySemiMajor (Mass center, Mass orbiting, double a, double e, double t0)
        {
            CheckEForEllipse (e);
            CheckRPositive (a);

            EllipticOrbit orbit = new EllipticOrbit (center, orbiting);

            orbit.ComputeOrbitByAE (a, e, t0);

            return orbit;
        }

        protected void ComputeOrbitByRPE (double rp, double e, double t0)
        {
            _e  = e;
            _rp = rp;

            ComputeAuxiliary ();
            ComputeShapeByRPE ();
            ComputeMotionByRPE ();
            ComputeIntegrals ();

            SetMeanAnomalyForT0 (t0);
        }

        protected void ComputeOrbitByAE (double a, double e, double t0)
        {
            _a = a;
            _e = e;

            ComputeAuxiliary ();
            ComputeShapeByAE ();
            ComputeMotionByAE ();
            ComputeIntegrals ();

            SetMeanAnomalyForT0 (t0);
        }

        protected override void ComputeAuxiliary ()
        {
            base.ComputeAuxiliary ();

            _aux1me2     = 1.0 - _e * _e;
            _auxsqrt1me2 = double.Sqrt (_aux1me2);
        }

        protected override void ComputeShapeByRPE ()
        {
            base.ComputeShapeByRPE ();

            _b  = _rp * double.Sqrt (_aux1pe / _aux1me);
            _ra = _rp * _aux1pe / _aux1me;
        }

        private void ComputeShapeByAE ()
        {
            _p  = Formulae.Shape.NonParabola.FocalParameterByA (_a, _aux1me2);
            _b  = _a * _auxsqrt1me2;
            _rp = _a * _aux1me;
            _ra = _a * _aux1pe;
        }

        protected override void ComputeMotionByRPE ()
        {
            base.ComputeMotionByRPE ();

            _va = Formulae.Motion.NonParabola.SpeedAtApoapsisByRP (_mu, _rp, _aux1pe, _aux1me);
        }

        protected void ComputeMotionByAE ()
        {
            ComputeMotionInvariants ();

            _vp = Formulae.Motion.NonParabola.SpeedAtPeriapsisByA (_mu, _a, _aux1pe, _aux1me);
            _va = Formulae.Motion.NonParabola.SpeedAtApoapsisByA (_mu, _a, _aux1pe, _aux1me);
        }

        protected override void ComputeMotionInvariants ()
        {
            base.ComputeMotionInvariants ();

            _T     = Formulae.Motion.NonParabola.Ellipse.OrbitalPeriodByMeanMotion (_n);
            _vmean = Geometry2.Ellipse.Length (_a, _auxsqrt1me2) / _T;
        }

        protected void SetMeanAnomalyForT0 (double t0)
        {
            _t0 = t0;
            _M0 = Formulae.Motion.NonParabola.Ellipse.NormalizeMeanAnomaly (_n, _t0 - Time.J2000);
        }

        #endregion

        protected override void CheckR (double r)
        {
            ArgumentOutOfRangeCheckers.CheckInterval (r, _rp, _ra);
        }

        public override double SpeedForRadius (double r)
        {
            throw new NotImplementedException ();
        }

        public override double SpeedForTrueAnomaly (double trueAnomaly)
        {
            throw new NotImplementedException ();
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            throw new NotImplementedException ();
        }

        public override OrbitalPosition.PlanarPosition ComputePlanarPosition (double trueAnomaly)
        {
            throw new NotImplementedException ();
        }
    }
}