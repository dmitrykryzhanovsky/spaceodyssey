using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class KeplerOrbitTests
    {
        [TestMethod ()]
        public void SetOrientationTest ()
        {
            Mass   center   = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Sun.GM_SI));
            Mass   orbiting = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Mars.GM_SI));
            double e        = 0.09341233;
            double a        = 227936637242;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            orbit.SetMeanAnomalyForJ2000 (19.41248 * MathConst.AngularTimeConversions.DegToRad);
            orbit.SetOrientation (-double.Pi / 3.0, -2.0 * double.Pi / 3.0, -double.Pi / 6.0);

            double  t = double.Sqrt (3.0);
            Matrix3 expectedPQR = new Matrix3 (-0.375 * t,  0.125,      0.75,
                                               -0.625,     -0.375 * t, -0.25 * t,
                                                0.25 * t,  -0.75,       0.5);

            Assert.AreEqual (-double.Pi / 3.0, orbit.Inclination);
            Assert.AreEqual (-2.0 * double.Pi / 3.0, orbit.AscendingNode);
            Assert.AreEqual (-double.Pi / 6.0, orbit.PeriapsisArgument);

            Assert.AreEqual (expectedPQR [0, 0], orbit.PQR [0, 0], 1.0e-14);
            Assert.AreEqual (expectedPQR [0, 1], orbit.PQR [0, 1], 1.0e-14);
            Assert.AreEqual (expectedPQR [0, 2], orbit.PQR [0, 2], 1.0e-14);
            Assert.AreEqual (expectedPQR [1, 0], orbit.PQR [1, 0], 1.0e-14);
            Assert.AreEqual (expectedPQR [1, 1], orbit.PQR [1, 1], 1.0e-14);
            Assert.AreEqual (expectedPQR [1, 2], orbit.PQR [1, 2], 1.0e-14);
            Assert.AreEqual (expectedPQR [2, 0], orbit.PQR [2, 0], 1.0e-14);
            Assert.AreEqual (expectedPQR [2, 1], orbit.PQR [2, 1], 1.0e-14);
            Assert.AreEqual (expectedPQR [2, 2], orbit.PQR [2, 2], 1.0e-14);
        }
    }
}