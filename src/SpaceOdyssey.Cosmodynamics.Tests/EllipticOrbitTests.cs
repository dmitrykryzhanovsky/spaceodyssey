using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_E0 ()
        {
            Mass   central = Data.SunSI;
            Mass   probe   = Data.ProbeZeroMass;
            double a       = 149598261000.0;
            double e       = 0.0;

            EllipticOrbit actual = EllipticOrbit.CreateBySemiMajorAxis (central, probe, a, e);

            Assert.AreEqual (149598261000.0, actual.A);
            Assert.AreEqual (149598261000.0, actual.P);
            Assert.AreEqual (0.0, actual.E);
            Assert.AreEqual (149598261000.0, actual.RPeri);
            Assert.AreEqual (149598261000.0, actual.RApo);

            Assert.AreEqual (1.0, actual.RangeARp);
            Assert.AreEqual (1.0, actual.RangeRaA);
            Assert.AreEqual (1.0, actual.RangeRaRp);

            Assert.AreEqual (1.99097588291661e-7, actual.N);
            Assert.AreEqual (3.15583195210545e+7, actual.T);
            Assert.AreEqual (29784.6529777264, actual.VMean);
            Assert.AreEqual (29784.6529777264, actual.VPeri);            
            Assert.AreEqual (29784.6529777264, actual.VApo);

            Assert.AreEqual (-8.87125553003587e+8, actual.EnergyIntegral);
            Assert.AreEqual ( 4.45573228995634e+15, actual.ArealVelocity);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_EEarth ()
        {
            Assert.Fail ();
        }
    }
}