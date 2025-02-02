using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class TimeTests
    {
        [TestMethod ()]
        public void GetCalendarStyleTest_BeforeFirstGregorianYear ()
        {
            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1581, month: 12, day: 31);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarStyleTest_FirstGregorianYear_BeforeFirstGregorianMonth ()
        {
            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1582, month: 9, day: 30);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarStyleTest_FirstGregorianYear_FirstGregorianMonth_BeforeFirstGregorianDay ()
        {
            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1582, month: 10, day: 4);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarStyleTest_FirstGregorianYear_FirstGregorianMonth_FirstGregorianDay ()
        {
            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1582, month: 10, day: 15);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarStyleTest_FirstGregorianYear_FirstGregorianMonth_AfterFirstGregorianDay ()
        {
            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1582, month: 10, day: 16);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarStyleTest_FirstGregorianYear_AfterFirstGregorianMonth ()
        {
            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1582, month: 11, day: 1);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarStyleTest_AfterFirstGregorianYear ()
        {
            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = Time.GetCalendarStyle (year: 1583, month: 1, day: 1);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_JulianPeriodBeginInJulian ()
        {
            int expected = 0;

            int actual = Time.GetJDN (year: -4712, month: 1, day: 1, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_JulianPeriodBeginInGregorian ()
        {
            int expected = 0;

            int actual = Time.GetJDN (year: -4713, month: 11, day: 24, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_LastPregregorianDayInJulian ()
        {
            int expected = 2299160;

            int actual = Time.GetJDN (year: 1582, month: 10, day: 4, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_LastPregregorianDayInGregorian ()
        {
            int expected = 2299160;

            int actual = Time.GetJDN (year: 1582, month: 10, day: 14, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_FirstGregorianDayInJulian ()
        {
            int expected = 2299161;

            int actual = Time.GetJDN (year: 1582, month: 10, day: 5, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_FirstGregorianDayInGregorian ()
        {
            int expected = 2299161;

            int actual = Time.GetJDN (year: 1582, month: 10, day: 15, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_J2000InJulian ()
        {
            int expected = 2451558;

            int actual = Time.GetJDN (year: 2000, month: 1, day: 1, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_J2000InGregorian ()
        {
            int expected = 2451545;

            int actual = Time.GetJDN (year: 2000, month: 1, day: 1, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_T60InJulian ()
        {
            int expected = 2460684;

            int actual = Time.GetJDN (year: 2024, month: 12, day: 26, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_General_T60InGregorian ()
        {
            int expected = 2460671;

            int actual = Time.GetJDN (year: 2024, month: 12, day: 26, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_Gregorian_JulianPeriodBegin ()
        {
            int expected = 0;

            int actual = Time.GetJDN (year: -4713, month: 11, day: 24);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_Gregorian_FirstGregorianDay ()
        {
            int expected = 2299161;

            int actual = Time.GetJDN (year: 1582, month: 10, day: 15);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_Gregorian_J2000 ()
        {
            int expected = 2451545;

            int actual = Time.GetJDN (year: 2000, month: 1, day: 1);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_Gregorian_T60 ()
        {
            int expected = 2460671;

            int actual = Time.GetJDN (year: 2024, month: 12, day: 26);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateTest_General_JulianPeriodBeginInJulian ()
        {
            int jdn = 0;

            (int year, int month, int day) expected = (-4712, 1, 1);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_JulianPeriodBeginInGregorian ()
        {
            int jdn = 0;

            (int year, int month, int day) expected = (-4713, 11, 24);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_LastPregregorianDayInJulian ()
        {
            int jdn = 2299160;

            (int year, int month, int day) expected = (1582, 10, 4);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_LastPregregorianDayInGregorian ()
        {
            int jdn = 2299160;

            (int year, int month, int day) expected = (1582, 10, 14);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_FirstGregorianDayInJulian ()
        {
            int jdn = 2299161;

            (int year, int month, int day) expected = (1582, 10, 5);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_FirstGregorianDayInGregorian ()
        {
            int jdn = 2299161;

            (int year, int month, int day) expected = (1582, 10, 15);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_J2000InJulian ()
        {
            int jdn = 2451558;

            (int year, int month, int day) expected = (2000, 1, 1);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_J2000InGregorian ()
        {
            int jdn = 2451545;

            (int year, int month, int day) expected = (2000, 1, 1);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_T60InJulian ()
        {
            int jdn = 2460684;

            (int year, int month, int day) expected = (2024, 12, 26);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_General_T60InGregorian ()
        {
            int jdn = 2460671;

            (int year, int month, int day) expected = (2024, 12, 26);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_Gregorian_JulianPeriodBegin ()
        {
            int jdn = 0;

            (int year, int month, int day) expected = (-4713, 11, 24);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_Gregorian_FirstGregorianDay ()
        {
            int jdn = 2299161;

            (int year, int month, int day) expected = (1582, 10, 15);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_Gregorian_J2000 ()
        {
            int jdn = 2451545;

            (int year, int month, int day) expected = (2000, 1, 1);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDateTest_Gregorian_T60 ()
        {
            int jdn = 2460671;

            (int year, int month, int day) expected = (2024, 12, 26);

            (int year, int month, int day) actual = Time.GetCalendarDate (jdn);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMS_Midnight ()
        {
            double expected = 0.0;

            double actual = Time.GetDayFraction (hour: 0, min: 0, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMS_AlmostMidnight ()
        {
            double expected = 0.999999999988426;

            double actual = Time.GetDayFraction (hour: 23, min: 59, sec: 59.999999);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMS_DDDD ()
        {
            double expected = 0.57109982638888889;

            double actual = Time.GetDayFraction (hour: 13, min: 42, sec: 23.025);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMS_DDD0 ()
        {
            double expected = 0.57109953703703704;

            double actual = Time.GetDayFraction (hour: 13, min: 42, sec: 23.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMS_DD00 ()
        {
            double expected = 0.5708333333333333;

            double actual = Time.GetDayFraction (hour: 13, min: 42, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMS_D000 ()
        {
            double expected = 0.5416666666666666;

            double actual = Time.GetDayFraction (hour: 13, min: 0, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMSM_Midnight ()
        {
            double expected = 0.0;

            double actual = Time.GetDayFraction (hour: 0, min: 0, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMSM_AlmostMidnight ()
        {
            double expected = 0.99999998842592593;

            double actual = Time.GetDayFraction (hour: 23, min: 59, sec: 59, millisec: 999);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMSM_DDDD ()
        {
            double expected = 0.57109982638888889;

            double actual = Time.GetDayFraction (hour: 13, min: 42, sec: 23, millisec: 25);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMSM_DDD0 ()
        {
            double expected = 0.57109953703703704;

            double actual = Time.GetDayFraction (hour: 13, min: 42, sec: 23, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMSM_DD00 ()
        {
            double expected = 0.5708333333333333;

            double actual = Time.GetDayFraction (hour: 13, min: 42, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_HMSM_D000 ()
        {
            double expected = 0.5416666666666666;

            double actual = Time.GetDayFraction (hour: 13, min: 0, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTimeComponentsTest_Midnight ()
        {
            double dayFraction = 0.0;

            (int hour, int min, double sec) expected = (0, 0, 0.0);

            (int hour, int min, double sec) actual = Time.GetTimeComponents (dayFraction);

            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetTimeComponentsTest_AlmostMidnight ()
        {
            double dayFraction = 0.99999998842592592;

            (int hour, int min, double sec) expected = (23, 59, 59.999);

            (int hour, int min, double sec) actual = Time.GetTimeComponents (dayFraction);

            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec, 1.0e-4);
        }

        [TestMethod ()]
        public void GetTimeComponentsTest_DDDD ()
        {
            double dayFraction = 0.57109982638888889;

            (int hour, int min, double sec) expected = (13, 42, 23.025);

            (int hour, int min, double sec) actual = Time.GetTimeComponents (dayFraction);

            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec, 1.0e-4);
        }

        [TestMethod ()]
        public void GetTimeComponentsTest_DDD0 ()
        {
            double dayFraction = 0.57109953703703704;

            (int hour, int min, double sec) expected = (13, 42, 23.0);

            (int hour, int min, double sec) actual = Time.GetTimeComponents (dayFraction);

            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec, 1.0e-4);
        }

        [TestMethod ()]
        public void GetTimeComponentsTest_DD00 ()
        {
            double dayFraction = 0.5708333333333333;

            (int hour, int min, double sec) expected = (13, 42, 0.0);

            (int hour, int min, double sec) actual = Time.GetTimeComponents (dayFraction);

            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetTimeComponentsTest_D000 ()
        {
            double dayFraction = 0.5416666666666666;

            (int hour, int min, double sec) expected = (13, 0, 0.0);

            (int hour, int min, double sec) actual = Time.GetTimeComponents (dayFraction);

            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InJuian_Midnight ()
        {
            double expected = 2299159.5;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 0, min: 0, sec: 0.0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InJulian_Morning ()
        {
            double expected = 2299159.9;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 9, min: 36, sec: 0.0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InJulian_Noon ()
        {
            double expected = 2299160.0;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 12, min: 0, sec: 0.0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InJulian_Afternoon ()
        {
            double expected = 2299160.1;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 14, min: 24, sec: 0.0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InJulian_ApproachingToMidnight ()
        {
            double expected = 2299160.49;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 23, min: 45, sec: 36.0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InGregorian_Midnight ()
        {
            double expected = 2451544.5;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 0, min: 0, sec: 0.0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InGregorian_Morning ()
        {
            double expected = 2451544.9;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 9, min: 36, sec: 0.0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InGregorian_Noon ()
        {
            double expected = 2451545.0;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 12, min: 0, sec: 0.0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InGregorian_Afternoon ()
        {
            double expected = 2451545.1;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 14, min: 24, sec: 0.0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_General_InGregorian_ApproachingToMidnight ()
        {
            double expected = 2451545.49;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 23, min: 45, sec: 36.0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_Gregorian_Midnight ()
        {
            double expected = 2451544.5;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 0, min: 0, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_Gregorian_Morning ()
        {
            double expected = 2451544.9;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 9, min: 36, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_Gregorian_Noon ()
        {
            double expected = 2451545.0;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 12, min: 0, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_Gregorian_Afternoon ()
        {
            double expected = 2451545.1;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 14, min: 24, sec: 0.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Sec_Gregorian_ApproachingToMidnight ()
        {
            double expected = 2451545.49;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 23, min: 45, sec: 36.0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InJuian_Midnight ()
        {
            double expected = 2299159.5;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 0, min: 0, sec: 0, millisec: 0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InJulian_Morning ()
        {
            double expected = 2299159.9;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 9, min: 36, sec: 0, millisec: 0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InJulian_Noon ()
        {
            double expected = 2299160.0;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 12, min: 0, sec: 0, millisec: 0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InJulian_Afternoon ()
        {
            double expected = 2299160.1;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 14, min: 24, sec: 0, millisec: 0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InJulian_ApproachingToMidnight ()
        {
            double expected = 2299160.49;

            double actual = Time.GetJD (year: 1582, month: 10, day: 4, hour: 23, min: 45, sec: 36, millisec: 0, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InGregorian_Midnight ()
        {
            double expected = 2451544.5;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 0, min: 0, sec: 0, millisec: 0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InGregorian_Morning ()
        {
            double expected = 2451544.9;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 9, min: 36, sec: 0, millisec: 0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InGregorian_Noon ()
        {
            double expected = 2451545.0;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 12, min: 0, sec: 0, millisec: 0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InGregorian_Afternoon ()
        {
            double expected = 2451545.1;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 14, min: 24, sec: 0, millisec: 0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_General_InGregorian_ApproachingToMidnight ()
        {
            double expected = 2451545.49;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 23, min: 45, sec: 36, millisec: 0, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_Gregorian_Midnight ()
        {
            double expected = 2451544.5;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 0, min: 0, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_Gregorian_Morning ()
        {
            double expected = 2451544.9;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 9, min: 36, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_Gregorian_Noon ()
        {
            double expected = 2451545.0;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 12, min: 0, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_Gregorian_Afternoon ()
        {
            double expected = 2451545.1;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 14, min: 24, sec: 0, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDTest_Milisec_Gregorian_ApproachingToMidnight ()
        {
            double expected = 2451545.49;

            double actual = Time.GetJD (year: 2000, month: 1, day: 1, hour: 23, min: 45, sec: 36, millisec: 0);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_General_LastPregregorianDayInJulian_Midnight ()
        {
            double jd = 2299159.5;

            (int year, int month, int day, int hour, int min, double sec) expected = (1582, 10, 4, 0, 0, 0.0);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd, ECalendarStyle.Julian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_General_FirstGreagorianDayInGregorian_Midnight ()
        {
            double jd = 2299160.5;

            (int year, int month, int day, int hour, int min, double sec) expected = (1582, 10, 15, 0, 0, 0.0);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_Gregorian_Midnight ()
        {
            double jd = 2451544.5;

            (int year, int month, int day, int hour, int min, double sec) expected = (2000, 1, 1, 0, 0, 0.0);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_Gregorian_Morning ()
        {
            double jd = 2451544.9;

            (int year, int month, int day, int hour, int min, double sec) expected = (2000, 1, 1, 9, 35, 59.999999);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec, 1.0e-4);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_Gregorian_Noon ()
        {
            double jd = 2451545.0;

            (int year, int month, int day, int hour, int min, double sec) expected = (2000, 1, 1, 12, 0, 0.0);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_Gregorian_Afternoon ()
        {
            double jd = 2451545.1;

            (int year, int month, int day, int hour, int min, double sec) expected = (2000, 1, 1, 14, 24, 0.0);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec, 1.0e-4);
        }

        [TestMethod ()]
        public void GetDateComponentsTest_Gregorian_ApproachingToMidnight ()
        {
            double jd = 2451545.49;

            (int year, int month, int day, int hour, int min, double sec) expected = (2000, 1, 1, 23, 45, 36.0);

            (int year, int month, int day, int hour, int min, double sec) actual = Time.GetDateComponents (jd);

            Assert.AreEqual (expected.year, actual.year);
            Assert.AreEqual (expected.month, actual.month);
            Assert.AreEqual (expected.day, actual.day);
            Assert.AreEqual (expected.hour, actual.hour);
            Assert.AreEqual (expected.min, actual.min);
            Assert.AreEqual (expected.sec, actual.sec, 1.0e-4);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Sunday ()
        {
            int jdn = 2460667;

            int expected = 0;

            int actual = Time.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Monday ()
        {
            int jdn = 2460668;

            int expected = 1;

            int actual = Time.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Friday ()
        {
            int jdn = 2460672;

            int expected = 5;

            int actual = Time.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Saturday ()
        {
            int jdn = 2460673;

            int expected = 6;

            int actual = Time.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GeJDNumberTest_Midnight ()
        {
            double jd = 2460670.5;

            int expected = 2460671;

            int actual = Time.GetJDNumber (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GeJDNumberTest_BeforeNoon ()
        {
            double jd = 2460670.99;

            int expected = 2460671;

            int actual = Time.GetJDNumber (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GeJDNumberTest_Noon ()
        {
            double jd = 2460671.0;

            int expected = 2460671;

            int actual = Time.GetJDNumber (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GeJDNumberTest_Afternoon ()
        {
            double jd = 2460671.01;

            int expected = 2460671;

            int actual = Time.GetJDNumber (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GeJDNumberTest_ApproachingMidnight ()
        {
            double jd = 2460671.499999999;

            int expected = 2460671;

            int actual = Time.GetJDNumber (jd);

            Assert.AreEqual (expected, actual);
        }
    }
}