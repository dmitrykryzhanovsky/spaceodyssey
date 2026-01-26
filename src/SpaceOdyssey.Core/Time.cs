namespace SpaceOdyssey
{
    /// <summary>
    /// Методы для работы с юлианскими датами.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Формулы для расчётов взяты из https://ru.wikipedia.org/wiki/Юлианская_дата. В качестве инструментов для проверки тестовых 
    ///     значений использовались конвертеры https://ssd.jpl.nasa.gov/tools/jdc/#/cd и https://www.onlineconversion.com/julian_date.htm.
    /// </para>
    /// <para>
    ///     Календарные даты задаются следующим образом: 
    ///     <list type="bullet">
    ///         <item>day – номер дня месяца, как он указан в календаре: например, для 5 ноября 1955 г. day = 5.</item>
    ///         <item>month – порядковый номер месяца, начиная с 1: январь = 1, февраль = 2 .. декабрь = 12.</item> 
    ///         <item>year – номер года в астрономической нотации: 
    ///               - для годов нашей эры совпадает с календарной записью года (например, для 1955 г. year = 1955); 
    ///               - для годов до нашей эры равен отрицательному числу, по абсолютному значению на единицу меньшему календарной 
    ///                 записи года.Например, для 45 г. до н.э. year = -44, для 480 г. до н.э. year = -479. Таким образом, для 
    ///                 1 г. до н.э. year = 0. В результате в астрономической нотации используется непрерывный счёт годов, ходя в 
    ///                 календарной записи 0-го года не существует и после 1 г. до н.э.сразу идёт 1 г. н.э.</item>
    ///     </list>
    /// </para>
    /// <para>
    ///     Отсчёт юлианских дат начинается с 1 января 4713 г. до н.э. по юлианскому календарю (старому стилю) = (-4712, 1, 1). 
    ///     Полдень этой даты – момент JD = 0.0, а JDN для неё равен 0 (так как прошло 0 суток с момента начала отсчёта юлианских дат). 
    ///     В григорианском календаре ей соответствует дата 24 ноября 4714 г. до н.э. = (-4713, 11, 24).
    /// </para>
    /// </remarks>
    public static class Time
    {
        // Первая дата григорианского календаря (нового стиля) – 15 октября 1582 г.
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
        /// Определяет стиль календаря (юлианский или григорианский) для заданной даты (year, month, day).
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

        #region Календарная дата → Номер юлианского дня

        /// <summary>
        /// Возвращает номер юлианского дня для полудня указанной даты.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указана дата.</param>
        public static int GetJDN (int year, int month, int day, ECalendarStyle calendarStyle)
        {
            if (calendarStyle == ECalendarStyle.Gregorian) return ComputeJDNForGregorian (year, month, day);

            else return ComputeJDNForJulian (year, month, day);
        }

        /// <summary>
        /// Возвращает номер юлианского дня для полудня указанной даты по григорианскому календарю.
        /// </summary>
        public static int GetJDN (int year, int month, int day)
        {
            return ComputeJDNForGregorian (year, month, day);
        }

        /// <summary>
        /// Вычисляет номер юлианского дня для полудня указанной даты, при условии, что она задана по юлианскому календарю.
        /// </summary>
        private static int ComputeJDNForJulian (int year, int month, int day)
        {
            (int jdnCommonTerm, int y) = JDNCommonTerm (year, month, day);

            return jdnCommonTerm - 32083;
        }

        /// <summary>
        /// Вычисляет номер юлианского дня для полудня указанной даты, при условии, что она задана по григорианскому календарю.
        /// </summary>
        private static int ComputeJDNForGregorian (int year, int month, int day)
        {
            (int jdnCommonTerm, int y) = JDNCommonTerm (year, month, day);

            return jdnCommonTerm - (y / 100) + (y / 400) - 32045;
        }

        private static (int jdnCommonTerm, int y) JDNCommonTerm (int year, int month, int day)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;

            return (jdnCommonTerm: day + ((153 * m + 2) / 5) + 365 * y + (y / 4), y);
        }

        #endregion

        #region Номер юлианского дня → Календарная дата

        /// <summary>
        /// Возвращает календарную дату для указанного номера юлианского дня jdn.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указана дата.</param>
        public static (int year, int month, int day) GetCalendarDate (int jdn, ECalendarStyle calendarStyle)
        {
            if (calendarStyle == ECalendarStyle.Gregorian) return ComputeCalendarDateForGregorian (jdn);

            else return ComputeCalendarDateForJulian (jdn);
        }

        /// <summary>
        /// Возвращает календарную дату по григорианскому календарю для указанного номера юлианского дня jdn.
        /// </summary>
        public static (int year, int month, int day) GetCalendarDate (int jdn)
        {
            return ComputeCalendarDateForGregorian (jdn);
        }

        /// <summary>
        /// Вычисляет календарную дату, при условии, что она задана по юлианскому календарю, для заданного номера юлианского дня jdn.
        /// </summary>
        private static (int year, int month, int day) ComputeCalendarDateForJulian (int jdn)
        {
            (int c, int b100) = TermsForJulian (jdn);

            return CalendarComponents (c, b100);
        }

        /// <summary>
        /// Вычисляет календарную дату, при условии, что она задана по григорианскому календарю, для заданного номера юлианского дня 
        /// jdn.
        /// </summary>
        private static (int year, int month, int day) ComputeCalendarDateForGregorian (int jdn)
        {
            (int c, int b100) = TermsForGregorian (jdn);

            return CalendarComponents (c, b100);
        }

        private static (int c, int b100) TermsForJulian (int jdn)
        {
            return (c: jdn + 32082, b100: 0);
        }

        private static (int c, int b100) TermsForGregorian (int jdn)
        {
            int a = jdn + 32044;
            int b = (4 * a + 3) / 146097;
            int c = a - (146097 * b) / 4;

            return (c, b100: 100 * b);
        }

        private static (int year, int month, int day) CalendarComponents (int c, int b100)
        {
            int d = (4 * c + 3) / 1461;
            int e = c - (1461 * d) / 4;
            int m = (5 * e + 2) / 153;

            int day   = e - (153 * m + 2) / 5 + 1;
            int month = m + 3 - 12 * (m / 10);
            int year  = b100 + d - 4800 + (m / 10);

            return (year, month, day);
        }

        #endregion

        #region Момент времени в сутках → Доля суток

        /// <summary>
        /// Возвращает долю суток (от 0 до 1), прошедшую от начала суток до заданного момента времени.
        /// </summary>
        public static double GetDayFraction (int hour, int min, double sec)
        {
            return (sec + AstroConst.Time.SecInMin * (min + AstroConst.Time.MinInHour * hour)) / AstroConst.Time.SecInDay;
        }

        /// <summary>
        /// Возвращает долю суток (от 0 до 1), прошедшую от начала суток до заданного момента времени.
        /// </summary>
        public static double GetDayFraction (int hour, int min, int sec, int millisec)
        {
            return (double)(millisec + AstroConst.Time.MillisecInSec * 
                            (sec + AstroConst.Time.SecInMin * 
                             (min + AstroConst.Time.MinInHour * hour))) / AstroConst.Time.MillisecInDay;
        }

        #endregion

        #region Доля суток → Момент времени в сутках

        /// <summary>
        /// Восстанавливает компоненты времени (часы, минуты, секунды) для момента времени, заданного долей суток dayFraction (от 0 до 
        /// 1), прошедшей после полуночи.
        /// </summary>
        public static (int hour, int min, double sec) GetTimeComponents (double dayFraction)
        {
            double totalSecF   = dayFraction * AstroConst.Time.SecInDay;
            int    totalSecInt = (int)totalSecF;

            (int totalMin, int secInt) = int.DivRem (totalSecInt, AstroConst.Time.SecInMin);
            (int hour, int min) = int.DivRem (totalMin, AstroConst.Time.MinInHour);

            double sec = secInt + (totalSecF - totalSecInt);

            return (hour, min, sec);
        }

        #endregion

        #region Календарная дата и момент времени в сутках → Юлианская дата

        /// <summary>
        /// Возвращает юлианскую дату для заданного момента времени.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указана календарная дата.</param>
        public static double GetJD (int year, int month, int day, int hour, int min, double sec, ECalendarStyle calendarStyle)
        {
            int jdn = GetJDN (year, month, day, calendarStyle);

            return ComposeJD (jdn, hour, min, sec);
        }

        /// <summary>
        /// Возвращает юлианскую дату для заданного момента времени по григорианскому календарю.
        /// </summary>
        public static double GetJD (int year, int month, int day, int hour, int min, double sec)
        {
            int jdn = GetJDN (year, month, day);

            return ComposeJD (jdn, hour, min, sec);
        }

        private static double ComposeJD (int jdn, int hour, int min, double sec)
        {
            double dayFraction = GetDayFraction (hour, min, sec);

            return jdn + dayFraction - 0.5;
        }

        /// <summary>
        /// Возвращает юлианскую дату для заданного момента времени.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указана календарная дата.</param>
        public static double GetJD (int year, int month, int day, int hour, int min, int sec, int millisec, 
            ECalendarStyle calendarStyle)
        {
            int jdn = GetJDN (year, month, day, calendarStyle);

            return ComposeJD (jdn, hour, min, sec, millisec);
        }

        /// <summary>
        /// Возвращает юлианскую дату для заданного момента времени по григорианскому календарю.
        /// </summary>
        public static double GetJD (int year, int month, int day, int hour, int min, int sec, int millisec)
        {
            int jdn = GetJDN (year, month, day);

            return ComposeJD (jdn, hour, min, sec, millisec);
        }

        private static double ComposeJD (int jdn, int hour, int min, int sec, int millisec)
        {
            double dayFraction = GetDayFraction (hour, min, sec, millisec);

            return jdn + dayFraction - 0.5;
        }

        /// <summary>
        /// Возвращает юлианскую дату для момента времени, заданного типом DateTime, с учётом установленного в объекте dateTime 
        /// часового пояса.
        /// </summary>
        public static double GetJD (DateTime dateTime)
        {
            DateTime utc = dateTime.ToUniversalTime ();

            return GetJD (utc.Year, utc.Month, utc.Day, 
                          utc.Hour, utc.Minute, utc.Second, utc.Millisecond);
        }

        #endregion

        #region Юлианская дата → Календарная дата и момент времени в сутках

        /// <summary>
        /// Возвращает компоненты календарной даты и времени для заданной юлианской даты jd.
        /// </summary>
        /// <param name="calendarStyle">Стиль календаря (юлианский / григорианский), по которому указывается календарная дата.</param>
        public static (int year, int month, int day, int hour, int min, double sec) GetDateComponents (double jd, 
            ECalendarStyle calendarStyle)
        {
            (int jdn, double dayFraction)   = SplitDateAndTime (jd);

            (int year, int month, int day)  = GetCalendarDate (jdn, calendarStyle);
            (int hour, int min, double sec) = GetTimeComponents (dayFraction);

            return (year, month, day, hour, min, sec);
        }

        /// <summary>
        /// Возвращает компоненты календарной даты и времени для заданной юлианской даты jd по григорианскому календарю.
        /// </summary>
        public static (int year, int month, int day, int hour, int min, double sec) GetDateComponents (double jd)
        {
            (int jdn, double dayFraction)   = SplitDateAndTime (jd);

            (int year, int month, int day)  = GetCalendarDate (jdn);
            (int hour, int min, double sec) = GetTimeComponents (dayFraction);

            return (year, month, day, hour, min, sec);
        }

        private static (int jdn, double dayFraction) SplitDateAndTime (double jd)
        {
            double shifted = jd + 0.5;

            int    jdn         = (int)shifted;
            double dayFraction = shifted - jdn;

            return (jdn, dayFraction);
        }

        #endregion

        /// <summary>
        /// Возвращает день недели для заданного номера юлианского дня jdn: 0 – воскресенье, 1 – понедельник .. 6 – суббота.
        /// </summary>
        public static int GetWeekDay (int jdn)
        {
            int remainder = jdn % 7;

            if (remainder < 6) return ++remainder;

            else return 0;
        }

        /// <summary>
        /// Возвращает номер юлианского дня для заданной юлианской даты jd (т.е. какому номеру юлианского дня соответствует полдень 
        /// заданной даты, вне зависимости от того, соответствует ли jd полуночи, первой половине суток, полудню или второй половине 
        /// суток).
        /// </summary>
        public static int GetJDNumber (double jd)
        {
            return (int)double.Round (jd, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Возвращает разницу в юлианских столетиях между моментом времени t и моментом времени t0.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     Моменты времени t и t0 задаются их юлианскими датами.
        /// </para>
        /// <para>
        ///     По умолчанию t0 = J2000, так как подавляющее большинство астрономических расчётов в настоящее время связаны с этой 
        ///     эпохой.
        /// </para>
        /// </remarks>
        public static double GetJulianCentirues (double t, double t0 = Time.J2000)
        {
            return (t - t0) / AstroConst.Time.JulianCentury;
        }
    }
}