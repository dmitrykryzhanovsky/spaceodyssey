using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class SiderealTimeTests
    {
        [TestMethod ()]
        public void GMSTInRotationTest_Midnight ()
        {
            double jd = 2460670.5;

            double expected = 0.2638490787037037;

            double actual = SiderealTime.GMSTInRotation (jd);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void GMSTInRotationTest_Morning ()
        {
            double jd = 2460670.75;

            double expected = 0.51453355671296296;

            double actual = SiderealTime.GMSTInRotation (jd);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void GMSTInRotationTest_Noon ()
        {
            double jd = 2460671.0;

            double expected = 0.76521803356481481;

            double actual = SiderealTime.GMSTInRotation (jd);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void GMSTInRotationTest_Evening ()
        {
            double jd = 2460671.25;

            double expected = 0.01590251157407407;

            double actual = SiderealTime.GMSTInRotation (jd);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void LMSTInRotationTest_Location ()
        {
            double jd   = 2460671.0;
            double gmst = SiderealTime.GMSTInRotation (jd);

            Location location = new Location (latitude: 0.8499753457212385, longitude: 0.77667151713747666);

            double expected = 0.88882914467592592;

            double actual = SiderealTime.LMSTInRotation (location, gmst);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void LMSTInRotationTest_Longitude ()
        {
            double jd   = 2460671.0;
            double gmst = SiderealTime.GMSTInRotation (jd);

            double longitude = 0.77667151713747666;
            
            double expected = 0.88882914467592592;

            double actual = SiderealTime.LMSTInRotation (longitude, gmst);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }
    }
}