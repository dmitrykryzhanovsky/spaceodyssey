using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        private double _auxsqrt1me2; // Вспомогательная величина sqrt(1 - e^2).

        private double _b;
        private double _ra;

        private double _T;
        private double _va;
        private double _vmean;

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

        protected override void ComputeOrbitByRPE (double rp, double e, double t0)
        {
            base.ComputeOrbitByRPE (rp, e, t0);

            _auxsqrt1me2 = double.Sqrt (1.0 - _e * _e);

            _b     = rp * double.Sqrt (_aux1pe / _aux1me);
            _ra    = rp * _aux1pe / _aux1me;

            _T     = double.Tau / _n;
            _va    = Formulae.Motion.NonParabola.SpeedAtApoapsisByRP (_mu, _rp, _aux1pe, _aux1me);
            _vmean = Geometry2.Ellipse.Length (_a, _b, _auxsqrt1me2) / _T;

            _M0    = NormalizeMeanAnomaly (_n, _t0 - Time.J2000);
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