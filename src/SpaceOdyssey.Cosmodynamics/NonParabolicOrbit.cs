namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        private double _a;

        protected NonParabolicOrbit (IGravityMass gravityMass, double p, double e, double a, double rmin, double n) : 
            base (gravityMass, p, e, rmin, n)
        {
        }
    }
}