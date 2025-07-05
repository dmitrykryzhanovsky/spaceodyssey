using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.KeplerOrbit.Tests
{
    [TestClass ()]
    public class FormulaeTests
    {
        #region Shape

        [TestMethod ()]
        public void ConicSectionTest ()
        {
            double trueAnomaly = double.Pi * 4.0 / 3.0;
            double p = 2.0;
            double e = 0.5;
            
            double expected = 2.6666666666666667;

            double actual = Formulae.Shape.ConicSection (trueAnomaly, p, e);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ConicSectionParabolaTest ()
        {
            double trueAnomaly = -double.Pi * 2.0 / 3.0;
            double p           =  2.0;

            double expected = 4.0;

            double actual = Formulae.Shape.ConicSectionParabola (trueAnomaly, p);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void ConicSectionInverseTest ()
        {
            double r = 2.6666666666666667;
            double p = 2.0;
            double e = 0.5;

            double expected = double.Pi * 2.0 / 3.0;

            double actual = Formulae.Shape.ConicSectionInverse (r, p, e);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void ConicSectionInverseParabolaTest ()
        {
            double r = 4.0;
            double p = 2.0;

            double expected = double.Pi * 2.0 / 3.0;

            double actual = Formulae.Shape.ConicSectionInverseParabola (r, p);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void PParabolaByRpTest ()
        {
            double rp = 2.0;

            double expected = 4.0;

            double actual = Formulae.Shape.PParabolaByRp (rp);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void AsymptoteTest ()
        {
            double e = 2.0;

            double expected = double.Pi * 2.0 / 3.0;

            double actual = Formulae.Shape.Asymptote (e);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void RangeARpTest ()
        {
            double x1me = 0.5;

            double expected = 2.0;

            double actual = Formulae.Shape.RangeARp (x1me);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RangeRaATest ()
        {
            double x1pe = 1.5;

            double expected = 1.5;

            double actual = Formulae.Shape.RangeRaA (x1pe);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RangeRaRpTest ()
        {
            double x1me = 0.5;
            double x1pe = 1.5;

            double expected = 3.0;

            double actual = Formulae.Shape.RangeRaRp (x1me, x1pe);

            Assert.AreEqual (expected, actual);
        }

        #endregion

        #region Motion

        [TestMethod ()]
        public void GMATest ()
        {
            double mu = 1.32712440018e+20;
            double a  = 149598261000.0;

            double expected = 8.8712555300358739e+8;

            double actual = Formulae.Motion.GMA (mu, a);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GMASqrtTest ()
        {
            double mua = 8.8712555300358739e+8;

            double expected = 2.9784652977726422e+4;

            double actual = Formulae.Motion.GMASqrt (mua);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void V1CircularTest ()
        {
            double mu = 1.32712440018e+20;
            double r  = 149598261000.0;

            double expected = 2.9784652977726422e+4;

            double actual = Formulae.Motion.V1Circular (mu, r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void V2EscapeTest ()
        {
            double mu = 1.32712440018e+20;
            double r  = 149598261000.0;

            double expected = 4.2121860191676896e+4;

            double actual = Formulae.Motion.V2Escape (mu, r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void VelocityByDistanceTest ()
        {
            double r  =  1.49598261e+11;
            double mu =  1.32712440018e+20;
            double h  = -8.8712555300358739e+8;

            double expected = 29784.6529777264;
                              
            double actual = Formulae.Motion.VelocityByDistance (r, mu, h);

            Assert.AreEqual (expected, actual, 1.0e-10);
        }

        [TestMethod ()]
        public void MeanMotionTest ()
        {
            double a       = 149598261000.0;
            double muasqrt = 2.9784652977726422e+4;

            double expected = 1.9909758829166084e-7;

            double actual = Formulae.Motion.MeanMotion (a, muasqrt);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void OrbitalPeriodTest ()
        {
            double a       = 149598261000.0;
            double muasqrt = 2.9784652977726422e+4;

            double expected = 3.1558319521054472e+7;

            double actual = Formulae.Motion.OrbitalPeriod (a, muasqrt);

            Assert.AreEqual (expected, actual, 1.0e-8);
        }

        #endregion

        #region Integrals

        [TestMethod ()]
        public void ArealVelocityNonParabolaTest ()
        {
            double mu = 1.32712440018e+20;
            double a  = 149598261000.0;

            double expected = 4.4557322899563444e+15;

            double actual = Formulae.Integrals.ArealVelocityNonParabola (mu, a);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void ArealVelocityParabolaTest ()
        {
            double mu = 1.32712440018e+20;
            double rp = 74799130500.0;

            double expected = 4.4557322899563444e+15;

            double actual = Formulae.Integrals.ArealVelocityParabola (mu, rp);

            Assert.AreEqual (expected, actual);
        }

        #endregion

        [TestMethod ()]
        public void ComputePlanarPositionForCircleTest ()
        {
            double    sin     = 0.5;
            double    cos     = 0.5 * double.Sqrt (3.0);
            double    anomaly = double.Pi / 6.0;
            double [] param   = new double [] { 2.0 };

            (double x, double y, double r, double trueAnomaly) expected = (1.7320508075688773, 1.0, 2.0, 0.52359877559829887);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.ComputePlanarPositionForCircle (anomaly, sin, cos, param);

            Assert.AreEqual (expected.x, actual.x);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void ComputePlanarPositionForEllipseTest ()
        {
            double    sin     = 0.5;
            double    cos     = 0.5 * double.Sqrt (3.0);
            double    anomaly = double.Pi / 6.0;
            double [] param   = new double [] { 2.0, 0.6, 0.8 };

            (double x, double y, double r, double trueAnomaly) expected = (0.53205080756887729, 0.8, 0.96076951545867362, 0.98390442268361651);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.ComputePlanarPositionForEllipse (anomaly, sin, cos, param);

            Assert.AreEqual (expected.x, actual.x);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void ComputePlanarPositionForHyperbolaTest ()
        {
            double    sh      = 0.52109530549374736;
            double    ch      = 1.12762596520638079;
            double    anomaly = 0.5;
            double [] param   = new double [] { 2.0, 1.4, 0.97979589711327124 };

            (double x, double y, double r, double trueAnomaly) expected = (0.54474806958723843, 1.02113408465552067, 1.1573527025778662, 1.08072980780868621);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.ComputePlanarPositionForHyperbola (anomaly, sh, ch, param);

            Assert.AreEqual (expected.x, actual.x);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r, 1.0e-15);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void ComputePlanarPositionForParabolaTest ()
        {
            double    sin     = 0.5;
            double    cos     = 0.5 * double.Sqrt (3.0);
            double    anomaly = double.Sqrt (3.0) / 3.0;
            double [] param   = new double [] { 2.0 };

            (double x, double y, double r, double trueAnomaly) expected = (1.3333333333333333, 2.3094010767585031, 2.6666666666666667, 1.0471975511965977);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.ComputePlanarPositionForParabola (anomaly, sin, cos, param);

            Assert.AreEqual (expected.x, actual.x, 1.0e-15);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void ComputePlanarVelocityForCircleTest ()
        {
            double    sin   = 0.5 * double.Sqrt (3.0);
            double    cos   = 0.5;
            double [] param = new double [] { 8.8712555300358739e+8 };

            (double vx, double vy) expected = (-7.682732652474252e+8, 4.43562776501793695e+8);

            (double vx, double vy) actual = Formulae.ComputePlanarVelocityForCircle (sin, cos, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-6);
            Assert.AreEqual (expected.vy, actual.vy);
        }

        [TestMethod ()]
        public void ComputePlanarVelocityForEllipseTest ()
        {
            double    sin   = 0.5 * double.Sqrt (3.0);
            double    cos   = 0.5;
            double [] param = new double [] { 8.8712555300358739e+8, 0.6, 0.8 };

            (double vx, double vy) expected = (-1.09753323606775029e+9, 5.0692888743062137e+8);

            (double vx, double vy) actual = Formulae.ComputePlanarVelocityForEllipse (sin, cos, param);

            Assert.AreEqual (expected.vx, actual.vx);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-7);
        }

        [TestMethod ()]
        public void ComputePlanarVelocityForHyperbolaTest ()
        {
            double    sh    = 0.52109530549374736;
            double    ch    = 1.12762596520638079;
            double [] param = new double [] { 8.8712555300358739e+8, 1.4, 0.97979589711327124 };

            (double vx, double vy) expected = (-798852346.435183, 1693752848.47108);

            (double vx, double vy) actual = Formulae.ComputePlanarVelocityForHyperbola (sh, ch, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-6);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-5);
        }

        [TestMethod ()]
        public void ComputePlanarVelocityForParabolaTest_AfterPericenter ()
        {
            double    r     = 2.6666666666666667;
            double    y     = 2.3094010767585031;
            double [] param = new double [] { 1.32712440018e+20, 4.0 };

            (double vx, double vy) expected = (-4.98834466565563e+9, 8.64006640658074e+9);

            (double vx, double vy) actual = Formulae.ComputePlanarVelocityForParabola (r, y, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-5);
            Assert.AreEqual (expected.vy, actual.vy);
        }

        [TestMethod ()]
        public void ComputePlanarVelocityForParabolaTest_Pericenter ()
        {
            double    r     = 2.0;
            double    y     = 0.0;
            double [] param = new double [] { 1.32712440018e+20, 4.0 };

            (double vx, double vy) expected = (0.0, 1.15200885421077E+10);

            (double vx, double vy) actual = Formulae.ComputePlanarVelocityForParabola (r, y, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-4);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-4);
        }

        [TestMethod ()]
        public void ComputePlanarVelocityForParabolaTest_BeforePericenter ()
        {
            double    r     =  2.6666666666666667;
            double    y     = -2.3094010767585031;
            double [] param = new double [] { 1.32712440018e+20, 4.0 };

            (double vx, double vy) expected = (4.98834466565563e+9, 8.64006640658074e+9);

            (double vx, double vy) actual = Formulae.ComputePlanarVelocityForParabola (r, y, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-5);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-5);
        }
    }
}