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
    }
}