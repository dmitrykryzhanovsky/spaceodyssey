using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class ParabolicOrbitTests
    {
        private static readonly CentralBody CentralBodyForTests = CentralBody.CreateGParameter (4.0);

        [TestMethod ()]
        public void SetAminTest_Common ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            Assert.AreEqual (4.0, orbit.P);
            Assert.AreEqual (1.0, orbit.E);
            Assert.AreEqual (2.0, orbit.Amin);
            Assert.AreEqual (double.Pi, orbit.Asymptote);
            Assert.AreEqual (0.5, orbit.N);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_0 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double trueAnomaly = 0.0;

            double expected = 2.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_60 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double trueAnomaly = double.Pi / 3.0;

            double expected = 8.0 / 3.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_90 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double trueAnomaly = double.Pi / 2.0;

            double expected = 4.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_120 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double trueAnomaly = 2.0 * double.Pi / 3.0;

            double expected = 8.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_180 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double trueAnomaly = double.Pi;

            double actual = orbit.Radius (trueAnomaly);

            Assert.IsTrue (double.IsPositiveInfinity (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_0 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double r = 2.0;

            double expected = 0.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_60 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double r = 8.0 / 3.0;

            double expected = double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_90 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double r = 4.0;

            double expected = double.Pi / 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_120 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double r = 8.0;

            double expected = 2.0 * double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_180 ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            double r = double.PositiveInfinity;

            double expected = double.Pi;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusLessThanAmin ()
        {
            ParabolicOrbit orbit = new ParabolicOrbit (CentralBodyForTests);

            orbit.SetAmin (2.0);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (1.999999999999999);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.IsTrue (wasException);
        }
    }
}