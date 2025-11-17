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

        protected override void ComputeOrbitByPeriapsis (double e, double rp, double t0)
        {
            base.ComputeOrbitByPeriapsis (e, rp, t0);

            _vinfinity = _auxsqrth;
        }
    }
}