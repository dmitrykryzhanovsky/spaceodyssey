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

        public static class Mars
        {
            /// <summary>
            /// Локальная гравитационная постоянная, связанная с Марсом, в единицах системы СИ.
            /// </summary>
            public const double GM_SI = 4.282837e+13;
        }

        /// <summary>
        /// Преобразование значения из системы СИ в систему (метр – сутки).
        /// </summary>
        public static double ConvertSIToMetreDay (double x)
        {
            return x * AstroConst.Time.SEC_IN_DAY_SQR;
        }
    }
}