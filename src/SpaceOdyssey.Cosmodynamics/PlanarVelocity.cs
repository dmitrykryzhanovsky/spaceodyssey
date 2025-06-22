using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public struct PlanarVelocity
    {
        private readonly Vector2 _v;

        public Vector2 Vector
        {
            get => _v;
        }

        public double VX
        {
            get => _v.X;
        }

        public double VY
        {
            get => _v.Y;
        }

        public double Speed
        {
            get => _v.GetLength ();
        }

        private PlanarVelocity (double vx, double vy)
        {
            _v = new Vector2 (vx, vy);
        }

        public static PlanarVelocity ComputePlanarVelocity (ComputePlanarVelocityDelegate method, double sin, double cos, 
            params double [] param)
        {
            (double vx, double vy) = method (sin, cos, param);

            return new PlanarVelocity (vx, vy);
        }
    }
}