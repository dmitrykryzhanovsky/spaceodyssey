using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class ParabolicOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   central = Data.SunSI;
            Mass   probe   = Data.EarthSI;
            double rp      = 74799130500.0;

            ParabolicOrbit actual = ParabolicOrbit.CreateByPeriapsis (central, probe, rp);

            Assert.AreEqual (149598261000.0, actual.P);
            Assert.AreEqual (1.0, actual.E);
            Assert.AreEqual (74799130500.0, actual.RPeri);

            Assert.AreEqual (double.Pi, actual.Asymptote);

            Assert.AreEqual (59569.395413283, actual.VPeri, 1.0e-9);

            Assert.AreEqual (0.0, actual.EnergyIntegral);
            Assert.AreEqual (4.45573898132426e+15, actual.ArealVelocity, 1.0e+1);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0);

            double trueAnomaly = double.Pi * (2.0 / 3.0);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (8.0, actual, 1.0e-14);
        }
    }
}