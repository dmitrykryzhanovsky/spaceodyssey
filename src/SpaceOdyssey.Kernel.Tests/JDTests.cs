using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class JDTests
    {
        [TestMethod ()]
        public void GetCalebdarStyleTest_FirstJulianDay ()
        {
            int year = -4712;
            int month = 1;
            int day = 1;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_LastDayBC ()
        {
            int year = 0;
            int month = 12;
            int day = 31;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_FirstDayAD ()
        {
            int year = 1;
            int month = 1;
            int day = 1;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_PreLilianDay ()
        {
            int year = 1582;
            int month = 10;
            int day = 4;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_LilianDay ()
        {
            int year = 1582;
            int month = 10;
            int day = 15;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_1582OctoberAfterLilianDay ()
        {
            int year = 1582;
            int month = 10;
            int day = 16;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_1582AfterOctober ()
        {
            int year = 1582;
            int month = 11;
            int day = 1;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_ThirdMillenium ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_PreLilianDayJulianDate ()
        {
            int jdn = 2299160;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_LilianDayJulianDate ()
        {
            int jdn = 2299161;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_ThirdMilleniumJulianDate ()
        {
            int jdn = 2460138;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_FirstJulianDay ()
        {
            int year = -4712;
            int month = 1;
            int day = 1;

            int expected = 0;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_SecondJulianDay ()
        {
            int year = -4712;
            int month = 1;
            int day = 2;

            int expected = 1;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_LastDayBC ()
        {
            int year = 0;
            int month = 12;
            int day = 31;

            int expected = 1721423;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_FirstDayAD ()
        {
            int year = 1;
            int month = 1;
            int day = 1;

            int expected = 1721424;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_PreLilianDay ()
        {
            int year = 1582;
            int month = 10;
            int day = 4;

            int expected = 2299160;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_LilianDay ()
        {
            int year = 1582;
            int month = 10;
            int day = 15;

            int expected = 2299161;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_1582OctoberAfterLilianDay ()
        {
            int year = 1582;
            int month = 10;
            int day = 16;

            int expected = 2299162;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNest_1582AfterOctober ()
        {
            int year = 1582;
            int month = 11;
            int day = 1;

            int expected = 2299178;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_ThirdMillenium ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;

            int expected = 2460138;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_FirstJulianDay ()
        {
            int jdn = 0;

            (int year, int month, int day) expected = (-4712, 1, 1);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_SecondJulianDay ()
        {
            int jdn = 1;

            (int year, int month, int day) expected = (-4712, 1, 2);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_LastDayBC ()
        {
            int jdn = 1721423;

            (int year, int month, int day) expected = (0, 12, 31);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_FirstDayAD ()
        {
            int jdn = 1721424;

            (int year, int month, int day) expected = (1, 1, 1);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_PreLilianDay ()
        {
            int jdn = 2299160;

            (int year, int month, int day) expected = (1582, 10, 4);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_LilianDay ()
        {
            int jdn = 2299161;

            (int year, int month, int day) expected = (1582, 10, 15);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_1582OctoberAfterLilianDay ()
        {
            int jdn = 2299162;

            (int year, int month, int day) expected = (1582, 10, 16);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_1582AfterOctober ()
        {
            int jdn = 2299178;

            (int year, int month, int day) expected = (1582, 11, 1);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalendarDateTest_ThirdMillenium ()
        {
            int jdn = 2460138;

            (int year, int month, int day) expected = (2023, 7, 12);

            (int year, int month, int day) actual = JD.GetCalendarDate (jdn, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianDateTest_Midnight ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;
            int hour = 0;
            int min = 0;
            int sec = 0;
            int millisec = 0;

            double expected = 2460137.5;

            double actual = JD.GetJulianDate (year, month, day, hour, min, sec, millisec, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianDateTest_OneMillisecondBeforeNoon ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;
            int hour = 11;
            int min = 59;
            int sec = 59;
            int millisec = 999;

            double expected = 2460137.99999998843;

            double actual = JD.GetJulianDate (year, month, day, hour, min, sec, millisec, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianDateTest_Noon ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;
            int hour = 12;
            int min = 0;
            int sec = 0;
            int millisec = 0;

            double expected = 2460138.0;

            double actual = JD.GetJulianDate (year, month, day, hour, min, sec, millisec, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianDateTest_OneMillisecondAfterNoon ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;
            int hour = 12;
            int min = 0;
            int sec = 0;
            int millisec = 1;

            double expected = 2460138.0000000116;

            double actual = JD.GetJulianDate (year, month, day, hour, min, sec, millisec, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianDateTest_OneMillisecondBeforeMidnight ()
        {
            int year = 2023;
            int month = 7;
            int day = 12;
            int hour = 23;
            int min = 59;
            int sec = 59;
            int millisec = 999;

            double expected = 2460138.49999998843;

            double actual = JD.GetJulianDate (year, month, day, hour, min, sec, millisec, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateTimeTest_Midnight ()
        {
            double jd = 2460137.5;

            (int year, int month, int day, int hour, int min, int sec, int millisec) expected = (2023, 7, 12, 0, 0, 0, 0);

            (int year, int month, int day, int hour, int min, int sec, int millisec) actual = JD.GetDateTime (jd, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateTimeTest_OneMillisecondBeforeNoon ()
        {
            double jd = 2460137.99999998843;

            (int year, int month, int day, int hour, int min, int sec, int millisec) expected = (2023, 7, 12, 11, 59, 59, 998);

            (int year, int month, int day, int hour, int min, int sec, int millisec) actual = JD.GetDateTime (jd, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateTimeTest_Noon ()
        {
            double jd = 2460138.0;

            (int year, int month, int day, int hour, int min, int sec, int millisec) expected = (2023, 7, 12, 12, 0, 0, 0);

            (int year, int month, int day, int hour, int min, int sec, int millisec) actual = JD.GetDateTime (jd, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateTimeTest_OneMillisecondAfterNoon ()
        {
            double jd = 2460138.0000000116;

            (int year, int month, int day, int hour, int min, int sec, int millisec) expected = (2023, 7, 12, 12, 0, 0, 1);

            (int year, int month, int day, int hour, int min, int sec, int millisec) actual = JD.GetDateTime (jd, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDateTimeTest_OneMillisecondBeforeMidnight ()
        {
            double jd = 2460138.49999998843;

            (int year, int month, int day, int hour, int min, int sec, int millisec) expected = (2023, 7, 12, 23, 59, 59, 998);

            (int year, int month, int day, int hour, int min, int sec, int millisec) actual = JD.GetDateTime (jd, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Monday ()
        {
            int jdn = 2460311;

            int expected = 1;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Tuesday ()
        {
            int jdn = 2460312;

            int expected = 2;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Wednesday ()
        {
            int jdn = 2460313;

            int expected = 3;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Thursday ()
        {
            int jdn = 2460314;

            int expected = 4;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Friday ()
        {
            int jdn = 2460315;

            int expected = 5;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Saturday ()
        {
            int jdn = 2460316;

            int expected = 6;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetWeekDayTest_Sunday ()
        {
            int jdn = 2460317;

            int expected = 0;

            int actual = JD.GetWeekDay (jdn);

            Assert.AreEqual (expected, actual);
        }
    }
}