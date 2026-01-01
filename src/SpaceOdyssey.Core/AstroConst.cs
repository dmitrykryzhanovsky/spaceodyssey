namespace SpaceOdyssey
{
    /// <summary>
    /// Астрономические константы.
    /// </summary>
    public static class AstroConst
    {
        public static class Time
        {
            /// <summary>
            /// Количество минут в часе.
            /// </summary>
            public const int MIN_IN_HOUR = 60;

            /// <summary>
            /// Количество секунд в минуте.
            /// </summary>
            public const int SEC_IN_MIN = 60;

            /// <summary>
            /// Количество миллисекунд в секунде.
            /// </summary>
            public const int MILLISEC_IN_SEC = 1000;

            /// <summary>
            /// Количество секунд в сутках.
            /// </summary>
            public const double SEC_IN_DAY = 86400.0;

            /// <summary>
            /// Количество секунд в сутках в квадрате.
            /// </summary>
            public const double SEC_IN_DAY_SQR = SEC_IN_DAY * SEC_IN_DAY;

            /// <summary>
            /// Количество секунд в 1 периоде вращения Земли вокруг своей оси = 23 ч 56 мин 4,091 с.
            /// </summary>
            public const double SEC_IN_EARTHROTATION = 86164.091;

            /// <summary>
            /// Количество оборотов Земли вокруг своей оси в 1 сутках.
            /// </summary>
            public const double EARTHROTATION_IN_DAY = SEC_IN_DAY / SEC_IN_EARTHROTATION;

            /// <summary>
            /// Количество миллисекунд в сутках.
            /// </summary>
            public const double MILLISEC_IN_DAY = 86400000.0;

            /// <summary>
            /// Количество суток в юлианском столетии.
            /// </summary>
            public const double JULIAN_CENTURIES = 36525.0;
        }

        /// <summary>
        /// Астрономическая единица, в метрах.
        /// </summary>
        public const double AU = 149597870700.0;
    }
}