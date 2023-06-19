namespace SpaceOdyssey.Cosmodynamics
{
    public class Jupiter : CelestialObject
    {
        private const double GravitationalParameter = 1.26686534e+17;

        private const double Radius = 69911000.0;

        public static readonly Jupiter Instance = new Jupiter ();

        private Jupiter () : base (GravitationalParameter, Radius)
        {
        }
    }
}