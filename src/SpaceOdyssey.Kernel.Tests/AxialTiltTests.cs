using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class AxialTiltTests
    {
        [TestMethod ()]
        public void GetTiltTest_JD2000 ()
        {
            double T = 0.0;

            double expected = 0.40909280420293639;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltTest_T05 ()
        {
            double T = 0.5;

            double expected = 0.40897932182413950;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetTiltTest_Tminus05 ()
        {
            double T = -0.5;

            double expected = 0.40920628515153292;

            double actual = AxialTilt.GetTilt (T);

            Assert.AreEqual (expected, actual);
        }
    }
}