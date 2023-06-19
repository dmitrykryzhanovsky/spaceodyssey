namespace SpaceOdyssey.Cosmodynamics
{
    public class Saturn : CelestialObject
    {
        private const double GravitationalParameter = 3.7931187e+16;

        private const double Radius = 58232000.0;

        public static readonly Saturn Instance = new Saturn ();

        private Saturn () : base (GravitationalParameter, Radius)
        {
        }
    }
}