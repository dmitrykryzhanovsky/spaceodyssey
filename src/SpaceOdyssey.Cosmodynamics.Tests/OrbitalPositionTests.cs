using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class OrbitalPositionTests
    {
        //TODO: довести тест до ума, когда доделаю матрицы поворота. Предвычислить его вручную.
        [TestMethod ()]
        public void ComputeSpatialPositionTest_Mars_2026Jan01_1745UTCp3 ()
        {
            double JD = Time.GetJD (2026, 1, 1, 14, 45, 0, 0);

            Mass   center   = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Sun.GM_SI));
            Mass   orbiting = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Mars.GM_SI));
            double e        = 0.09341233;
            double a        = 227936637242;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            orbit.SetMeanAnomalyForJ2000 (19.41248 * MathConst.AngularTimeConversions.DegToRad);
            orbit.SetOrientation (  1.85061 * MathConst.AngularTimeConversions.DegToRad,
                                   49.57854 * MathConst.AngularTimeConversions.DegToRad,
                                  286.46230 * MathConst.AngularTimeConversions.DegToRad);

            OrbitalPosition o = orbit.ComputePosition (JD);
            o.ComputeSpatialPosition ();

            Vector3 v = o.SpatialPositionCartesian;
            Polar3  p = o.SpatialPositionPolar;

            Assert.AreEqual (213633000000, p.R, 1.0e+9);
            Assert.AreEqual (-0.8894, p.Lat * MathConst.AngularTimeConversions.RadToDeg, 1.0e-1);
            Assert.AreEqual (282.8142, p.Long * MathConst.AngularTimeConversions.RadToDeg, 2.0);
        }
    }
}