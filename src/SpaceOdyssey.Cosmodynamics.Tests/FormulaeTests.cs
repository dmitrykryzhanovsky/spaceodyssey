using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class FormulaeTests
    {
        #region Shape

        #region Non parabola

        [TestMethod ()]
        public void Shape_NonParabola_ConicSectionEquationTest ()
        {
            double p   = 1.38;
            double e   = 0.42;
            double phi = 0.73;

            double expected = 1.05104959378798;

            double actual = Formulae.Shape.NonParabola.ConicSectionEquation (p, e, phi);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void Shape_NonParabola_ConicSectionInverseEquationTest ()
        {
            double p = 1.38;
            double e = 0.42;
            double r = 1.05104959378798;

            double expected = 0.73;

            double actual = Formulae.Shape.NonParabola.ConicSectionInverseEquation (p, e, r);

            Assert.AreEqual (expected, actual, 1.0e-13);
        }

        #endregion

        #region Parabola

        [TestMethod ()]
        public void Shape_Parabola_ConicSectionEquationTest ()
        {
            double p   = 1.38;
            double phi = 0.73;

            double expected = 0.790751914619988;

            double actual = Formulae.Shape.Parabola.ConicSectionEquation (p, phi);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void Shape_Parabola_ConicSectionInverseEquationTest ()
        {
            double p = 1.38;
            double r = 0.790751914619988;

            double expected = 0.73;

            double actual = Formulae.Shape.Parabola.ConicSectionInverseEquation (p, r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void Shape_Parabola_FocalParameterByRPTest ()
        {
            double rp = 1.38;

            double expected = 2.76;

            double actual = Formulae.Shape.Parabola.FocalParameterByRP (rp);

            Assert.AreEqual (expected, actual);
        }

        #endregion

        #endregion

        #region Motion

        #region Parabola

        [TestMethod ()]
        public void Motion_Parabola_MeanMotionTest ()
        {
            double sqrtmu = 2.58346666322598403e-5;
            double rp     = 1.38;

            double expected = 1.1268581093156e-5;

            double actual = Formulae.Motion.Parabola.MeanMotion (sqrtmu, rp);

            Assert.AreEqual (expected, actual, 1.0e-20);
        }

        [TestMethod ()]
        public void Motion_Parabola_SpeedAtRadiusTest ()
        {
            double mu = 6.6743e-10;
            double r  = 1.38;

            double expected = 3.11012838171106e-05;

            double actual = Formulae.Motion.Parabola.SpeedAtRadius (mu, r);

            Assert.AreEqual (expected, actual, 1.0e-19);
        }

        #endregion

        #endregion
    }
}