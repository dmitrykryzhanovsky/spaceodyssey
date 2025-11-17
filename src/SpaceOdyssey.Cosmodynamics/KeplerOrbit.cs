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

        protected double _h;

        protected double _n;
        protected double _vp;

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

        protected virtual void ComputeOrbitByPeriapsis (double e, double rp, double t0)
        {
            _e  = e;
            _rp = rp;
            _t0 = t0;
        }
    }
}