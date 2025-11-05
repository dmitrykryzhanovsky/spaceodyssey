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
        /// Расстояние в апоцентре.
        /// </summary>
        /// <remarks>Для незамкнутых орбит (параболической и гиперболической) апоцентра не существует, расстояние до небесного тела 
        /// возрастает до бесконечности. В этом случае данное свойство возвращает +∞.</remarks>
        public abstract double RA { get; }

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