using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Параболическая орбита.
    /// </summary>
    public class ParabolicOrbit : KeplerOrbit
    {
        #region Constructors

        public ParabolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация элементов орбиты через среднее движение meanMotion.
        /// </summary>
        /// <param name="meanMotion">Должно быть больше 0.</param>
        /// <exception cref="TemporalElementNegativeException">Если meanMotion <= 0.</exception>
        public void SetOrbitalElementsByMeanMotion (double meanMotion)
        {
            CheckMeanMotion (meanMotion);

            _n = meanMotion;

            _e    = 1.0;
            _amin = double.Cbrt (K2 / (2.0 * _n * _n));
            _p    = 2.0 * _amin;
        }

        /// <summary>
        /// Инициализация элементов орбиты через расстояние в перицентре periapsis.
        /// </summary>
        /// <param name="periapsis">Должно быть больше 0.</param>
        /// <exception cref="DimensionalElementNegativeException">Если periapsis <= 0.</exception>
        public void SetOrbitalElementsByPeriapsis (double periapsis)
        {
            CheckPeriapsis (periapsis);

            _amin = periapsis;

            _e = 1.0;
            _p = 2.0 * _amin;
            _n = K / (_amin * double.Sqrt (2.0 * _amin));
        }

        public override PlanarPosition ComputePlanarPosition (double t)
        {
            double A = 1.5 * ComputeMeanAnomaly (t);
            double B = double.Cbrt (A + double.Sqrt (A * A + 1.0));

            double tanV2       = B - 1.0 / B;
            double trueAnomaly = 2.0 * double.Atan (tanV2);

            double x = _amin * (1.0 - tanV2 * tanV2);
            double y = _amin * 2.0 * tanV2;
            double r = CosmodynamicsFormulae.Radius (_p, _e, trueAnomaly);

            return PlanarPosition.BuildPlanarPositionForParabolicOrbit (x, y, r, trueAnomaly);
        }
    }
}