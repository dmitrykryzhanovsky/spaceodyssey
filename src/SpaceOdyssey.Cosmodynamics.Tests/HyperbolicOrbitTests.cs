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

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);
            orbit.SetPeriapsisTimeInJD (t0);

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

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.6;
            double rp       = 2.0;            

            double trueAnomaly = double.Pi * (2.0 / 3.0);
            double expected    = 26.0;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-13);
        }

        [TestMethod ()]
        public void TrueAnomalyTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.6;
            double rp       = 2.0;

            double r        = 26.0;
            double expected = double.Pi * 2.0 / 3.0;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Boundary_Asymptote ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.6;
            double rp       = 2.0;

            double r        = double.PositiveInfinity;
            double expected = 2.24592785973192827;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Boundary_REqualsRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.6;
            double rp       = 2.0;

            double r        = 2.0;
            double expected = 0.0;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Exception_RLessRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.6;
            double rp       = 2.0;
            double r        = 1.999999999999;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

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

        [TestMethod ()]
        public void SpeedForRadiusTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.5;
            double rp       = 2.0;

            double r        = 5.0;
            double expected = 2.08285741230646895e-5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

            double actual = orbit.SpeedForRadius (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void SpeedForTrueAnomalyTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.5;
            double rp       = 2.0;

            double trueAnomaly = double.Pi / 6.0;
            double expected    = 2.79398693831719394e-5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);

            double actual = orbit.SpeedForTrueAnomaly (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ComputePositionTest ()
        {
            Mass   center   = Mass.CreateBySqrtGM (Astrodata.Sun.GaussianSqrtGM);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 1.5;
            double rp       = 2.0;
            double t0       = 2460670.5;
            double t        = 2461016.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center, orbiting, e, rp);
            orbit.SetPeriapsisTimeInJD (t0);

            OrbitalPosition position = orbit.ComputePosition (t);

            Assert.AreEqual (2461016.5, position.T);
            Assert.AreEqual (0.743990779587500, position.M, 1.0e-15);
            Assert.AreEqual (0.985551848876987, position.E, 1.0e-15);
            Assert.AreEqual (-0.105046482990337, position.Planar.Coordinates.X, 1.0e-15);
            Assert.AreEqual (5.15649984964034, position.Planar.Coordinates.Y, 1.0e-14);
            Assert.AreEqual (5.15756972448551, position.Planar.Coordinates.R, 1.0e-14);
            Assert.AreEqual (1.59116517350791, position.Planar.Coordinates.TrueAnomaly, 1.0e-14);
            Assert.AreEqual (-0.00769141670008985, position.Planar.Velocity.VX, 1.0e-17);
            Assert.AreEqual (0.0113828318247143, position.Planar.Velocity.VY, 1.0e-16);
            Assert.AreEqual (0.0137377855276661, position.Planar.Velocity.Speed, 1.0e-16);
        }
    }
}