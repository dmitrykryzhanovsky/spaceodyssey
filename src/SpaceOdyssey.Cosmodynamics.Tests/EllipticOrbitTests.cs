using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        [TestMethod ()]
        public void CreateAETest_Common ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            Assert.AreEqual (1.5, orbit.P);
            Assert.AreEqual (0.5, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (1.0, orbit.Amin);
            Assert.AreEqual (3.0, orbit.Amax);
        }

        [TestMethod ()]
        public void CreateAETest_AZero ()
        {
            double a = 0.0;
            double e = 0.5;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAETest_ANegative ()
        {
            double a = -2.0;
            double e =  0.5;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAETest_ENegative ()
        {
            double a =  2.0;
            double e = -0.5;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAETest_EOne ()
        {
            double a = 2.0;
            double e = 1.0;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAETest_GreaterThanOne ()
        {
            double a = 2.0;
            double e = 1.5;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminAmaxTest_Common ()
        {
            double amin = 1.0;
            double amax = 3.0;

            EllipticOrbit orbit = EllipticOrbit.CreateAminAmax (amin, amax);

            Assert.AreEqual (1.5, orbit.P);
            Assert.AreEqual (0.5, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (1.0, orbit.Amin);
            Assert.AreEqual (3.0, orbit.Amax);
        }

        [TestMethod ()]
        public void CreateAminAmaxTest_AminZero ()
        {
            double amin = 0.0;
            double amax = 3.0;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAminAmax (amin, amax);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminAmaxTest_AminNegative ()
        {
            double amin = -1.0;
            double amax =  3.0;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAminAmax (amin, amax);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminAmaxTest_AmaxLessThanAmin ()
        {
            double amin = 1.0;
            double amax = 0.9999999999999999;

            bool wasException = false;

            try
            {
                EllipticOrbit orbit = EllipticOrbit.CreateAminAmax (amin, amax);
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
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double trueAnomaly = 0.0;

            double expected = 1.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI_3 ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double trueAnomaly = double.Pi / 3.0;

            double expected = 1.2;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI_2 ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double trueAnomaly = double.Pi / 2.0;

            double expected = 1.5;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double trueAnomaly = double.Pi;

            double expected = 3.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly3PI_2 ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double trueAnomaly = 3.0 * double.Pi / 2.0;

            double expected = 1.5;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly0 ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double r = 1.0;

            double expected = 0.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI_3 ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double r = 1.2;

            double expected = double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI_2 ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double r = 1.5;

            double expected = double.Pi / 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            double r = 3.0;

            double expected = double.Pi;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusLessThanAmin ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (0.999999999999999);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusGreaterThanAmax ()
        {
            double a = 2.0;
            double e = 0.5;

            EllipticOrbit orbit = EllipticOrbit.CreateAE (a, e);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (3.000000000000001);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }
    }
}