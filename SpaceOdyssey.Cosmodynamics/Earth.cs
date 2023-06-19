namespace SpaceOdyssey.Cosmodynamics
{
    public class Earth : CelestialObject
    {
        private const double GravitationalParameter = 3.986004418e+14;

        private const double Radius = 6371000.0;

        public static readonly Earth Instance = new Earth ();

        private Earth () : base (GravitationalParameter, Radius)
        {
        }
    }
}