namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        private double _a;

        /// <summary>
        /// Большая полуось.
        /// </summary>
        public double A
        {
            get => _a;
        }

        protected NonParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }
    }
}