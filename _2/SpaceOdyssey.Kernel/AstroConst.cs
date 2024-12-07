namespace SpaceOdyssey
{
    public static class AstroConst
    {
        public static class Time
        {
            /// <summary>
            /// Дней в неделе.
            /// </summary>
            public const int DaysPerWeek = 7;

            /// <summary>
            /// Миллисекунд в сутках.
            /// </summary>
            public const double MillisecondsPerDay = 86400000.0;

            /// <summary>
            /// Миллисекунд в часе.
            /// </summary>
            public const int MillisecondsPerHour = 3600000;

            /// <summary>
            /// Миллисекунд в минуте.
            /// </summary>
            public const int MillisecondsPerMinute = 60000;

            /// <summary>
            /// Миллисекунд в секунде.
            /// </summary>
            public const int MillisecondsPerSecond = 1000;
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