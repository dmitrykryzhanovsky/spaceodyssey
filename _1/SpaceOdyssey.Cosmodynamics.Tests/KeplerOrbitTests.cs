using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class KeplerOrbitTests
    {
        [TestMethod ()]
        public void RadiusTest_Circle ()
        {
            CircularOrbit orbit = new CircularOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsBySemiMajorAxis (semiMajorAxis: 2.0);

            double trueAnomaly = 42.0;

            double expected = 2.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Ellipse ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsBySemiMajorAxis (semiMajorAxis: 2.0, eccentricity: 0.5);

            double trueAnomaly = double.Pi;

            double expected = 3.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Parabola ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsByPeriapsis (periapsis: 2.0);

            double trueAnomaly = double.Pi / 2.0;

            double expected = 4.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Hyperbola ()
        {
            // TODO: Нужно поменять местами аргументы в SetOrbitalElementsByPeriapsis
            HyperbolicOrbit orbit = new HyperbolicOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsByPeriapsis (periapsis: 2.0, eccentricity: 0.5);

            double trueAnomaly = 0.0;

            double expected = 2.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }
    }
}