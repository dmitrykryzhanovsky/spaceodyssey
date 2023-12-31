using Archimedes;

namespace SpaceOdyssey
{
    public static class JD
    {
        private const int GregorianTerm = -32045;

        private const int JulianTerm = -32083;

        private const int GregorianYear = 1582;

        private const int GregorianMonth = 10;

        private const int GregorianDay = 15;

        private const int GregorianShift = -GregorianTerm - 1;

        private const int JulianShift = -JulianTerm - 1;

        private const int GregorianJDN = 2299161;

        public static bool IsGregorianCalendar (int year, int month, int day)
        {
            return ((year > GregorianYear) ||
                   ((year == GregorianYear) && ((month > GregorianMonth) ||
                                               ((month == GregorianMonth) && (day >= GregorianDay)))));
        }

        // А как здесь с -1 год?
        public static bool IsGregorianCalendar (DateTime date)
        {
            return IsGregorianCalendar (date.Year, date.Month, date.Day);
        }

        public static int GetJDN (int year, int month, int day)
        {
            int juliandDay = JDNInvariantTerm (year, month, day);

            return (IsGregorianCalendar (year, month, day)) ? juliandDay + AddGregorianTerm (year) : 
                                                              juliandDay + AddJulianTerm ();
        }

        public static int GetJDN (DateTime date)
        {
            return GetJDN (date.Year, date.Month, date.Day);
        }

        public static int GetJDNForGregorianCalendar (int year, int month, int day)
        {
            return JDNInvariantTerm (year, month, day) + AddGregorianTerm (year);
        }

        public static int GetJDNForGregorianCalendar (DateTime date)
        {
            return GetJDNForGregorianCalendar (date.Year, date.Month, date.Day);
        }

        public static int GetJDNForJulianCalendar (int year, int month, int day)
        {
            return JDNInvariantTerm (year, month, day) + AddJulianTerm ();
        }

        public static int GetJDNForJulianCalendar (DateTime date)
        {
            return GetJDNForJulianCalendar (date.Year, date.Month, date.Day);
        }

        private static int JDNInvariantTerm (int year, int month, int day)
        {
            return day + (int)((153 * month + 2) / 5) + 365 * year + (int)(year / 4);
        }

        private static int AddGregorianTerm (int year)
        {
            return -(int)(year / 100) + (int)(year / 400) + GregorianTerm;
        }

        private static int AddJulianTerm ()
        {
            return JulianTerm;
        }

        public static double GetJDFraction (int hour, int min, int sec = 0, int millisec = 0)
        {
            return DayFraction (hour, min, sec, millisec) - 0.5;
        }

        public static double GetJDFraction (DateTime date)
        {
            return GetJDFraction (date.Hour, date.Minute, date.Second, date.Microsecond);
        }

        private static double DayFraction (int hour, int min, int sec, int millisec)
        {
            return (double)(hour * 3600000 + min * 1440000 + sec * 1000 + millisec) / 86400000.0;
        }

        public static double GetJD (int year, int month, int day, int hour, int min, int sec = 0, int millisec = 0)
        {
            return GetJDN (year, month, day) + GetJDFraction (hour, min, sec, millisec);
        }

