using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class OrbitalPositionTests
    {
        [TestMethod ()]
        public void ComputeSpatialTest ()
        {
            Mass   center   = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Sun.GM_SI));
            Mass   orbiting = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Mars.GM_SI));
            double e        = 0.09341233;
            double a        = 227936637242;

            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center, orbiting, e, a);

            orbit.SetMeanAnomalyForJ2000 (19.41248 * MathConst.AngularTimeConversions.DegToRad);
            orbit.SetOrientation (  1.85061 * MathConst.AngularTimeConversions.DegToRad,
                                   49.57854 * MathConst.AngularTimeConversions.DegToRad,
                                  286.46230 * MathConst.AngularTimeConversions.DegToRad);

            OrbitalPosition o = new OrbitalPosition (orbit, orbit.T0, 0.0, 0.0, orbit.RP, 0.0, orbit.RP, 0.0, 0.0, orbit.VP);
                
            o.ComputeSpatialPositionCartesian ();
            o.ComputeSpatialPositionPolar ();
            o.ComputeSpatialVelocity ();

            Vector3 r = o.SpatialPositionCartesian;
            Polar3  p = o.SpatialPositionPolar;
            Vector3 v = o.SpatialVelocity;

            Assert.AreEqual (188760358218.843, r.X, 1.0e-3);
            Assert.AreEqual (-83848306113.064, r.Y, 1.0e-3);
            Assert.AreEqual ( -6399738234.4366, r.Z, 1.0e-3);
            Assert.AreEqual (206644544864.86, p.R, 1.0e-3);            
            Assert.AreEqual (-0.0309747431675642, p.Lat, 1.0e-16);
            Assert.AreEqual (-0.418024412872058, p.Long, 1.0e-15);
            Assert.AreEqual (930009339.234916, v.X, 1.0e-5);
            Assert.AreEqual (2092049459.77599, v.Y, 1.0e-5);
            Assert.AreEqual (20952812.2827448, v.Z, 1.0e-7);
        }
    }
}