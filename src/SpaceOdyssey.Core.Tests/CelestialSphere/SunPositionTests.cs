using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.CelestialSphere.Tests
{
    [TestClass ()]
    public class SunPositionTests
    {
        [TestMethod ()]
        public void ComputeApproximateInEclipticTest ()
        {
            double T = 0.25134150171115674;

            UnitPolar3 actual = SunPosition.ComputeApproximateInEcliptic (T);

            Assert.AreEqual (0.0, actual.Latitude);
            Assert.AreEqual (5.75918074253019892, actual.Longitude, 1.0e-2);
        }
    }
}