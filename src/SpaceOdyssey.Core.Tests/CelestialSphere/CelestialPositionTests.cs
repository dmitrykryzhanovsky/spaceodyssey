using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.CelestialSphere.Tests
{
    [TestClass ()]
    public class CelestialPositionTests
    {
        [TestMethod ()]
        public void GetHorizontalTest_Vega_WesternSide ()
        {
            double jd   = 2460735.8914004629;
            double gmst = SiderealTime.GMSTInRotation (jd);

            Location location = new Location (latitude: 0.850313939596126, longitude: 0.77667151713747666);
            double   lmst     = SiderealTime.LMSTInRotation (location, gmst);

            UnitPolar3 vega = new UnitPolar3 (0.677216353780985, 4.87720478497365);

            HorizontalPosition expected = new HorizontalPosition (1.39499949232881, 2.95002676933194);

            HorizontalPosition actual = CelestialPosition.GetHorizontal (location, lmst, vega);

            Assert.AreEqual (expected.H, actual.H); 
            Assert.AreEqual (expected.A, actual.A);
        }
    }
}