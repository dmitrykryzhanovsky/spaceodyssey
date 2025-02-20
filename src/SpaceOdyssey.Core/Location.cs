using Archimedes;

namespace SpaceOdyssey
{
    public class Location
    {
        private double _latitude;

        private double _longitude;

        private double _sinLatitude;

        private double _cosLatitude;

        public double Latitide
        {
            get => _latitude;
        }

        public double Longitude
        {
            get => _longitude;
        }

        public double SinLatitude
        {
            get => _sinLatitude;
        }

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