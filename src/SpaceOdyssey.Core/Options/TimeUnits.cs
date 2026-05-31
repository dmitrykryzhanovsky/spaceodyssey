namespace SpaceOdyssey
{
    /// <summary>
    /// Астрономические константы.
    /// </summary>
    public static class TimeUnits
    {
        /// <summary>
        /// Количество часов в сутках.
        /// </summary>
        public const int HourInDay = 24;

        /// <summary>
        /// Количество минут в часе.
        /// </summary>
        public const int MinInHour = 60;

        /// <summary>
        /// Количество секунд в минуте.
        /// </summary>
        public const int SecInMin = 60;

        /// <summary>
        /// Количество секунд в часе.
        /// </summary>
        public const int SecInHour = MinInHour * SecInMin;

        /// <summary>
        /// Количество секунд в сутках.
        /// </summary>
        public const double SecInDay = HourInDay * SecInHour;

        /// <summary>
        /// Количество секунд в сутках в квадрате.
        /// </summary>
        public const double SecInDaySquare = SecInDay * SecInDay;

        /// <summary>
        /// Количество миллисекунд в секунде.
        /// </summary>
        public const int MillisecInSec = 1000;

        /// <summary>
        /// Количество миллисекунд в сутках.
        /// </summary>
        public const double MillisecInDay = SecInDay * MillisecInSec;

        /// <summary>
        /// Количество суток в юлианском столетии.
        /// </summary>
        public const double JulianCentury = 36525.0;
    }
}