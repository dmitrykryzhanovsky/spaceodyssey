using Microsoft.VisualStudio.TestTools.UnitTesting;

using SpaceOdyssey;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class SpaceTests
    {
        [TestMethod ()]
        public void EqToEcTransformTest_Sirius ()
        {
            double ascension   = Trigonometry.CompoundHourHMinHSec (6, 45, 8.92);
            double declination = Trigonometry.CompoundDegMinSec (-16, 42, 58.02);

            Polar3 eq = Polar3.CreateFineUnit (Trigonometry.DegToRad (declination), Trigonometry.HourToRad (ascension));

            Assert.Fail ();
        }
    }
}