namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonClosedOrbit : KeplerOrbit
    {
        public abstract double Asymptote { get; }

        protected NonClosedOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }
    }
}