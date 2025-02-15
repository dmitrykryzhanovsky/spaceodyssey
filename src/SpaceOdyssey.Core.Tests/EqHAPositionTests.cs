using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EqHAPositionTests
    {
        [TestMethod ()]
        public void EqHAPositionTest_NEQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, 2.0);

            EqHAPosition expected = new EqHAPosition (1.0, -2.0);

            EqHAPosition actual = new EqHAPosition (p);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void EqHAPositionTest_SEQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, 1.0);

            EqHAPosition expected = new EqHAPosition (1.0, -1.0);

            EqHAPosition actual = new EqHAPosition (p);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void EqHAPositionTest_SWQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, -1.0);

            EqHAPosition expected = new EqHAPosition (1.0, 1.0);

            EqHAPosition actual = new EqHAPosition (p);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void EqHAPositionTest_NWQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, -2.0);

            EqHAPosition expected = new EqHAPosition (1.0, 2.0);

            EqHAPosition actual = new EqHAPosition (p);

            Assert.AreEqual (expected.Dec, actual.Dec);
            Assert.AreEqual (expected.HA,  actual.HA);
        }

        [TestMethod ()]
        public void ToPolar3Test_NEQuadrant ()
        {
            EqHAPosition u = new EqHAPosition (1.0, double.Pi - 2.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, 2.0 - double.Pi);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }

        [TestMethod ()]
        public void ToPolar3Test_SEQuadrant ()
        {
            EqHAPosition u = new EqHAPosition (1.0, double.Pi - 1.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, 1.0 - double.Pi);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }

        [TestMethod ()]
        public void ToPolar3Test_SWQuadrant ()
        {
            EqHAPosition u = new EqHAPosition (1.0, double.Pi + 1.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, -double.Pi - 1.0);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }

        [TestMethod ()]
        public void ToPolar3Test_NWQuadrant ()
        {
            EqHAPosition u = new EqHAPosition (1.0, double.Pi + 2.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, -double.Pi - 2.0);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }
    }
}