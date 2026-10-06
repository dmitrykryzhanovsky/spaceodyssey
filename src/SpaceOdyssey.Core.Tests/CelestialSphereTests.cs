using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Security.Cryptography;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class CelestialSphereTests
    {
        [TestMethod ()]
        public void HorizontalToEq1Test_NorthPole_Zenith ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (MathConst.M_PI_2);
            (double sinH, double cosH)     = double.SinCos (MathConst.M_PI_2);
            (double sinA, double cosA)     = (42, 73);

            Eq1Position expected = new Eq1Position (MathConst.M_PI_2, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_NorthPole_Nadir ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (MathConst.M_PI_2);
            (double sinH, double cosH)     = double.SinCos (-MathConst.M_PI_2);
            (double sinA, double cosA)     = (42, 73);

            Eq1Position expected = new Eq1Position (-MathConst.M_PI_2, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_SouthPole_Zenith ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (-MathConst.M_PI_2);
            (double sinH, double cosH)     = double.SinCos (MathConst.M_PI_2);
            (double sinA, double cosA)     = (42, 73);

            Eq1Position expected = new Eq1Position (-MathConst.M_PI_2, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_SouthPole_Nadir ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (-MathConst.M_PI_2);
            (double sinH, double cosH)     = double.SinCos (-MathConst.M_PI_2);
            (double sinA, double cosA)     = (42, 73);

            Eq1Position expected = new Eq1Position (MathConst.M_PI_2, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_Equator_North ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (0.0);
            (double sinH, double cosH)     = double.SinCos (0.0);
            (double sinA, double cosA)     = double.SinCos (0.0);

            Eq1Position expected = new Eq1Position (MathConst.M_PI_2, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_Equator_East ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (0.0);
            (double sinH, double cosH)     = double.SinCos (0.0);
            (double sinA, double cosA)     = double.SinCos (MathConst.M_PI_2);

            Eq1Position expected = new Eq1Position (0.0, -MathConst.M_PI_2);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_Equator_South ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (0.0);
            (double sinH, double cosH)     = double.SinCos (0.0);
            (double sinA, double cosA)     = double.SinCos (double.Pi);

            Eq1Position expected = new Eq1Position (-MathConst.M_PI_2, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_Equator_West ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (0.0);
            (double sinH, double cosH)     = double.SinCos (0.0);
            (double sinA, double cosA)     = double.SinCos (3.0 * MathConst.M_PI_2);

            Eq1Position expected = new Eq1Position (0.0, MathConst.M_PI_2);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_Equator_Zenith ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (0.0);
            (double sinH, double cosH)     = double.SinCos (MathConst.M_PI_2);
            (double sinA, double cosA)     = double.SinCos (0.0);

            Eq1Position expected = new Eq1Position (0.0, 0.0);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_Equator_Nadir ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (0.0);
            (double sinH, double cosH)     = double.SinCos (-MathConst.M_PI_2);
            (double sinA, double cosA)     = double.SinCos (0.0);

            Eq1Position expected = new Eq1Position (0.0, double.Pi);

            Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle, actual.HourAngle);
        }

        [TestMethod ()]
        public void HorizontalToEq1Test_NorthernHemisphere ()
        {
            (double sinPhi, double cosPhi) = double.SinCos (double.Pi / 6.0);

            double [] H   = new double [] { 0, 0, 0, 0, MathConst.M_PI_2, -MathConst.M_PI_2, double.Pi / 6.0, -double.Pi / 6.0 };
            double [] A   = new double [] { 0, MathConst.M_PI_2, double.Pi, 3.0 * MathConst.M_PI_2, 0, 0, 0, double.Pi };

            double [] Dec = new double [] { MathConst.M_PI_3, 0, -MathConst.M_PI_3, 0, double.Pi / 6.0, -double.Pi / 6.0, MathConst.M_PI_2, -MathConst.M_PI_2 };
            double [] Tau = new double [] { double.Pi, -MathConst.M_PI_2, 0, MathConst.M_PI_2, 0, double.Pi, double.Pi, 0 };

            for (int i = 0; i < H.Length; i++)
            {
                (double sinH, double cosH) = double.SinCos (H [i]);
                (double sinA, double cosA) = double.SinCos (A [i]);

                Eq1Position expected = new Eq1Position (Dec [i], Tau [i]);

                Eq1Position actual = CelestialSphere.HorizontalToEquatorial1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

                Assert.AreEqual (expected.Declination, actual.Declination, 1.0e-15);
                Assert.AreEqual (expected.HourAngle, actual.HourAngle, 1.0e-15);
            }
        }
    }
}