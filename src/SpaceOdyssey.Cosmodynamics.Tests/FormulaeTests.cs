using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics
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

            Assert.AreEqual (expected, actual, 1.0e-19);
        }

        [TestMethod ()]
        public void Motion_NonParabola_SpeedTest_Ellipse ()
        {
            double mu = 6.6743e-10;
            double r  = 1.38;
            double a  = 3.0;

            double expected = 2.72912657897320164e-5;

            double actual = Formulae.Motion.NonParabola.Speed (mu, r, a);

            Assert.AreEqual (expected, actual, 1.0e-19);
        }

        [TestMethod ()]
        public void Motion_NonParabola_SpeedTest_Hyperbola ()
        {
            double mu =  6.6743e-10;
            double r  =  1.38;
            double a  = -3.0;

            double expected = 3.44929923569865193e-5;

            double actual = Formulae.Motion.NonParabola.Speed (mu, r, a);

            Assert.AreEqual (expected, actual, 1.0e-19);
        }

        #endregion

        #region Ellipse

        [TestMethod ()]
        public void Motion_Ellipse_NormalizeMeanAnomalyTest ()
        {
            double n  = 9.93959118862213e-6;
            double dt = 2.0e+8;

            double expected = 2.43168065567485;

            double actual = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (n, dt);

            Assert.AreEqual (expected, actual, 1.0e-11);
        }

        [TestMethod ()]
        public void Motion_Ellipse_SpeedMeanTest ()
        {
            double a        = 1.89041095890411;
            double sqrt1me2 = 0.6;
            double T        = 6.32137196384089e+5;

            double expected = 1.52677357618512e-5;

            double actual = Formulae.Motion.Ellipse.SpeedMean (a, sqrt1me2, T);

            Assert.AreEqual (expected, actual, 1.0e-19);
        }

        #endregion

        #region Circle

        [TestMethod ()]
        public void Motion_Circle_SpeedTest ()
        {
            double mu = 6.6743e-10;
            double r  = 1.38;

            double expected = 2.19919286906863147e-5;

            double actual = Formulae.Motion.Circle.Speed (mu, r);

            Assert.AreEqual (expected, actual, 1.0e-19);
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