using Microsoft.VisualStudio.TestTools.UnitTesting;

using SpaceOdyssey;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class AxialTiltTests
    {
        [TestMethod ()]
        public void GetTiltForJDTest_J2000 ()
        {
            double jd = AstroConst.J2000;

            double expected = Trigonometry.DegToRad (23.43929111);

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltForJDTest_Y2001 ()
        {
            double jd = AstroConst.J2000 + 365.0;

            double expected = 0.409090536100906;

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void GetTiltForJDTest_Y1999 ()
        {
            double jd = AstroConst.J2000 - 365.0;

            double expected = 0.409095072304396;

            double actual = AxialTilt.GetTiltForJD (jd);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }
    }
}