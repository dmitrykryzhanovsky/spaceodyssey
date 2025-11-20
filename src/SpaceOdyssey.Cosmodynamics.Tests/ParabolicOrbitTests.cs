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

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp, t0);

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
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp, t0);
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
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }
    }
}