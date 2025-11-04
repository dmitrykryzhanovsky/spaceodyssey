namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit, INonClosedOrbit
    {
        private readonly double _a;
    }
}