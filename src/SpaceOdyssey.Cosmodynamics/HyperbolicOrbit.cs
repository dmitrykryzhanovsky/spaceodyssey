namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Гиперболическая орбита.
    /// </summary>
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        // Асимптотический угол гиперболы: такое значение истинной аномалии, при которой расстояние до орбитального центра становится
        // равным +∞.
        private double _asymptote;

        /// <summary>
        /// Асимптотический угол гиперболы: такое значение истинной аномалии, при которой расстояние до орбитального центра становится 
        /// равным +∞.
        /// </summary>
        public double Asymptote
        {
            get => _asymptote;
        }

        #region Constructors

        public HyperbolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и среднее движение meanMotion.
        /// </summary>
        /// <param name="eccentricity">Должен быть больше 1.</param>
        /// <param name="meanMotion">Должно быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует гиперболе (меньше либо равен 1).</exception>
        /// <exception cref="TemporalElementNegativeException">Если meanMotion <= 0.</exception>
        public override void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion)
        {
            CheckEccentricity (eccentricity);
            CheckMeanMotion (meanMotion);

            _e = eccentricity;
            _n = meanMotion;

            _e2factor  = double.Sqrt (_e * _e - 1.0);
            _asymptote = double.Acos (-1.0 / _e);

            _a    = -CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (K2, _n);
            _p    = _a * (1.0 - _e * _e);
            _amin = _a * (1.0 - _e);
        }

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и расстояние в перицентре periapsis.
        /// </summary>
        /// <param name="eccentricity">Должен быть больше 1.</param>
        /// <param name="periapsis">Должно быть больше 0.</param>
        /// <exception cref="EllipseEccentricityOutOfRangeException">Если eccentricity не соответствует гиперболе (меньше либо равен 1).</exception>
        /// <exception cref="DimensionalElementNegativeException">Если periapsis <= 0.</exception>
        public override void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis)
        {
            CheckEccentricity (eccentricity);
            CheckPeriapsis (periapsis);

            _e    = eccentricity;
            _amin = periapsis;

            _e2factor  = double.Sqrt (_e * _e - 1.0);
            _asymptote = double.Acos (-1.0 / _e);

            _p = _amin * (1.0 + _e);
            _a = _amin / (1.0 - _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForHyperbola (K, _a);
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
            
            _a = -CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (K2, _n);
            _p = _amin * (2.0 - _amin / _a);

            _e         = (_a - _amin) / _a;
            _e2factor  = double.Sqrt (_amin * (_amin - 2.0 * _a)) / -_a;
            _asymptote = double.Acos (_a / (_amin - _a));            
        }

        private static void CheckEccentricity (double eccentricity)
        {
            if (!CosmodynamicsFormulae.IsEccentricityValidForHyperbola (eccentricity)) throw new HyperbolaEccentricityOutOfRangeException ();
        }
    }
}