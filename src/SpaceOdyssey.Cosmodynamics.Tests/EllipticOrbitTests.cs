using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.27;
            double rp       = 1.38;            
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);

            Assert.AreEqual (0.27, orbit.E);
            Assert.AreEqual (1.7526, orbit.P);
            Assert.AreEqual (1.89041095890411, orbit.A, 1.0e-15);
            Assert.AreEqual (1.82020170491496, orbit.B, 1.0e-14);
            Assert.AreEqual (1.38, orbit.RP);
            Assert.AreEqual (2.40082191780822, orbit.RA, 1.0e-15);
            Assert.AreEqual (1.73972602739726, orbit.RatioAP, 1.0e-14);
            Assert.AreEqual (1.27, orbit.RatioAMean);
            Assert.AreEqual (1.36986301369863, orbit.RatioMeanP);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (-1.76530398550725e-10, orbit.W, 1.0e-24);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T, 1.0e-9);
            Assert.AreEqual (2.4783644969435e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.42457171871557e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.84426370289652e-5, orbit.VMean, 1.0e-19);            
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0, 1.0e-14);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_ELess0 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = -0.27;
            double rp       =  1.38;            
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
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
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_EGreater1 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.27;
            double rp       = 1.38;            
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
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
            double e        = 0.27;
            double rp       = 0.0;            
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_RpNegative()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        =  0.27;
            double rp       = -1.38;            
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.27;
            double a        = 1.89041095890411;
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a, t0);

            Assert.AreEqual (0.27, orbit.E);
            Assert.AreEqual (1.7526, orbit.P, 1.0e-15);
            Assert.AreEqual (1.89041095890411, orbit.A);
            Assert.AreEqual (1.82020170491496, orbit.B, 1.0e-14);
            Assert.AreEqual (1.38, orbit.RP, 1.0e-15);
            Assert.AreEqual (2.40082191780822, orbit.RA, 1.0e-15);
            Assert.AreEqual (1.73972602739726, orbit.RatioAP, 1.0e-14);
            Assert.AreEqual (1.27, orbit.RatioAMean);
            Assert.AreEqual (1.36986301369863, orbit.RatioMeanP);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (-1.76530398550725e-10, orbit.W, 1.0e-24);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T, 1.0e-9);
            Assert.AreEqual (2.4783644969435e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.42457171871557e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.84426370289652e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_ELess0 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = -0.27;
            double a        =  1.38;
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_E1 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.0;
            double a        = 1.38;
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_EGreater1 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.27;
            double a        = 1.38;
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_AZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.27;
            double a        = 0.0;
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_ANegative ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        =  0.27;
            double a        = -1.38;
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByApsidesTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.38;
            double ra       = 2.40082191780822;
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra, t0);

            Assert.AreEqual (0.27, orbit.E, 1.0e-15);
            Assert.AreEqual (1.7526, orbit.P, 1.0e-15);
            Assert.AreEqual (1.89041095890411, orbit.A);
            Assert.AreEqual (1.82020170491496, orbit.B, 1.0e-14);
            Assert.AreEqual (1.38, orbit.RP);
            Assert.AreEqual (2.40082191780822, orbit.RA);
            Assert.AreEqual (1.73972602739726, orbit.RatioAP, 1.0e-14);
            Assert.AreEqual (1.27, orbit.RatioAMean, 1.0e-15);
            Assert.AreEqual (1.36986301369863, orbit.RatioMeanP, 1.0e-15);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (-1.76530398550725e-10, orbit.W, 1.0e-24);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T, 1.0e-9);
            Assert.AreEqual (2.4783644969435e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.42457171871557e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.84426370289652e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateByApsidesTest_RaEqualsRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.89041095890411;
            double ra       = 1.89041095890411;
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra, t0);

            Assert.AreEqual (0.0, orbit.E);
            Assert.AreEqual (1.89041095890411, orbit.P);
            Assert.AreEqual (1.89041095890411, orbit.A);
            Assert.AreEqual (1.89041095890411, orbit.B);
            Assert.AreEqual (1.89041095890411, orbit.RP);
            Assert.AreEqual (1.89041095890411, orbit.RA);
            Assert.AreEqual (1.0, orbit.RatioAP);
            Assert.AreEqual (1.0, orbit.RatioAMean);
            Assert.AreEqual (1.0, orbit.RatioMeanP);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (-1.76530398550725e-10, orbit.W, 1.0e-24);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T, 1.0e-9);
            Assert.AreEqual (1.87899121099980e-5, orbit.VP, 1.0e-19);
            Assert.AreEqual (1.87899121099980e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.87899121099980e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateByApsidesTestTest_Exception_RpZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 0.0;
            double ra       = 2.40082191780822;
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByApsidesTestTest_Exception_RpNegative ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = -1.38;
            double ra       =  2.40082191780822;
            double t0       =  0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByApsidesTestTest_Exception_RaLessRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.38;
            double ra       = 1.379999999999;
            double t0       = 0.42;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra, t0);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }
    }
}