using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;
using SpaceOdyssey;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class PrecessionTests
    {
        [TestMethod ()]
        public void EclipticPrecessionRotationMatrix_J2000Test_J2000 ()
        {
            double dT = 0.0;

            double expectedpi = 0.0;
            double expectedP = 3.05216868284462;
            double expecteds = 0.0;

            Matrix3 a = Space3.CreateRotationOZ (-expectedP - expecteds);
            Matrix3 b = Space3.CreateRotationOX (expectedpi);
            Matrix3 c = Space3.CreateRotationOZ (expectedP);

            Matrix3 expectedMatrix = a * b * c;
            Matrix3 actualMatrix = Precession.EclipticPrecessionRotationMatrix_J2000 (dT);

            Assert.AreEqual (expectedMatrix [0, 0], actualMatrix [0, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [0, 1], actualMatrix [0, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [0, 2], actualMatrix [0, 2], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 0], actualMatrix [1, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 1], actualMatrix [1, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 2], actualMatrix [1, 2], 1.0e-15);
            Assert.AreEqual (expectedMatrix [2, 0], actualMatrix [2, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [2, 1], actualMatrix [2, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [2, 2], actualMatrix [2, 2], 1.0e-15);
        }

        [TestMethod ()]
        public void EclipticPrecessionRotationMatrix_J2000Test_Y2001 ()
        {
            double dT = 365.0 / AstroConst.JulianCentury;

            double expectedpi = 0.000002277189181;
            double expectedP = 3.05212654219974;
            double expecteds = 0.000243651137512;

            Matrix3 a = Space3.CreateRotationOZ (-expectedP - expecteds);
            Matrix3 b = Space3.CreateRotationOX (expectedpi);
            Matrix3 c = Space3.CreateRotationOZ (expectedP);

            Matrix3 expectedMatrix = a * b * c;
            Matrix3 actualMatrix = Precession.EclipticPrecessionRotationMatrix_J2000 (dT);

            Assert.AreEqual (expectedMatrix [0, 0], actualMatrix [0, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [0, 1], actualMatrix [0, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [0, 2], actualMatrix [0, 2], 1.0e-9);
            Assert.AreEqual (expectedMatrix [1, 0], actualMatrix [1, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 1], actualMatrix [1, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 2], actualMatrix [1, 2], 1.0e-9);
            Assert.AreEqual (expectedMatrix [2, 0], actualMatrix [2, 0], 1.0e-9);
            Assert.AreEqual (expectedMatrix [2, 1], actualMatrix [2, 1], 1.0e-9);
            Assert.AreEqual (expectedMatrix [2, 2], actualMatrix [2, 2], 1.0e-15);
        }

        [TestMethod ()]
        public void EclipticPrecessionRotationMatrix_J2000Test_Y1999 ()
        {
            double dT = -365.0 / AstroConst.JulianCentury;

            double expectedpi = -0.000002277221155;
            double expectedP = 3.052210823523740;
            double expecteds = -0.000243650061604;

            Matrix3 a = Space3.CreateRotationOZ (-expectedP - expecteds);
            Matrix3 b = Space3.CreateRotationOX (expectedpi);
            Matrix3 c = Space3.CreateRotationOZ (expectedP);

            Matrix3 expectedMatrix = a * b * c;
            Matrix3 actualMatrix = Precession.EclipticPrecessionRotationMatrix_J2000 (dT);

            Assert.AreEqual (expectedMatrix [0, 0], actualMatrix [0, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [0, 1], actualMatrix [0, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [0, 2], actualMatrix [0, 2], 1.0e-9);
            Assert.AreEqual (expectedMatrix [1, 0], actualMatrix [1, 0], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 1], actualMatrix [1, 1], 1.0e-15);
            Assert.AreEqual (expectedMatrix [1, 2], actualMatrix [1, 2], 1.0e-9);
            Assert.AreEqual (expectedMatrix [2, 0], actualMatrix [2, 0], 1.0e-9);
            Assert.AreEqual (expectedMatrix [2, 1], actualMatrix [2, 1], 1.0e-9);
            Assert.AreEqual (expectedMatrix [2, 2], actualMatrix [2, 2], 1.0e-15);
        }
    }
}