namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        /// <summary>
        /// Эксцентриситет параболы = 1.
        /// </summary>
        private const double ParabolicEccentricity = 1.0;

        /// <summary>
        /// Свойство для отражения того факта, что орбита незамкнутая и уходит на бесконечность.
        /// </summary>
        public double RInfinity
        {
            get => double.PositiveInfinity;
        }

        /// <summary>
        /// Асимптота – истинная аномалия (в верхней полуплоскости), к которой тело стремится, удаляясь на бесконечность.
        /// </summary>
        /// <remarks>Для параболы всегда равна π.</remarks>
        public double Asymptote
        {
            get => double.Pi;
        }

        /// <summary>
        /// Скорость при удалении на бесконечность.
        /// </summary>
        /// <remarks>Для параболы всегда равна 0.</remarks>
        public double VInfinity
        {
            get => 0.0;
        }

        #region Constructors

        private ParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        private void ComputeOrbitByPeriapsis (double rp, double t0)
        {
            SetParametersByPeriapsis (ParabolicEccentricity, rp, t0);

            _p  = 2.0 * _rp;
            _h  = 0.0;
            _n  = double.Sqrt (_mu / _p) / _rp;
            _vp = Formulae.Motion.Parabola.Speed (_mu, _rp);
        }
    }
}