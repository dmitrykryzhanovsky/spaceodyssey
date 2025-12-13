using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class CircularOrbitTests
    {
        [TestMethod ()]
        public void CreateBySemiMajorAxisTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double a        = 1.89041095890411;
            double t0       = 0.42;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center, orbiting, a);
            orbit.SetPeriapsisTimeInJD (t0);

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
            Assert.AreEqual (1.87899121099980e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.87899121099980e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.87899121099980e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (-0.765390322836009, orbit.M0, 1.0e-13);
        }
       
        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_AZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double a        = 0.0;

            bool argumentOutOfRangeException = false;

            try
            {
                CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center, orbiting, a);
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
            double a        = -1.38;

            bool argumentOutOfRangeException = false;

            try
            {
                CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center, orbiting, a);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByOrbitingPeriodTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double T        = 6.32137196384089e+5;
            double t0       = 0.42;

            CircularOrbit orbit = CircularOrbit.CreateByOrbitingPeriod (center, orbiting, T);
            orbit.SetPeriapsisTimeInJD (t0);

            Assert.AreEqual (0.0, orbit.E);
            Assert.AreEqual (1.89041095890411, orbit.P, 1.0e-14);
            Assert.AreEqual (1.89041095890411, orbit.A, 1.0e-14);
            Assert.AreEqual (1.89041095890411, orbit.B, 1.0e-14);
            Assert.AreEqual (1.89041095890411, orbit.RP, 1.0e-14);
            Assert.AreEqual (1.89041095890411, orbit.RA, 1.0e-14);
            Assert.AreEqual (1.0, orbit.RatioAP);
            Assert.AreEqual (1.0, orbit.RatioAMean);
            Assert.AreEqual (1.0, orbit.RatioMeanP);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (-1.76530398550725e-10, orbit.W, 1.0e-24);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T);
            Assert.AreEqual (1.87899121099980e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.87899121099980e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.87899121099980e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (-0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateByOrbitingPeriodTest_Exception_TZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double T        = 0.0;

            bool argumentOutOfRangeException = false;

            try
            {
                CircularOrbit orbit = CircularOrbit.CreateByOrbitingPeriod (center, orbiting, T);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void CreateByOrbitingPeriodTest_Exception_TNegative ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double T        = -1.38;

            bool argumentOutOfRangeException = false;

            try
            {
                CircularOrbit orbit = CircularOrbit.CreateByOrbitingPeriod (center, orbiting, T);
            }

            catch (ArgumentOutOfRangeException)
            {
                argumentOutOfRangeException = true;
            }

            Assert.IsTrue (argumentOutOfRangeException);
        }

        [TestMethod ()]
        public void SetMeanAnomalyForJ2000Test ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double a        = 1.89041095890411;
            double M0       = 0.765390322836009;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center, orbiting, a);
            orbit.SetMeanAnomalyForJ2000 (M0);

            Assert.AreEqual (2374540.79446364426, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0);
        }

        [TestMethod ()]
        public void ComputePositionTest ()
        {
            Mass   center   = Mass.CreateBySqrtGM (Astrodata.Sun.GaussianSqrtGM);
            Mass   orbiting = Mass.ZeroMass;
            double a        = 2.0;
            double t0       = 2460670.5;
            double t        = 2461016.5;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center, orbiting, a);
            orbit.SetPeriapsisTimeInJD (t0);

            OrbitalPosition position = orbit.ComputePosition (t);

            Assert.AreEqual (2461016.5, position.T);
            Assert.AreEqual (2.10432370154635, position.M, 1.0e-14);
            Assert.AreEqual (2.10432370154635, position.E, 1.0e-14);
            Assert.AreEqual (-1.01714726751128, position.Planar.Coordinates.X, 1.0e-14);
            Assert.AreEqual (1.72203700198177, position.Planar.Coordinates.Y, 1.0e-14);
            Assert.AreEqual (2.0, position.Planar.Coordinates.R);
            Assert.AreEqual (2.10432370154635, position.Planar.Coordinates.TrueAnomaly, 1.0e-14);
            Assert.AreEqual (-0.010473188665347, position.Planar.Velocity.VX, 1.0e-16);
            Assert.AreEqual (-0.00618614769649445, position.Planar.Velocity.VY, 1.0e-17);
            Assert.AreEqual (0.012163720818187, position.Planar.Velocity.Speed, 1.0e-16);
        }
    }
}