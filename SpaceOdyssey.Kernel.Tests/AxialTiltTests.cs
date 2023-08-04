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

        [TestMethod ()]
        public void GetTiltSinCosForJDTest_Y1999 ()
        {
            double jd = AstroConst.J2000 - 365.0;

            double expectedTilt = 0.409095072304396;
            double expectedSin = 0.397779236855502;
            double expectedCos = 0.917481159875588;

            (double actualTilt, double actualSin, double actualCos) = AxialTilt.GetTiltSinCosForJD (jd);

            Assert.AreEqual (expectedTilt, actualTilt, 1.0e-15);
            Assert.AreEqual (expectedSin, actualSin, 1.0e-15);
            Assert.AreEqual (expectedCos, actualCos, 1.0e-15);
        }

        [TestMethod ()]
        public void GetTiltSinCosMatricesForJDTest_Y1999 ()
        {
            double jd = AstroConst.J2000 - 365.0;

            double expectedTilt = 0.409095072304396;
            double expectedSin  = 0.397779236855502;
            double expectedCos  = 0.917481159875588;

            Matrix3 expectedPositive = new Matrix3 (1, 0, 0, 
                0,  expectedCos,  expectedSin, 
                0, -expectedSin,  expectedCos);
            Matrix3 expectedNegative = new Matrix3 (1, 0, 0, 
                0,  expectedCos, -expectedSin, 
                0,  expectedSin,  expectedCos);

            (double actualTilt, double actualSin, double actualCos, Matrix3 actualPositive, Matrix3 actualNegative) = 
                AxialTilt.GetTiltSinCosMatricesForJD (jd);

            Assert.AreEqual (expectedTilt, actualTilt, 1.0e-15);
            Assert.AreEqual (expectedSin, actualSin, 1.0e-15);
            Assert.AreEqual (expectedCos, actualCos, 1.0e-15);

            Assert.AreEqual (expectedPositive [0, 0], actualPositive [0, 0], 1.0e-15);
            Assert.AreEqual (expectedPositive [0, 1], actualPositive [0, 1], 1.0e-15);
            Assert.AreEqual (expectedPositive [0, 2], actualPositive [0, 2], 1.0e-15);
            Assert.AreEqual (expectedPositive [1, 0], actualPositive [1, 0], 1.0e-15);
            Assert.AreEqual (expectedPositive [1, 1], actualPositive [1, 1], 1.0e-15);
            Assert.AreEqual (expectedPositive [1, 2], actualPositive [1, 2], 1.0e-15);
            Assert.AreEqual (expectedPositive [2, 0], actualPositive [2, 0], 1.0e-15);
            Assert.AreEqual (expectedPositive [2, 1], actualPositive [2, 1], 1.0e-15);
            Assert.AreEqual (expectedPositive [2, 2], actualPositive [2, 2], 1.0e-15);

            Assert.AreEqual (expectedNegative [0, 0], actualNegative [0, 0], 1.0e-15);
            Assert.AreEqual (expectedNegative [0, 1], actualNegative [0, 1], 1.0e-15);
            Assert.AreEqual (expectedNegative [0, 2], actualNegative [0, 2], 1.0e-15);
            Assert.AreEqual (expectedNegative [1, 0], actualNegative [1, 0], 1.0e-15);
            Assert.AreEqual (expectedNegative [1, 1], actualNegative [1, 1], 1.0e-15);
            Assert.AreEqual (expectedNegative [1, 2], actualNegative [1, 2], 1.0e-15);
            Assert.AreEqual (expectedNegative [2, 0], actualNegative [2, 0], 1.0e-15);
            Assert.AreEqual (expectedNegative [2, 1], actualNegative [2, 1], 1.0e-15);
            Assert.AreEqual (expectedNegative [2, 2], actualNegative [2, 2], 1.0e-15);
        }
    }
}