using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class JDTests
    {
        [TestMethod ()]
        public void GetCalebdarStyleTest_FirstJulianDay ()
        {
            int year  = -4712;
            int month = 1;
            int day   = 1;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_LastDayBC ()
        {
            int year  = 0;
            int month = 12;
            int day   = 31;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_FirstDayAD ()
        {
            int year  = 1;
            int month = 1;
            int day   = 1;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_PreLilianDay ()
        {
            int year  = 1582;
            int month = 10;
            int day   = 4;

            ECalendarStyle expected = ECalendarStyle.Julian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_LilianDay ()
        {
            int year  = 1582;
            int month = 10;
            int day   = 15;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_1582OctoberAfterLilianDay ()
        {
            int year  = 1582;
            int month = 10;
            int day   = 16;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_1582AfterOctober ()
        {
            int year  = 1582;
            int month = 11;
            int day   = 1;

            ECalendarStyle expected = ECalendarStyle.Gregorian;

            ECalendarStyle actual = JD.GetCalebdarStyle (year, month, day);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetCalebdarStyleTest_ThirdMillenium ()
        {
            int year  = 2023;
            int month = 7;
            int day   = 12;

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
            int year  = -4712;
            int month = 1;
            int day   = 1;

            int expected = 0;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_LastDayBC ()
        {
            int year  = 0;
            int month = 12;
            int day   = 31;

            int expected = 1721423;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_FirstDayAD ()
        {
            int year  = 1;
            int month = 1;
            int day   = 1;

            int expected = 1721424;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_PreLilianDay ()
        {
            int year  = 1582;
            int month = 10;
            int day   = 4;

            int expected = 2299160;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Julian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_LilianDay ()
        {
            int year  = 1582;
            int month = 10;
            int day   = 15;

            int expected = 2299161;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_1582OctoberAfterLilianDay ()
        {
            int year  = 1582;
            int month = 10;
            int day   = 16;

            int expected = 2299162;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNest_1582AfterOctober ()
        {
            int year  = 1582;
            int month = 11;
            int day   = 1;

            int expected = 2299178;

            int actual = JD.GetJDN (year, month, day, ECalendarStyle.Gregorian);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJDNTest_ThirdMillenium ()
        {
            int year  = 2023;
            int month = 7;
            int day   = 12;

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
        public void GetJulianDateTest ()
        {
            Assert.Fail ();
        }

        [TestMethod ()]
        public void GetDateTimeTest ()
        {
            Assert.Fail ();
        }

        [TestMethod ()]
        public void GetWeekDayTest ()
        {
            Assert.Fail ();
        }
    }
}