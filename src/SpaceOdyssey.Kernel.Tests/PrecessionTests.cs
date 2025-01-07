using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class PrecessionTests
    {
        [TestMethod ()]
        public void GetLongitudePrecessionTest ()
        {
            double T0 = 0.02;
            double dT = 0.23;

            double expected = 0.0056081366477320803;

            double actual = Precession.GetLongitudePrecession (T0, dT);

            Assert.AreEqual (expected, actual);
        }
        //0,058778732564
        //0,000000073002 
        //0,058778659562
        //-0,0000000168
        //1156,761219051698
        //0,00560813664773208026155446014945
    }
}