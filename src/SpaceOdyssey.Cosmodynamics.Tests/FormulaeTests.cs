using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics
{
    [TestClass ()]
    public class FormulaeTests
    {
        #region Shape

        #region Hyperbola

        [TestMethod ()]
        public void Shape_NonParabola_Hyperbola_AsymptoteTest ()
        {
            double e = 1.42;

            double expected = 2.35212779191392;

            double actual = Formulae.Shape.Hyperbola.Asymptote (e);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        #endregion

        #endregion

        #region Integrals

        #region NonParabola

        [TestMethod ()]
        public void Integrals_NonParabola_EnergyIntegralTest ()
        {
            double mu = 6.6743e-10;
            double a  = 3.0;

            double expected = -2.22476666666667e-10;

            double actual = Formulae.Integrals.NonParabola.EnergyIntegral (mu, a);

            Assert.AreEqual (expected, actual, 1.0e-24);
        }

        #endregion

        #endregion

        #region Motion

        #region NonParabola

        [TestMethod ()]
        public void Motion_NonParabola_MeanMotionTest ()
        {
            double sqrth =  1.49156517345594e-5;
            double a     = -3.0;

            double expected = 4.97188391151982e-6;

            double actual = Formulae.Motion.NonParabola.MeanMotion (sqrth, a);

            Assert.AreEqual (expected, actual, 1.0e-21);
        }

        #endregion

        #region Parabola

        [TestMethod ()]
        public void Motion_Parabola_SpeedTest ()
        {
            double mu = 6.6743e-10;
            double r  = 1.38;

            double expected = 3.11012838171106e-5;

            double actual = Formulae.Motion.Parabola.Speed (mu, r);

            Assert.AreEqual (expected, actual, 1.0e-19);
        }

        #endregion

        #endregion
    }
}