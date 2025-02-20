using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.CelestialSphere.Tests
{
    [TestClass ()]
    public class SunPositionTests
    {
        [TestMethod ()]
        public void ComputeApproximateInEclipticTest_RunCalculations ()
        {
            double T = 0.01;

            UnitPolar3 actual = SunPosition.ComputeApproximateInEcliptic (T);

            Assert.AreEqual (0.0, actual.Latitude);
            Assert.AreEqual (4.89375050049672, actual.Longitude, 1.0e-14);
        }

        [TestMethod ()]
        public void ComputeApproximateInEclipticTest_Stellarium ()
        {
            double T = 0.25134150171115674;

            UnitPolar3 actual = SunPosition.ComputeApproximateInEcliptic (T);

            Assert.AreEqual (0.0, actual.Latitude);
            Assert.AreEqual (5.75918074253019892, actual.Longitude, 1.0e-2);
        }
    }
}