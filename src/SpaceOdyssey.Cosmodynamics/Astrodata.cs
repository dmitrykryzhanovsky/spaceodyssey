namespace SpaceOdyssey.Cosmodynamics
{
    public static class Astrodata
    {
        public static class Sun
        {
            /// <summary>
            /// Локальная гравитационная постоянная, связанная с Солнцем, в единицах системы СИ.
            /// </summary>
            private const double GM_SI = 1.32712440018e+20;

            public static readonly Mass SI = Mass.CreateByGM (GM_SI);
        }

        public static class Earth
        {
            /// <summary>
            /// Локальная гравитационная постоянная, связанная с Землёй, в единицах системы СИ.
            /// </summary>
            private const double GM_SI = 3.986004418e+14;

            public static readonly Mass SI = Mass.CreateByGM (GM_SI);
        }        
    }
}