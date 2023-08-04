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

            double epsilon = Trigonometry.DegToRad ( 23.43929111);

            Polar3 ec = Space3.ReferenceRotationOX (eq, epsilon);

            double x1 = Trigonometry.RadToDeg (ec.Phi);
            double x2 = Trigonometry.RadToDeg (ec.L);

            (int deg1, int min1, double sec1) = Trigonometry.GetDegMinSec (x1);
            (int deg2, int min2, double sec2) = Trigonometry.GetDegMinSec (x2);

            Assert.Fail ();
        }
    }
}