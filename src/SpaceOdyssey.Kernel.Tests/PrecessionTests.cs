using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class PrecessionTests
    {
        [TestMethod ()]
        public void GetVernalEquinoxPrecessionTest ()
        {
            double T0 = 0.02;
            double dT = 0.23;

            double expected = 3.05151773961781482;

            double actual = Precession.GetVernalEquinoxPrecession (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void GetPrecessionNutationTest ()
        {
            double T0 = 0.02;
            double dT = 0.23;

            double expected = 5.240165842335575e-5;

            double actual = Precession.GetPrecessionNutation (T0, dT);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetLongitudePrecessionTest ()
        {
            double T0 = 0.02;
            double dT = 0.23;

            double expected = 0.0056081366477320803;

            double actual = Precession.GetLongitudePrecession (T0, dT);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetEulerAnglesForPrecessionTest ()
        {
            double T0 = 0.00;
            double dT = 0.25012310959008350;

            (double alpha, double beta, double gamma) actual = Precession.GetEulerAnglesForPrecession (T0, dT);
            Archimedes.UnitPolar3 x = Archimedes.Rotation3.RotateSpaceByEulerAngles (new Archimedes.UnitPolar3 (0.070670320667974843, 2.10209879178602602), actual.Item1, actual.Item2, actual.Item3);

            Assert.AreEqual (1, 1);
        }
    }
}//0.070623797473839081 2.0959976871211907