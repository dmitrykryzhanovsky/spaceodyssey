using SpaceOdyssey;
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
        public void GetJDNTest ()
        {
            Assert.Fail ();
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
    }
}