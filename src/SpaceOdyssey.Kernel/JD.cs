namespace SpaceOdyssey
{
    /// <summary>
    /// Методы для работы с юлианскими датами.
    /// </summary>
    /// <remarks><list type="bullet">
    /// <item>Формулы для перевода между юлианскими и календарными датами взяты из [https://ru.wikipedia.org/wiki/Юлианская_дата].</item>
    /// <item>Годы до нашей эры записываются в астрономическом формате: 1 г. до н. э. = 0, 49 г. до н.э. = -48.</item>
    /// <item>Отчёт юлианских дат начинается с 1 января 4713 г. до н.э. по юлианскому календарю (старому стилю) = (-4712, 1, 1). 
    /// Полдень этой даты – момент JD = 0.0, а JDN для неё равен 0 (так как прошло 0 суток с момента начала отсчёта юлианских дат).</item>
    /// <item>Значения юлианских дат для тестирования брались из [https://www.onlineconversion.com/julian_date.htm].</item>
    /// </list></remarks>
    public static class JD
    {
        // Первый день по григорианскому календарю (новому стилю).

        private const int LilianYear = 1582;

        private const int LilianMonth = 10;

        private const int LilianDay = 15;

        private const int LilianJDN = 2299161;

        // Количество дней в юлианском столетии.
        private const double DaysPerJulianCentury = 36525.0;

        /// <summary>
        /// Определяет стиль календаря для заданной календарной даты.
        /// </summary>
        public static ECalendarStyle GetCalebdarStyle (int year, int month, int day)
        {
            if ((year > LilianYear) ||
                ((year == LilianYear) && ((month > LilianMonth) ||
                                          ((month == LilianMonth) && (day >= LilianDay)))))
            {
                return ECalendarStyle.Gregorian;
            }

            else return ECalendarStyle.Julian;
        }

        /// <summary>
        /// Определяет стиль календаря для заданного юлианского дня.
        /// </summary>
        public static ECalendarStyle GetCalebdarStyle (int jdn)
        {
            return (jdn >= LilianJDN) ? ECalendarStyle.Gregorian : ECalendarStyle.Julian;
        }

        /// <summary>
        /// Возвращает номер юлианского дня для заданной календарной даты.
        /// </summary>
        public static int GetJDN (int year, int month, int day, ECalendarStyle calendarStyle = ECalendarStyle.Gregorian)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;

            int jdnBasis = day + (153 * m + 2) / 5 + 365 * y + y / 4;

            return (calendarStyle == ECalendarStyle.Gregorian) ? jdnBasis - (y / 100) + (y / 400) - 32045 :
                                                                 jdnBasis - 32083;
        }

        /// <summary>
        /// Возвращает календарную дату для заданного юлианского дня.
        /// </summary>
        public static (int year, int month, int day) GetCalendarDate (int jdn, ECalendarStyle calendarStyle = ECalendarStyle.Gregorian)
        {
            int c, yTerm;

            if (calendarStyle == ECalendarStyle.Gregorian)
            {
                int a = jdn + 32044;
                int b = (4 * a + 3) / 146097;

                c     = a - (146097 * b) / 4;
                yTerm = 100 * b;
            }

            else
            {
                c     = jdn + 32082;
                yTerm = 0;
            }

            int d = (4 * c + 3) / 1461;
            int e = c - (1461 * d) / 4;
            int m = (5 * e + 2) / 153;

            int day   = e - (153 * m + 2) / 5 + 1;
            int month = m + 3 - 12 * (m / 10);
            int year  = yTerm + d - 4800 + (m / 10);

            return (year, month, day);
        }

        /// <summary>
        /// Возвращает юлианскую дату для заданных календарной даты и момента суток.
        /// </summary>
        public static double GetJulianDate (int year, int month, int day, int hour, int min, int sec, int millisec, 
            ECalendarStyle calendarStyle = ECalendarStyle.Gregorian)
        {
            return GetJDN (year, month, day, calendarStyle) + Kit.GetDayFraction (hour, min, sec, millisec) - 0.5;
        }

        /// <summary>
        /// Возвращает календарную дату и момент суток для заданной юлианской даты.
        /// </summary>
        public static (int year, int month, int day, int hour, int min, int sec, int millisec) GetDateTime (double jd, 
            ECalendarStyle calendarStyle = ECalendarStyle.Gregorian)
        {
            jd += 0.5;

            int    jdn = (int)jd;
            double dayFraction = jd - jdn;

            (int year, int month, int day) = GetCalendarDate (jdn, calendarStyle);
            (int hour, int min, int sec, int millisec) = Kit.GetDayTime (dayFraction);

            return (year, month, day, hour, min, sec, millisec);
        }

        /// <summary>
        /// Возвращает день недели для заданного юлианского дня.
        /// </summary>
        /// <returns>0 – воскресенье, 1 – понедельник .. 6 – суббота.</returns>
        public static int GetWeekDay (int jdn)
        {
            return (jdn + 1) % AstroConst.Time.DaysPerWeek;
        }

        /// <summary>
        /// Возвращает количество юлианских столетий, прошедших от момента времени с юлианской датой <paramref name="epoch"/> до 
        /// момента времени с юлианской датой <paramref name="jd"/>.
        /// </summary>
        /// <param name="epoch">В качестве значения по-умолчанию используется эпоха J2000.</param>
        /// <returns>Если момент <paramref name="jd"/> был раньше момента <paramref name="epoch"/>, возвращается отрицательное значение.</returns>
        public static double GetJulianCenturies (double jd, double epoch = AstroConst.Epoch.J2000)
        {
            return (jd - epoch) / DaysPerJulianCentury;
        }
    }
}