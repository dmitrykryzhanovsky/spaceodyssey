using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceOdyssey.Structures;

namespace SpaceOdyssey.CoordinateSystem.Tests
{
    [TestClass ()]
    public class EqHALocalTests
    {
        [TestMethod ()]
        public void ToHorizontalTest_Vector3_Latitude_East ()
        {
            double phi = 1.0;

            Vector3 v = new Vector3 (0, 1, 0);

            Vector3 actual = EqHALocal.ToHorizontal (v, phi);

            Assert.AreEqual (0, actual.X);
            Assert.AreEqual (1, actual.Y);
            Assert.AreEqual (0, actual.Z);
        }

        [TestMethod ()]
        public void ToHorizontalTest_Vector3_SinCosLatitude_West ()
        {
            double phi = 1.0;

            Vector3 v = new Vector3 (0, -1, 0);

            Vector3 actual = EqHALocal.ToHorizontal (v, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual ( 0, actual.X);
            Assert.AreEqual (-1, actual.Y);
            Assert.AreEqual ( 0, actual.Z);
        }

        [TestMethod ()]
        public void ToHorizontalTest_Polar3_Latitude_NorthPole ()
        {
            double phi = 1.0;

            EqHALocalPosition p = new EqHALocalPosition (declination: MathConst.M_PI_2, hourAngle: 0.0);

            HorizontalPosition expected = new HorizontalPosition (altitude: phi, azimuth: 0.0);

            HorizontalPosition actual = EqHALocal.ToHorizontal (p, phi);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void ToHorizontalTest_Polar3_Latitude_Zenith ()
        {
            double phi = 1.0;

            EqHALocalPosition p = new EqHALocalPosition (declination: phi, hourAngle: 0.0);

            HorizontalPosition expected = new HorizontalPosition (altitude: MathConst.M_PI_2, azimuth: 0.0);

            HorizontalPosition actual = EqHALocal.ToHorizontal (p, phi);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void ToHorizontalTest_Polar3_SinCosLatitude_EquatorSouth ()
        {
            double phi = 1.0;

            EqHALocalPosition p = new EqHALocalPosition (declination: 0.0, hourAngle: 0.0);

            HorizontalPosition expected = new HorizontalPosition (altitude: MathConst.M_PI_2 - phi, azimuth: double.Pi);

            HorizontalPosition actual = EqHALocal.ToHorizontal (p, phi);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void ToHorizontalTest_Polar3_SinCosLatitude_HorizonSouth ()
        {
            double phi = 1.0;

            EqHALocalPosition p = new EqHALocalPosition (declination: phi - MathConst.M_PI_2, hourAngle: 0.0);

            HorizontalPosition expected = new HorizontalPosition (altitude: 0.0, azimuth: double.Pi);

            HorizontalPosition actual = EqHALocal.ToHorizontal (p, phi);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void ToHorizontalTest_Polar3_Latitude_Sirius ()
        {
            double phi = 0.85031379415202107;

            EqHALocalPosition p = new EqHALocalPosition (declination: -0.29239452477292892, hourAngle: 0.10678433418066473);

            HorizontalPosition expected = new HorizontalPosition (altitude: 0.42413634003659091, azimuth: -3.02937767896018004);

            HorizontalPosition actual = EqHALocal.ToHorizontal (p, phi);

            Assert.AreEqual (expected.H, actual.H, 1.0e-6);
            Assert.AreEqual (expected.A, actual.A, 1.0e-6);
        }
    }
}