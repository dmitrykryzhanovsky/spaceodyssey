using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class MassTests
    {
        [TestMethod ()]
        public void CloneTest ()
        {
            double m = 42.0;

            Mass other  = Mass.CreateByMass (m);
            Mass actual = (Mass)other.Clone ();

            Assert.AreEqual (42.0, actual.M);
            Assert.AreEqual (2.803206e-9, actual.GM);
            Assert.AreEqual (5.2945311407149170e-5, actual.GMSqrt);
        }

        [TestMethod ()]
        public void CreateByMassTest ()
        {
            double m = 42.0;

            Mass actual = Mass.CreateByMass (m);

            Assert.AreEqual (42.0, actual.M);
            Assert.AreEqual (2.803206e-9, actual.GM);
            Assert.AreEqual (5.2945311407149170e-5, actual.GMSqrt);
        }

        [TestMethod ()]
        public void CreateByGMTest ()
        {
            double gm = 73.0;

            Mass actual = Mass.CreateByGM (gm);

            Assert.AreEqual (1.0937476589305245e+12, actual.M, 1.0e-3);
            Assert.AreEqual (73.0, actual.GM);
            Assert.AreEqual (8.5440037453175312, actual.GMSqrt);
        }

        [TestMethod ()]
        public void CreateByGMSqrtTest ()
        {
            double gmsqrt = 108.0;

            Mass actual = Mass.CreateByGMSqrt (gmsqrt);

            Assert.AreEqual (1.7475989991459779e+14, actual.M, 1.0e-1);
            Assert.AreEqual (11664.0, actual.GM);
            Assert.AreEqual (  108.0, actual.GMSqrt);
        }
    }
}