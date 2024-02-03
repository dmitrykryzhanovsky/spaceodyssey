using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эллиптическая орбита.
    /// </summary>
    public class EllipticOrbit : NonParabolicOrbit
    {
        // Малая полуось эллипса.
        protected double _b;

        // Максимальное расстояние (расстояние в апоцентре).
        protected double _amax;

        // Орбитальный период.
        protected double _T;

        /// <summary>
        /// Малая полуось эллипса.
        /// </summary>
        public double B
        {
            get => _b;
        }

        /// <summary>
        /// Максимальное расстояние (расстояние в апоцентре).
        /// </summary>
        public double Apoapsis
        {
            get => _amax;
        }

        /// <summary>
        /// Орбитальный период.
        /// </summary>
        public double OrbitalPeriod
        {
            get => _T;
        }

        #region Constructors

        public EllipticOrbit (ICentralBody centralBody) : base (centralBody)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и большую полуось semiMajorAxis.
        /// </summary>
        /// <param name="eccentricity">Должен быть 0 <= eccentricity < 1.</param>
        /// <param name="semiMajorAxis">Должна быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует эллипсу (либо < 0, либо >= 1).</exception>
        /// <exception cref="DimensionalElementNegativeException">Если semiMajorAxis <= 0.</exception>
        public void SetOrbitalElementsBySemiMajorAxis (double eccentricity, double semiMajorAxis)
        {
            CheckEccentricity (eccentricity);
            CheckSemiMajorAxis (semiMajorAxis);

            _e = eccentricity;
            _a = semiMajorAxis;

            _e2factor = double.Sqrt (1.0 - _e * _e);
            
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и среднее движение meanMotion.
        /// </summary>
        /// <param name="eccentricity">Должен быть 0 <= eccentricity < 1.</param>
        /// <param name="meanMotion">Должно быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует эллипсу (либо < 0, либо >= 1).</exception>
        /// <exception cref="TemporalElementNegativeException">Если meanMotion <= 0.</exception>
        public override void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion)
        {
            CheckEccentricity (eccentricity);
            CheckMeanMotion (meanMotion);

            _e = eccentricity;
            _n = meanMotion;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _a    = CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (Mu, _n);
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и орбитальный период orbitalPeriod.
        /// </summary>
        /// <param name="eccentricity">Должен быть 0 <= eccentricity < 1.</param>
        /// <param name="orbitalPeriod">Должен быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует эллипсу (либо < 0, либо >= 1).</exception>
        /// <exception cref="TemporalElementNegativeException">Если orbitalPeriod <= 0.</exception>
        public void SetOrbitalElementsByOrbitalPeriod (double eccentricity, double orbitalPeriod)
        {
            CheckEccentricity (eccentricity);
            CheckOrbitalPeriod (orbitalPeriod);

            _e = eccentricity;
            _T = orbitalPeriod;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _a    = CosmodynamicsFormulae.SemiMajorAxisByOrbitalPeriod (Mu, _T);
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _n = CosmodynamicsFormulae.MeanMotionByOrbitalPeriod (_T);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и расстояние в перицентре periapsis.
        /// </summary>
        /// <param name="eccentricity">Должен быть 0 <= eccentricity < 1.</param>
        /// <param name="periapsis">Должно быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует эллипсу (либо < 0, либо >= 1).</exception>
        /// <exception cref="DimensionalElementNegativeException">Если periapsis <= 0.</exception>
        public override void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis)
        {
            CheckEccentricity (eccentricity);
            CheckPeriapsis (periapsis);

            _e    = eccentricity;
            _amin = periapsis;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _p    = _amin * (1.0 + _e);
            _a    = _amin / (1.0 - _e);
            _b    = _amin * double.Sqrt ((1.0 + _e) / (1.0 - _e));
            _amax = _amin * (1.0 + _e) / (1.0 - _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через расстояние в перицентре periapsis и среднее движение meanMotion.
        /// </summary>
        /// <param name="periapsis">Должно быть больше 0.</param>
        /// <param name="meanMotion">Должно быть больше 0.</param>
        /// <exception cref="DimensionalElementNegativeException">Если periapsis <= 0.</exception>
        /// <exception cref="TemporalElementNegativeException">Если meanMotion <= 0.</exception>
        public override void SetOrbitalElementsByPeriapsisAndMeanMotion (double periapsis, double meanMotion)
        {
            CheckPeriapsis (periapsis);
            CheckMeanMotion (meanMotion);

            _amin = periapsis;
            _n    = meanMotion;

            _a    = CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (Mu, _n);
            _amax = 2.0 * _a - _amin;
            _p    = _amin * _amax / _a;
            _b    = double.Sqrt (_amin * _amax);

            _e        = 1.0 - _amin / _a;
            _e2factor = _b / _a;

            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и расстояние в апоцентре apoapsis.
        /// </summary>
        /// <param name="eccentricity">Должен быть 0 <= eccentricity < 1.</param>
        /// <param name="apoapsis">Должно быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует эллипсу (либо < 0, либо >= 1).</exception>
        /// <exception cref="DimensionalElementNegativeException">Если apoapsis <= 0.</exception>
        public void SetOrbitalElementsByApoapsis (double eccentricity, double apoapsis)
        {
            CheckEccentricity (eccentricity);
            CheckApoapsis (apoapsis);

            _e    = eccentricity;
            _amax = apoapsis;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _p    = _amax * (1.0 - _e);
            _a    = _amax / (1.0 + _e);
            _b    = _amax * double.Sqrt ((1.0 - _e) / (1.0 + _e));
            _amin = _amax * (1.0 - _e) / (1.0 + _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через расстояния в перицентре periapsis и апоцентре apoapsis.
        /// </summary>
        /// <param name="periapsis">Должно быть больше 0.</param>
        /// <param name="apoapsis">Должно быть больше 0.</param>
        /// <exception cref="DimensionalElementNegativeException">Если (periapsis <= 0) или (apoapsis <= 0).</exception>
        /// <exception cref="MinMaxDisorderException">Если periapsis > apoapsis.</exception>
        public void SetOrbitalElementsByApsisDistances (double periapsis, double apoapsis)
        {
            CheckPeriapsis (periapsis);
            CheckApoapsis (apoapsis);
            CheckApsisDistances (periapsis, apoapsis);

            _amin = periapsis;
            _amax = apoapsis;

            double majorAxis = _amax + _amin;

            _e        = (_amax - _amin) / majorAxis;
            _e2factor = 2.0 * double.Sqrt (_amax * _amin) / majorAxis;

            _p = 2.0 * _amax * _amin / majorAxis;
            _a = majorAxis / 2.0;
            _b = double.Sqrt (_amax * _amin);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        #region Проверка элементов орбиты на валидность

        private static void CheckEccentricity (double eccentricity)
        {
            if (!CosmodynamicsFormulae.IsEccentricityValidForEllipse (eccentricity)) throw new EllipseEccentricityOutOfRangeException ();
        }

        protected static void CheckSemiMajorAxis (double semiMajorAxis)
        {
            if (semiMajorAxis <= 0.0) throw new DimensionalElementNegativeException ();
        }

        private static void CheckApoapsis (double apoapsis)
        {
            if (apoapsis <= 0.0) throw new DimensionalElementNegativeException ();
        }

        private static void CheckApsisDistances (double periapsis, double apoapsis)
        {
            if (periapsis > apoapsis) throw new MinMaxDisorderException ("periapsis", "apoapsis");
        }        

        protected static void CheckOrbitalPeriod (double orbitalPeriod)
        {
            if (orbitalPeriod <= 0.0) throw new TemporalElementNegativeException ();
        }

        #endregion

        /// <summary>
        /// Вычисляет планарную позицию – положение в плоскости орбиты – для юлианской даты t.
        /// </summary>
        public override PlanarPosition ComputePlanarPosition (double t)
        {
            double M = ComputeMeanAnomaly (t);
            double E = KeplerEquation.SolveElliptic (M, _e, ComputingSettings.DoublePrecision);

            (double sinE, double cosE) = double.SinCos (E);
            double denominator = 1.0 - _e * cosE;

            double x  = _a * (cosE - _e);
            double y  = _a * _e2factor * sinE;
            double vx = -_gmFactor * sinE / denominator;
            double vy = _gmFactor *_e2factor * cosE / denominator;

            return PlanarPosition.BuildPlanarPositionForEllipticAndHyperbolicOrbit (x, y, vx, vy);
        }

        /// <summary>
        /// Вычисляет среднюю аномалию для юлианской даты t и приводит её в диапазон [–π; +π].
        /// </summary>
        protected override double ComputeMeanAnomaly (double t)
        {
            return Trigonometry.Normalize (base.ComputeMeanAnomaly (t));
        }
    }
}