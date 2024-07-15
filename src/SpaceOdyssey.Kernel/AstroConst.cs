namespace SpaceOdyssey
{
    public static class AstroConst
    {
        public static class Time
        {
            public const int DaysPerWeek = 7;

            public const double MillisecondsPerDay = 86400000.0;

            public const int MillisecondsPerHour = 3600000;

            public const int MillisecondsPerMinute = 60000;

            public const int MillisecondsPerSecond = 1000;

            /// <summary>
            /// Количество суток в юлианском столетии.
            /// </summary>
            public const int JulianCentury = 36525;
        }

        public static class Epoch
        {
            /// <summary>
            /// Юлианская эпоха J2000 = 1.5 января 2000 (полдень 1 января 2000 г.)
            /// </summary>
            public const double J2000 = 2451545.0;

            /// <summary>
            /// Юлианская эпоха J1900 = 0.5 января 1900 (полдень 31 декабря 1899 г.)
            /// </summary>
            public const double J1900 = 2415020.0;
        }

        /// <summary>
        /// Гауссова гравитационная постоянная.
        /// </summary>
        /// <remarks>Квадратный корень из гравитационной постоянной Ньютона, выраженной в астрономической системе единиц (сутки, масса 
        /// Солнца, астрономическая единица). Значение взято из https://en.wikipedia.org/wiki/Astronomical_constant#Table_of_astronomical_constants.</remarks>
        public const double GaussianGravitationalConstant = 0.01720209895;

        /// <summary>
        /// Квадрат гауссовой гравитационной постоянной.
        /// </summary>
        public const double GaussianGravitationalParameter = GaussianGravitationalConstant * GaussianGravitationalConstant;
    }
}