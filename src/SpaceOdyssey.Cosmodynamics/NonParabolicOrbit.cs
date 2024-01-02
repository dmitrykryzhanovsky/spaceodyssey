namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        protected double _e2factor;

        protected double _a;

        protected NonParabolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }
    }
}