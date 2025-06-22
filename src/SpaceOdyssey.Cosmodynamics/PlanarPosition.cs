using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public struct PlanarPosition
    {
        private readonly Vector2 _v;
        private readonly Polar2  _p;

        public Vector2 CartesianPosition
        {
            get => _v;
        }

        public Polar2 PolarPosition
        {
            get => _p;
        }

        public double X
        {
            get => _v.X;
        }

        public double Y
        {
            get => _v.Y;
        }

        public double R
        {
            get => _p.R;
        }

        public double TrueAnomaly
        {
            get => _p.Heading;
        }

        private PlanarPosition (double x, double y, double r, double trueAnomaly)
        {
            _v = new Vector2 (x, y);
            _p = new Polar2 (r, trueAnomaly);
        }

        public static PlanarPosition ComputePlanarPosition (ComputePlanarPositionDelegate method, double anomaly, params double [] param)
        {
            (double x, double y, double r, double trueAnomaly) = method (anomaly, param);

            return new PlanarPosition (x, y, r, trueAnomaly);
        }
    }
}