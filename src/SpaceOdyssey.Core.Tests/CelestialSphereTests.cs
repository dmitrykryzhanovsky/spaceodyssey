using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class CelestialSphereTests
    {
        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialPole_NorthPole ()
        {
            double   declination = MathConst.PI_DIV_2;
            Location location    = new Location (MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoDeclining);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialHemisphere_NorthPole ()
        {
            double   declination = double.Pi / 3.0;
            Location location    = new Location (MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoDeclining);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_CelestialEquator_NorthPole ()
        {
            double   declination = 0.0;
            Location location    = new Location (MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_SouthCelestialHemisphere_NorthPole ()
        {
            double   declination = -double.Pi / 3.0;
            Location location    = new Location (MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoRising);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_SouthCelestialPole_NorthPole ()
        {
            double   declination = -MathConst.PI_DIV_2;
            Location location    = new Location (MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoRising);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialPole_NorthHemisphere ()
        {
            double   declination = MathConst.PI_DIV_2;
            Location location    = new Location (double.Pi / 3.0);

            RiseParams expected = new RiseParams (ECircumpolar.NoDeclining);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NoDeclining_NorthHemisphere ()
        {
            double   declination = MathConst.PI_DIV_4;
            Location location    = new Location (double.Pi / 3.0);

            RiseParams expected = new RiseParams (ECircumpolar.NoDeclining);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_TouchingHorizonNorth_NorthHemisphere ()
        {
            double   declination = double.Pi / 6.0;
            Location location    = new Location (double.Pi / 3.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual ( 0.0,        actual.RiseAzimuth, 1.0e-7);
            Assert.AreEqual (-double.Pi,  actual.RiseHourAngle, 1.0e-7);
            Assert.AreEqual ( double.Tau, actual.DeclineAzimuth, 1.0e-7);
            Assert.AreEqual ( double.Pi,  actual.DeclineHourAngle, 1.0e-7);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_UsualNorth_NorthHemisphere ()
        {
            double   declination = double.Pi / 8.0;
            Location location = new Location (double.Pi / 3.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual (0.0, actual.RiseAzimuth, 1.0e-7);
            Assert.AreEqual (-double.Pi, actual.RiseHourAngle, 1.0e-7);
            Assert.AreEqual (double.Tau, actual.DeclineAzimuth, 1.0e-7);
            Assert.AreEqual (double.Pi, actual.DeclineHourAngle, 1.0e-7);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_CelestialEquator_NorthHemisphere ()
        {
            double   declination = 0.0;
            Location location    = new Location (double.Pi / 3.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual ( MathConst.PI_DIV_2,       actual.RiseAzimuth);
            Assert.AreEqual (-MathConst.PI_DIV_2,       actual.RiseHourAngle);
            Assert.AreEqual ( MathConst.PI_DIV_2 * 3.0, actual.DeclineAzimuth);
            Assert.AreEqual ( MathConst.PI_DIV_2,       actual.DeclineHourAngle);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialPole_Equator ()
        {
            double   declination = MathConst.PI_DIV_2;
            Location location    = new Location (0.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual ( 0.0,        actual.RiseAzimuth);
            Assert.AreEqual (-double.Pi,  actual.RiseHourAngle);
            Assert.AreEqual ( double.Tau, actual.DeclineAzimuth);
            Assert.AreEqual ( double.Pi,  actual.DeclineHourAngle);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialHemisphere_Equator ()
        {
            double   declination = double.Pi / 3.0;
            Location location    = new Location (0.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual ( double.Pi / 6.0,        actual.RiseAzimuth, 1.0e-15);
            Assert.AreEqual (-double.Pi *  5.0 / 6.0, actual.RiseHourAngle);
            Assert.AreEqual ( double.Pi * 11.0 / 6.0, actual.DeclineAzimuth, 1.0e-15);
            Assert.AreEqual ( double.Pi *  5.0 / 6.0, actual.DeclineHourAngle);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_CelestialEquator_Equator ()
        {
            double   declination = 0.0;
            Location location    = new Location (0.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual ( MathConst.PI_DIV_2,       actual.RiseAzimuth);
            Assert.AreEqual (-MathConst.PI_DIV_2,       actual.RiseHourAngle);
            Assert.AreEqual ( MathConst.PI_DIV_2 * 3.0, actual.DeclineAzimuth);
            Assert.AreEqual ( MathConst.PI_DIV_2,       actual.DeclineHourAngle);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_SouthCelestialHemisphere_Equator ()
        {
            double   declination = -double.Pi / 3.0;
            Location location    = new Location (0.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual ( double.Pi * 5.0 / 6.0, actual.RiseAzimuth, 1.0e-15);
            Assert.AreEqual (-double.Pi / 6.0,       actual.RiseHourAngle, 1.0e-15);
            Assert.AreEqual ( double.Pi * 7.0 / 6.0, actual.DeclineAzimuth, 1.0e-15);
            Assert.AreEqual ( double.Pi / 6.0,       actual.DeclineHourAngle, 1.0e-15);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_SouthCelestialPole_Equator ()
        {
            double   declination = -MathConst.PI_DIV_2;
            Location location    = new Location (0.0);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
            Assert.AreEqual (double.Pi, actual.RiseAzimuth);
            Assert.AreEqual (0.0,       actual.RiseHourAngle);
            Assert.AreEqual (double.Pi, actual.DeclineAzimuth);
            Assert.AreEqual (0.0,       actual.DeclineHourAngle);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialPole_SouthPole ()
        {
            double   declination = MathConst.PI_DIV_2;
            Location location    = new Location (-MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoRising);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_NorthCelestialHemisphere_SouthPole ()
        {
            double   declination = double.Pi / 3.0;
            Location location    = new Location (-MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoRising);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_CelestialEquator_SouthPole ()
        {
            double   declination = 0.0;
            Location location    = new Location (-MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.Usual);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_SouthCelestialHemisphere_SouthPole ()
        {
            double   declination = -double.Pi / 3.0;
            Location location    = new Location (-MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoDeclining);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }

        [TestMethod ()]
        public void RiseAzimuthTest_SouthCelestialPole_SouthPole ()
        {
            double   declination = -MathConst.PI_DIV_2;
            Location location    = new Location (-MathConst.PI_DIV_2);

            RiseParams expected = new RiseParams (ECircumpolar.NoDeclining);

            RiseParams actual = CelestialSphere.RiseAzimuth (declination, location);

            Assert.AreEqual (expected.Circumpolar, actual.Circumpolar);
        }
    }
}