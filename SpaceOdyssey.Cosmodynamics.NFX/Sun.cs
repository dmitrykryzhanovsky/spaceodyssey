namespace SpaceOdyssey.Cosmodynamics
{
    public class Sun : CelestialObject
    {
        private const double GravitationalParameter = 1.32712440018e+20;

        private const double Radius = 695700000.0;

        public static readonly Sun Instance = new Sun ();

        private Sun () : base (GravitationalParameter, Radius)
        {
        }
    }
}