        public static double GetJD (DateTime date)
        {
            return GetJD (date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        public static double GetJDForGregorianCalendar (int year, int month, int day, int hour, int min, int sec = 0, int millisec = 0)
        {
            return GetJDNForGregorianCalendar (year, month, day) + GetJDFraction (hour, min, sec, millisec);
        }

        public static double GetJDForGregorianCalendar (DateTime date)
        {
            return GetJDForGregorianCalendar (date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        public static double GetJDForJulianCalendar (int year, int month, int day, int hour, int min, int sec = 0, int millisec = 0)
        {
            return GetJDNForJulianCalendar (year, month, day) + GetJDFraction (hour, min, sec, millisec);
        }

        public static double GetJDForJulianCalendar (DateTime date)
        {
            return GetJDForJulianCalendar (date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        public static (int jdn, double julianDayFraction) GetJulianDateComponents (double jd)
        {
            return jd.IntFractionComponents ();
        }

        public static bool IsGregorianJD (int jdn)
        {
            return (jdn >= GregorianJDN);
        }

        public static (int year, int month, int day) GetYMD (int jdn)
        {
            return (IsGregorianJD (jdn)) ? GetYMDForGregorianCalendar (jdn) : 
                                           GetYMDForJulianCalendar (jdn);
        }

        public static DateTime GetDateTime (int jdn)
        {
            (int year, int month, int day) = GetYMD (jdn);

            return new DateTime (year, month, day);
        }

        public static (int year, int month, int day) GetYMDForGregorianCalendar (int jdn)
        {
            (int year, int month, int day) = CalculateYMD (CalculateGregorianInput (jdn, out int b));

            year += 100 * b;

            return (year, month, day);
        }

        public static DateTime GetDateTimeForGregorianCalendar (int jdn)
        {
            (int year, int month, int day) = GetYMDForGregorianCalendar (jdn);

            return new DateTime (year, month, day);
        }

        public static (int year, int month, int day) GetYMDForJulianCalendar (int jdn)
        {
            return CalculateYMD (CalculateJulianInput (jdn));
        }

        public static DateTime GetDateTimeForJulianCalendar (int jdn)
        {
            (int year, int month, int day) = GetYMDForJulianCalendar (jdn);

            return new DateTime (year, month, day);
        }
                
        private static (int year, int month, int day) CalculateYMD (int c)
        {
            int d = (int)((4 * c + 3) / 1461);
            int e = c - (int)((1461 * d) / 4);
            int m = (int)((5 * e + 2) / 153);

            int day   = e - (int)((153 * m + 2) / 5) + 1;
            int month = m + 3 - 12 * (int)(m / 10);
            int year  = d - 4800 + (int)(m / 10);

            return (year, month, day);
        }

        private static int CalculateGregorianInput (int jdn, out int b)
        {
            int a = jdn + GregorianShift;

            b = (int)((4 * a + 3) / 146097);

            return a - (int)((146097 * b) / 4);
        }

        private static int CalculateJulianInput (int jdn)
        {
            return jdn + JulianShift;
        }

        public static (int hour, int min, int sec, int millisec) GetHMSMForJulianDayFraction (double julianDayFraction)
        {
            return CalculateHMSM (julianDayFraction + 0.5);
        }

        public static TimeOnly GetDateTimeForJulianDayFraction (double julianDayFraction)
        {
            (int hour, int min, int sec, int millisec) = GetHMSMForJulianDayFraction (julianDayFraction);

            return new TimeOnly (hour, min, sec, millisec);
        }

        private static (int hour, int min, int sec, int millisec) CalculateHMSM (double dayFraction)
        {
            int remainder = (int)Math.Round (dayFraction * 86400000.0);
            
            (int hour, remainder) = Math.DivRem (remainder, 3600000);
            (int min, remainder)  = Math.DivRem (remainder, 60000);
            (int sec, remainder)  = Math.DivRem (remainder, 1000);

            return (hour, min, sec, remainder);
        }

        public static (int year, int month, int day, int hour, int min, int sec, int millisec) GetTComponents (double jd)
        {
            (int jdn, double julianDayFraction) = GetJulianDateComponents (jd);

            (int year, int month, int day) = GetYMD (jdn);
            (int hour, int min, int sec, int millisec) = GetHMSMForJulianDayFraction (julianDayFraction);

            return (year, month, day, hour, min, sec, millisec);
        }

        public static DateTime GetDateTime (double jd)
        {
            (int year, int month, int day, int hour, int min, int sec, int millisec) = GetTComponents (jd);

            return new DateTime (year, month, day, hour, min, sec, millisec);
        }

        public static (int year, int month, int day, int hour, int min, int sec, int millisec) GetTComponentsForGregorianCalendar (double jd)
        {
            (int jdn, double julianDayFraction) = GetJulianDateComponents (jd);

            (int year, int month, int day) = GetYMDForGregorianCalendar (jdn);
            (int hour, int min, int sec, int millisec) = GetHMSMForJulianDayFraction (julianDayFraction);

            return (year, month, day, hour, min, sec, millisec);
        }

        public static DateTime GetDateTimeForGregorianCalendar (double jd)
        {
            (int year, int month, int day, int hour, int min, int sec, int millisec) = GetTComponentsForGregorianCalendar (jd);

            return new DateTime (year, month, day, hour, min, sec, millisec);
        }

        public static (int year, int month, int day, int hour, int min, int sec, int millisec) GetTComponentsForJulianCalendar (double jd)
        {
            (int jdn, double julianDayFraction) = GetJulianDateComponents (jd);

            (int year, int month, int day) = GetYMDForJulianCalendar (jdn);
            (int hour, int min, int sec, int millisec) = GetHMSMForJulianDayFraction (julianDayFraction);

            return (year, month, day, hour, min, sec, millisec);
        }

        public static DateTime GetDateTimeForJulianCalendar (double jd)
        {
            (int year, int month, int day, int hour, int min, int sec, int millisec) = GetTComponentsForJulianCalendar (jd);

            return new DateTime (year, month, day, hour, min, sec, millisec);
        }

        public static double GetJD (int jdn, double julianDayFraction)
        {
            return jdn + julianDayFraction;
        }

        public static double GetJulianCenturies (double jd, double referenceEpoch = AstroConst.J2000)
        {
            return (jd - referenceEpoch) / (double)AstroConst.JulianCentury;
        }
    }
}