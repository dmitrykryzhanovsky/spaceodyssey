using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class LightDilationTests
    {
        [TestMethod ()]
        public void ComputeLightDilationTest ()
        {
            Mass sun   = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Sun.GM_SI));
            Mass earth = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Earth.GM_SI));
            Mass mars  = Mass.CreateByGM (Astrodata.ConvertSIToMetreDay (Astrodata.Mars.GM_SI));

            double t0 = Time.GetJD (DateTime.Now.ToUniversalTime ());

            EllipticOrbit earthOrbit = EllipticOrbit.CreateBySemiMajorAxis (sun, earth, e: 0.01671022, a: 1.00000011 * AstroConst.AU);
            earthOrbit.SetMeanAnomalyForJ2000 (Trigonometry.DegToRad (-2.48284));
            earthOrbit.SetOrientation (inclination: Trigonometry.DegToRad (0.00005), 
                                       ascendingNode: Trigonometry.DegToRad (-11.26064), 
                                       periapsisArgument: Trigonometry.DegToRad (114.20783));

            EllipticOrbit marsOrbit = EllipticOrbit.CreateBySemiMajorAxis (sun, earth, e: 0.09341233, a: 1.52366231 * AstroConst.AU);
            marsOrbit.SetMeanAnomalyForJ2000 (Trigonometry.DegToRad (19.41248));
            marsOrbit.SetOrientation (inclination: Trigonometry.DegToRad (1.85061),
                                      ascendingNode: Trigonometry.DegToRad (49.57854),
                                      periapsisArgument: Trigonometry.DegToRad (286.46230));

            double halfEpsilon = 1.0 / (24.0 * 60.0 * 2.0);

            double actual = LightDilation.ComputeLightDilation (t0, earthOrbit, marsOrbit, halfEpsilon);

            int y = 4;
        }
    }
}