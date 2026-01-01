using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class AstrodataTests
    {
        [TestMethod ()]
        public void ConvertSIToMetreDayTest ()
        {
            double x = 4.2;

            double expected = 31352832000.0;

            double actual = Astrodata.ConvertSIToMetreDay (x);

            Assert.AreEqual (expected, actual);
        }
    }
}