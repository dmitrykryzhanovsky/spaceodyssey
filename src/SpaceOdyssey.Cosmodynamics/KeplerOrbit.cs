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

        protected double _vp;

        protected double _energyIntegral;
        protected double _arealVelocity;

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

        #region Constructors

        protected KeplerOrbit (Mass center, Mass probe)
        {
            InitMasses (center, probe);
        }

        private void InitMasses (Mass center, Mass probe)
        {
            _center = center;
            _probe  = probe;
            _mu     = center.GM + probe.GM;
        }

        #endregion

        protected void ComputeOrbit ()
        {
            ComputeShape ();
            ComputeMotion ();
            ComputeIntegrals ();
        }

        protected abstract void ComputeShape ();

        protected abstract void ComputeMotion ();

        protected abstract void ComputeIntegrals ();

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

        public static class Formulae
        {
            public static double ConicSection (double trueAnomaly, double p, double e)
            {
                return p / (1.0 + e * double.Cos (trueAnomaly));
            }

            public static double ConicSectionParabola (double trueAnomaly, double p)
            {
                return p / (1.0 + double.Cos (trueAnomaly));
            }

            public static double ConicSectionInverse (double r, double p, double e)
            {
                return double.Acos ((p / r - 1.0) / e);
            }

            public static double ConicSectionInverseParabola (double r, double p)
            {
                return double.Acos (p / r - 1.0);
            }

            public static double PParabolaByRp (double rp)
            {
                return rp * 2.0;
            }

            public static double Asymptote (double e)
            {
                return double.Acos (-1.0 / e);
            }

            public static double RangeARp (double x1me)
            {
                return 1.0 / x1me;
            }

            public static double RangeRaA (double x1pe)
            {
                return x1pe;
            }

            public static double RangeRaRp (double x1me, double x1pe)
            {
                return x1pe / x1me;
            }

            public static double GMA (double mu, double a)
            {
                return mu / a;
            }

            public static double GMASqrt (double mua)
            {
                return double.Sqrt (mua);
            }

            public static double V1Circular (double mu, double r)
            {
                return double.Sqrt (mu / r);
            }

            public static double V2Escape (double mu, double r)
            {
                return double.Sqrt (2.0 * mu / r);
            }

            public static double MeanMotion (double a, double muasqrt)
            {
                return muasqrt / a;
            }

            public static double OrbitalPeriod (double a, double muasqrt)
            {
                return double.Tau * a / muasqrt;
            }

            public static double ArealVelocityNonParabola (double mu, double a)
            {
                return double.Sqrt (mu * a);
            }

            public static double ArealVelocityParabola (double mu, double rp)
            {
                return double.Sqrt (2.0 * mu * rp);
            }
        }

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
    }
}