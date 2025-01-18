using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EarthAxialTiltTests
    {
        [TestMethod ()]
        public void ComputeDE200Test ()
        {
            double T = 5;

            double expected = 84147.584875;

            double actual = EarthAxialTilt.ComputeDE200 (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void ComputeP03Test ()
        {
            double T = 5;

            double expected = 84147.467506875;

            double actual = EarthAxialTilt.ComputeP03 (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void ComputeLaskarTest ()
        {
            double T = 5;

            double expected = 84147.6471314996315;

            double actual = EarthAxialTilt.ComputeLaskar (T);

            Assert.AreEqual (expected, actual);
        }
    }
}