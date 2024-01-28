using Archimedes;

using System.Drawing;

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

            _gmFactor = CosmodynamicsFormulae.GMFactorForHyperbola (K, _a);
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

            _gmFactor = CosmodynamicsFormulae.GMFactorForHyperbola (K, _a);
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

            _gmFactor = CosmodynamicsFormulae.GMFactorForHyperbola (K, _a);
        }

        #region Проверка элементов орбиты на валидность

        private static void CheckEccentricity (double eccentricity)
        {
            if (!CosmodynamicsFormulae.IsEccentricityValidForHyperbola (eccentricity)) throw new HyperbolaEccentricityOutOfRangeException ();
        }

        #endregion

        /// <summary>
        /// Вычисляет планарную позицию – положение в плоскости орбиты – для юлианской даты t.
        /// </summary>
        public override PlanarPosition ComputePlanarPosition (double t)
        {
            double M = ComputeMeanAnomaly (t);
            double H = KeplerEquation.Hyperbolic (M, _e, ComputingSettings.DoublePrecision);

            double shH = double.Sinh (H);
            double chH = double.Cosh (H);
            double denominator = _e * chH - 1.0;

            double x  = -_a * (_e - chH);
            double y  = _a * _e2factor * shH;
            double vx = -_gmFactor * shH / denominator;
            double vy = _gmFactor * _e2factor * chH / denominator;

            return PlanarPosition.BuildPlanarPositionForEllipticAndHyperbolicOrbit (x, y, vx, vy);
        }
    }
}