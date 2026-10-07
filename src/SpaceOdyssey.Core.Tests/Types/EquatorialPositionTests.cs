using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EquatorialPositionTests
    {
        [TestMethod ()]
        public void EquatorialPositionTest_NEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 2.0);

            EquatorialPosition expected = new EquatorialPosition (1.0, 2.0);

            EquatorialPosition actual = new EquatorialPosition (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.RightAscension, actual.RightAscension);
        }

        [TestMethod ()]
        public void EquatorialPositionTest_SEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 1.0);

            EquatorialPosition expected = new EquatorialPosition (1.0, 1.0);

            EquatorialPosition actual = new EquatorialPosition (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.RightAscension, actual.RightAscension);
        }

        [TestMethod ()]
        public void EquatorialPositionTest_SWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -1.0);

            EquatorialPosition expected = new EquatorialPosition (1.0, -1.0);

            EquatorialPosition actual = new EquatorialPosition (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.RightAscension, actual.RightAscension);
        }

        [TestMethod ()]
        public void EquatorialPositionTest_NWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -2.0);

            EquatorialPosition expected = new EquatorialPosition (1.0, -2.0);

            EquatorialPosition actual = new EquatorialPosition (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.RightAscension, actual.RightAscension);
        }

        [TestMethod ()]
        public void ToPolar3Test_NEQuadrant ()
        {
            EquatorialPosition u = new EquatorialPosition (1.0, double.Pi - 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi - 2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SEQuadrant ()
        {
            EquatorialPosition u = new EquatorialPosition (1.0, double.Pi - 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi - 1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SWQuadrant ()
        {
            EquatorialPosition u = new EquatorialPosition (1.0, double.Pi + 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi + 1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_NWQuadrant ()
        {
            EquatorialPosition u = new EquatorialPosition (1.0, double.Pi + 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, double.Pi + 2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }
    }
}