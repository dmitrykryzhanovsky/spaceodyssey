using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        private static readonly CentralBody CentralBodyForTests = CentralBody.CreateGParameter (4.0);

        [TestMethod ()]
        public void SetAETest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            Assert.AreEqual (1.5, orbit.P);
            Assert.AreEqual (0.5, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (1.0, orbit.Amin);
            Assert.AreEqual (3.0, orbit.Amax);
            Assert.AreEqual (0.707106781186547524, orbit.N, 1.0e-15);
            Assert.AreEqual (8.88576587631673249, orbit.T);
        }

        [TestMethod ()]
        public void SetAminAmaxTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAminAmax (amin: 1.0, amax: 3.0);

            Assert.AreEqual (1.5, orbit.P);
            Assert.AreEqual (0.5, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (1.0, orbit.Amin);
            Assert.AreEqual (3.0, orbit.Amax);
            Assert.AreEqual (0.707106781186547524, orbit.N, 1.0e-15);
            Assert.AreEqual (8.88576587631673249, orbit.T);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_0 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double trueAnomaly = 0.0;

            double expected = 1.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_60 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double trueAnomaly = double.Pi / 3.0;

            double expected = 1.2;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_90 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double trueAnomaly = double.Pi / 2.0;

            double expected = 1.5;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_180 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double trueAnomaly = double.Pi;

            double expected = 3.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_270 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double trueAnomaly = 3.0 * double.Pi / 2.0;

            double expected = 1.5;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_0 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double r = 1.0;

            double expected = 0.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_60 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double r = 1.2;

            double expected = double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_90 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double r = 1.5;

            double expected = double.Pi / 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_180 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            double r = 3.0;

            double expected = double.Pi;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusLessThanAmin ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (0.999999999999999);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.IsTrue (wasException);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusGreaterThanAmax ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (3.000000000000001);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.IsTrue (wasException);
        }
    }
}