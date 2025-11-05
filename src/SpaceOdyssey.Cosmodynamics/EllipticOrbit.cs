namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        private double _b;
        private double _ra;

        /// <summary>
        /// Малая полуось.
        /// </summary>
        public double B
        {
            get => _b;
        }

        public override double RA
        {
            get => _ra;
        }

        /// <summary>
        /// Отношение расстояния в апоцентре к расстоянию в перицентре.
        /// </summary>
        public double RatioAP
        {
            get => throw new NotImplementedException ();
        }

        /// <summary>
        /// Отношение расстояния в апоцентре к среднему расстоянию.
        /// </summary>
        public double RatioAMean
        {
            get => throw new NotImplementedException ();
        }

        /// <summary>
        /// Отношение расстояния среднего расстояния к расстоянию в перицентре.
        /// </summary>
        public double RatioMeanP
        {
            get => throw new NotImplementedException ();
        }

        protected EllipticOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }
    }
}