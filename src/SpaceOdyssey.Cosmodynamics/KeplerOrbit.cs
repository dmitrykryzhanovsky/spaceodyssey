namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для кеплеровых орбит.
    /// </summary>
    public abstract class KeplerOrbit
    {
        protected double _p;

        private double _e;

        protected double _amin;

        /// <summary>
        /// Фокальный (орбитальный) параметр.
        /// </summary>
        /// <remarks>Расстояние от центра тяготения, расположенного в фокусе, при истинной аномалии = 90°.</remarks>
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
        public double Amin
        {
            get => _amin;
        }

        protected KeplerOrbit (double p, double e, double amin)
        {
            _p    = p;
            _e    = e;
            _amin = amin;
        }

        /// <summary>
        /// Расстояние до центра тяготения при истинной аномалии trueAnomaly.
        /// </summary>
        /// <param name="trueAnomaly">Задаётся в радианах.</param>
        public virtual double Radius (double trueAnomaly)
        {
            return _p / (1.0 + _e * double.Cos (trueAnomaly));
        }

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если значение <paramref name="r"/> не проходит проверку на 
        /// корректность. Условие корректности задаётся в методе <see cref="CheckParametersForTrueAnomaly"/>.</exception>
        public virtual double TrueAnomaly (double r)
        {
            CheckParametersForTrueAnomaly (r);

            return double.Acos ((_p / r - 1.0) / _e);
        }

        protected virtual void CheckParametersForTrueAnomaly (double r)
        {
            if (r < _amin) throw new ArgumentOutOfRangeException ();
        }
    }
}