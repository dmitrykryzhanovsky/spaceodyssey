using Archimedes;

namespace SpaceOdyssey
{
    public class Location
    {
        public ELocationOption LocationOption { get; private set; }

        private double _latitude;

        private double _sinLatitude;

        private double _cosLatitude;

        public double TanLatitude { get; private set; }

        public Location (double latitude)
        {
            SetLatitude (latitude);
        }

        private void SetLatitude (double latitude)
        {
            if ((-MathConst.M_PI_2 < latitude) && (latitude < MathConst.M_PI_2))
            {
                if ((latitude > 0.0) || (latitude < 0.0)) 
                    SetLatitudeParams (ELocationOption.NorthHemisphere, latitude, double.SinCos (latitude));
                else 
                    SetLatitudeParams (ELocationOption.Equator, 0.0, 0.0, 1.0, 0.0);
            }

            else if (latitude == MathConst.M_PI_2)
            {
                SetLatitudeParams (ELocationOption.NorthPole, MathConst.M_PI_2, 1.0, 0.0, double.PositiveInfinity);
            }

            else if (latitude == -MathConst.M_PI_2)
            {
                SetLatitudeParams (ELocationOption.SouthPole, -MathConst.M_PI_2, -1.0, 0.0, double.NegativeInfinity);
            }

            else throw new ArgumentOutOfRangeException ();
        }

        private void SetLatitudeParams (ELocationOption locationOption, double latitude, (double sinLatitude, double cosLatitude) sincos)
        {
            LocationOption = locationOption;

            _latitude    = latitude;
            _sinLatitude = sincos.sinLatitude;
            _cosLatitude = sincos.cosLatitude;
            TanLatitude  = _sinLatitude / _cosLatitude;
        }

        private void SetLatitudeParams (ELocationOption locationOption, double latitude, double sinLatitude, double cosLatitude, 
            double tanLatitude)
        {
            LocationOption = locationOption;

            _latitude    = latitude;
            _sinLatitude = sinLatitude;
            _cosLatitude = cosLatitude;
            TanLatitude  = tanLatitude;
        }
    }
}