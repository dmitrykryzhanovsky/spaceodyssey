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
    }
}