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
            Polar3 p = new Polar3 (1.0, 1.0, 2.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi - 2.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void HorizontalPositionTest_SEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 1.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi - 1.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void HorizontalPositionTest_SWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -1.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi + 1.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void HorizontalPositionTest_NWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -2.0);

            HorizontalPosition expected = new HorizontalPosition (1.0, double.Pi + 2.0);

            HorizontalPosition actual = new HorizontalPosition (p);

            Assert.AreEqual (expected.H, actual.H);
            Assert.AreEqual (expected.A, actual.A);
        }

        [TestMethod ()]
        public void ToPolar3Test_NEQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi - 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, 2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SEQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi - 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, 1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SWQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi + 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, -1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_NWQuadrant ()
        {
            HorizontalPosition u = new HorizontalPosition (1.0, double.Pi + 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, -2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }
    }
}