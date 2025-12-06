using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        /// <summary>
        /// Эксцентриситет окружности = 0.
        /// </summary>
        protected const double CircularEccentricity = 0.0;

        /// <summary>
        /// Эксцентриситет параболы = 1.
        /// </summary>
        protected const double ParabolicEccentricity = 1.0;

        private readonly Mass _center;     // Центральное тело.
        private readonly Mass _orbiting;   // Тело, обращающееся по орбите.

        protected readonly double _mu;     // Локальная гравитационная постоянная для данной орбиты.
        protected readonly double _sqrtmu; // Квадратный корень из локальной гравитационной постоянной.

        protected double _e;
        protected double _p;
        protected double _rp;

        protected double _h;

        protected double _n;
        protected double _vp;

        protected double _t0;

        /// <summary>
        /// Эксцентриситет.
        /// </summary>
        public double E
        {
            get => _e;
        }

        /// <summary>
        /// Фокальный параметр.
        /// </summary>
        public double P
        {
            get => _p;
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

        #region Init and compute orbit

        #region Set parameters

        protected void SetParametersByPeriapsis (double e, double rp)
        {
            _e  = e;
            _rp = rp;
        }

        public virtual void SetPeriapsisTime (double t0)
        {
            _t0 = t0;
        }

        #endregion

        #endregion

        /// <summary>
        /// Возвращает расстояние от фокуса (радиус) для истинной аномалии trueAnomaly.
        /// </summary>
        public abstract double Radius (double trueAnomaly);

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <param name="r">Должно быть положительным и соответствовать ограничениям, накладываемым на расстояние формой орбиты.</param>
        public double TrueAnomaly (double r)
        {
            CheckR (r);

            return ConicSectionInverseEquation (r);
        }

        /// <summary>
        /// Проверяет, что расстояние r соответствует ограничениям, накладываемым формой орбиты, а именно что r >= расстояния в 
        /// перицентре r.
        /// </summary>
        protected virtual void CheckR (double r)
        {
            Checkers.CheckRGreaterEqualPeriapsis (r, _rp);
        }

        protected abstract double ConicSectionInverseEquation (double r);

        /// <summary>
        /// Скорость на орбите на расстоянии r.
        /// </summary>
        public abstract double SpeedForRadius (double r);

        /// <summary>
        /// Скорость на орбите для истинной аномалии trueAnomaly.
        /// </summary>
        public abstract double SpeedForTrueAnomaly (double trueAnomaly);

        protected static class Checkers
        {
            /// <summary>
            /// Проверяет, чтобы эксцентриситет эллипса был 0 <= e < 1.
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException">Генерируется, если e < 0 или e >= 1.</exception>
            internal static void CheckEForEllipse (double e)
            {
                ArgumentOutOfRangeCheckers.CheckIntervalRightExcluded (e, CircularEccentricity, ParabolicEccentricity);
            }

            /// <summary>
            /// Проверяет, чтобы эксцентриситет гиперболы e был больше 1.
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException">Генерируется, если e <= 1.</exception>
            internal static void CheckEForHyperbola (double e)
            {
                ArgumentOutOfRangeCheckers.CheckGreater (e, ParabolicEccentricity);
            }

            /// <summary>
            /// Проверяет, чтобы расстояние r было положительным.
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException">Генерируется, если r <= 0.</exception>
            internal static void CheckRPositive (double r)
            {
                ArgumentOutOfRangeCheckers.CheckPositive (r);
            }

            /// <summary>
            /// Проверяет, чтобы расстояние r было больше или равно rp.
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException">Генерируется, если r < rp.</exception>
            internal static void CheckRGreaterEqualPeriapsis (double r, double rp)
            {
                ArgumentOutOfRangeCheckers.CheckGreaterEqual (r, rp);
            }

            /// <summary>
            /// Проверяет, чтобы расстояние r лежало на интервале [rp; ra].
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException">Генерируется, если rp <= r <= ra.</exception>
            internal static void CheckRBetweenPeriapsisAndApoapsis (double r, double rp, double ra)
            {
                ArgumentOutOfRangeCheckers.CheckInterval (r, rp, ra);
            }

            /// <summary>
            /// Проверяет, чтобы отрезок времени T был положительным.
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException">Генерируется, если T <= 0.</exception>
            internal static void CheckTPositive (double T)
            {
                ArgumentOutOfRangeCheckers.CheckPositive (T);
            }
        }
    }
}