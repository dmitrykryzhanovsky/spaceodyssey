namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        private ParabolicOrbit (IGravityMass gravityMass, double p, double e, double rmin, double n) : base (gravityMass, p, e, rmin, n)
        {
        }
    }
}