using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.CelestialSphere.Tests
{
    [TestClass ()]
    public class MoonPositionTests
    {
        [TestMethod ()]
        public void ComputeApproximateInEclipticTest_RunCalculations ()
        {
            double T = 0.01;

            UnitPolar3 actual = MoonPosition.ComputeApproximateInEcliptic (T);

            Assert.AreEqual (-0.0803173109493475, actual.Latitude);
            Assert.AreEqual ( 6.03286365497341, actual.Longitude, 1.0e-14);
        }

        [TestMethod ()]
        public void ComputeApproximateInEclipticTest_Stellarium ()
        {
            double JD = 2460727.22131;

            UnitPolar3 actual = MoonPosition.ComputeApproximateInEcliptic (Time.GetJulianCentirues (JD));

            Assert.AreEqual (-0.08833159825711412942410157970731, actual.Latitude, 1.0e-2);
            Assert.AreEqual ( 4.2287291558361945597687949681249, actual.Longitude, 1.0e-2);
        }
    }
}