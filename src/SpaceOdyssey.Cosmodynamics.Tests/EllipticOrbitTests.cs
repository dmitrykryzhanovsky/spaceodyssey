using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Reflection;

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

        [TestMethod ()]
        public void MeanAnomalyTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            orbit.T0  = 100.0;
            double t1 = 108.0;

            double expected = 5.65685424949238;

            double actual = orbit.MeanAnomaly (t1);

            Assert.AreEqual (expected, actual);
        }

        // TODO: написать тесты для e = 0.0, e = 0.5 и e = 0.99 для 4 ключевых точек, для произвольных точек в 4 квадрантых и для 2 больших M -
        // положительного и отрицательного - за пределами основного периода, чтобы посмотреть, как отрабатыавет IEEE754Remainder.

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_M0 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = 0.0;

            double expected = 0.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_MQ1 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = double.Pi / 6.0;

            double expected = double.Pi / 6.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_M90 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = double.Pi / 2.0;

            double expected = double.Pi / 2.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_MQ2 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = 2.0 * double.Pi / 3.0;

            double expected = 2.0 * double.Pi / 3.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_M180 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = double.Pi;

            double expected = double.Pi;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_MQ3 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = 7.0 * double.Pi / 6.0;

            double expected = -5.0 * double.Pi / 6.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_M270 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = 3.0 * double.Pi / 2.0;

            double expected = -double.Pi / 2.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_MQ4 ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = 5.0 * double.Pi / 3.0;

            double expected = -double.Pi / 3.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_MBigPositive ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = 25.0 * double.Pi / 6.0;

            double expected = double.Pi / 6.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual, 1.0e-13);
        }

        [TestMethod ()]
        public void SolveKeplerEquationTest_E00_MBigNegative ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.0);

            double M = -29.0 * double.Pi / 6.0;

            double expected = -5.0 * double.Pi / 6.0;

            double actual = orbit.SolveKeplerEquation (M);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }




        [TestMethod ()]
        public void EllipticKeplerEquationTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            object [] parameters = { double.Pi / 6.0, new double [] { 0.5, double.Pi / 4.0 } };

            double expected = -0.51179938779914944;

            object result = (typeof (EllipticOrbit)).GetMethod ("EllipticKeplerEquation",
                             BindingFlags.NonPublic | BindingFlags.Static).Invoke (orbit, parameters);
            double actual = (double)result;

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void EllipticKeplerDerivativeTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            object [] parameters = { double.Pi / 6.0, new double [] { 0.5 } };

            double expected = 0.56698729810778068;

            object result = (typeof (EllipticOrbit)).GetMethod ("EllipticKeplerDerivative",
                             BindingFlags.NonPublic | BindingFlags.Static).Invoke (orbit, parameters);
            double actual = (double)result;

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void EllipticPlanarCartesianCoordinatesTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            object [] parameters = { 0.5, 2.0, 0.86602540378443865, 0.5, 0.86602540378443865 };

            double expectedX = 0.73205080756887729;
            double expectedY = 0.86602540378443865;

            object result = (typeof (EllipticOrbit)).GetMethod ("EllipticPlanarCartesianCoordinates",
                             BindingFlags.NonPublic | BindingFlags.Static).Invoke (orbit, parameters);
            string output = result.ToString ();

            string [] actual = output.Split (", ");
            actual [0] = actual [0].Remove (0, 1);
            actual [1] = actual [1].Remove (actual [1].Length - 1);

            Assert.AreEqual (expectedX, double.Parse (actual [0]), 1.0e-15);
            Assert.AreEqual (expectedY, double.Parse (actual [1]), 1.0e-15);
        }

        [TestMethod ()]
        public void EllipticPlanarVelocityComponentsTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (CentralBodyForTests);

            orbit.SetAE (a: 2.0, e: 0.5);

            object [] parameters = { 0.5, 0.86602540378443865, 1.41421356237309505, 0.5, 0.86602540378443865 };

            double expectedVx = -1.24712984496547051;
            double expectedVy =  1.87069476744820576;

            object result = (typeof (EllipticOrbit)).GetMethod ("EllipticPlanarVelocityComponents",
                             BindingFlags.NonPublic | BindingFlags.Static).Invoke (orbit, parameters);
            string output = result.ToString ();

            string [] actual = output.Split (", ");
            actual [0] = actual [0].Remove (0, 1);
            actual [1] = actual [1].Remove (actual [1].Length - 1); 

            Assert.AreEqual (expectedVx, double.Parse (actual [0]), 1.0e-15);
            Assert.AreEqual (expectedVy, double.Parse (actual [1]), 1.0e-15);
        }
    }
}