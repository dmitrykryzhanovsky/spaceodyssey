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

            EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
            orbit.SetPeriapsisTimeInJD (t0);

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
            Assert.AreEqual (-0.765390322836009, orbit.M0, 1.0e-14);
        }

        [TestMethod ()]
        public void CreateByPeriapsisTest_Exception_ELess0 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = -0.27;
            double rp       =  1.38; 

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
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

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
            orbit.SetPeriapsisTimeInJD (t0);

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
            Assert.AreEqual (-0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Earth ()
        {
            Mass   center   = Mass.CreateByGM (Astrodata.Sun.GM_SI);
            Mass   orbiting = Mass.CreateByGM (Astrodata.Earth.GM_SI);
            double e        = 0.01671123;
            double a        = 149598261000.0;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            Assert.AreEqual (0.01671123, orbit.E);
            Assert.AreEqual (0.999723343057640, orbit.P / AstroConst.AU, 1.0e-15);
            Assert.AreEqual (1.00000261, orbit.A / AstroConst.AU, 1.0e-8);
            Assert.AreEqual (0.999862966275978, orbit.B / AstroConst.AU, 1.0e-15);
            Assert.AreEqual (0.98329134, orbit.RP / AstroConst.AU, 1.0e-8);
            Assert.AreEqual (1.01671388, orbit.RA / AstroConst.AU, 1.0e-8);
            Assert.AreEqual (1.03399048277547, orbit.RatioAP, 1.0e-14);
            Assert.AreEqual (1.01671123, orbit.RatioAMean, 1.0e-14);
            Assert.AreEqual (1.01699524138774, orbit.RatioMeanP, 1.0e-14);
            Assert.AreEqual (-8.87128217476016e+8, orbit.EnergyIntegral, 1.0e-6);
            Assert.AreEqual (-4.43564108738008e+8, orbit.W, 1.0e-6);
            Assert.AreEqual (0.985605291482164, orbit.N * 86400.0 * 180.0 / double.Pi, 1.0e-14);
            Assert.AreEqual (365.256363004, orbit.T / 86400.0, 2.0e-3);
            Assert.AreEqual (30287, orbit.VP, 1.0e+0);
            Assert.AreEqual (29291, orbit.VA, 1.0e+0);
            Assert.AreEqual (29783, orbit.VMean, 1.0e+0);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_Exception_ELess0 ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = -0.27;
            double a        =  1.38;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
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

            EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra);
            orbit.SetPeriapsisTimeInJD (t0);

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
            Assert.AreEqual (-0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateByApsidesTest_RaEqualsRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.89041095890411;
            double ra       = 1.89041095890411;
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra);
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
            Assert.AreEqual (1.87899121099980e-5, orbit.VP, 1.0e-19);
            Assert.AreEqual (1.87899121099980e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.87899121099980e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (-0.765390322836009, orbit.M0, 1.0e-13);
        }

        [TestMethod ()]
        public void CreateByApsidesTestTest_Exception_RpZero ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 0.0;
            double ra       = 2.40082191780822;

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra);
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

            bool argumentOutOfRangeException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateByApsides (center, orbiting, rp, ra);
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
            double e        = 0.27;
            double rp       = 1.38;
            double M0       = 0.765390322836009;

            EllipticOrbit orbit = EllipticOrbit.CreateByPeriapsis (center, orbiting, e, rp);
            orbit.SetMeanAnomalyForJ2000 (M0);

            Assert.AreEqual (2374540.79446364426, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0);
        }

        [TestMethod ()]
        public void SetMeanAnomalyForJ2000Test_Earth ()
        {
            Mass   center   = Mass.CreateByGM (Astrodata.Sun.GM_SI * 86400.0 * 86400.0);
            Mass   orbiting = Mass.CreateByGM (Astrodata.Earth.GM_SI * 86400.0 * 86400.0);
            double e        = 0.01671123;
            double a        = 149598261000.0;
            double M0       = -0.0433337328002166;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
            orbit.SetMeanAnomalyForJ2000 (M0);

            Assert.AreEqual (2451548, orbit.T0, 1.0e+0);
            Assert.AreEqual (-0.0433337328002166, orbit.M0);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.6;
            double a        = 2.0;

            double trueAnomaly = double.Pi * (2.0 / 3.0);
            double expected    = 1.8285714285714286;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void TrueAnomalyTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.6;
            double a        = 2.0;

            double r        = 1.82857142857142857;
            double expected = double.Pi * 2.0 / 3.0;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Boundary_REqualsRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.6;
            double a        = 2.0;

            double r        = 0.8;
            double expected = 0.0;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Boundary_REqualsRa ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.6;
            double a        = 2.0;

            double r        = 3.1999999999999999;
            double expected = double.Pi;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Exception_RLessRp ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.6;
            double a        = 2.0;
            double r        = 0.799999999999;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

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
        public void TrueAnomalyTest_Exception_RGreaterRa ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.6;
            double a        = 2.0;
            double r        = 3.200000000001;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

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
            double e        = 0.5;
            double a        = 4.0;

            double r        = 5.0;
            double expected = 1.00057233621562814e-5;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            double actual = orbit.SpeedForRadius (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void SpeedForTrueAnomalyTest ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.5;
            double a        = 4.0;

            double trueAnomaly = double.Pi / 6.0;
            double expected    = 2.16971490849823239e-5;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            double actual = orbit.SpeedForTrueAnomaly (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ComputePositionTest_E0 ()
        {
            Mass   center   = Mass.CreateBySqrtGM (Astrodata.Sun.SqrtGM_Gaussian);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.0;
            double a        = 2.0;
            double t0       = 2460670.5;
            double t        = 2461016.5;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
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

        [TestMethod ()]
        public void ComputePositionTest_E05 ()
        {
            Mass   center   = Mass.CreateBySqrtGM (Astrodata.Sun.SqrtGM_Gaussian);
            Mass   orbiting = Mass.ZeroMass;
            double e        = 0.5;
            double a        = 2.0;
            double t0       = 2460670.5;
            double t        = 2461016.5;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);
            orbit.SetPeriapsisTimeInJD (t0);

            OrbitalPosition position = orbit.ComputePosition (t);

            Assert.AreEqual (2461016.5, position.T);
            Assert.AreEqual (2.10432370154635, position.M, 1.0e-14);
            Assert.AreEqual (2.43061219975285, position.E, 1.0e-14);
            Assert.AreEqual (-2.51544483733668, position.Planar.Coordinates.X, 1.0e-14);
            Assert.AreEqual (1.13029651363800, position.Planar.Coordinates.Y, 1.0e-14);
            Assert.AreEqual (2.75772241866834, position.Planar.Coordinates.R, 1.0e-14);
            Assert.AreEqual (2.71928555953323, position.Planar.Coordinates.TrueAnomaly, 1.0e-14);
            Assert.AreEqual (-0.00575675372039197, position.Planar.Velocity.VX, 1.0e-17);
            Assert.AreEqual (-0.00578877484809761, position.Planar.Velocity.VY, 1.0e-17);
            Assert.AreEqual (0.00816395294200146, position.Planar.Velocity.Speed, 1.0e-17);
        }
    }
}