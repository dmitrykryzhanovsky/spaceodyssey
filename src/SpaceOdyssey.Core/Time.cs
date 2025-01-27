namespace SpaceOdyssey
{
    public static class Time
    {
        // Первая дата григорианского календа рая (нового стиля) – 15 октября 1582 г.
        private const int FirstGregorianYear  = 1582;
        private const int FirstGregorianMonth = 10;
        private const int FirstGregorianDay   = 15;

        /// <summary>
        /// Эпоха J2000 – полдень 1 января 2000 г. по земному времени (1.5 января 2000 г.)
        /// </summary>
        public const double J2000 = 2451545.0;

        /// <summary>
        /// Эпоха B1950 – начало 1950 бесселева года (0.923 января 1950 г.)
        /// </summary>
        public const double B1950 = 2433282.4235;

        /// <summary>
        /// Определить стиль календаря (юлианский или григорианский) для заданной даты (year, month, day).
        /// </summary>
        public static ECalendarStyle GetCalendarStyle (int year, int month, int day)
        {
            if ((year > FirstGregorianYear) ||
                ((year == FirstGregorianYear) && ((month > FirstGregorianMonth) ||
                                                  ((month == FirstGregorianMonth) && (day >= FirstGregorianDay)))))
            {
                return ECalendarStyle.Gregorian;
            }

            else return ECalendarStyle.Julian;
        }

        /// <summary>
        /// Возвращает номер юлианского дня для полудня указанной даты.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указана дата.</param>
        public static int GetJDN (int year, int month, int day, ECalendarStyle calendarStyle)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;

            int commonTerm = day + ((153 * m + 2) / 5) + 365 * y + (y / 4);

            if (calendarStyle == ECalendarStyle.Gregorian) return commonTerm - (y / 100) + (y / 400) - 32045;

            else return commonTerm - 32083;
        }

        /// <summary>
        /// Возвращает номер юлианского дня для полудня указанной даты по григорианскому календарю.
        /// </summary>
        public static int GetJDN (int year, int month, int day)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;

            return day + ((153 * m + 2) / 5) + 365 * y + (y / 4) - (y / 100) + (y / 400) - 32045;
        }
    }
}