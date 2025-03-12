using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Положение на орбите.
    /// </summary>
    public struct OrbitPosition
    {
        private Vector2 _planarPosition;

        private Polar2 _planarPolar;

        private Vector2 _planarVelocity;

        private double _meanAnomaly;

        private double _EAnomaly;

        public double X
        {
            get => _planarPosition.X;
        }

        public double Y
        {
            get => _planarPosition.Y;
        }

        /// <summary>
        /// Расстояние до центра тяготения.
        /// </summary>
        public double R
        {
            get => _planarPolar.R;
        }

        /// <summary>
        /// Истинная аномалия.
        /// </summary>
        /// <remarks>Задаётся в радианах.</remarks>
        public double TrueAnomaly
        {
            get => _planarPolar.Heading;
        }

        public Vector2 PlanarVelocity
        {
            get => _planarVelocity;
        }

        public double VelocityMagnitude
        {
            get => throw new NotImplementedException ();
        }

        public double MeanAnomaly
        {
            get => _meanAnomaly;
        }

        public double EAnomaly
        {
            get => _EAnomaly;
        }
    }
}