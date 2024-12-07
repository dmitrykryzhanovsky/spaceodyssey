namespace SpaceOdyssey
{
    public static class AstroConst
    {
        public static class Time
        {
            /// <summary>
            /// Количество суток в юлианском столетии.
            /// </summary>
            public const double JulianCentury = 36525.0;
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
    }
}