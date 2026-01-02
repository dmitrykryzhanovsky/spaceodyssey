using Archimedes;

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
            /// Количество часов в сутках.
            /// </summary>
            public const int HourInDay = 24;

            /// <summary>
            /// Количество минут в часе.
            /// </summary>
            public const int MinInHour = MathConst.AngularTimeConversions.MinInUnit;

            /// <summary>
            /// Количество секунд в минуте.
            /// </summary>
            public const int SecInMin = MathConst.AngularTimeConversions.SecInMin;

            /// <summary>
            /// Количество секунд в часе.
            /// </summary>
            public const int SecInHour = MathConst.AngularTimeConversions.SecInUnit;

            /// <summary>
            /// Количество секунд в сутках.
            /// </summary>
            public const double SecInDay = SecInMin * MinInHour * HourInDay;

            /// <summary>
            /// Количество секунд в сутках в квадрате.
            /// </summary>
            public const double SecInDaySquare = SecInDay * SecInDay;

            /// <summary>
            /// Количество миллисекунд в секунде.
            /// </summary>
            public const int MillisecInSec = MathConst.AngularTimeConversions.MillisecInSec;

            /// <summary>
            /// Количество миллисекунд в сутках.
            /// </summary>
            public const double MillisecInDay = MillisecInSec * SecInDay;

            /// <summary>
            /// Период вращения Земли вокруг своей оси = 23 ч 56 мин 4,091 с.
            /// </summary>
            private static readonly double [] EarthRotationPeriodComponents = new double [] { 23.0, 56.0, 4.091 };

            /// <summary>
            /// Количество секунд в 1 периоде вращения Земли вокруг своей оси = 23 ч 56 мин 4,091 с.
            /// </summary>
            public static readonly double SecInEarthRotation = EarthRotationPeriodComponents [0] * SecInHour + 
                                                               EarthRotationPeriodComponents [1] * SecInMin + 
                                                               EarthRotationPeriodComponents [2];

            /// <summary>
            /// Количество оборотов Земли вокруг своей оси в 1 сутках.
            /// </summary>
            public static readonly double EarthRotationInDay = SecInDay / SecInEarthRotation;

            /// <summary>
            /// Количество суток в юлианском столетии.
            /// </summary>
            public const double JulianCentury = 36525.0;
        }

        /// <summary>
        /// Астрономическая единица, в метрах.
        /// </summary>
        public const double AU = 149597870700.0;

        /// <summary>
        /// Скорость света в метрах / сутки.
        /// </summary>
        public const double LightSpeed_MD = PhysConst.LightSpeed * AstroConst.Time.SecInDay;
    }
}