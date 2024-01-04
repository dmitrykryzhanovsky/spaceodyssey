using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class CosmodynamicsFormulaeTests
    {
        [TestMethod ()]
        public void RadiusTest_E0 ()
        {
            double p = 1.42;
            double e = 0.0;
            double trueAnomaly = 60.0;

            double expected = 1.42;

            double actual = CosmodynamicsFormulae.Radius (p, e, Trigonometry.DegToRad (trueAnomaly));

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_E_Ellipse ()
        {
            double p = 1.42;
            double e = 0.5;
            double trueAnomaly = 120.0;

            double expected = 1.8933333333333333;

            double actual = CosmodynamicsFormulae.Radius (p, e, Trigonometry.DegToRad (trueAnomaly));

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void RadiusTest_E_1 ()
        {
            double p = 1.42;
            double e = 1.0;
            double trueAnomaly = -120.0;

            double expected = 2.84;

            double actual = CosmodynamicsFormulae.Radius (p, e, Trigonometry.DegToRad (trueAnomaly));

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void RadiusTest_E_Hyperbola ()
        {
            double p = 1.42;
            double e = 1.5;
            double trueAnomaly = -60.0;

            double expected = 0.81142857142857143;

            double actual = CosmodynamicsFormulae.Radius (p, e, Trigonometry.DegToRad (trueAnomaly));

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest ()
        {
            Assert.Fail ();
        }

        [TestMethod ()]
        public void IsEccentricityValidForHyperbolaTest ()
        {
            Assert.Fail ();
        }
    }
}