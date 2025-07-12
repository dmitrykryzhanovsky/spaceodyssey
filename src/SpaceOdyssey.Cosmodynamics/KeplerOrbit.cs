namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для кеплеровых орбит.
    /// </summary>
    public abstract class KeplerOrbit
    {
        private Mass _center; // Центральное тело.
        private Mass _probe;  // Обращающееся тело.

        protected double _mu; // Локальная гравитационная постоянная (по сумме масс _center и _probe).

        protected double _p;
        protected double _e;
        protected double _rp;

        protected double _n;
        protected double _vp;

        protected double _energyIntegral;
        protected double _arealVelocity;

        protected double _t0;

        /// <summary>
        /// Фокальный параметр орбиты (расстояние при истинной аномалии равной 90°).
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
        public double RPeri
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
        /// Орбитальная скорость в перицентре.
        /// </summary>
        public double VPeri
        {
            get => _vp;
        }

        /// <summary>
        /// Интеграл энергии.
        /// </summary>
        public double EnergyIntegral
        {
            get => _energyIntegral;
        }

        /// <summary>
        /// Секторальная скорость.
        /// </summary>
        public double ArealVelocity
        {
            get => _arealVelocity;
        }

        /// <summary>
        /// Момент прохождения перицентра.
        /// </summary>
        public double T0
        {
            get => _t0;
        }

        #region Constructors

        protected KeplerOrbit (Mass center, Mass probe, double t0)
        {
            InitMasses (center, probe);

            _t0 = t0;
        }

        private void InitMasses (Mass center, Mass probe)
        {
            _center = center;
            _probe  = probe;
            _mu     = center.GM + probe.GM;
        }

        #endregion

        #region Orbit parameter computations

        protected void ComputeOrbit ()
        {
            ComputeShape ();
            ComputeMotion ();
            ComputeIntegrals ();
        }

        protected abstract void ComputeShape ();

        protected abstract void ComputeMotion ();

        protected abstract void ComputeIntegrals ();

        #endregion

        /// <summary>
        /// Расстояние до центра тяготения при истинной аномалии trueAnomaly.
        /// </summary>
        public abstract double Radius (double trueAnomaly);

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <param name="r">Должно быть положительным и соответствовать ограничениям, накладываемым на расстояние формой орбиты.</param>
        public abstract double TrueAnomaly (double r);

        /// <summary>
        /// Вычисление положения на орбите в момент времени t.
        /// </summary>
        /// <param name="t">Выражен в юлианских датах.</param>
        public virtual OrbitalPosition ComputePosition (double t)
        {
            double M = _n * (t - _t0);

            return ComputePositionByM (t, M);
        }

        protected abstract OrbitalPosition ComputePositionByM (double t, double M);

        #region Checkers

        /// <summary>
        /// Чекеры для проверки значений входных параметров орбит на корректность.
        /// </summary>
        protected static class Checkers
        {
            public static void CheckRNonClosed (double r, double rp)
            {
                if (r < rp) throw new ArgumentOutOfRangeException ();
            }

            public static void CheckRClosed (double r, double rp, double ra)
            {
                if ((r < rp) || (r > ra)) throw new ArgumentOutOfRangeException ();
            }

            public static void CheckA (double a)
            {
                if (a <= 0.0) throw new ArgumentOutOfRangeException ();
            }

            public static void CheckPeriapsis (double rp)
            {
                if (rp <= 0.0) throw new ArgumentOutOfRangeException ();
            }

            public static void CheckEccentricityForEllipse (double e)
            {
                if ((e < 0.0) || (e >= 1.0)) throw new ArgumentOutOfRangeException ();
            }

            public static void CheckEccentricityForHyperbola (double e)
            {
                if (e <= 1.0) throw new ArgumentOutOfRangeException ();
            }
        }

        #endregion
    }
}