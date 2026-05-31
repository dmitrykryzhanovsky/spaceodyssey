namespace SpaceOdyssey
{
    public static class AstrometryConst
    {
        // Период вращения Земли вокруг своей оси = 23 ч 56 мин 4,091 с.
        private const double EarthRotationPeriodComponentHour = 23.0;
        private const double EarthRotationPeriodComponentMin  = 56.0;
        private const double EarthRotationPeriodComponentSec  = 4.091;

        /// <summary>
        /// Количество секунд в 1 периоде вращения Земли вокруг своей оси = 23 ч 56 мин 4,091 с.
        /// </summary>
        public static readonly double SecInEarthRotation = EarthRotationPeriodComponentHour * TimeUnits.SecInHour +
                                                           EarthRotationPeriodComponentMin  * TimeUnits.SecInMin +
                                                           EarthRotationPeriodComponentSec;

        /// <summary>
        /// Количество оборотов Земли вокруг своей оси в 1 сутках.
        /// </summary>
        public static readonly double EarthRotationInDay = TimeUnits.SecInDay / SecInEarthRotation;
    }
}