namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
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

        #region Init and compute orbit

        /// <summary>
        /// Создаёт параболическую орбиту, инициализируя расстояние в перицентре rp и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если rp <= 0.</exception>
        public static ParabolicOrbit CreateByPeriapsis (Mass center, Mass orbiting, double rp)
        {
            Checkers.CheckRPositive (rp);

            ParabolicOrbit orbit = new ParabolicOrbit (center, orbiting);

            orbit.ComputeOrbitByPeriapsis (rp);

            return orbit;
        }

        private void ComputeOrbitByPeriapsis (double rp)
        {
            SetParametersByPeriapsis (ParabolicEccentricity, rp);

            _p  = 2.0 * _rp;
            _h  = 0.0;
            _n  = double.Sqrt (_mu / _p) / _rp;
            _vp = Formulae.Motion.Parabola.Speed (_mu, _rp);
        }

        #endregion

        public override double Radius (double trueAnomaly)
        {
            return Formulae.Shape.Parabola.ConicSectionEquation (_p, trueAnomaly);
        }

        protected override double ConicSectionInverseEquation (double r)
        {
            return Formulae.Shape.Parabola.ConicSectionInverseEquation (_p, r);
        }
    }
}