using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Круговая орбита.
    /// </summary>
    public class CircularOrbit : EllipticOrbit
    {
        #region Constructors

        public CircularOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация элементов орбиты через большую полуось semiMajorAxis.
        /// </summary>
        /// <param name="semiMajorAxis">Должна быть больше 0.</param>
        /// <exception cref="DimensionalElementNegativeException">Если semiMajorAxis <= 0.</exception>
        public void SetOrbitalElementsBySemiMajorAxis (double semiMajorAxis)
        {
            CheckSemiMajorAxis (semiMajorAxis);

            _a = semiMajorAxis;

            _e        = 0.0;
            _e2factor = 1.0;

            _p    = _a;
            _b    = _a;
            _amin = _a;
            _amax = _a;

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через среднее движение meanMotion.
        /// </summary>
        /// <param name="meanMotion">Должно быть больше 0.</param>
        /// <exception cref="TemporalElementNegativeException">Если meanMotion <= 0.</exception>
        public void SetOrbitalElementsByMeanMotion (double meanMotion)
        {
            CheckMeanMotion (meanMotion);

            _n = meanMotion;

            _e        = 0.0;
            _e2factor = 1.0;

            _a    = CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (K2, _n);
            _p    = _a;
            _b    = _a;
            _amin = _a;
            _amax = _a;

            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Инициализация элементов орбиты через орбитальный период orbitalPeriod.
        /// </summary>
        /// <param name="orbitalPeriod">Должен быть больше 0.</param>
        /// <exception cref="TemporalElementNegativeException">Если orbitalPeriod <= 0.</exception>
        public void SetOrbitalElementsByOrbitalPeriod (double orbitalPeriod)
        {
            CheckOrbitalPeriod (orbitalPeriod);

            _T = orbitalPeriod;

            _e        = 0.0;
            _e2factor = 1.0;

            _a    = CosmodynamicsFormulae.SemiMajorAxisByOrbitalPeriod (K2, _T);
            _p    = _a;
            _b    = _a;
            _amin = _a;
            _amax = _a;

            _n = CosmodynamicsFormulae.MeanMotionByOrbitalPeriod (_T);

            _gmFactor = CosmodynamicsFormulae.GMFactorForEllipse (K, _a);
        }

        /// <summary>
        /// Вычисляет планарную позицию – положение в плоскости орбиты – для юлианской даты t.
        /// </summary>
        public override PlanarPosition ComputePlanarPosition (double t)
        {
            return PlanarPosition.BuildPlanarPositionForCircularOrbit (ComputeMeanAnomaly (t), _a, _gmFactor);
        }
    }
}