using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class AxialTiltTests
    {
        [TestMethod ()]
        public void GetTiltTest_J2000 ()
        {
            double T = 0.0;

            double expected = 0.40909280420293639;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltTest_2100 ()
        {
            double T = 1.0;

            double expected = 0.40886584460739628;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltTest_2200 ()
        {
            double T = 2.0;

            double expected = 0.40863893202908697;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltTest_1900 ()
        {
            double T = -1.0;

            double expected = 0.40931975807767506;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void GetTiltForJDTest_J2000 ()
        {
            double jd = 2451545.0;

            double expected = 0.40909280420293639;

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltForJDTest_2100 ()
        {
            double jd = 2488070.0;

            double expected = 0.40886584460739628;

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltForJDTest_2200 ()
        {
            double jd = 2524595.0;

            double expected = 0.40863893202908697;

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltForJDTest_1900 ()
        {
            double jd = 2415020.0;

            double expected = 0.40931975807767506;

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }
    }
}