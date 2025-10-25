using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для кеплеровых орбит.
    /// </summary>
    public abstract class KeplerOrbit
    {
        /// <summary>
        /// Эксцентриситет круговой орбиты e = 0.
        /// </summary>
        protected const double CircularEccentricity = 0.0;

        /// <summary>
        /// Эксцентриситет параболической орбиты e = 1.
        /// </summary>
        protected const double ParabolicEccentricity = 1.0;

        /// <summary>
        /// Интеграл энергии параболической орбиты.
        /// </summary>
        protected const double ParabolicEnergyIntegral = 0.0;

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

        #region Compute position in the orbit plane

        /// <summary>
        /// Вычисление положения на орбите в момент времени t.
        /// </summary>
        /// <param name="t">Выражен в юлианских датах.</param>
        public OrbitalPosition ComputePosition (double t)
        {
            double passedMeanAnomaly = Formulae.Motion.MeanAnomalyForTime (t, _t0, _n);
            double M = GetMeanAnolamyForThisOrbitType (passedMeanAnomaly);
            double E = SolveKeplerEquation (M, _e);

            (double x, double y, double r, double trueAnomaly, double vx, double vy, double speed) = GetPositionElements (E);

            return new OrbitalPosition (t, passedMeanAnomaly, M, E, x, y, r, trueAnomaly, vx, vy, speed);
        }

        /// <summary>
        /// На основе пройденной средней аномалии passedMeanAnomaly (которая в общем случае может выходить за пределы диапазона (-π; +π]) 
        /// вычисляет для заданного типа орбиты среднюю аномалию, приведённую в диапазон (-π; +π], которая используется для дальнейших 
        /// расчётов положения на орбите.
        /// </summary>
        protected abstract double GetMeanAnolamyForThisOrbitType (double passedMeanAnomaly);

        /// <summary>
        /// В общем случае решает уравнение Кеплера для средней аномалии M и эксцентриситета e. Более подробные комментарии см. в 
        /// перегруженных методах в дочерних классах.
        /// </summary>
        protected abstract double SolveKeplerEquation (double M, double e);

        /// <summary>
        /// Определяет характеристики положения на орбите на основе решения уравнения Кеплера.
        /// </summary>
        protected abstract (double x, double y, double r, double trueAnomaly, double vx, double vy, double speed) GetPositionElements 
            (double E);

        #endregion

        #region Checkers

        /// <summary>
        /// Чекеры для проверки значений входных параметров орбит на корректность.
        /// </summary>
        protected static class Checkers
        {
            public static void CheckRNonClosed (double r, double rp)
            {
                ArgumentOutOfRangeCheckers.CheckGreaterEqual (r, rp);
            }

            public static void CheckRClosed (double r, double rp, double ra)
            {
                ArgumentOutOfRangeCheckers.CheckInterval (r, rp, ra);
            }

            public static void CheckA (double a)
            {
                ArgumentOutOfRangeCheckers.CheckPositive (a);
            }

            public static void CheckPeriapsis (double rp)
            {
                ArgumentOutOfRangeCheckers.CheckPositive (rp);
            }

            public static void CheckEccentricityForEllipse (double e)
            {
                ArgumentOutOfRangeCheckers.CheckIntervalRightExcluded (e, CircularEccentricity, ParabolicEccentricity);
            }

            public static void CheckEccentricityForHyperbola (double e)
            {
                ArgumentOutOfRangeCheckers.CheckGreater (e, ParabolicEccentricity);
            }
        }

        #endregion
    }
}