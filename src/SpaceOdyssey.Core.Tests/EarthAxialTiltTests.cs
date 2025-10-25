using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EarthAxialTiltTests
    {
        [TestMethod ()]
        public void ComputeDEInArcsec200Test ()
        {
            double T = 5;

            double expected = 84147.584875;

            double actual = EarthAxialTilt.ComputeDE200InArcsec (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void ComputeP03InArcsecTest ()
        {
            double T = 5;

            double expected = 84147.467506875;

            double actual = EarthAxialTilt.ComputeP03InArcsec (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void ComputeLaskarInArcsecTest ()
        {
            double T = 5;

            double expected = 84147.6471314996315;

            double actual = EarthAxialTilt.ComputeLaskarInArcsec (T);

            Assert.AreEqual (expected, actual);
        }
    }
}