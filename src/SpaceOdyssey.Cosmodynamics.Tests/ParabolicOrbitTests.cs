using Microsoft.VisualStudio.TestTools.UnitTesting;

using SpaceOdyssey.Cosmodynamics;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class ParabolicOrbitTests
    {
        [TestMethod ()]
        public void SetOrbitalElementsByMeanMotionTest ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (SolarSystem.Sun);
            double meanMotion = 0.0172021241615188;

            orbit.SetOrbitalElementsByMeanMotion (meanMotion);

            Assert.AreEqual (1.0, orbit.Eccentricity);

            Assert.AreEqual (1.5873995009658983, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.7936997504829491, orbit.Periapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByPeriapsisTest ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (SolarSystem.Sun);
            double periapsis = 0.7936997504829491;

            orbit.SetOrbitalElementsByPeriapsis (periapsis);

            Assert.AreEqual (1.0, orbit.Eccentricity);

            Assert.AreEqual (1.5873995009658983, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.7936997504829491, orbit.Periapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
        }

        [TestMethod ()]
        public void ComputePlanarPositionTest ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsByMeanMotion (meanMotion: 0.0172021241615188);
            orbit.SetPeripasisJD (periapsisJD: 0.0);

            double t = 0.0;

            PlanarPosition planarPosition = orbit.ComputePlanarPosition (t);

            Assert.AreEqual (0.793699750482949, planarPosition.Radius);
            Assert.AreEqual (0.0, planarPosition.TrueAnomaly);
            Assert.AreEqual (0.793699750482949, planarPosition.X);
            Assert.AreEqual (0.0, planarPosition.Y);
            Assert.AreEqual (0.027306643309548, planarPosition.Speed, 1.0e-15);
            Assert.AreEqual (0.0, planarPosition.Velocity.X);
            Assert.AreEqual (0.027306643309548, planarPosition.Velocity.Y);
        }
    }
}