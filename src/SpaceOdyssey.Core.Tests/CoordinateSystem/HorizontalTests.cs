using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.CoordinateSystem.Tests
{
    [TestClass ()]
    public class HorizontalTests
    {
        [TestMethod ()]
        public void ToEqHALocalTest_Vector3_Latitude_East ()
        {
            double phi = 1.0;

            Vector3 v = new Vector3 (0, 1, 0);

            Vector3 actual = Horizontal.ToEqHALocal (v, phi);

            Assert.AreEqual (0, actual.X);
            Assert.AreEqual (1, actual.Y);
            Assert.AreEqual (0, actual.Z);
        }

        [TestMethod ()]
        public void ToEqHALocalTest_Vector3_SinCosLatitude_West ()
        {
            double phi = 1.0;

            Vector3 v = new Vector3 (0, -1, 0);

            Vector3 actual = Horizontal.ToEqHALocal (v, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual ( 0, actual.X);
            Assert.AreEqual (-1, actual.Y);
            Assert.AreEqual ( 0, actual.Z);
        }

        [TestMethod ()]
        public void ToEqHALocalTest_Polar3_Latitude_NorthPole ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: phi, azimuth: 0.0);

            EqHALocalPosition expected = new EqHALocalPosition (declination: MathConst.PI_2, hourAngle: 0.0);

            EqHALocalPosition actual = Horizontal.ToEqHALocal (p, phi);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHALocalTest_Polar3_Latitude_Zenith ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: MathConst.PI_2, azimuth: 0.0);

            EqHALocalPosition expected = new EqHALocalPosition (declination: phi, hourAngle: 0.0);

            EqHALocalPosition actual = Horizontal.ToEqHALocal (p, phi);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHALocalTest_Polar3_SinCosLatitude_EquatorSouth ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: MathConst.PI_2 - phi, azimuth: double.Pi);

            EqHALocalPosition expected = new EqHALocalPosition (declination: 0.0, hourAngle: 0.0);

            EqHALocalPosition actual = Horizontal.ToEqHALocal (p, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHALocalTest_Polar3_SinCosLatitude_HorizonSouth ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: 0.0, azimuth: double.Pi);

            EqHALocalPosition expected = new EqHALocalPosition (declination: phi - MathConst.PI_2, hourAngle: 0.0);

            EqHALocalPosition actual = Horizontal.ToEqHALocal (p, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual (expected.Dec, actual.Dec, 1.0e-15);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHALocalTest_Polar3_Latitude_Sirius ()
        {
            double phi = 0.85031379415202107;

            HorizontalPosition p = new HorizontalPosition (altitude: 0.42413634003659091, azimuth: 3.25380762821940644);

            EqHALocalPosition expected = new EqHALocalPosition (declination: -0.29239452477292892, hourAngle: 0.10678433418066473);

            EqHALocalPosition actual = Horizontal.ToEqHALocal (p, phi);

            Assert.AreEqual (expected.Dec, actual.Dec, 1.0e-6);
            Assert.AreEqual (expected.HA,  actual.HA, 1.0e-6);
        }
    }
}