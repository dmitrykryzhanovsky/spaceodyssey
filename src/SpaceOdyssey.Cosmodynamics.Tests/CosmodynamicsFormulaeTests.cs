﻿using SpaceOdyssey.Cosmodynamics;
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
        public void IsEccentricityValidForEllipseTest_Less0 ()
        {
            double e = -1.0;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_Near0Left ()
        {
            double e = -1.0e-15;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_0 ()
        {
            double e = 0.0;

            bool expected = true;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_Near0Right ()
        {
            double e = 1.0e-15;

            bool expected = true;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_Between_0_1 ()
        {
            double e = 0.5;

            bool expected = true;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_Near1Left ()
        {
            double e = 1.0 - 1.0e-15;

            bool expected = true;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_1 ()
        {
            double e = 1.0;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_Near1Right ()
        {
            double e = 1.0 + 1.0e-15;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForEllipseTest_Greater1 ()
        {
            double e = 2.0;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForEllipse (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForHyperbolaTest_Less1 ()
        {
            double e = 0.5;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForHyperbola (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForHyperbolaTest_Near1Left ()
        {
            double e = 1.0 - 1.0e-15;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForHyperbola (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForHyperbolaTest_1 ()
        {
            double e = 1.0;

            bool expected = false;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForHyperbola (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForHyperbolaTest_Near1Right ()
        {
            double e = 1.0 + 1.0e-15;

            bool expected = true;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForHyperbola (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void IsEccentricityValidForHyperbolaTest_Greater1 ()
        {
            double e = 2.0;

            bool expected = true;

            bool actual = CosmodynamicsFormulae.IsEccentricityValidForHyperbola (e);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SemiMajorAxisByMeanMotionTest ()
        {
            double K2 = AstroConst.GaussianGravitationalConstant2;
            double n = Trigonometry.DegToRad (0.98560911311504671);

            double expected = 0.999999022929777;

            double actual = CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (K2, n);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }
    }
}