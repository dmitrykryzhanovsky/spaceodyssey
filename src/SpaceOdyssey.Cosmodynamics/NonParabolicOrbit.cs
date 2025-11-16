namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        protected double _aux1pe;   // Вспомогательная величина 1 + e.
        protected double _aux1me;   // Вспомогательная величина 1 - e.
        protected double _auxsqrth; // Вспомогательная величина sqrt (mu / abs (a)) = sqrt (abs (h)).

        protected double _a;

        /// <summary>
        /// Большая полуось.
        /// </summary>
        public double A
        {
            get => _a;
        }

        #region Constructors

        protected NonParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion
    }
}