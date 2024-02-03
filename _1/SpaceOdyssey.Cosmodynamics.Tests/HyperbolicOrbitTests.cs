using Microsoft.VisualStudio.TestTools.UnitTesting;

using SpaceOdyssey.Cosmodynamics;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class HyperbolicOrbitTests
    {
        [TestMethod ()]
        public void SetOrbitalElementsByMeanMotionTest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (SolarSystem.Sun);
            double eccentricity = 1.000001;
            double meanMotion = 0.0172021241615188;

            orbit.SetOrbitalElementsByMeanMotion (eccentricity, meanMotion);

            Assert.AreEqual (1.000001, orbit.Eccentricity);
            Assert.AreEqual (3.14017844061667541, orbit.Asymptote, 1.0e-13);

            Assert.AreEqual (-0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.00000199999904586, orbit.OrbitalParameter, 1.0e-16);
            Assert.AreEqual (0.00000099999902293, orbit.Periapsis, 1.0e-16);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByPeriapsisTest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (SolarSystem.Sun);
            double eccentricity = 1.5;
            double periapsis = 0.4999995114648885;

            orbit.SetOrbitalElementsByPeriapsis (eccentricity, periapsis);

            Assert.AreEqual (1.5, orbit.Eccentricity);
            Assert.AreEqual (2.3005239830218630, orbit.Asymptote);

            Assert.AreEqual (-0.999999022929777, orbit.SemiMajorAxis);
            Assert.AreEqual (1.249998778662221, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.4999995114648885, orbit.Periapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByPeriapsisAndMeanMotionTest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (SolarSystem.Sun);
            double periapsis = 0.618;
            double meanMotion = 0.0172021241615188;

            orbit.SetOrbitalElementsByPeriapsisAndMeanMotion (periapsis, meanMotion);

            Assert.AreEqual (1.6180006038299878, orbit.Eccentricity, 1.0e-15);
            Assert.AreEqual (2.2370519803988667, orbit.Asymptote);

            Assert.AreEqual (-0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (1.6179243731669324604, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.618, orbit.Periapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion);
        }

        [TestMethod ()]
        public void ComputePlanarPositionTest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (SolarSystem.Sun);

            orbit.SetOrbitalElementsByMeanMotion (eccentricity: 1.25, meanMotion: 0.0172021241615188);
            orbit.SetPeripasisJD (periapsisJD: 120.0);

            double t = 60.0;

            PlanarPosition planarPosition = orbit.ComputePlanarPosition (t);

            Assert.AreEqual (0.926161658156436, planarPosition.Radius, 1.0e-14);
            Assert.AreEqual (1.521811525682540, planarPosition.TrueAnomaly, 1.0e-15);
            Assert.AreEqual (0.045349703360920, planarPosition.X, 1.0e-14);
            Assert.AreEqual (0.925050712903977, planarPosition.Y, 1.0e-14);
            Assert.AreEqual (0.018522828806656, planarPosition.Speed, 1.0e-15);
            Assert.AreEqual (-0.017744949176174, planarPosition.Velocity.X, 1.0e-15);
            Assert.AreEqual (0.005311493738648, planarPosition.Velocity.Y, 1.0e-15);
        }
    }
}