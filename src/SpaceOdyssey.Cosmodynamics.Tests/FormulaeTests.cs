using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.KeplerOrbit.Tests
{
    [TestClass ()]
    public class FormulaeTests
    {
        [TestMethod ()]
        public void ConicSectionTest ()
        {
            double trueAnomaly = double.Pi * 4.0 / 3.0;
            double p = 2.0;
            double e = 0.5;
            
            double expected = 2.6666666666666667;

            double actual = Formulae.ConicSection (trueAnomaly, p, e);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ConicSectionParabolaTest ()
        {
            double trueAnomaly = -double.Pi * 2.0 / 3.0;
            double p           =  2.0;

            double expected = 4.0;

            double actual = Formulae.ConicSectionParabola (trueAnomaly, p);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void ConicSectionInverseTest ()
        {
            double r = 2.6666666666666667;
            double p = 2.0;
            double e = 0.5;

            double expected = double.Pi * 2.0 / 3.0;

            double actual = Formulae.ConicSectionInverse (r, p, e);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ConicSectionInverseParabolaTest ()
        {
            double r = 4.0;
            double p = 2.0;

            double expected = double.Pi * 2.0 / 3.0;

            double actual = Formulae.ConicSectionInverseParabola (r, p);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void PParabolaByRpTest ()
        {
            double rp = 2.0;

            double expected = 4.0;

            double actual = Formulae.PParabolaByRp (rp);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void AsymptoteTest ()
        {
            double e = 2.0;

            double expected = double.Pi * 2.0 / 3.0;

            double actual = Formulae.Asymptote (e);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void RangeARpTest ()
        {
            double x1me = 0.5;

            double expected = 2.0;

            double actual = Formulae.RangeARp (x1me);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RangeRaATest ()
        {
            double x1pe = 1.5;

            double expected = 1.5;

            double actual = Formulae.RangeRaA (x1pe);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RangeRaRpTest ()
        {
            double x1me = 0.5;
            double x1pe = 1.5;

            double expected = 3.0;

            double actual = Formulae.RangeRaRp (x1me, x1pe);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GMATest ()
        {
            double mu = 1.32712440018e+20;
            double a  = 149598261000.0;

            double expected = 8.8712555300358739e+8;

            double actual = Formulae.GMA (mu, a);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GMASqrtTest ()
        {
            double mua = 8.8712555300358739e+8;

            double expected = 2.9784652977726422e+4;

            double actual = Formulae.GMASqrt (mua);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void V1CircularTest ()
        {
            double mu = 1.32712440018e+20;
            double r  = 149598261000.0;

            double expected = 2.9784652977726422e+4;

            double actual = Formulae.V1Circular (mu, r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void V2EscapeTest ()
        {
            double mu = 1.32712440018e+20;
            double r  = 149598261000.0;

            double expected = 4.2121860191676896e+4;

            double actual = Formulae.V2Escape (mu, r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void MeanMotionTest ()
        {
            double a       = 149598261000.0;
            double muasqrt = 2.9784652977726422e+4;

            double expected = 1.9909758829166084e-7;

            double actual = Formulae.MeanMotion (a, muasqrt);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void OrbitalPeriodTest ()
        {
            double a       = 149598261000.0;
            double muasqrt = 2.9784652977726422e+4;

            double expected = 3.1558319521054472e+7;

            double actual = Formulae.OrbitalPeriod (a, muasqrt);

            Assert.AreEqual (expected, actual, 1.0e-8);
        }

        [TestMethod ()]
        public void ArealVelocityNonParabolaTest ()
        {
            double mu = 1.32712440018e+20;
            double a  = 149598261000.0;

            double expected = 4.4557322899563444e+15;

            double actual = Formulae.ArealVelocityNonParabola (mu, a);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void ArealVelocityParabolaTest ()
        {
            double mu = 1.32712440018e+20;
            double rp = 74799130500.0;

            double expected = 4.4557322899563444e+15;

            double actual = Formulae.ArealVelocityParabola (mu, rp);

            Assert.AreEqual (expected, actual);
        }
    }
}