using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Местоположение (точка наблюдения) на поверхности небесного тела.
    /// </summary>
    public class ObserverLocation
    {
        private readonly double _lat;

        private readonly double _long;

        private readonly double _sinLat;

        private readonly double _cosLat;

        /// <summary>
        /// Широта в радианах.
        /// </summary>
        public double Lat
        {
            get => _lat;
        }

        /// <summary>
        /// Долгота в радианах.
        /// </summary>
        public double Long
        {
            get => _long;
        }

        /// <summary>
        /// Синус широты.
        /// </summary>
        public double SinLat
        {
            get => _sinLat;
        }

        /// <summary>
        /// Косинус широты.
        /// </summary>
        public double CosLat
        {
            get => _sinLat;
        }

        public ObserverLocation (double latitude, double longitude)
        {
            if ((-MathConst.M_PI_2 <= latitude) && (latitude <= MathConst.M_PI_2))
            {
                _lat  = latitude;
                _long = longitude;

                (_sinLat, _cosLat) = double.SinCos (latitude);
            }

            else throw new ArgumentOutOfRangeException ();
        }
    }
}