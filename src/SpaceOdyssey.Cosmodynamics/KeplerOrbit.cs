namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для кеплеровых орбит.
    /// </summary>
    public abstract class KeplerOrbit
    {
        private CentralBody _centralBody;

        protected double _p;
        protected double _e;
        protected double _amin;

        protected double _n;

        private double _t0;

        /// <summary>
        /// Центральное тело, создающее гравитационное поле орбиты.
        /// </summary>
        public CentralBody CentralBody
        {
            get => _centralBody;
        }

        protected double Mu
        {
            get => _centralBody.GParameter;
        }

        protected double K
        {
            get => _centralBody.GConstant;
        }

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

        /// <summary>
        /// Среднее суточное движение.
        /// </summary>
        /// <remarks>Выражается в радианах / сутки.</remarks>
        public double N
        {
            get => _n;
        }

        /// <summary>
        /// Момент прохождения перицентра в юлианских датах.
        /// </summary>
        public double T0
        {
            get => _t0;

            set => _t0 = value;
        }

        protected KeplerOrbit (CentralBody centralBody)
        {
            _centralBody = centralBody;
        }

        protected KeplerOrbit (CentralBody centralBody, double e) : this (centralBody)
        {
            _e = e;
        }

        protected abstract void CheckE (double e);

        protected void CheckAmin (double amin)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException (nameof (amin));
        }

        protected void CheckN (double n)
        {
            if (n <= 0.0) throw new ArgumentOutOfRangeException (nameof (n));
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
        /// корректность. Условие корректности задаётся в методе <see cref="CheckR"/>.</exception>
        public virtual double TrueAnomaly (double r)
        {
            CheckR (r);

            return double.Acos ((_p / r - 1.0) / _e);
        }

        protected virtual void CheckR (double r)
        {
            if (r < _amin) throw new ArgumentOutOfRangeException (nameof (r));
        }

        public abstract OrbitalPosition ComputePosition (double t);

        public double MeanAnomaly (double t)
        {
            return _n * (t - _t0);
        }

        public abstract double SolveKeplerEquation (double M);
    }
}