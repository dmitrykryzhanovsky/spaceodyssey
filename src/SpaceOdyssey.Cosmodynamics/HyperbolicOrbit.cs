namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private double _asymptote;
        private double _vinfinity;

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
        public double Asymptote
        {
            get => _asymptote;
        }

        /// <summary>
        /// Скорость при удалении на бесконечность.
        /// </summary>
        public double VInfinity
        {
            get => _vinfinity;
        }

        #region Constructors

        private HyperbolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        #region Init and compute orbit

        /// <summary>
        /// Создаёт гиперболическую орбиту, инициализируя расстояние в перицентре rp, эксцентриситет e и момент прохождения перицентра 
        /// t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e <= 1 или</item>
        /// <item>rp <= 0.</item></list></exception>
        public static HyperbolicOrbit CreateByPeriapsis (Mass center, Mass orbiting, double e, double rp)
        {
            Checkers.CheckEForHyperbola (e);
            Checkers.CheckRPositive (rp);

            HyperbolicOrbit orbit = new HyperbolicOrbit (center, orbiting);

            orbit.ComputeOrbitByPeriapsis (e, rp);

            return orbit;
        }

        protected override void ComputeOrbitByPeriapsis (double e, double rp)
        {
            base.ComputeOrbitByPeriapsis (e, rp);

            _asymptote = Formulae.Shape.Hyperbola.Asymptote (_e);
            _vinfinity = _auxsqrth;
        }

        #endregion
    }
}