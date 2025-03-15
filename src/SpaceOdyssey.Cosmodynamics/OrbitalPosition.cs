using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Положение на орбите.
    /// </summary>
    public struct OrbitalPosition
    {
        private readonly Vector2 _planarCartesianPosition;
        private readonly Polar2  _planarPolarPosition;
        private readonly Vector2 _planarVelocity;

        private readonly double  _meanAnomaly;
        private readonly double  _eccentricAnomaly;

        public double X
        {
            get => _planarCartesianPosition.X;
        }

        public double Y
        {
            get => _planarCartesianPosition.Y;
        }

        /// <summary>
        /// Расстояние до центра тяготения.
        /// </summary>
        public double R
        {
            get => _planarPolarPosition.R;
        }

        /// <summary>
        /// Истинная аномалия.
        /// </summary>
        /// <remarks>Задаётся в радианах.</remarks>
        public double TrueAnomaly
        {
            get => _planarPolarPosition.Heading;
        }

        public Vector2 PlanarVelocity
        {
            get => _planarVelocity;
        }

        public double Velocity
        {
            get => _planarVelocity.GetLength ();
        }

        public double MeanAnomaly
        {
            get => _meanAnomaly;
        }

        public double EccentricAnomaly
        {
            get => _eccentricAnomaly;
        }

        public OrbitalPosition (double x, double y, double r, double trueAnomaly, double vx, double vy, double M, double E)
        {
            _planarCartesianPosition = new Vector2 (x, y);
            _planarPolarPosition     = new Polar2 (r, trueAnomaly);
            _planarVelocity          = new Vector2 (vx, vy);

            _meanAnomaly      = M;
            _eccentricAnomaly = E;
        }
    }
}