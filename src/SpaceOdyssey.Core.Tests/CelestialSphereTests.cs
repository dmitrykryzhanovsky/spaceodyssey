using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class CelestialSphereTests
    {
        [TestMethod ()]
        public void HorizontalToEq1Test ()
        {
            double phi = Trigonometry.DegToRad (48.7);

            (double sinPhi, double cosPhi) = double.SinCos (phi);

            double [] H   = new double [] { 0, 0, 0, 0, double.Pi / 2.0, -double.Pi / 2.0, phi, -phi };
            double [] A   = new double [] { 0, double.Pi / 2.0, double.Pi, 3.0 * double.Pi / 2.0, 0, 0, 0, double.Pi };
            double [] Dec = new double [] { phi, 0, -phi, 0, double.Pi / 2.0 - phi, phi - double.Pi / 2.0, double.Pi / 2.0, -double.Pi / 2.0 };
            double [] Tau = new double [] { double.Pi, 3.0 * double.Pi / 2.0, 0, double.Pi, 0, double.Pi, 0, 0 };

            for (int i = 0; i < 8; i++)
            {
                (double sinH, double cosH) = double.SinCos (H [i]);
                (double sinA, double cosA) = double.SinCos (A [i]);

                (double dec, double tau) actual = CelestialSphere.HorizontalToEq1 (sinH, cosH, sinA, cosA, sinPhi, cosPhi);

                Assert.AreEqual (Dec [i], actual.dec);
                Assert.AreEqual (Tau [i], actual.tau);
            }
        }

        [TestMethod ()]
        public void EquatorialToEclipticTest ()
        {
            double jd      = JD.GetJD (1980, 1, 1, 0, 0, 0);
            double dt      = JD.GetJulianCentirues (jd);
            double epsilon = Trigonometry.SecToRad (EarthAxialTilt.ComputeDE200InArcsec (dt));
            
            (double sin, double cos) = double.SinCos (epsilon);

            double dec = Trigonometry.DegToRad (Trigonometry.AssemblyAngle (0, 16, 42.2));
            double ra  = Trigonometry.HourToRad (Trigonometry.AssemblyAngle (0, 2, 33.73));

            EquatorialPosition equatorial = new EquatorialPosition (dec, ra);

            EclipticPosition ecliptic = CelestialSphere.EquatorialToEcliptic (equatorial, sin, cos);

            (int, int, double) latitude  = Trigonometry.SplitAngle (Trigonometry.RadToDeg (ecliptic.B));
            (int, int, double) longidude = Trigonometry.SplitAngle (Trigonometry.RadToDeg (ecliptic.L));

            Assert.AreEqual (0, latitude.Item1);
            Assert.AreEqual (0, latitude.Item2);
            Assert.AreEqual (2.3, latitude.Item3, 1.0e+0);
            Assert.AreEqual (0, longidude.Item1);
            Assert.AreEqual (41, longidude.Item2);
            Assert.AreEqual (54.27, longidude.Item3, 1.0e-1);
        }

        [TestMethod ()]
        public void EclipticToEquatorialTest ()
        {
            double jd      = JD.GetJD (1980, 1, 1, 0, 0, 0);
            double dt      = JD.GetJulianCentirues (jd);
            double epsilon = Trigonometry.SecToRad (EarthAxialTilt.ComputeDE200InArcsec (dt));

            (double sin, double cos) = double.SinCos (epsilon);

            double b = Trigonometry.DegToRad (Trigonometry.AssemblyAngle (0, 0, 5.8));
            double l = Trigonometry.DegToRad (Trigonometry.AssemblyAngle (50, 7, 39.50));

            EclipticPosition ecliptic = new EclipticPosition (b, l);

            EquatorialPosition equatorial = CelestialSphere.EclipticToEquatorial (ecliptic, sin, cos);

            (int, int, double) dec = Trigonometry.SplitAngle (Trigonometry.RadToDeg (equatorial.Declination));
            (int, int, double) ra  = Trigonometry.SplitAngle (Trigonometry.RadToHour (equatorial.RightAscension));

            Assert.AreEqual (17, dec.Item1);
            Assert.AreEqual (46, dec.Item2);
            Assert.AreEqual (43.5, dec.Item3, 1.0e+0);
            Assert.AreEqual (3, ra.Item1);
            Assert.AreEqual (10, ra.Item2);
            Assert.AreEqual (44.07, ra.Item3, 1.0e+0);
        }
    }
}