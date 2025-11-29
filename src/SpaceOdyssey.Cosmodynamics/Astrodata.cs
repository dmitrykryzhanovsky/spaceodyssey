namespace SpaceOdyssey.Cosmodynamics
{
    public static class Astrodata
    {
        public static class Sun
        {
            /// <summary>
            /// Локальная гравитационная постоянная, связанная с Солнцем, в единицах системы СИ.
            /// </summary>
            public const double GM_SI = 1.32712440018e+20;

            /// <summary>
            /// Гауссова гравитационная постоянная.
            /// </summary>
            /// <remarks>Квадратный корень локальной гравитационной постоянной, связанной с Солнцем, выраженный в единицах (а.е., сутки))</remarks>
            public const double GaussianSqrtGM = 0.01720209895;
        }

        public static class Earth
        {
            /// <summary>
            /// Локальная гравитационная постоянная, связанная с Землёй, в единицах системы СИ.
            /// </summary>
            public const double GM_SI = 3.986004418e+14;
        }        
    }
}