using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class LightDilationTests
    {
        [TestMethod ()]
        public void ComputeLightDilationTest ()
        {
            Polar3 marsP   = new Polar3 (r: 360322000000, 
                                         latitude: Trigonometry.DegToRad (-0.91033333333333333), 
                                         longitude: Trigonometry.DegToRad (285.04088888888888889));            
            Vector3 marsC  = marsP.GetCartesian ();
            Vector3 earthC = Vector3.Origin;

            double actual = LightDilation.ComputeLightDilation (earthC, marsC, PhysConst.LightSpeed);
            actual /= 60.0;

            Assert.AreEqual (20.0316667, actual, 1.0e-4);
        }

        [TestMethod ()]
        public void ComputeDilatedPositionTest ()
        {
            Polar3 marsP   = new Polar3 (r: 360322000000,
                                         latitude: Trigonometry.DegToRad (-0.91033333333333333),
                                         longitude: Trigonometry.DegToRad (285.04088888888888889));
            Vector3 marsC  = marsP.GetCartesian ();
            Vector3 earthC = Vector3.Origin;

            double actual = LightDilation.ComputeLightDilation (earthC, marsC, PhysConst.LightSpeed);
            actual /= 60.0;

            Assert.AreEqual (20.0316667, actual, 1.0e-4);
        }
    }
}