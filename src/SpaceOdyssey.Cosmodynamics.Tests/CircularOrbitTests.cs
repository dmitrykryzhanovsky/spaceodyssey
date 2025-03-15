using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class CircularOrbitTests
    {
        private static readonly CentralBody CentralBodyForTests = CentralBody.CreateGParameter (4.0); 

        [TestMethod ()]
        public void SetATest_Common ()
        {
            CircularOrbit orbit = new CircularOrbit (CentralBodyForTests);

            orbit.SetA (2.0);

            Assert.AreEqual (2.0, orbit.P);
            Assert.AreEqual (0.0, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (2.0, orbit.Amin);
            Assert.AreEqual (2.0, orbit.Amax);
            Assert.AreEqual (0.707106781186547524, orbit.N, 1.0e-15);
            Assert.AreEqual (8.88576587631673249, orbit.T);
        }

        [TestMethod ()]
        public void SetMeanMotionTest_Common ()
        {
            CircularOrbit orbit = new CircularOrbit (CentralBodyForTests);

            orbit.SetMeanMotion (0.707106781186547524);

            Assert.AreEqual (2.0, orbit.P, 1.0e-15);
            Assert.AreEqual (0.0, orbit.E);
            Assert.AreEqual (2.0, orbit.A, 1.0e-15);
            Assert.AreEqual (2.0, orbit.Amin, 1.0e-15);
            Assert.AreEqual (2.0, orbit.Amax, 1.0e-15);
            Assert.AreEqual (0.707106781186547524, orbit.N);
            Assert.AreEqual (8.88576587631673249, orbit.T);
        }

        [TestMethod ()]
        public void SetTTest_Common ()
        {
            CircularOrbit orbit = new CircularOrbit (CentralBodyForTests);

            orbit.SetT (8.88576587631673249);

            Assert.AreEqual (2.0, orbit.P);
            Assert.AreEqual (0.0, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (2.0, orbit.Amin);
            Assert.AreEqual (2.0, orbit.Amax);
            Assert.AreEqual (0.707106781186547524, orbit.N);
            Assert.AreEqual (8.88576587631673249, orbit.T);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            CircularOrbit orbit = new CircularOrbit (CentralBodyForTests);

            orbit.SetA (2.0);

            double expected = 2.0;

            double actual = orbit.Radius (DateTime.Now.Ticks);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_EqualToSemiMajor ()
        {
            CircularOrbit orbit = new CircularOrbit (CentralBodyForTests);

            orbit.SetA (2.0);

            double actual = orbit.TrueAnomaly (2.0);

            Assert.IsTrue (double.IsNaN (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_NotEqualToSemiMajor ()
        {
            CircularOrbit orbit = new CircularOrbit (CentralBodyForTests);

            orbit.SetA (2.0);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (2.000000000000001);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.IsTrue (wasException);
        }
    }
}