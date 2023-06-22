namespace SpaceOdyssey.Cosmodynamics
{
    public class Venus : CelestialObject
    {
        private const double GravitationalParameter = 3.24859e+14;

        private const double Radius = 6051800.0;

        public static readonly Venus Instance = new Venus ();

        private Venus () : base (GravitationalParameter, Radius)
        {
        }
    }
}