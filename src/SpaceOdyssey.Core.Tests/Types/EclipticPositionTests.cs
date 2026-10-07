using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EclipticPositionTests
    {
        [TestMethod ()]
        public void EclipticPositionTest_NEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 2.0);

            EclipticPosition expected = new EclipticPosition (1.0, 2.0);

            EclipticPosition actual = new EclipticPosition (p);

            Assert.AreEqual (expected.B, actual.B);
            Assert.AreEqual (expected.L, actual.L);
        }

        [TestMethod ()]
        public void EclipticPositionTest_SEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 1.0);

            EclipticPosition expected = new EclipticPosition (1.0, 1.0);

            EclipticPosition actual = new EclipticPosition (p);

            Assert.AreEqual (expected.B, actual.B);
            Assert.AreEqual (expected.L, actual.L);
        }

        [TestMethod ()]
        public void EclipticPositionTest_SWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -1.0);

            EclipticPosition expected = new EclipticPosition (1.0, -1.0);

            EclipticPosition actual = new EclipticPosition (p);

            Assert.AreEqual (expected.B, actual.B);
            Assert.AreEqual (expected.L, actual.L);
        }

        [TestMethod ()]
        public void EclipticPositionTest_NWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -2.0);

            EclipticPosition expected = new EclipticPosition (1.0, -2.0);

            EclipticPosition actual = new EclipticPosition (p);

            Assert.AreEqual (expected.B, actual.B);
            Assert.AreEqual (expected.L, actual.L);
        }

        [TestMethod ()]
        public void ToPolar3Test_NEQuadrant ()
        {
            EclipticPosition u = new EclipticPosition (1.0, double.Pi - 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi - 2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SEQuadrant ()
        {
            EclipticPosition u = new EclipticPosition (1.0, double.Pi - 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi - 1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SWQuadrant ()
        {
            EclipticPosition u = new EclipticPosition (1.0, double.Pi + 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi + 1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_NWQuadrant ()
        {
            EclipticPosition u = new EclipticPosition (1.0, double.Pi + 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi + 2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }
    }
}