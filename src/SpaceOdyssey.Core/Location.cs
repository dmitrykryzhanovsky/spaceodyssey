using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Местоположение (точка наблюдения) на поверхности небесного тела.
    /// </summary>
    public class Location
    {
        private double _latitude;

        private double _longitude;

        private double _sinLatitude;

        private double _cosLatitude;

        /// <summary>
        /// Широта в радианах.
        /// </summary>
        public double Latitide
        {
            get => _latitude;
        }

        /// <summary>
        /// Долгота в радианах.
        /// </summary>
        public double Longitude
        {
            get => _longitude;
        }

        /// <summary>
        /// Синус широты.
        /// </summary>
        public double SinLatitude
        {
            get => _sinLatitude;
        }

        /// <summary>
        /// Косинус широты.
        /// </summary>
        public double CosLatitude
        {
            get => _sinLatitude;
        }

        public Location (double latitude, double longitude)
        {
            if ((-MathConst.PI_2 <= latitude) && (latitude <= MathConst.PI_2))
            {
                _latitude  = latitude;
                _longitude = longitude;

                (_sinLatitude, _cosLatitude) = double.SinCos (latitude);
            }

            else throw new ArgumentOutOfRangeException ();
        }
    }
}