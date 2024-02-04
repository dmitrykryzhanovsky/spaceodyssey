namespace SpaceOdyssey
{
    public static class JD
    {
        private const int LilianYear = 1582;

        private const int LilianMonth = 10;

        private const int LilianDay = 15;

        private const int LilianJDN = 2299161;

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

        public static ECalendarStyle GetCalebdarStyle (int jdn)
        {
            return (jdn >= LilianJDN) ? ECalendarStyle.Gregorian : ECalendarStyle.Julian;
        }

        public static int GetJDN (int year, int month, int day, ECalendarStyle calendarStyle = ECalendarStyle.Gregorian)
        {
            int a = (14 - month) / 12;
            int y = year + 4800 - a;
            int m = month + 12 * a - 3;

            int jdnBasis = day + (153 * m + 2) / 5 + 365 * y + y / 4;

            return (calendarStyle == ECalendarStyle.Gregorian) ? jdnBasis - (y / 100) + (y / 400) - 32045 :
                                                                 jdnBasis - 32083;
        }

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

        public static double GetJulianDate (int year, int month, int day, int hour, int min, int sec, int millisec, 
            ECalendarStyle calendarStyle = ECalendarStyle.Gregorian)
        {
            return GetJDN (year, month, day, calendarStyle) + Kit.GetDayFraction (hour, min, sec, millisec) - 0.5;
        }

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

        public static int GetWeekDay (int jdn)
        {
            return (jdn + 1) % AstroConst.Time.DaysPerWeek;
        }
    }
}