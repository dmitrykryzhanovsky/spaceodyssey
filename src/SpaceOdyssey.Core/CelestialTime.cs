namespace SpaceOdyssey
{
    public static class CelestialTime
    {
        private static readonly double [] SideralTimeSecondSeries = new double [] {  241110.54841, 
                                                                                    8640184.812866, 
                                                                                          1.0027379093, 
                                                                                          0.093104, 
                                                                                         -0.0000062 };

        public static double SiderealTime (double UT, double jd)
        {
            double jd0 = double.Round (jd, MidpointRounding.ToPositiveInfinity) - 0.5;

            return SiderealTime (UT, jd, jd0);
        }

        public static double SiderealTime (double UT, double jd, double jd0)
        {
            double T  = JD.GetJulianCenturies (jd);
            double T0 = JD.GetJulianCenturies (jd0);

            return SiderealTimeByJulianCenturies (UT, T, T0);
        }

        public static double SiderealTimeByJulianCenturies (double UT, double T, double T0)
        {
            return  SideralTimeSecondSeries [0] +
                    SideralTimeSecondSeries [1] * T0 +
                    SideralTimeSecondSeries [2] * UT +
                   (SideralTimeSecondSeries [3] + SideralTimeSecondSeries [4] * T) * T * T;
        }

        // Эти функции для Гринвича - сделать для любой долготы
        // Сделать вычисление часового угла по звёздному времени и прямому восхождению
    }
}