namespace SpaceOdyssey.Cosmodynamics
{
    public static class Data
    {
        public static readonly Mass ProbeZeroMass = Mass.CreateByMass (0.0);

        private const double SunGMSI   = 1.32712440018e+20;
        private const double EarthGMSI = 3.986004418e+14;

        public static readonly Mass SunSI = Mass.CreateByGM (SunGMSI);

        public static readonly Mass EarthSI = Mass.CreateByGM (EarthGMSI);
    }
}