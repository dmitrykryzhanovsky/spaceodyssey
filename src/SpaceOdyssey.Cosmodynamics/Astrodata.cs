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

            /// <summary>
            /// Гауссова гравитационная постоянная.
            /// </summary>
            /// <remarks>Квадратный корень локальной гравитационной постоянной, связанной с Солнцем, выраженный в единицах (а.е., сутки))</remarks>
            private const double GaussianSqrtGM = 0.01720209895;

            /// <summary>
            /// Квадрат гауссовой гравитационной постоянной.
            /// </summary>
            private const double GaussianGM = GaussianSqrtGM * GaussianSqrtGM;

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