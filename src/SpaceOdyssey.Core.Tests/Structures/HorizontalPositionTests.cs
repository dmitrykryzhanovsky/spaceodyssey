using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class HorizontalPositionTests
    {
        [TestMethod ()]
        public void HorizontalPositionTest_NEQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, 2.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi - 2.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void HorizontalPositionTest_SEQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, 1.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi - 1.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void HorizontalPositionTest_SWQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, -1.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi + 1.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void HorizontalPositionTest_NWQuadrant ()
        {
            UnitPolar3 p = new UnitPolar3 (1.0, -2.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi + 2.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void ToPolar3Test_NEQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi - 2.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, 2.0);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }

        [TestMethod ()]
        public void ToPolar3Test_SEQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi - 1.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, 1.0);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }

        [TestMethod ()]
        public void ToPolar3Test_SWQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi + 1.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, -1.0);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }

        [TestMethod ()]
        public void ToPolar3Test_NWQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi + 2.0);

            UnitPolar3 expected = new UnitPolar3 (1.0, -2.0);

            UnitPolar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Latitude,  actual.Latitude);
            Assert.AreEqual (expected.Longitude, actual.Longitude);
        }
    }
}