namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        protected double _e2factor;

        protected double _a;

        protected NonParabolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        public abstract void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion);

        public abstract void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis);

        public abstract void SetOrbitalElementsByPeriapsisAndMeanMotion (double periapsis, double meanMotion);
    }
}