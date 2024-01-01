namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private HyperbolicOrbit (IGravityMass orbitalCenter, double p, double e, double a, double rmin, double n) :
            base (orbitalCenter, p, e, a, rmin, n)
        {
        }
    }
}