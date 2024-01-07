using Archimedes;

using System.Net.Http.Headers;

namespace SpaceOdyssey.Cosmodynamics
{
    public class PlanarPosition
    {
        private Vector2 _cartesian;

        private Polar2 _polar;

        public double Radius
        {
            get => _polar.R;
        }

        public double TrueAnomaly
        {
            get => _polar.Heading;
        }

        private PlanarPosition ()
        {
        }

        internal PlanarPosition (double x, double y)
        {
            _cartesian = new Vector2 (x, y);
            _polar     = _cartesian.CartesianToPolar ();
        }

        internal static PlanarPosition CreatePlanarPositionForCircularOrbit (double meanAnomaly, double radius)
        {
            PlanarPosition result = new PlanarPosition ();

            (double sin, double cos) = double.SinCos (meanAnomaly);

            result._cartesian = new Vector2 (radius * cos, radius * sin);
            result._polar     = new Polar2 (radius, meanAnomaly);

            return result;
        }
    }
}