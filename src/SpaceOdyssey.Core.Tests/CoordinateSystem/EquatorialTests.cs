using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.CoordinateSystem.Tests
{
    [TestClass ()]
    public class EquatorialTests
    {
        // В качестве тестовых данных для преобразования между эклиптической и экваториальной (второй) системами взято положение Марса
        // на 00:00:00 26 декабря 2024 г. по московскому времени согласно Stellarium.

        // Наклон земной оси для данного момента времени равен ε = 23° 26′ 18.3″.
        private const double Tilt    = 0.40907754228764761;
        private const double SinTilt = 0.39776315333428520;
        private const double CosTilt = 0.91748813281130014;

        // Положение Марса для данного момента времени в экваториальных и эклиптических координатах в радианах.
        private const double EquatorialLatitude  = 0.39942199301467009;
        private const double EquatorialLongitude = 2.21622926526970300;
        private const double EclipticLatitude    = 0.06410497379838951;
        private const double EclipticLongitude   = 2.15956181815321488;

        // Единичный вектор положения Марса для данного момента времени в экваториальных и эклиптических декартовых координатах.
        private static readonly double EquatorialX = double.Cos (EquatorialLatitude) * double.Cos (EquatorialLongitude);
        private static readonly double EquatorialY = double.Cos (EquatorialLatitude) * double.Sin (EquatorialLongitude);
        private static readonly double EquatorialZ = double.Sin (EquatorialLatitude);
        private static readonly double EclipticX   = double.Cos (EclipticLatitude) * double.Cos (EclipticLongitude);
        private static readonly double EclipticY   = double.Cos (EclipticLatitude) * double.Sin (EclipticLongitude);
        private static readonly double EclipticZ   = double.Sin (EclipticLatitude);

        [TestMethod ()]
        public void ToEclipticTest_Vector3_Tilt ()
        {
            Vector3 v = new Vector3 (EquatorialX, EquatorialY, EquatorialZ);

            Vector3 actual = Equatorial.ToEcliptic (v, Tilt);

            Assert.AreEqual (EclipticX, actual.X, 1.0e-6);
            Assert.AreEqual (EclipticY, actual.Y, 1.0e-6);
            Assert.AreEqual (EclipticZ, actual.Z, 1.0e-6);
        }

        [TestMethod ()]
        public void ToEclipticTest_Vector3_SinCosTilt ()
        {
            Vector3 v = new Vector3 (EquatorialX, EquatorialY, EquatorialZ);

            Vector3 actual = Equatorial.ToEcliptic (v, SinTilt, CosTilt);

            Assert.AreEqual (EclipticX, actual.X, 1.0e-6);
            Assert.AreEqual (EclipticY, actual.Y, 1.0e-6);
            Assert.AreEqual (EclipticZ, actual.Z, 1.0e-6);
        }

        [TestMethod ()]
        public void ToEclipticTest_Polar3_Tilt ()
        {
            Polar3 p = new Polar3 (r: 1.0, latitude: EquatorialLatitude, longitude: EquatorialLongitude);

            Polar3 actual = Equatorial.ToEcliptic (p, Tilt);

            Assert.AreEqual (1.0, actual.R);
            Assert.AreEqual (EclipticLatitude,  actual.Latitude,  1.0e-6);
            Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
        }

        [TestMethod ()]
        public void ToEclipticTest_Polar3_SinCosTilt ()
        {
            Polar3 p = new Polar3 (r: 1.0, latitude: EquatorialLatitude, longitude: EquatorialLongitude);

            Polar3 actual = Equatorial.ToEcliptic (p, SinTilt, CosTilt);

            Assert.AreEqual (1.0, actual.R);
            Assert.AreEqual (EclipticLatitude,  actual.Latitude,  1.0e-6);
            Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
        }

        [TestMethod ()]
        public void ToEclipticTest_UnitPolar3_Tilt ()
        {
            UnitPolar3 p = new UnitPolar3 (latitude: EquatorialLatitude, longitude: EquatorialLongitude);

            UnitPolar3 actual = Equatorial.ToEcliptic (p, Tilt);

            Assert.AreEqual (EclipticLatitude,  actual.Latitude,  1.0e-6);
            Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
        }

        [TestMethod ()]
        public void ToEclipticTest_UnitPolar3_SinCosTilt ()
        {
            UnitPolar3 p = new UnitPolar3 (latitude: EquatorialLatitude, longitude: EquatorialLongitude);

            UnitPolar3 actual = Equatorial.ToEcliptic (p, SinTilt, CosTilt);

            Assert.AreEqual (EclipticLatitude,  actual.Latitude,  1.0e-6);
            Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
        }
    }
}