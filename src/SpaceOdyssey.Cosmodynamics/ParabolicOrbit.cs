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
            throw new NotImplementedException ();
        }
    }
}