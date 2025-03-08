using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class CircularOrbitTests
    {
        [TestMethod ()]
        public void CreateTest_Common ()
        {
            double a = 2.0;

            CircularOrbit orbit = CircularOrbit.Create (a);

            Assert.AreEqual (2.0, orbit.P);
            Assert.AreEqual (0.0, orbit.E);
            Assert.AreEqual (2.0, orbit.A);
            Assert.AreEqual (2.0, orbit.Amin);
            Assert.AreEqual (2.0, orbit.Amax);
        }

        [TestMethod ()]
        public void CreateTest_AZero ()
        {
            double a = 0.0;

            bool wasException = false;

            try
            {
                CircularOrbit orbit = CircularOrbit.Create (a);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateTest_ANegative ()
        {
            double a = -2.0;

            bool wasException = false;

            try
            {
                CircularOrbit orbit = CircularOrbit.Create (a);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            double a = 2.0;

            CircularOrbit orbit = CircularOrbit.Create (a);

            double expected = 2.0;

            double actual = orbit.Radius (DateTime.Now.Ticks);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_EqualToSemiMajor ()
        {
            double a = 2.0;

            CircularOrbit orbit = CircularOrbit.Create (a);

            double actual = orbit.TrueAnomaly (2.0);

            Assert.AreEqual (true, double.IsNaN (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_NotEqualToSemiMajor ()
        {
            double a = 2.0;

            CircularOrbit orbit = CircularOrbit.Create (a);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (2.000000000000001);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }
    }
}