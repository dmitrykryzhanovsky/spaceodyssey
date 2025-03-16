using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class HyperbolicOrbitTests
    {
        private static readonly CentralBody CentralBodyForTests = CentralBody.CreateGParameter (4.0);

        [TestMethod ()]
        public void SetAminPTest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            Assert.AreEqual ( 5.0, orbit.P);
            Assert.AreEqual ( 1.5, orbit.E);
            Assert.AreEqual (-4.0, orbit.A);
            Assert.AreEqual ( 2.0, orbit.Amin);
            Assert.AreEqual ( 2.3005239830218629826861183514531, orbit.Asymptote);
            Assert.AreEqual ( 0.25, orbit.N);
        }

        [TestMethod ()]
        public void SetAminETest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminE (amin: 2.0, e: 1.5);

            Assert.AreEqual ( 5.0, orbit.P);
            Assert.AreEqual ( 1.5, orbit.E);
            Assert.AreEqual (-4.0, orbit.A);
            Assert.AreEqual ( 2.0, orbit.Amin);
            Assert.AreEqual ( 2.3005239830218629826861183514531, orbit.Asymptote);
            Assert.AreEqual ( 0.25, orbit.N);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_0 ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double trueAnomaly = 0.0;

            double expected = 2.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_60 ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double trueAnomaly = double.Pi / 3.0;

            double expected = 20.0 / 7.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly_90 ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double trueAnomaly = double.Pi / 2.0;

            double expected = 5.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Asymptote ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double trueAnomaly = 2.3005239830218629826861183514531;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (true, double.IsPositiveInfinity (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_0 ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double r = 2.0;

            double expected = 0.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_60 ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double r = 20.0 / 7.0;

            double expected = double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly_90 ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double r = 5.0;

            double expected = double.Pi / 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Asymptote ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            double r = double.PositiveInfinity;

            double expected = 2.3005239830218629826861183514531;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusLessThanAmin ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

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

        [TestMethod ()]
        public void MeanAnomalyTest ()
        {
            HyperbolicOrbit orbit = new HyperbolicOrbit (CentralBodyForTests);

            orbit.SetAminP (amin: 2.0, p: 5.0);

            orbit.T0  = 100.0;
            double t1 = 108.0;

            double expected = 2.0;

            double actual = orbit.MeanAnomaly (t1);

            Assert.AreEqual (expected, actual);
        }
    }
}