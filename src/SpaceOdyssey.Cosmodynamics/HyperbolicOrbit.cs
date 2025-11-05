namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : KeplerOrbit
    {
        private double _asymptote;

        public override double RA
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

        protected HyperbolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }
    }
}