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
    }
}