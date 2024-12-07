using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class KitTests
    {
        [TestMethod ()]
        public void GetDayFractionTest_Midnight ()
        {
            int hour = 0;
            int min = 0;
            int sec = 0;
            int millisec = 0;

            double expected = 0.0;

            double actual = Kit.GetDayFraction (hour, min, sec, millisec);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_OneMillisecondAfterMidnight ()
        {
            int hour = 0;
            int min = 0;
            int sec = 0;
            int millisec = 1;

            double expected = 1.1574074074074074e-8;

            double actual = Kit.GetDayFraction (hour, min, sec, millisec);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_ArbitraryMoment ()
        {
            int hour = 7;
            int min = 11;
            int sec = 13;
            int millisec = 17;

            double expected = 0.29945621527777778;

            double actual = Kit.GetDayFraction (hour, min, sec, millisec);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayFractionTest_OneMillisecondBeforeMidnight ()
        {
            int hour = 23;
            int min = 59;
            int sec = 59;
            int millisec = 999;

            double expected = 0.99999998842592593;

            double actual = Kit.GetDayFraction (hour, min, sec, millisec);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayTimeTest_Midnight ()
        {
            double dayFraction = 0.0;

            (int hour, int min, int sec, int millisec) expected = (0, 0, 0, 0);

            (int hour, int min, int sec, int millisec) actual = Kit.GetDayTime (dayFraction);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayTimeTest_OneMillisecondAfterMidnight ()
        {
            double dayFraction = 1.1574074074074074e-8;

            (int hour, int min, int sec, int millisec) expected = (0, 0, 0, 1);

            (int hour, int min, int sec, int millisec) actual = Kit.GetDayTime (dayFraction);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayTimeTest_ArbitraryMoment ()
        {
            double dayFraction = 0.29945621527777778;

            (int hour, int min, int sec, int millisec) expected = (7, 11, 13, 17);

            (int hour, int min, int sec, int millisec) actual = Kit.GetDayTime (dayFraction);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetDayTimeTest_OneMillisecondBeforeMidnight ()
        {
            double dayFraction = 0.99999998842592593;

            (int hour, int min, int sec, int millisec) expected = (23, 59, 59, 999);

            (int hour, int min, int sec, int millisec) actual = Kit.GetDayTime (dayFraction);

            Assert.AreEqual (expected, actual);
        }
    }
}