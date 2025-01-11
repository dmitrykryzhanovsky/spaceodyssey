using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class CoordinatesTests
    {//0.070623797473839081 2.0959976871211907
        private const double _testJD              =  2460680.7465777778;
        private const double _testJulianCenturies =  0.25012310959008350;
        private const double _testTilt            =  0.40903603483869127;
        private const double _testSinTilt         =  0.39772507039980866;
        private const double _testCosTilt         =  0.91750464215472351;
        private const double _testR               =  2.0;
        private const double _testEquatorialDec   =  0.41905985598169296;
        private const double _testEquatorialAsc   =  2.15707351193492019;
        private const double _testEquatorialX     = -1.01078174214107423;
        private const double _testEquatorialY     =  1.52185539624631247;
        private const double _testEquatorialZ     =  0.81380367575370056;
        private const double _testEclipticLat     =  0.07075332030887535;
                                                    // 0.070623797473839081
        private const double _testEclipticLong    =  2.1021009126301449;
                                                    // 2.0959976871211907
        private const double _testEclipticX       = -1.01078174214107436;
        private const double _testEclipticY       =  1.71997951497497141;
        private const double _testEclipticZ       =  0.14138860569620438;

        [TestMethod ()]
        public void EquatorialToEclipticForJDTest_UnitPolar3 ()
        {
            UnitPolar3 p  = new UnitPolar3 (_testEquatorialDec, _testEquatorialAsc);

            UnitPolar3 actual = Coordinates.EquatorialToEclipticForJD (p, _testJD);

            Assert.AreEqual (_testEclipticLat, actual.Latitude);
            Assert.AreEqual (_testEclipticLong, actual.Longitude);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForJDTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEquatorialDec, _testEquatorialAsc);

            Polar3 actual = Coordinates.EquatorialToEclipticForJD (p, _testJD);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEclipticLat, actual.Latitude);
            Assert.AreEqual (_testEclipticLong, actual.Longitude);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForJDTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEquatorialX, _testEquatorialY, _testEquatorialZ);

            Vector3 actual = Coordinates.EquatorialToEclipticForJD (v, _testJD);

            Assert.AreEqual (_testEclipticX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEclipticY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEclipticZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForJulianCenturiesTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEquatorialDec, _testEquatorialAsc);

            UnitPolar3 actual = Coordinates.EquatorialToEclipticForJulianCenturies (p, _testJulianCenturies);

            Assert.AreEqual (_testEclipticLat, actual.Latitude);
            Assert.AreEqual (_testEclipticLong, actual.Longitude);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForJulianCenturiesTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEquatorialDec, _testEquatorialAsc);

            Polar3 actual = Coordinates.EquatorialToEclipticForJulianCenturies (p, _testJulianCenturies);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEclipticLat, actual.Latitude);
            Assert.AreEqual (_testEclipticLong, actual.Longitude);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForJulianCenturiesTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEquatorialX, _testEquatorialY, _testEquatorialZ);

            Vector3 actual = Coordinates.EquatorialToEclipticForJulianCenturies (v, _testJulianCenturies);

            Assert.AreEqual (_testEclipticX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEclipticY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEclipticZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForTiltTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEquatorialDec, _testEquatorialAsc);

            UnitPolar3 actual = Coordinates.EquatorialToEclipticForTilt (p, _testTilt);

            Assert.AreEqual (_testEclipticLat, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEclipticLong, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForTiltTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEquatorialDec, _testEquatorialAsc);

            Polar3 actual = Coordinates.EquatorialToEclipticForTilt (p, _testTilt);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEclipticLat, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEclipticLong, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForTiltTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEquatorialX, _testEquatorialY, _testEquatorialZ);

            Vector3 actual = Coordinates.EquatorialToEclipticForTilt (v, _testTilt);

            Assert.AreEqual (_testEclipticX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEclipticY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEclipticZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForSinCosTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEquatorialDec, _testEquatorialAsc);

            UnitPolar3 actual = Coordinates.EquatorialToEclipticForSinCos (p, _testSinTilt, _testCosTilt);

            Assert.AreEqual (_testEclipticLat, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEclipticLong, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForSinCosTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEquatorialDec, _testEquatorialAsc);

            Polar3 actual = Coordinates.EquatorialToEclipticForSinCos (p, _testSinTilt, _testCosTilt);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEclipticLat, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEclipticLong, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EquatorialToEclipticForSinCosTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEquatorialX, _testEquatorialY, _testEquatorialZ);

            Vector3 actual = Coordinates.EquatorialToEclipticForSinCos (v, _testSinTilt, _testCosTilt);

            Assert.AreEqual (_testEclipticX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEclipticY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEclipticZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForJDTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEclipticLat, _testEclipticLong);

            UnitPolar3 actual = Coordinates.EclipticToEquatorialForJD (p, _testJD);

            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForJDTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEclipticLat, _testEclipticLong);

            Polar3 actual = Coordinates.EclipticToEquatorialForJD (p, _testJD);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForJDTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEclipticX, _testEclipticY, _testEclipticZ);

            Vector3 actual = Coordinates.EclipticToEquatorialForJD (v, _testJD);

            Assert.AreEqual (_testEquatorialX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEquatorialY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEquatorialZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForJulianCenturiesTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEclipticLat, _testEclipticLong);

            UnitPolar3 actual = Coordinates.EclipticToEquatorialForJulianCenturies (p, _testJulianCenturies);

            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForJulianCenturiesTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEclipticLat, _testEclipticLong);

            Polar3 actual = Coordinates.EclipticToEquatorialForJulianCenturies (p, _testJulianCenturies);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForJulianCenturiesTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEclipticX, _testEclipticY, _testEclipticZ);

            Vector3 actual = Coordinates.EclipticToEquatorialForJulianCenturies (v, _testJulianCenturies);

            Assert.AreEqual (_testEquatorialX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEquatorialY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEquatorialZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForTiltTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEclipticLat, _testEclipticLong);

            UnitPolar3 actual = Coordinates.EclipticToEquatorialForTilt (p, _testTilt);

            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForTiltTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEclipticLat, _testEclipticLong);

            Polar3 actual = Coordinates.EclipticToEquatorialForTilt (p, _testTilt);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForTiltTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEclipticX, _testEclipticY, _testEclipticZ);

            Vector3 actual = Coordinates.EclipticToEquatorialForTilt (v, _testTilt);

            Assert.AreEqual (_testEquatorialX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEquatorialY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEquatorialZ, actual.Z, 1.0e-15);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForSinCosTest_UnitPolar3 ()
        {
            UnitPolar3 p = new UnitPolar3 (_testEclipticLat, _testEclipticLong);

            UnitPolar3 actual = Coordinates.EclipticToEquatorialForSinCos (p, _testSinTilt, _testCosTilt);

            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForSinCosTest_Polar3 ()
        {
            Polar3 p = new Polar3 (_testR, _testEclipticLat, _testEclipticLong);

            Polar3 actual = Coordinates.EclipticToEquatorialForSinCos (p, _testSinTilt, _testCosTilt);

            Assert.AreEqual (_testR, actual.R);
            Assert.AreEqual (_testEquatorialDec, actual.Latitude, 1.0e-16);
            Assert.AreEqual (_testEquatorialAsc, actual.Longitude, 1.0e-16);
        }

        [TestMethod ()]
        public void EclipticToEquatorialForSinCosTest_Vector3 ()
        {
            Vector3 v = new Vector3 (_testEclipticX, _testEclipticY, _testEclipticZ);

            Vector3 actual = Coordinates.EclipticToEquatorialForSinCos (v, _testSinTilt, _testCosTilt);

            Assert.AreEqual (_testEquatorialX, actual.X, 1.0e-15);
            Assert.AreEqual (_testEquatorialY, actual.Y, 1.0e-15);
            Assert.AreEqual (_testEquatorialZ, actual.Z, 1.0e-15);
        }
    }
}