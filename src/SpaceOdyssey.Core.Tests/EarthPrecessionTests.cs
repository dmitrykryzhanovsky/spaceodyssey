using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EarthPrecessionTests
    {
        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsec_VernalEquinoxTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 6913.482348;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsec.VernalEquinox (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsec_NutationTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 6013.084461;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsec.Nutation (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsec_InLogitudeTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 7.133337;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsec.InLongitude (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsecJ2000_VernalEquinoxTest ()
        {
            double dT = 3;

            double expected = 6921.857166;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.VernalEquinox (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsecJ2000_NutationTest ()
        {
            double dT = 3;

            double expected = 6007.963359;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.Nutation (dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Equatorial_ComputeEulerAnglesInArcsecJ2000_InLogitudeTest ()
        {
            double dT = 3;

            double expected = 7.140735;

            double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.InLongitude (dT);

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

            Polar3 p2000 = EarthPrecession.Equatorial.UpdateCoordinates (p1950, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

            (int deg,  int min, double sec) declination = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Lat));
            (int hour, int min, double sec) rightAscension = Trigonometry.SplitAngle (Trigonometry.RadToHour (p2000.Long));

            Assert.AreEqual (0, rightAscension.hour);
            Assert.AreEqual (2, rightAscension.min);
            Assert.AreEqual (33.73, rightAscension.sec, 1.0e-2);

            Assert.AreEqual (0, declination.deg);
            Assert.AreEqual (16, declination.min);
            Assert.AreEqual (42.2, declination.sec, 1.0e-1);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsec_VernalEquinoxTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 15083.9565;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsec.VernalEquinox (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsec_NutationTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 141.105732;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsec.Nutation (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        [TestMethod ()]
        public void Ecliptic_ComputeEulerAnglesInArcsec_InLogitudeTest ()
        {
            double T0 = -2;
            double dT =  3;

            double expected = 620372.370080;

            double actual = EarthPrecession.Ecliptic.ComputeEulerAnglesInArcsec.InLongitude (T0, dT);

            Assert.AreEqual (expected, actual, 1.0e-7);
        }

        //[TestMethod ()]
        //public void Equatorial_ComputeEulerAnglesInArcsecJ2000_VernalEquinoxTest ()
        //{
        //    double dT = 3;

        //    double expected = 6921.857166;

        //    double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.VernalEquinox (dT);

        //    Assert.AreEqual (expected, actual, 1.0e-7);
        //}

        //[TestMethod ()]
        //public void Equatorial_ComputeEulerAnglesInArcsecJ2000_NutationTest ()
        //{
        //    double dT = 3;

        //    double expected = 6007.963359;

        //    double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.Nutation (dT);

        //    Assert.AreEqual (expected, actual, 1.0e-7);
        //}

        //[TestMethod ()]
        //public void Equatorial_ComputeEulerAnglesInArcsecJ2000_InLogitudeTest ()
        //{
        //    double dT = 3;

        //    double expected = 7.140735;

        //    double actual = EarthPrecession.Equatorial.ComputeEulerAnglesInArcsecJ2000.InLongitude (dT);

        //    Assert.AreEqual (expected, actual, 1.0e-7);
        //}

        //[TestMethod ()]
        //public void Equatorial_GetEulerAnglesForPrecessionTest ()
        //{
        //    double T0 = -2;
        //    double dT = 3;

        //    (double alpha, double beta, double gamma) expected = (0.0335175082641968, 0.0291522561235996, 0.0335520916578924);

        //    (double alpha, double beta, double gamma) actual = EarthPrecession.Equatorial.GetEulerAnglesForPrecession (T0, dT);

        //    Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-16);
        //    Assert.AreEqual (expected.beta, actual.beta, 1.0e-16);
        //    Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-16);
        //}

        //[TestMethod ()]
        //public void Equatorial_GetEulerAnglesForPrecessionJ2000Test ()
        //{
        //    double dT = 3;

        //    (double alpha, double beta, double gamma) expected = (0.0335581105276288, 0.02912742832048, 0.0335927297878406);

        //    (double alpha, double beta, double gamma) actual = EarthPrecession.Equatorial.GetEulerAnglesForPrecessionJ2000 (dT);

        //    Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-16);
        //    Assert.AreEqual (expected.beta, actual.beta, 1.0e-16);
        //    Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-16);
        //}

        //[TestMethod ()]
        //public void Equatorial_UpdateCoordinatesTest ()
        //{
        //    double t1950 = JD.GetJD (1950, 1, 1, 12, 0, 0);

        //    double T0 = JD.GetJulianCentirues (t1950);
        //    double dT = -T0;

        //    (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Equatorial.GetEulerAnglesForPrecession (T0, dT);

        //    Polar3 p1950 = new Polar3 (1, 0, 0);

        //    Polar3 p2000 = EarthPrecession.Equatorial.UpdateCoordinates (p1950, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

        //    (int deg, int min, double sec) declination = Trigonometry.SplitAngle (Trigonometry.RadToDeg (p2000.Lat));
        //    (int hour, int min, double sec) rightAscension = Trigonometry.SplitAngle (Trigonometry.RadToHour (p2000.Long));

        //    Assert.AreEqual (0, rightAscension.hour);
        //    Assert.AreEqual (2, rightAscension.min);
        //    Assert.AreEqual (33.73, rightAscension.sec, 1.0e-2);

        //    Assert.AreEqual (0, declination.deg);
        //    Assert.AreEqual (16, declination.min);
        //    Assert.AreEqual (42.2, declination.sec, 1.0e-1);
        //}
    }
}