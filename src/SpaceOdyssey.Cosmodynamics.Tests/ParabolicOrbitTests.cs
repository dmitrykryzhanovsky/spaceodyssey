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
        public void TrueAnomalyTest_Boundary_Asymptote ()
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
        public void TrueAnomalyTest_Boundary_REqualsRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 2.0;

            double r        = 2.0;
            double expected = 0.0;

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

        [TestMethod ()]
        public void SpeedForRadiusTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 2.0;

            double r        = 4.0;
            double expected = 1.82678679653647596e-5;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);

            double actual = orbit.SpeedForRadius (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void SpeedForTrueAnomalyTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 2.0;

            double trueAnomaly = double.Pi / 6.0;
            double expected    = 2.49543717136682073e-5;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);

            double actual = orbit.SpeedForTrueAnomaly (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ComputePositionTest ()
        {
            Mass   center   = Mass.CreateBySqrtGM (Astrodata.Sun.GaussianSqrtGM);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.38;
            double t0       = 2460670.5;
            double t        = 2461016.5;

            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center, orbiting, rp);
            orbit.SetPeriapsisTime (t0);

            OrbitalPosition position = orbit.ComputePosition (t);

            Assert.AreEqual (2461016.5, position.T);
            Assert.AreEqual (2.59611491850979, position.M, 1.0e-14);
            Assert.AreEqual (1.49107559629711, position.E, 1.0e-14);
            Assert.AreEqual (-1.68816287874443, position.Planar.Coordinates.X, 1.0e-14);
            Assert.AreEqual (4.11536864578002, position.Planar.Coordinates.Y, 1.0e-14);
            Assert.AreEqual (4.44816287874443, position.Planar.Coordinates.R, 1.0e-14);
            Assert.AreEqual (1.96007280510973, position.Planar.Coordinates.TrueAnomaly, 1.0e-14);
            Assert.AreEqual (-0.00957976737907222, position.Planar.Velocity.VX, 1.0e-17);
            Assert.AreEqual (0.00642473621247797, position.Planar.Velocity.VY, 1.0e-17);
            Assert.AreEqual (0.0115346945532624, position.Planar.Velocity.Speed, 1.0e-16);
        }
    }
}