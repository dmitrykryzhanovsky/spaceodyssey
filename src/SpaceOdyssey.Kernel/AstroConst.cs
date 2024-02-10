namespace SpaceOdyssey
{
    public static class AstroConst
    {
        public static class Epoch
        {
            /// <summary>
            /// Эпоха J2000 – 1 января 2000 г., UT = 12:00:00.
            /// </summary>
            public const double J2000 = 2451545.0;
        }

        public static class Time
        {
            public const int DaysPerWeek = 7;

            public const double MillisecondsPerDay = 86400000.0;

            public const int MillisecondsPerHour = 3600000;

            public const int MillisecondsPerMinute = 60000;

            public const int MillisecondsPerSecond = 1000;
        }
    }
}