namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        private double _a;

        protected NonParabolicOrbit (IGravityMass orbitalCenter, double p, double e, double a, double rmin, double n) : 
            base (orbitalCenter, p, e, rmin, n)
        {
        }
    }
}