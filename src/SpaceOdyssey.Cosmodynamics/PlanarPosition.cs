using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class PlanarPosition
    {
        private Vector2 _cartesian;

        private Polar2 _polar;

        private Vector2 _velocity;

        private double _speed;

        public double Radius
        {
            get => _polar.R;
        }

        public double TrueAnomaly
        {
            get => _polar.Heading;
        }

        public double X
        {
            get => _cartesian.X;
        }

        public double Y
        {
            get => _cartesian.Y;
        }

        public double Speed
        {
            get => _speed;
        }

        public Vector2 Velocity
        {
            get => _velocity;
        }

        private PlanarPosition ()
        {
        }

        internal static PlanarPosition BuildPlanarPositionForEllipticAndHyperbolicOrbit (double x, double y, double vx, double vy)
        {
            PlanarPosition result = new PlanarPosition ();

            result._cartesian = new Vector2 (x, y);
            result._polar     = result._cartesian.CartesianToPolar ();
            result._velocity  = new Vector2 (vx, vy);
            result._speed     = result._velocity.GetLength ();

            return result;
        }

        internal static PlanarPosition BuildPlanarPositionForCircularOrbit (double meanAnomaly, double radius, double gmFactor)
        {
            PlanarPosition result = new PlanarPosition ();

            (double sin, double cos) = double.SinCos (meanAnomaly);

            result._cartesian = new Vector2 (radius * cos, radius * sin);
            result._polar     = new Polar2 (radius, meanAnomaly);
            result._velocity  = new Vector2 (-gmFactor * cos, gmFactor * sin);
            result._speed     = gmFactor;

            return result;
        }

        internal static PlanarPosition BuildPlanarPositionForParabolicOrbit (double x, double y, double radius, double trueAnomaly, 
            double speed, double beta)
        {
            PlanarPosition result = new PlanarPosition ();

            (double sin, double cos) = double.SinCos (beta);

            result._cartesian = new Vector2 (x, y);
            result._polar     = new Polar2 (radius, trueAnomaly);
            result._velocity  = new Vector2 (speed * cos, speed * sin);
            result._speed     = speed;

            return result;
        }
    }
}