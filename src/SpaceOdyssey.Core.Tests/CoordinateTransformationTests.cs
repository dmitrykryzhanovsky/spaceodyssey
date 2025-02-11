using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    public class CoordinateTransformationTests
    {
        [TestClass ()]
        public class HorizontalToEquatorialHATests
        {
            [TestMethod ()]
            public void TransformTest_Vector3_Latitude_East ()
            {
                Vector3 v = new Vector3 (0, 1, 0);

                Vector3 actual = CoordinateTransformation.HorizontalToEquatorialHA.Transform (v, 1.0);

                Assert.AreEqual (0, actual.X);
                Assert.AreEqual (1, actual.Y);
                Assert.AreEqual (0, actual.Z);
            }

            [TestMethod ()]
            public void TransformTest_Vector3_SinCosLatitude_West ()
            {
                Vector3 v = new Vector3 (0, -1, 0);

                Vector3 actual = CoordinateTransformation.HorizontalToEquatorialHA.Transform (v, double.Sin (1.0), double.Cos (1.0));

                Assert.AreEqual ( 0, actual.X);
                Assert.AreEqual (-1, actual.Y);
                Assert.AreEqual ( 0, actual.Z);
            }

            [TestMethod ()]
            public void TransformTest_Polar3_Latitude_NorthPole ()
            {
                Polar3 p = new Polar3 (r: 1.0, latitude: 1.0, longitude: 0.0);

                Polar3 actual = CoordinateTransformation.HorizontalToEquatorialHA.Transform (p, 1.0);

                Assert.AreEqual (1.0, actual.R);
                Assert.AreEqual (MathConst.M_PI_2, actual.Latitude);
                Assert.AreEqual (0.0, actual.Longitude);
            }

            [TestMethod ()]
            public void TransformTest_Polar3_SinCosLatitude_EquatorSouth ()
            {
                Polar3 p = new Polar3 (r: 1.0, latitude: MathConst.M_PI_2 - 1.0, longitude: double.Pi);

                Polar3 actual = CoordinateTransformation.HorizontalToEquatorialHA.Transform (p, double.Sin (1.0), double.Cos (1.0));

                Assert.AreEqual (1.0, actual.R);
                Assert.AreEqual (0.0, actual.Latitude);
                Assert.AreEqual (0.0, actual.Longitude);
            }

            [TestMethod ()]
            public void TransformTest_UnitPolar3_Latitude_Zenith ()
            {
                UnitPolar3 p = new UnitPolar3 (latitude: MathConst.M_PI_2, longitude: 0.0);

                UnitPolar3 actual = CoordinateTransformation.HorizontalToEquatorialHA.Transform (p, 1.0);

                Assert.AreEqual (1.0, actual.Latitude, 1.0e-15);
                Assert.AreEqual (0.0, actual.Longitude);
            }

            [TestMethod ()]
            public void TransformTest_UnitPolar3_SinCosLatitude_HorizonSouth ()
            {
                UnitPolar3 p = new UnitPolar3 (latitude: 0.0, longitude: double.Pi);

                UnitPolar3 actual = CoordinateTransformation.HorizontalToEquatorialHA.Transform (p, double.Sin (1.0), double.Cos (1.0));

                Assert.AreEqual (1.0 - MathConst.M_PI_2, actual.Latitude, 1.0e-15);
                Assert.AreEqual (0.0, actual.Longitude);
            }
        }

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

        [TestClass ()]
        public class EquatorialToEclipticTests
        {
            [TestMethod ()]
            public void TransformTest_Vector3_Tilt ()
            {
                Vector3 v = new Vector3 (EquatorialX, EquatorialY, EquatorialZ);

                Vector3 actual = CoordinateTransformation.EquatorialToEcliptic.Transform (v, Tilt);

                Assert.AreEqual (EclipticX, actual.X, 1.0e-6);
                Assert.AreEqual (EclipticY, actual.Y, 1.0e-6);
                Assert.AreEqual (EclipticZ, actual.Z, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_Vector3_SinCosTilt ()
            {
                Vector3 v = new Vector3 (EquatorialX, EquatorialY, EquatorialZ);

                Vector3 actual = CoordinateTransformation.EquatorialToEcliptic.Transform (v, SinTilt, CosTilt);

                Assert.AreEqual (EclipticX, actual.X, 1.0e-6);
                Assert.AreEqual (EclipticY, actual.Y, 1.0e-6);
                Assert.AreEqual (EclipticZ, actual.Z, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_Polar3_Tilt ()
            {
                Polar3 p = new Polar3 (r: 1.0, latitude: EquatorialLatitude, longitude: EquatorialLongitude);

                Polar3 actual = CoordinateTransformation.EquatorialToEcliptic.Transform (p, Tilt);

                Assert.AreEqual (1.0, actual.R);
                Assert.AreEqual (EclipticLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_Polar3_SinCosTilt ()
            {
                Polar3 p = new Polar3 (r: 1.0, latitude: EquatorialLatitude, longitude: EquatorialLongitude);

                Polar3 actual = CoordinateTransformation.EquatorialToEcliptic.Transform (p, SinTilt, CosTilt);

                Assert.AreEqual (1.0, actual.R);
                Assert.AreEqual (EclipticLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_UnitPolar3_Tilt ()
            {
                UnitPolar3 p = new UnitPolar3 (latitude: EquatorialLatitude, longitude: EquatorialLongitude);

                UnitPolar3 actual = CoordinateTransformation.EquatorialToEcliptic.Transform (p, Tilt);

                Assert.AreEqual (EclipticLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_UnitPolar3_SinCosTilt ()
            {
                UnitPolar3 p = new UnitPolar3 (latitude: EquatorialLatitude, longitude: EquatorialLongitude);

                UnitPolar3 actual = CoordinateTransformation.EquatorialToEcliptic.Transform (p, SinTilt, CosTilt);

                Assert.AreEqual (EclipticLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EclipticLongitude, actual.Longitude, 1.0e-6);
            }
        }

        [TestClass ()]
        public class EclipticToEquatorialTests
        {
            [TestMethod ()]
            public void TransformTest_Vector3_Tilt ()
            {
                Vector3 v = new Vector3 (EclipticX, EclipticY, EclipticZ);

                Vector3 actual = CoordinateTransformation.EclipticToEquatorial.Transform (v, Tilt);

                Assert.AreEqual (EquatorialX, actual.X, 1.0e-6);
                Assert.AreEqual (EquatorialY, actual.Y, 1.0e-6);
                Assert.AreEqual (EquatorialZ, actual.Z, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_Vector3_SinCosTilt ()
            {
                Vector3 v = new Vector3 (EclipticX, EclipticY, EclipticZ);

                Vector3 actual = CoordinateTransformation.EclipticToEquatorial.Transform (v, SinTilt, CosTilt);

                Assert.AreEqual (EquatorialX, actual.X, 1.0e-6);
                Assert.AreEqual (EquatorialY, actual.Y, 1.0e-6);
                Assert.AreEqual (EquatorialZ, actual.Z, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_Polar3_Tilt ()
            {
                Polar3 p = new Polar3 (r: 1.0, latitude: EclipticLatitude, longitude: EclipticLongitude);

                Polar3 actual = CoordinateTransformation.EclipticToEquatorial.Transform (p, Tilt);

                Assert.AreEqual (1.0, actual.R);
                Assert.AreEqual (EquatorialLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EquatorialLongitude, actual.Longitude, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_Polar3_SinCosTilt ()
            {
                Polar3 p = new Polar3 (r: 1.0, latitude: EclipticLatitude, longitude: EclipticLongitude);

                Polar3 actual = CoordinateTransformation.EclipticToEquatorial.Transform (p, SinTilt, CosTilt);

                Assert.AreEqual (1.0, actual.R);
                Assert.AreEqual (EquatorialLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EquatorialLongitude, actual.Longitude, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_UnitPolar3_Tilt ()
            {
                UnitPolar3 p = new UnitPolar3 (latitude: EclipticLatitude, longitude: EclipticLongitude);

                UnitPolar3 actual = CoordinateTransformation.EclipticToEquatorial.Transform (p, Tilt);

                Assert.AreEqual (EquatorialLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EquatorialLongitude, actual.Longitude, 1.0e-6);
            }

            [TestMethod ()]
            public void TransformTest_UnitPolar3_SinCosTilt ()
            {
                UnitPolar3 p = new UnitPolar3 (latitude: EclipticLatitude, longitude: EclipticLongitude);

                UnitPolar3 actual = CoordinateTransformation.EclipticToEquatorial.Transform (p, SinTilt, CosTilt);

                Assert.AreEqual (EquatorialLatitude, actual.Latitude, 1.0e-6);
                Assert.AreEqual (EquatorialLongitude, actual.Longitude, 1.0e-6);
            }
        }
    }
}