using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class ParabolicOrbitTests
    {
        [TestMethod ()]
        public void CreateTest_Common ()
        {
            double amin = 2.0;

            ParabolicOrbit target = ParabolicOrbit.Create (amin);

            Assert.AreEqual (4.0, target.P);
            Assert.AreEqual (1.0, target.E);
            Assert.AreEqual (2.0, target.Amin);
            Assert.AreEqual (double.Pi, target.Asymptote);
        }

        [TestMethod ()]
        public void CreateTest_AminZero ()
        {
            double amin = 0.0;

            bool wasException = false;

            try
            {
                ParabolicOrbit target = ParabolicOrbit.Create (amin);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateTest_AminNegative ()
        {
            double amin = -2.0;

            bool wasException = false;

            try
            {
                ParabolicOrbit target = ParabolicOrbit.Create (amin);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly0 ()
        {
            double amin        = 2.0;
            double trueAnomaly = 0.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = 2.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI_3 ()
        {
            double amin        = 2.0;
            double trueAnomaly = double.Pi / 3.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = 8.0 / 3.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI_2 ()
        {
            double amin        = 2.0;
            double trueAnomaly = double.Pi / 2.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = 4.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly2PI_3 ()
        {
            double amin        = 2.0;
            double trueAnomaly = 2.0 * double.Pi / 3.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = 8.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI ()
        {
            double amin        = 2.0;
            double trueAnomaly = double.Pi;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (true, double.IsPositiveInfinity (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly0 ()
        {
            double amin = 2.0;
            double r    = 2.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = 0.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI_3 ()
        {
            double amin = 2.0;
            double r    = 8.0 / 3.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI_2 ()
        {
            double amin = 2.0;
            double r    = 4.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = double.Pi / 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly2PI_3 ()
        {
            double amin = 2.0;
            double r    = 8.0;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = 2.0 * double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI ()
        {
            double amin = 2.0;
            double r    = double.PositiveInfinity;

            ParabolicOrbit orbit = ParabolicOrbit.Create (amin);

            double expected = double.Pi;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }
    }
}