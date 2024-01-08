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
            Assert.Fail ();
        }
    }
}