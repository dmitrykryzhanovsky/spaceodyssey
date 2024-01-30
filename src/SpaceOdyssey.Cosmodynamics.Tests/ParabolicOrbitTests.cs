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
        public void ComputePlanarPositionTest_Pericenter ()
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
            Assert.AreEqual (0.0, planarPosition.Velocity.X, 1.0e-15);
            Assert.AreEqual (0.027306643309548, planarPosition.Velocity.Y, 1.0e-15);
        }

        [TestMethod ()]
        public void ComputePlanarPositionTest_TrueAnomaly90 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsByMeanMotion (meanMotion: 0.0172021241615188);
            orbit.SetPeripasisJD (periapsisJD: 0.0);

            double t = 77.50980755713900379;

            PlanarPosition planarPosition = orbit.ComputePlanarPosition (t);

            Assert.AreEqual (1.587399500965898, planarPosition.Radius);
            Assert.AreEqual (1.5707963267948966, planarPosition.TrueAnomaly);
            Assert.AreEqual (0.0, planarPosition.X);
            Assert.AreEqual (1.587399500965898, planarPosition.Y);
            Assert.AreEqual (0.0193087126556239, planarPosition.Speed, 1.0e-16);
            Assert.AreEqual (-0.0136533216547742, planarPosition.Velocity.X, 1.0e-16);
            Assert.AreEqual (0.0136533216547742, planarPosition.Velocity.Y, 1.0e-16);
        }

        [TestMethod ()]
        public void ComputePlanarPositionTest_TrueAnomalyminus90 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsByMeanMotion (meanMotion: 0.0172021241615188);
            orbit.SetPeripasisJD (periapsisJD: 0.0);

            double t = -77.50980755713900379;

            PlanarPosition planarPosition = orbit.ComputePlanarPosition (t);

            Assert.AreEqual (1.587399500965898, planarPosition.Radius, 1.0e-15);
            Assert.AreEqual (-1.5707963267948966, planarPosition.TrueAnomaly, 1.0e-15);
            Assert.AreEqual (0.0, planarPosition.X, 1.0e-15);
            Assert.AreEqual (-1.587399500965898, planarPosition.Y, 1.0e-15);
            Assert.AreEqual (0.0193087126556239, planarPosition.Speed, 1.0e-16);
            Assert.AreEqual (0.0136533216547742, planarPosition.Velocity.X, 1.0e-16);
            Assert.AreEqual (0.0136533216547742, planarPosition.Velocity.Y, 1.0e-16);
        }
    }
}