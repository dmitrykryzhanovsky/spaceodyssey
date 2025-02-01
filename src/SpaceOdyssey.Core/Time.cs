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
            if ((year   > FirstGregorianYear) ||
                ((year == FirstGregorianYear) && ((month   > FirstGregorianMonth) ||
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
            if (calendarStyle == ECalendarStyle.Gregorian) return GetJDNForGregorian (year, month, day);

            else return GetJDNForJulian (year, month, day);
        }

        /// <summary>
        /// Возвращает номер юлианского дня для полудня указанной даты по григорианскому календарю.
        /// </summary>
        public static int GetJDN (int year, int month, int day)
        {
            return GetJDNForGregorian (year, month, day);
        }

        private static int GetJDNForJulian (int year, int month, int day)
        {
            (int jdnCommonTerm, int y) = GetJDNCommonTerm (year, month, day);

            return jdnCommonTerm - 32083;
        }

        private static int GetJDNForGregorian (int year, int month, int day)
        {
            (int jdnCommonTerm, int y) = GetJDNCommonTerm (year, month, day);

            return jdnCommonTerm - (y / 100) + (y / 400) - 32045;
        }

        private static (int jdnCommonTerm, int y) GetJDNCommonTerm (int year, int month, int day)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;

            return (jdnCommonTerm: day + ((153 * m + 2) / 5) + 365 * y + (y / 4), 
                    y);
        }

        /// <summary>
        /// Возвращает календарную дату для указанного номера юлианского дня jdn.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указана дата.</param>
        public static (int year, int month, int day) GetCalendarDate (int jdn, ECalendarStyle calendarStyle)
        {
            if (calendarStyle == ECalendarStyle.Gregorian) return GetCalendarDateForGregorian (jdn);

            else return GetCalendarDateForJulian (jdn);
        }

        /// <summary>
        /// Возвращает календарную дату по григорианскому календарю для указанного номера юлианского дня jdn.
        /// </summary>
        public static (int year, int month, int day) GetCalendarDate (int jdn)
        {
            return GetCalendarDateForGregorian (jdn);
        }

        private static (int year, int month, int day) GetCalendarDateForJulian (int jdn)
        {
            (int c, int b100) = GetTermsForJulian (jdn);

            return GetCalendarComponents (c, b100);
        }

        private static (int year, int month, int day) GetCalendarDateForGregorian (int jdn)
        {
            (int c, int b100) = GetTermsForGregorian (jdn);

            return GetCalendarComponents (c, b100);
        }

        private static (int c, int b100) GetTermsForJulian (int jdn)
        {
            return (c: jdn + 32082, b100: 0);
        }

        private static (int c, int b100) GetTermsForGregorian (int jdn)
        {
            int a = jdn + 32044;
            int b = (4 * a + 3) / 146097;
            int c = a - (146097 * b) / 4;

            return (c, b100: 100 * b);
        }

        private static (int year, int month, int day) GetCalendarComponents (int c, int b100)
        {
            int d = (4 * c + 3) / 1461;
            int e = c - (1461 * d) / 4;
            int m = (5 * e + 2) / 153;

            int day   = e - (153 * m + 2) / 5 + 1;
            int month = m + 3 - 12 * (m / 10);
            int year  = b100 + d - 4800 + (m / 10);

            return (year, month, day);
        }

        /// <summary>
        /// Возвращает долю суток (от 0 до 1), прошедшую от начала суток до заданного момента времени.
        /// </summary>
        public static double GetDayFraction (int hour, int min, double sec)
        {
            return (sec + AstroConst.Time.SEC_IN_MIN * (min + AstroConst.Time.MIN_IN_HOUR * hour)) / AstroConst.Time.SEC_IN_DAY;
        }

        /// <summary>
        /// Возвращает долю суток (от 0 до 1), прошедшую от начала суток до заданного момента времени.
        /// </summary>
        public static double GetDayFraction (int hour, int min, int sec, int millisec)
        {
            return (double)(millisec + AstroConst.Time.MILLISEC_IN_SEC * 
                                (sec + AstroConst.Time.SEC_IN_MIN * 
                                (min + AstroConst.Time.MIN_IN_HOUR * hour))) / AstroConst.Time.MILLISEC_IN_DAY;
        }

        /// <summary>
        /// Восстанавливает компоненты времени (часы, минуты, секунды) для момента времени, заданного долей суток dayFraction (от 0 до 
        /// 1), прошедшей после полуночи.
        /// </summary>
        public static (int hour, int min, double sec) GetTimeComponents (double dayFraction)
        {
            double totalSecF   = dayFraction * AstroConst.Time.SEC_IN_DAY;
            int    totalSecInt = (int)totalSecF;

            (int totalMin, int secInt) = int.DivRem (totalSecInt, AstroConst.Time.SEC_IN_MIN);
            (int hour, int min) = int.DivRem (totalMin, AstroConst.Time.MIN_IN_HOUR);

            double sec = secInt + (totalSecF - totalSecInt);

            return (hour, min, sec);
        }
    }
}