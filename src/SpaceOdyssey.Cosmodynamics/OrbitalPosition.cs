namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Положение тела на орбите.
    /// </summary>
    public partial struct OrbitalPosition
    {
        private readonly double _t;

        private readonly double _M;
        private readonly double _MNormalized;
        private readonly double _E;

        private readonly Planar _planarPosition;
        
        /// <summary>
        /// Момент времени.
        /// </summary>
        public double Time
        {
            get => _t;
        }

        /// <summary>
        /// Средняя аномалия, отсчитываемая от момента прохождения перицентра, заданного в элементах орбиты.
        /// </summary>
        /// <remarks>Может содержать в себе любое число оборотов, и, таким образом, выходить за пределы диапазона (-π; +π].</remarks>
        public double M
        {
            get => _M;
        }

        /// <summary>
        /// Средняя аномалия, приведённая в диапазон (-π; +π].
        /// </summary>
        public double MNormalized
        {
            get => _MNormalized;
        }

        /// <summary>
        /// Эксцентрическая аномалия.
        /// </summary>
        public double E
        {
            get => _E;
        }

        /// <summary>
        /// Истинная аномалия.
        /// </summary>
        public double TrueAnomaly
        {
            get => _planarPosition.PolarPosition.Heading;
        }

        /// <summary>
        /// Расстояние до центра орбиты.
        /// </summary>
        public double R
        {
            get => _planarPosition.PolarPosition.R;
        }

        /// <summary>
        /// Величина скорости.
        /// </summary>
        public double Speed
        {
            get => _planarPosition.Speed;
        }

        /// <summary>
        /// Положение тела в плоскости орбиты.
        /// </summary>
        public Planar PlanarPosition
        {
            get => _planarPosition;
        }

        internal OrbitalPosition (double t, double M, double MNormalized, double E, double planarX, double planarY, double r, 
            double trueAnomaly, double planarVX, double planarVY, double speed)
        {
            _t = t;

            _M           = M;
            _MNormalized = MNormalized;
            _E           = E;

            _planarPosition = new Planar (planarX, planarY, r, trueAnomaly, planarVX, planarVY, speed);
        }
    }
}