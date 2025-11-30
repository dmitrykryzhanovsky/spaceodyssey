using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class ParabolicOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.38;
            double t0       = 0.42;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);
            orbit.SetPeriapsisTime (t0);

            Assert.AreEqual (1.0, orbit.E);
            Assert.AreEqual (2.76, orbit.P);
            Assert.AreEqual (1.38, orbit.RP);
            Assert.AreEqual (double.PositiveInfinity, orbit.RInfinity);
            Assert.AreEqual (double.Pi, orbit.Asymptote);
            Assert.AreEqual (0.0, orbit.EnergyIntegral);
            Assert.AreEqual (0.0, orbit.W);
            Assert.AreEqual (1.1268581093156e-5, orbit.N, 1.0e-20);
            Assert.AreEqual (3.11012838171106e-5, orbit.VP, 1.0e-19);
            Assert.AreEqual (0.0, orbit.VInfinity);
            Assert.AreEqual (0.42, orbit.T0);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_RpZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 0.0;

            bool argumentOutOfRangeException = false;

            try
            {
                ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_RpNegative ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = -1.38;

            bool argumentOutOfRangeException = false;

            try
            {
                ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            Mass   center      = Mass.CreateByMass (10.0);
            Mass   orbiting    = Mass.ZeroMass;
            double rp          = 2.0;

            double trueAnomaly = double.Pi * (2.0 / 3.0);
            double expected    = 8.0;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void TrueAnomalyTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 2.0;

            double r        = 8.0 / 3.0;
            double expected = double.Pi / 3.0;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Asymptote ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 2.0;

            double r        = double.PositiveInfinity;
            double expected = double.Pi;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Exception_RLessRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 2.0;
            double r        = 1.999999999999;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);

            bool argumentOutOfRangeException = false;

            try
            {
                double actual = orbit.TrueAnomaly (r);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }
    }
}