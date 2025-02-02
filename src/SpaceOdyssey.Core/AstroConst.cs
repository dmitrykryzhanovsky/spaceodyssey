namespace SpaceOdyssey
{
    /// <summary>
    /// Астрономические константы.
    /// </summary>
    public static class AstroConst
    {
        public static class Time
        {
            public const int MIN_IN_HOUR = 60;

            public const int SEC_IN_MIN = 60;

            public const int MILLISEC_IN_SEC = 1000;

            public const double SEC_IN_DAY = 86400.0;

            public const double MILLISEC_IN_DAY = 86400000.0;

            /// <summary>
            /// Количество суток в юлианском столетии.
            /// </summary>
            public const double JULIAN_CENTURIES = 36525.0;
        }
    }
}