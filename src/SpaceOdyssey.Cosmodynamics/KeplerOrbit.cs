namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private readonly Mass _center;   // Центральное тело.
        private readonly Mass _orbiting; // Тело, обращающееся по орбите.

        private readonly double _mu;     // Локальная гравитационная постоянная для данной орбиты.

        private double _p;
        private double _e;
        private double _rp;

        private double _n;
        private double _vp;

        private double _h;

        private double _t0;

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
        /// Полная удельная энергия (приходящаяся на 1 кг массы) тела, двигающегося по данной орбите.
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

        protected KeplerOrbit (Mass center, Mass orbiting)
        {
            _center   = center;
            _orbiting = orbiting;

            _mu       = _center.GM + _orbiting.GM;
        }

        public abstract double Radius (double trueAnomaly);

        public abstract double TrueAnomaly (double r);

        public abstract double SpeedForRadius (double r);

        public abstract double SpeedForTrueAnomaly (double trueAnomaly);

        public abstract OrbitalPosition ComputePosition (double t);

        public abstract OrbitalPosition.PlanarPosition ComputePlanarPosition (double trueAnomaly);
    }
}