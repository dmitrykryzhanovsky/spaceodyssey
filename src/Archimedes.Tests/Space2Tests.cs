using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Archimedes.Tests
{
    [TestClass ()]
    public class Space2Tests
    {
        [TestMethod ()]
        public void ComputePolarComponentsTest ()
        {
            double x = -3;
            double y = -4;

            double expectedR       =  5;
            double expectedHeading = -2.2142974355881810;

            (double r, double heading) actual = Space2.ComputePolarComponents (x, y);

            Assert.AreEqual (expectedR, actual.r);
            Assert.AreEqual (expectedHeading, actual.heading);
        }
    }
}