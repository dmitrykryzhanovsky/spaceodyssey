using Microsoft.VisualStudio.TestTools.UnitTesting;

using SpaceOdyssey.Cosmodynamics;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class CircularOrbitTests
    {
        [TestMethod ()]
        public void SetOrbitalElementsBySemiMajorAxisTest_Common ()
        {
            CircularOrbit orbit = new CircularOrbit (SolarSystem.Sun);
            double semiMajorAxis = 0.999999022929777;

            orbit.SetOrbitalElementsBySemiMajorAxis (semiMajorAxis);

            Assert.AreEqual (0.0, orbit.Eccentricity);
            Assert.AreEqual (1.0, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis);
            Assert.AreEqual (0.999999022929777, orbit.OrbitalParameter);
            Assert.AreEqual (0.999999022929777, orbit.B);
            Assert.AreEqual (0.999999022929777, orbit.Periapsis);
            Assert.AreEqual (0.999999022929777, orbit.Apoapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByMeanMotionTest ()
        {
            CircularOrbit orbit = new CircularOrbit (SolarSystem.Sun);
            double meanMotion = 0.0172021241615188;

            orbit.SetOrbitalElementsByMeanMotion (meanMotion);

            Assert.AreEqual (0.0, orbit.Eccentricity);
            Assert.AreEqual (1.0, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.B, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.Periapsis, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.Apoapsis, 1.0e-15);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByOrbitalPeriodTest ()
        {
            CircularOrbit orbit = new CircularOrbit (SolarSystem.Sun);
            double orbitalPeriod = 365.256363004;

            orbit.SetOrbitalElementsByOrbitalPeriod (orbitalPeriod);

            Assert.AreEqual (0.0, orbit.Eccentricity);
            Assert.AreEqual (1.0, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.B, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.Periapsis, 1.0e-15);
            Assert.AreEqual (0.999999022929777, orbit.Apoapsis, 1.0e-15);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod);
        }
    }
}