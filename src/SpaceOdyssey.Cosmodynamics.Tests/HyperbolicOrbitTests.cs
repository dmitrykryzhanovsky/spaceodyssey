using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class HyperbolicOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;            
            double e        = 1.73;
            double rp       = 1.38;
            double t0       = 0.42;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);

            Assert.AreEqual (1.73, orbit.E);
            Assert.AreEqual (3.7674, orbit.P);
            Assert.AreEqual (-1.89041095890411, orbit.A, 1.0e-15);                        
            Assert.AreEqual (1.38, orbit.RP);
            Assert.AreEqual (double.PositiveInfinity, orbit.RInfinity);
            Assert.AreEqual (2.18711451530721, orbit.Asymptote, 1.0e-14);
            Assert.AreEqual (3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (1.76530398550725e-10, orbit.W, 1.0e-24);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (3.63366296204521e-5, orbit.VP, 1.0e-19);
            Assert.AreEqual (1.8789912109998e-5, orbit.VInfinity, 1.0e-19);            
            Assert.AreEqual (0.42, orbit.T0);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_E1 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;            
            double e        = 1.0;
            double rp       = 1.38;
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_ELess1 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.73;
            double rp       = 1.38;            
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_RpZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.73;
            double rp       = 0.0;            
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
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
            double e        =  0.73;
            double rp       = -1.38;            
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }
    }
}