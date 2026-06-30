using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EarthPrecessionTests
    {
        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsec_AlphaTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 6913.482348;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsec.Alpha (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsec_BetaTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 6013.084461;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsec.Beta (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsec_GammaComponentTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 7.133337;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsec.GammaComponent (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsecJ2000_AlphaTest ()
        {
            double dT = 3;

            double expected = 6921.857166;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.Alpha (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsecJ2000_BetaTest ()
        {
            double dT = 3;

            double expected = 6007.963359;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.Beta (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsecJ2000_GammaComponentTest ()
        {
            double dT = 3;

            double expected = 7.140735;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.GammaComponent (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_GetEulerAnglesForPrecessionTest ()
        {
            double T0 = -2;
            double dT =  3;

            (double alpha, double beta, double gamma) expected = (0.0335175082641968, 0.0291522561235996, 0.0335520916578924);

            (double alpha, double beta, double gamma) actual = EarthPrecession.Equatorial.GetEulerAnglesForPrecession (T0, dT);

            Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-16);
            Assert.AreEqual (expected.beta, actual.beta, 1.0e-16);
            Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-16);
        }

        [TestMethod ()]
        public void Equatorial_GetEulerAnglesForPrecessionJ2000Test ()
        {
            double dT = 3;

            (double alpha, double beta, double gamma) expected = (0.0335581105276288, 0.02912742832048, 0.0335927297878406);

            (double alpha, double beta, double gamma) actual = EarthPrecession.Equatorial.GetEulerAnglesForPrecessionJ2000 (dT);

            Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-16);
            Assert.AreEqual (expected.beta, actual.beta, 1.0e-16);
            Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-16);
        }

        [TestMethod ()]
        public void Equatorial_UpdateCoordinatesTest ()
        {
            double t1950 = JD.GetJD (1950, 1, 1, 12, 0, 0);

            double T0 =  JD.GetJulianCentirues (t1950);
            double dT = -T0;

            (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Equatorial.GetEulerAnglesForPrecession (T0, dT);

            Polar3 p1950 = new Polar3 (1, 0, 0);

            Polar3 p2000 = Rotation3.Apply.Passive.EulerAngles.RotateSpace (p1950, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

            (int deg,  int min, double sec) declination    = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Lat));
            (int hour, int min, double sec) rightAscension = Trigonometry.SplitAngle (Trigonometry.RadToHour (p2000.Long));

            Assert.AreEqual (0, rightAscension.hour);
            Assert.AreEqual (2, rightAscension.min);
            Assert.AreEqual (33.73, rightAscension.sec, 1.0e-2);

            Assert.AreEqual (0, declination.deg);
            Assert.AreEqual (16, declination.min);
            Assert.AreEqual (42.2, declination.sec, 1.0e-1);
        }

        [TestMethod ()]
        public void Equatorial_ByEulerAnglesTest ()
        {
            double t1950 = JD.GetJD (1950, 1, 1, 12, 0, 0);

            double T0 =  JD.GetJulianCentirues (t1950);
            double dT = -T0;

            (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Equatorial.GetEulerAnglesForPrecession (T0, dT);

            Polar3 p1950 = new Polar3 (1, 0, 0);

            Polar3 p2000 = EarthPrecession.Equatorial.UpdateCoordinates (p1950, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

            (int deg,  int min, double sec) declination    = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Lat));
            (int hour, int min, double sec) rightAscension = Trigonometry.SplitAngle (Trigonometry.RadToHour (p2000.Long));

            Assert.AreEqual (0, rightAscension.hour);
            Assert.AreEqual (2, rightAscension.min);
            Assert.AreEqual (33.73, rightAscension.sec, 1.0e-2);

            Assert.AreEqual (0, declination.deg);
            Assert.AreEqual (16, declination.min);
            Assert.AreEqual (42.2, declination.sec, 1.0e-1);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsec_AlphaTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 620372.370080;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsec.Alpha (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsec_BetaTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 141.105732;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsec.Beta (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsec_GammaComponentTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 15083.9565;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsec.GammaComponent (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsecJ2000_AlphaTest ()
        {
            double dT = 3;

            double expected = 626945.87354;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsecJ2000.Alpha (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsecJ2000_BetaTest ()
        {
            double dT = 3;

            double expected = 140.71314;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsecJ2000.Beta (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsecJ2000_GammaComponentTest ()
        {
            double dT = 3;

            double expected = 15097.289808;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsecJ2000.GammaComponent (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_GetEulerAnglesForPrecessionTest ()
        {
            double T0 = -2;
            double dT =  3;

            (double alpha, double beta, double gamma) expected = (3.00765012397132, 0.000684099893565757, -3.08077920873593);

            (double alpha, double beta, double gamma) actual = EarthPrecession.Ecliptic.GetEulerAnglesForPrecession (T0, dT);

            Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-14);
            Assert.AreEqual (expected.beta, actual.beta, 1.0e-16);
            Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-14);
        }

        [TestMethod ()]
        public void Ecliptic_GetEulerAnglesForPrecessionJ2000Test ()
        {
            double dT = 3;

            (double alpha, double beta, double gamma) expected = (3.03951936807361, 0.000682196553838815, -3.11271309453955);

            (double alpha, double beta, double gamma) actual = EarthPrecession.Ecliptic.GetEulerAnglesForPrecessionJ2000 (dT);

            Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-14);
            Assert.AreEqual (expected.beta, actual.beta, 1.0e-16);
            Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-14);
        }

        [TestMethod ()]
        public void Ecliptic_UpdateCoordinatesTest ()
        {
            double t1950 = JD.GetJD (1950, 1, 1, 12, 0, 0);

            double T0 =  JD.GetJulianCentirues (t1950);
            double dT = -T0;

            (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Ecliptic.GetEulerAnglesForPrecession (T0, dT);

            Polar3 p1950 = new Polar3 (1, 0, 0);

            Polar3 p2000 = EarthPrecession.Ecliptic.UpdateCoordinates (p1950, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

            (int deg, int min, double sec) latitude  = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Lat));
            (int deg, int min, double sec) longitude = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Long));

            Assert.AreEqual (0, longitude.deg);
            Assert.AreEqual (41, longitude.min);
            Assert.AreEqual (54.27, longitude.sec, 1.0e-1);

            Assert.AreEqual (0, latitude.deg);
            Assert.AreEqual (0, latitude.min);
            Assert.AreEqual (2.3, latitude.sec, 1.0e-1);
        }

        [TestMethod ()]
        public void Ecliptic_ByEulerAnglesTest ()
        {
            double t1950 = JD.GetJD (1950, 1, 1, 12, 0, 0);

            double T0 =  JD.GetJulianCentirues (t1950);
            double dT = -T0;

            (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Ecliptic.GetEulerAnglesForPrecession (T0, dT);

            Polar3 p1950 = new Polar3 (1, 0, 0);

            Polar3 p2000 = Rotation3.Apply.Passive.EulerAngles.RotateSpace (p1950, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

            (int deg, int min, double sec) latitude  = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Lat));
            (int deg, int min, double sec) longitude = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Long));

            Assert.AreEqual (0, longitude.deg);
            Assert.AreEqual (41, longitude.min);
            Assert.AreEqual (54.27, longitude.sec, 1.0e-1);

            Assert.AreEqual (0, latitude.deg);
            Assert.AreEqual (0, latitude.min);
            Assert.AreEqual (2.3, latitude.sec, 1.0e-1);
        }
    }
}