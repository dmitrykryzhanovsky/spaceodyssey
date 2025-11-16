using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        [TestMethod ()]
        public void CreateByRPeriapsisTest_Arbitrary ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double rp       = 1.38;
            double e        = 0.27;
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateByRPeriapsis (center, orbiting, rp, e, t0);

            Assert.AreEqual (1.89041095890411, orbit.A, 1.0e-15);
            Assert.AreEqual (1.7526, orbit.P);
            Assert.AreEqual (0.27, orbit.E);
            Assert.AreEqual (1.82020170491496, orbit.B, 1.0e-14);
            Assert.AreEqual (1.38, orbit.RP);
            Assert.AreEqual (2.40082191780822, orbit.RA, 1.0e-15);
            Assert.AreEqual (1.73972602739726, orbit.RatioAP, 1.0e-14);
            Assert.AreEqual (1.27, orbit.RatioAMean);
            Assert.AreEqual (1.36986301369863, orbit.RatioMeanP);            
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T, 1.0e-9);
            Assert.AreEqual (2.4783644969435e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.42457171871557e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.84426370289652e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0, 1.0e-14);
        }

        [TestMethod ()]
        public void CreateBySemiMajorTest_Arbitrary ()
        {
            Mass   center   = Mass.CreateByMass (10.0);
            Mass   orbiting = Mass.ZeroMass;
            double a        = 1.89041095890411;
            double e        = 0.27;
            double t0       = 0.42;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajor (center, orbiting, a, e, t0);

            Assert.AreEqual (1.89041095890411, orbit.A, 1.0e-15);
            Assert.AreEqual (1.7526, orbit.P, 1.0e-15);
            Assert.AreEqual (0.27, orbit.E);
            Assert.AreEqual (1.82020170491496, orbit.B, 1.0e-14);
            Assert.AreEqual (1.38, orbit.RP, 1.0e-15);
            Assert.AreEqual (2.40082191780822, orbit.RA, 1.0e-15);
            Assert.AreEqual (1.73972602739726, orbit.RatioAP, 1.0e-14);
            Assert.AreEqual (1.27, orbit.RatioAMean);
            Assert.AreEqual (1.36986301369863, orbit.RatioMeanP);
            Assert.AreEqual (9.93959118862213e-6, orbit.N, 1.0e-20);
            Assert.AreEqual (6.32137196384089e+5, orbit.T, 1.0e-9);
            Assert.AreEqual (2.4783644969435e-5, orbit.VP, 1.0e-18);
            Assert.AreEqual (1.42457171871557e-5, orbit.VA, 1.0e-19);
            Assert.AreEqual (1.84426370289652e-5, orbit.VMean, 1.0e-19);
            Assert.AreEqual (-3.53060797101449e-10, orbit.EnergyIntegral, 1.0e-24);
            Assert.AreEqual (0.42, orbit.T0);
            Assert.AreEqual (0.765390322836009, orbit.M0, 1.0e-13);
        }

        //TODO: тесты на исключение
        //TODO: проверить на приммере Марса
        //TODO: опция с M0
        //++TODO: круговые орбиты
        //++TODO: другие опции инициализации: rmax, rmin, T
    }
}