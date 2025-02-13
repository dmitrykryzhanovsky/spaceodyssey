using Archimedes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.CoordinateSystem.Tests
{
    [TestClass ()]
    public class HorizontalTests
    {
        [TestMethod ()]
        public void ToEqHATest_Vector3_Latitude_East ()
        {
            double phi = 1.0;

            Vector3 v = new Vector3 (0, 1, 0);

            Vector3 actual = Horizontal.ToEqHA (v, phi);

            Assert.AreEqual (0, actual.X);
            Assert.AreEqual (1, actual.Y);
            Assert.AreEqual (0, actual.Z);
        }

        [TestMethod ()]
        public void ToEqHATest_Vector3_SinCosLatitude_West ()
        {
            double phi = 1.0;

            Vector3 v = new Vector3 (0, -1, 0);

            Vector3 actual = Horizontal.ToEqHA (v, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual ( 0, actual.X);
            Assert.AreEqual (-1, actual.Y);
            Assert.AreEqual ( 0, actual.Z);
        }

        [TestMethod ()]
        public void ToEqHATest_PolarPosition_Latitude_NorthPole ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: phi, azimuth: 0.0);

            EqHAPosition expected = new EqHAPosition (declination: MathConst.M_PI_2, hourAngle: 0.0);

            EqHAPosition actual = Horizontal.ToEqHA (p, phi);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHATest_PolarPosition_Latitude_Zenith ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: MathConst.M_PI_2, azimuth: 0.0);

            EqHAPosition expected = new EqHAPosition (declination: phi, hourAngle: 0.0);

            EqHAPosition actual = Horizontal.ToEqHA (p, phi);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHATest_PolarPosition_SinCosLatitude_EquatorSouth ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: MathConst.M_PI_2 - phi, azimuth: double.Pi);

            EqHAPosition expected = new EqHAPosition (declination: 0.0, hourAngle: 0.0);

            EqHAPosition actual = Horizontal.ToEqHA (p, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToEqHATest_PolarPosition_SinCosLatitude_HorizonSouth ()
        {
            double phi = 1.0;

            HorizontalPosition p = new HorizontalPosition (altitude: 0.0, azimuth: double.Pi);

            EqHAPosition expected = new EqHAPosition (declination: phi - MathConst.M_PI_2, hourAngle: 0.0);

            EqHAPosition actual = Horizontal.ToEqHA (p, double.Sin (phi), double.Cos (phi));

            Assert.AreEqual (expected.Dec, actual.Dec, 1.0e-15);
            Assert.AreEqual (expected.HA,  actual.HA);
        }
    }
}