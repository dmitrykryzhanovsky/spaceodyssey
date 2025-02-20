namespace SpaceOdyssey
{
    public static class SideralTime
    {
        private static readonly double [] SecondSeries = new double [] 
        {   24110.54841,
          8640184.812866,
          AstroConst.Time.SEC_IN_DAY * AstroConst.Time.SEC_IN_DAY / AstroConst.Time.SEC_IN_SIDERALDAY,
                0.093104,
               -0.0000062 };

        public static double GMSideralTimeInRad (double jd)
        {
            double jd05 = jd + 0.5;
            double jd0  = double.Floor (jd05);

            double UTFraction = jd05 - jd0;
            double T0 = Time.GetJulianCentirues (jd0 - 0.5);
            double T  = Time.GetJulianCentirues (jd);

            return GMSideralTimeInRad (UTFraction, T0, T);
        }

        public static double GMSideralTimeInRad (double UTFraction, double T0, double T)
        {
            return double.Tau * (SecondSeries [0] + SecondSeries [1] * T0 + SecondSeries [2] * UTFraction + 
                T * T * (SecondSeries [3] + SecondSeries [4] * T)) / AstroConst.Time.SEC_IN_DAY;
        }

        public static double LocalSideralTimeInRad (Location location, double GMSideralTime)
        {
            return LocalSideralTimeInRad (location.Longitude, GMSideralTime);
        }

        public static double LocalSideralTimeInRad (double longitude, double GMSideralTime)
        {
            return GMSideralTime + longitude;
        }
    }
}