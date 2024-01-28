namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для кеплеровых орбит.
    /// </summary>
    public abstract class KeplerOrbit
    {
        #region Свойства гравитационного поля орбитальной системы

        // Центральное тело данной орбиты.
        protected readonly ICentralBody _centralBody;

        // Гравитационная постоянная – квадратный корень из произведения гравитационной постоянной Ньютона G и массы центрального тела M:
        // sqrt (GM).
        protected double K
        {
            get => _centralBody.GravitationalConstant;
        }

        // Гравитационный параметр – произведение гравитационной постоянной Ньютона G и массы центрального тела M: GM.
        protected double Mu
        {
            get => _centralBody.GravitationalParameter;
        }

        #endregion

        // Эксцентриситет орбиты.
        protected double _e;

        // Орбитальный (фокальный) параметр – расстояние от фокуса орбиты до точки с истинной аномалией 90°.
        protected double _p;

        // Минимальное расстояние (расстояние в перицентре).
        protected double _amin;

        // Среднее движение, рад / единица времени.
        protected double _n;

        // Средняя аномалия на момент времени J2000.
        private double _M0;

        // Юлианская дата прохождения перицентра.
        protected double _T0;

        /// <summary>
        /// Эксцентриситет орбиты.
        /// </summary>
        public double Eccentricity
        {
            get => _e;
        }

        /// <summary>
        /// Орбитальный (фокальный) параметр – расстояние от фокуса орбиты до точки с истинной аномалией 90°.
        /// </summary>
        public double OrbitalParameter
        {
            get => _p;
        }

        /// <summary>
        /// Минимальное расстояние (расстояние в перицентре).
        /// </summary>
        public double Periapsis
        {
            get => _amin;
        }

        /// <summary>
        /// Среднее движение, рад / единица времени.
        /// </summary>
        public double MeanMotion
        {
            get => _n;
        }

        #region Constructors

        protected KeplerOrbit (ICentralBody centralBody)
        {
            _centralBody = centralBody;
        }

        #endregion

        /// <summary>
        /// Устанавливает среднюю аномалию на момент времени J2000.
        /// </summary>
        public void SetMeanAnomalyJ2000 (double meanAnomalyJ200)
        {
            _M0 = meanAnomalyJ200;
            _T0 = AstroConst.J2000 - _M0 / _n;
        }

        /// <summary>
        /// Устанавливает юлианскую дату прохождения перицентра.
        /// </summary>
        /// <remarks>Для эллиптических (и круговых) орбит это может быть дата любого прохождения перицентра. Для параболических и 
        /// гиперболических – единственного.</remarks>
        public void SetPeripasisJD (double periapsisJD)
        {
            _T0 = periapsisJD;
            _M0 = _n * (_T0 - AstroConst.J2000);
        }

        #region Проверка элементов орбиты на валидность

        protected static void CheckPeriapsis (double periapsis)
        {
            if (periapsis <= 0.0) throw new DimensionalElementNegativeException ();
        }

        protected static void CheckMeanMotion (double meanMotion)
        {
            if (meanMotion <= 0.0) throw new TemporalElementNegativeException ();
        }

        #endregion

        /// <summary>
        /// Вычисляет планарную позицию – положение в плоскости орбиты – для юлианской даты t.
        /// </summary>
        public abstract PlanarPosition ComputePlanarPosition (double t);

        /// <summary>
        /// Вычисляет среднюю аномалию для юлианской даты t.
        /// </summary>
        protected virtual double ComputeMeanAnomaly (double t)
        {
            return _n * (t - _T0);
        }
    }
}