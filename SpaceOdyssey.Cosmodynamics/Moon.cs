namespace SpaceOdyssey.Cosmodynamics
{
    public class Moon : CelestialObject
    {
        private const double GravitationalParameter = 4.9048695e+12;

        private const double Radius = 1738100.0;

        public static readonly Moon Instance = new Moon ();

        private Moon () : base (GravitationalParameter, Radius)
        {
        }
    }
}