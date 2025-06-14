using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Archimedes.Tests
{
    [TestClass ()]
    public class ArgumentOutOfRangeCheckersTests
    {
        [TestMethod ()]
        public void CheckPositiveTest_Positive ()
        {
            int x = 42;

            bool flag = true;

            try
            {
                ArgumentOutOfRangeCheckers.CheckPositive (x);
            }

            catch
            {
                flag = false;
            }

            Assert.IsTrue (flag);
        }

        [TestMethod ()]
        public void CheckPositiveTest_Zero ()
        {
            int x = 0;

            bool flag = false;

            try
            {
                ArgumentOutOfRangeCheckers.CheckPositive (x);
            }

            catch (ArgumentOutOfRangeException)
            {
                flag = true;
            }

            Assert.IsTrue (flag);
        }

        [TestMethod ()]
        public void CheckPositiveTest_Negative ()
        {
            int x = -42;

            bool flag = false;

            try
            {
                ArgumentOutOfRangeCheckers.CheckPositive (x);
            }

            catch (ArgumentOutOfRangeException)
            {
                flag = true;
            }

            Assert.IsTrue (flag);
        }
    }
}