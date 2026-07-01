using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class Eq1PositionTests
    {
        [TestMethod ()]
        public void Eq1PositionTest_NEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 2.0);

            Eq1Position expected = new Eq1Position (1.0, -2.0);

            Eq1Position actual = new Eq1Position (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle,  actual.HourAngle);
        }

        [TestMethod ()]
        public void Eq1PositionTest_SEQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, 1.0);

            Eq1Position expected = new Eq1Position (1.0, -1.0);

            Eq1Position actual = new Eq1Position (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle,  actual.HourAngle);
        }

        [TestMethod ()]
        public void Eq1PositionTest_SWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -1.0);

            Eq1Position expected = new Eq1Position (1.0, 1.0);

            Eq1Position actual = new Eq1Position (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle,  actual.HourAngle);
        }

        [TestMethod ()]
        public void Eq1PositionTest_NWQuadrant ()
        {
            Polar3 p = new Polar3 (1.0, 1.0, -2.0);

            Eq1Position expected = new Eq1Position (1.0, 2.0);

            Eq1Position actual = new Eq1Position (p);

            Assert.AreEqual (expected.Declination, actual.Declination);
            Assert.AreEqual (expected.HourAngle,  actual.HourAngle);
        }

        [TestMethod ()]
        public void ToPolar3Test_NEQuadrant ()
        {
            Eq1Position u = new Eq1Position (1.0, double.Pi - 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, 2.0 - double.Pi);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SEQuadrant ()
        {
            Eq1Position u = new Eq1Position (1.0, double.Pi - 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, 1.0 - double.Pi);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_SWQuadrant ()
        {
            Eq1Position u = new Eq1Position (1.0, double.Pi + 1.0);

            Polar3 expected = new Polar3 (1.0, 1.0, -double.Pi - 1.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }

        [TestMethod ()]
        public void ToPolar3Test_NWQuadrant ()
        {
            Eq1Position u = new Eq1Position (1.0, double.Pi + 2.0);

            Polar3 expected = new Polar3 (1.0, 1.0, -double.Pi - 2.0);

            Polar3 actual = u.ToPolar3 ();

            Assert.AreEqual (expected.Lat,  actual.Lat);
            Assert.AreEqual (expected.Long, actual.Long);
        }
    }
}