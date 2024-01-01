namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private HyperbolicOrbit (IGravityMass gravityMass, double p, double e, double a, double rmin, double n) :
            base (gravityMass, p, e, a, rmin, n)
        {
        }
    }
}