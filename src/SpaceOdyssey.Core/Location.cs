using Archimedes;

namespace SpaceOdyssey
{
    public class Location
    {
        private double _latitude;

        private double _sinLatitude;

        private double _cosLatitude;

        public double CosLatitude
        {
            get => _cosLatitude;
        }

        public Location (double latitude)
        {
            SetLatitude (latitude);
        }

        private void SetLatitude (double latitude)
        {
            if ((-MathConst.PI_DIV_2 <= latitude) && (latitude <= MathConst.PI_DIV_2))
            {
                _latitude = latitude;

                (_sinLatitude, _cosLatitude) = double.SinCos (latitude);
            }

            else throw new ArgumentOutOfRangeException ();
        }
    }
}