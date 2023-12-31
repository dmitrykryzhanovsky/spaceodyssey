using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class KeplerEquationTests
    {
        [TestMethod ()]
        public void EllipticTest_Eccentricity_0_M_0 ()
        {
            double eccentricity = 0.0;
            double M = 0.0;
            double epsilon = 5.0e-16;

            double actual = 0.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0_M_Quadrant1 ()
        {
            double eccentricity = 0.0;
            double M = 1.0;
            double epsilon = 5.0e-16;

            double actual = 1.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0_M_Quadrant2 ()
        {
            double eccentricity = 0.0;
            double M = 3.0;
            double epsilon = 5.0e-16;

            double actual = 3.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0_M_180 ()
        {
            double eccentricity = 0.0;
            double M = Double.Pi;
            double epsilon = 5.0e-16;

            double actual = Double.Pi;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0_M_Bottom ()
        {
            double eccentricity = 0.0;
            double M = 5.0;
            double epsilon = 5.0e-16;

            double actual = 5.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0_M_Negative ()
        {
            double eccentricity = 0.0;
            double M = -2.0;
            double epsilon = 5.0e-16;

            double actual = -2.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_042_M_0 ()
        {
            double eccentricity = 0.42;
            double M = 0.0;
            double epsilon = 5.0e-16;

            double actual = 0.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_042_M_Quadrant1 ()
        {
            double eccentricity = 0.42;
            double M = 0.646582186380684;
            double epsilon = 5.0e-16;

            double actual = 1.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_042_M_Quadrant2 ()
        {
            double eccentricity = 0.42;
            double M = 2.94072959661486;
            double epsilon = 5.0e-16;

            double actual = 3.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_042_M_180 ()
        {
            double eccentricity = 0.42;
            double M = Double.Pi;
            double epsilon = 5.0e-16;

            double actual = Double.Pi;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_042_M_Bottom ()
        {
            double eccentricity = 0.42;
            double M = 5.40274819535852;
            double epsilon = 5.0e-16;

            double actual = 5.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_042_M_Negative ()
        {
            double eccentricity = 0.42;
            double M = -1.61809508073321;
            double epsilon = 5.0e-16;

            double actual = -2.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_070_M_0 ()
        {
            double eccentricity = 0.7;
            double M = 0.0;
            double epsilon = 5.0e-16;

            double actual = 0.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_070_M_Quadrant1 ()
        {
            double eccentricity = 0.7;
            double M = 0.410970310634473;
            double epsilon = 5.0e-16;

            double actual = 1.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_070_M_Quadrant2 ()
        {
            double eccentricity = 0.7;
            double M = 2.90121599435809;
            double epsilon = 5.0e-16;

            double actual = 3.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_070_M_180 ()
        {
            double eccentricity = 0.7;
            double M = Double.Pi;
            double epsilon = 5.0e-16;

            double actual = Double.Pi;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_070_M_Bottom ()
        {
            double eccentricity = 0.7;
            double M = 5.6712469922642;
            double epsilon = 5.0e-16;

            double actual = 5.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_070_M_Negative ()
        {
            double eccentricity = 0.7;
            double M = -1.36349180122202;
            double epsilon = 5.0e-16;

            double actual = -2.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_081_M_0 ()
        {
            double eccentricity = 0.81;
            double M = 0.0;
            double epsilon = 5.0e-16;

            double actual = 0.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_081_M_Quadrant1 ()
        {
            double eccentricity = 0.81;
            double M = 0.318408502305604;
            double epsilon = 5.0e-16;

            double actual = 1.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_081_M_Quadrant2 ()
        {
            double eccentricity = 0.81;
            double M = 2.88569279347151;
            double epsilon = 5.0e-16;

            double actual = 3.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_081_M_180 ()
        {
            double eccentricity = 0.81;
            double M = Double.Pi;
            double epsilon = 5.0e-16;

            double actual = Double.Pi;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_081_M_Bottom ()
        {
            double eccentricity = 0.81;
            double M = 5.77672866247714;
            double epsilon = 5.0e-16;

            double actual = 5.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_081_M_Negative ()
        {
            double eccentricity = 0.81;
            double M = -1.2634690842712;
            double epsilon = 5.0e-16;

            double actual = -2.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_099_M_0 ()
        {
            double eccentricity = 0.99;
            double M = 0.0;
            double epsilon = 5.0e-16;

            double actual = 0.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_099_M_Quadrant1 ()
        {
            double eccentricity = 0.99;
            double M = 0.166943725040183;
            double epsilon = 5.0e-16;

            double actual = 1.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_099_M_Quadrant2 ()
        {
            double eccentricity = 0.99;
            double M = 2.86029119202073;
            double epsilon = 5.0e-16;

            double actual = 3.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_099_M_180 ()
        {
            double eccentricity = 0.99;
            double M = Double.Pi;
            double epsilon = 5.0e-16;

            double actual = Double.Pi;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_099_M_Bottom ()
        {
            double eccentricity = 0.99;
            double M = 5.94933503191651;
            double epsilon = 5.0e-16;

            double actual = 5.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_099_M_Negative ()
        {
            double eccentricity = 0.99;
            double M = -1.09979554744258;
            double epsilon = 5.0e-16;

            double actual = -2.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0999999_M_0 ()
        {
            double eccentricity = 0.999999;
            double M = 0.0;
            double epsilon = 5.0e-16;

            double actual = 0.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0999999_M_Quadrant1 ()
        {
            double eccentricity = 0.999999;
            double M = 0.158529856663088;
            double epsilon = 5.0e-16;

            double actual = 1.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0999999_M_Quadrant2 ()
        {
            double eccentricity = 0.999999;
            double M = 2.85888013306014;
            double epsilon = 5.0e-16;

            double actual = 3.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0999999_M_180 ()
        {
            double eccentricity = 0.999999;
            double M = Double.Pi;
            double epsilon = 5.0e-16;

            double actual = Double.Pi;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 2.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0999999_M_Bottom ()
        {
            double eccentricity = 0.999999;
            double M = 5.95892331573886;
            double epsilon = 5.0e-16;

            double actual = 5.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }

        [TestMethod ()]
        public void EllipticTest_Eccentricity_0999999_M_Negative ()
        {
            double eccentricity = 0.999999;
            double M = -1.09070348247175;
            double epsilon = 5.0e-16;

            double actual = -2.0;

            double expected = KeplerEquation.Elliptic (M, eccentricity, epsilon);

            Assert.AreEqual (expected, actual, 10.0 * epsilon);
        }
    }
}