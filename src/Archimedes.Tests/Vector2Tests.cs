using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Archimedes.Tests
{
    [TestClass ()]
    public class Vector2Tests
    {
        [TestMethod ()]
        public void GetLengthTest ()
        {
            Vector2 v = new Vector2 (3, 4);

            double expected = 5;

            double actual = v.GetLength ();

            Assert.AreEqual (expected, actual);
        }
    }
}