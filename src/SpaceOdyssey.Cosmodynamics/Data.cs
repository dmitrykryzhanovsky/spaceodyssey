namespace SpaceOdyssey.Cosmodynamics
{
    public static class Data
    {
        public static readonly Mass ProbeZeroMass = Mass.CreateByMass (0.0);

        public static class Sun
        {
            private const double GM_SI = 1.32712440018e+20;

            public static readonly Mass SI = Mass.CreateByGM (GM_SI);
        }

        public static class Earth
        {
            private const double GM_SI = 3.986004418e+14;

            public static readonly Mass SI = Mass.CreateByGM (GM_SI);
        }        
    }
}