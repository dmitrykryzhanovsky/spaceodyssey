using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private readonly Mass _center;     // Центральное тело.
        private readonly Mass _orbiting;   // Тело, обращающееся по орбите.

        protected readonly double _mu;     // Локальная гравитационная постоянная для данной орбиты.
        protected readonly double _sqrtmu; // Квадратный корень из локальной гравитационной постоянной.

        protected double _p;
        protected double _e;
        protected double _rp;

        protected double _n;
        protected double _vp;

        protected double _h;

        protected double _t0;

        /// <summary>
        /// Фокальный параметр.
        /// </summary>
        public double P
        {
            get => _p;
        }

        /// <summary>
        /// Эксцентриситет.
        /// </summary>
        public double E
        {
            get => _e;
        }

        /// <summary>
        /// Расстояние в перицентре.
        /// </summary>
        public double RP
        {
            get => _rp;
        }

        /// <summary>
        /// Среднее движение, угол / единица времени.
        /// </summary>
        public double N
        {
            get => _n;
        }

        /// <summary>
        /// Скорость в перицентре.
        /// </summary>
        public double VP
        {
            get => _vp;
        }

        /// <summary>
        /// Интеграл энергии.
        /// </summary>
        public double EnergyIntegral
        {
            get => _h;
        }

        /// <summary>
        /// Удельная орбитальная энергия.
        /// </summary>
        public double W
        {
            get => _h / 2.0;
        }

        /// <summary>
        /// Момент прохождения перицентра, в юлианских датах.
        /// </summary>
        public double T0
        {
            get => _t0;
        }

        #region Constructors

        protected KeplerOrbit (Mass center, Mass orbiting)
        {
            _center   = center;
            _orbiting = orbiting;

            _mu       = _center.GM + _orbiting.GM;
            _sqrtmu   = double.Sqrt (_mu);
        }

        #endregion

        public abstract double Radius (double trueAnomaly);

        public double TrueAnomaly (double r)
        {
            CheckR (r);

            return ConicSectionInverseEquation (r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        protected abstract void CheckR (double r);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        protected abstract double ConicSectionInverseEquation (double r);

        public abstract double SpeedForRadius (double r);

        public abstract double SpeedForTrueAnomaly (double trueAnomaly);

        public abstract OrbitalPosition ComputePosition (double t);

        public abstract OrbitalPosition.PlanarPosition ComputePlanarPosition (double trueAnomaly);

        /// <summary>
        /// Проверяет, чтобы расстояние r было положительным.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если r <= 0.</exception>
        protected static void CheckRPositive (double r)
        {
            ArgumentOutOfRangeCheckers.CheckPositive (r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="rp"></param>
        protected static void CheckRForNonClosedOrbit (double r, double rp)
        {
            ArgumentOutOfRangeCheckers.CheckGreaterEqual (r, rp);
        }
    }
}