using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.CelestialSphere.Tests
{
    [TestClass ()]
    public class CelestialPositionTests
    {
        [TestMethod ()]
        public void GetHorizonalTest_Vega ()
        {
            double jd   = 2460729.71982;
            double gmst = SiderealTime.GMSTInRotation (jd);

            Location location = new Location (latitude: 0.8499753457212385, longitude: 0.77667151713747666);
            double   lmst     = SiderealTime.LMSTInRotation (location, gmst);

            UnitPolar3 vega = new UnitPolar3 (0.677222171545159, 4.87719096778373);

            HorizontalPosition expected = new HorizontalPosition (1.39499949232881, 2.95002676933194);

            HorizontalPosition actual = CelestialPosition.GetHorizonal (location, lmst, vega);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }
    }
}