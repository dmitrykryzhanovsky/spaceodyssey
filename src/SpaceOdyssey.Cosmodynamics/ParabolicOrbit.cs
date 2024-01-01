namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        private ParabolicOrbit (IGravityMass orbitalCenter, double p, double e, double rmin, double n) : base (orbitalCenter, p, e, rmin, n)
        {
        }
    }
}