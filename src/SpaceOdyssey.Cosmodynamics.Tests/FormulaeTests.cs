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
            double p = 2.0;

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
            double a = 149598261000.0;

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
            double r = 149598261000.0;

            double expected = 2.9784652977726422e+4;

            double actual = Formulae.Motion.V1Circular (mu, r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void V2EscapeTest ()
        {
            double mu = 1.32712440018e+20;
            double r = 149598261000.0;

            double expected = 4.2121860191676896e+4;

            double actual = Formulae.Motion.V2Escape (mu, r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void VelocityByDistanceTest ()
        {
            double r = 1.49598261e+11;
            double mu = 1.32712440018e+20;
            double h = -8.8712555300358739e+8;

            double expected = 29784.6529777264;

            double actual = Formulae.Motion.VelocityByDistance (r, mu, h);

            Assert.AreEqual (expected, actual, 1.0e-10);
        }

        [TestMethod ()]
        public void MeanMotionNonParabolaTest ()
        {
            double a = 149598261000.0;
            double muasqrt = 2.9784652977726422e+4;

            double expected = 1.9909758829166084e-7;

            double actual = Formulae.Motion.MeanMotionNonParabola (a, muasqrt);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void MeanMotionParabolaTest ()
        {
            double mu = 1.32712440018e+20;
            double rp = 74799130500.0;

            double expected = 5.97292764874982e-07;

            double actual = Formulae.Motion.MeanMotionParabola (mu, rp);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void OrbitalPeriodTest ()
        {
            double a = 149598261000.0;
            double muasqrt = 2.9784652977726422e+4;

            double expected = 3.1558319521054472e+7;

            double actual = Formulae.Motion.OrbitalPeriod (a, muasqrt);

            Assert.AreEqual (expected, actual, 1.0e-8);
        }

        [TestMethod ()]
        public void MeanAnomalyForTimeTest ()
        {
            double t = 5.0;
            double t0 = 2.0;
            double n = 7.0;

            double expected = 21.0;

            double actual = Formulae.Motion.MeanAnomalyForTime (t, t0, n);

            Assert.AreEqual (expected, actual);
        }

        #endregion

        #region Integrals

        [TestMethod ()]
        public void ArealVelocityNonParabolaTest ()
        {
            double mu = 1.32712440018e+20;
            double a = 149598261000.0;

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

        #region PlanarPosition

        [TestMethod ()]
        public void PlanarPositionComputeForCircleTest ()
        {
            double sin = 0.5;
            double cos = 0.5 * double.Sqrt (3.0);
            double anomaly = double.Pi / 6.0;
            double [] param = new double [] { 2.0 };

            (double x, double y, double r, double trueAnomaly) expected =
                (1.7320508075688773,
                 1.0,
                 2.0,
                 0.52359877559829887);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.PlanarPosition.ComputeForCircle (anomaly, sin, cos,
                param);

            Assert.AreEqual (expected.x, actual.x);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void PlanarPositionComputeForEllipseTest ()
        {
            double sin = 0.5;
            double cos = 0.5 * double.Sqrt (3.0);
            double [] param = new double [] { 2.0, 0.6, 0.8 };

            (double x, double y, double r, double trueAnomaly) expected =
                (0.53205080756887729,
                 0.8,
                 0.96076951545867362,
                 0.98390442268361651);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.PlanarPosition.ComputeForEllipse (sin, cos, param);

            Assert.AreEqual (expected.x, actual.x);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void PlanarPositionComputeForHyperbolaTest ()
        {
            double sh = 0.52109530549374736;
            double ch = 1.12762596520638079;
            double [] param = new double [] { 2.0, 1.4, 0.97979589711327124 };

            (double x, double y, double r, double trueAnomaly) expected =
                (0.54474806958723843,
                 1.02113408465552067,
                 1.1573527025778662,
                 1.08072980780868621);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.PlanarPosition.ComputeForHyperbola (sh, ch, param);

            Assert.AreEqual (expected.x, actual.x);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r, 1.0e-15);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        [TestMethod ()]
        public void PlanarPositionComputeForParabolaTest ()
        {
            double tanv2 = double.Sqrt (3.0) / 3.0;
            double [] param = new double [] { 2.0 };

            (double x, double y, double r, double trueAnomaly) expected =
                (1.3333333333333333,
                 2.3094010767585031,
                 2.6666666666666667,
                 1.0471975511965977);

            (double x, double y, double r, double trueAnomaly) actual = Formulae.PlanarPosition.ComputeForParabola (tanv2, param);

            Assert.AreEqual (expected.x, actual.x, 1.0e-15);
            Assert.AreEqual (expected.y, actual.y);
            Assert.AreEqual (expected.r, actual.r);
            Assert.AreEqual (expected.trueAnomaly, actual.trueAnomaly);
        }

        #endregion

        #region PlanarVelocity

        [TestMethod ()]
        public void PlanarVelocityComputeForCircleTest ()
        {
            double sin = 0.5 * double.Sqrt (3.0);
            double cos = 0.5;
            double [] param = new double [] { 8.8712555300358739e+8 };

            (double vx, double vy, double speed) expected = (-7.682732652474252e+8, 4.43562776501793695e+8, 8.8712555300358739e+8);

            (double vx, double vy, double speed) actual = Formulae.PlanarVelocity.ComputeForCircle (sin, cos, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-6);
            Assert.AreEqual (expected.vy, actual.vy);
            Assert.AreEqual (expected.speed, actual.speed);
        }

        [TestMethod ()]
        public void PlanarVelocityComputeForEllipseTest ()
        {
            double sin = 0.5 * double.Sqrt (3.0);
            double cos = 0.5;
            double [] param = new double [] { 8.8712555300358739e+8, 0.6, 0.8 };

            (double vx, double vy, double speed) expected = (-1.09753323606775029e+9, 5.0692888743062137e+8,
                1.2089483451268692e+9);

            (double vx, double vy, double speed) actual = Formulae.PlanarVelocity.ComputeForEllipse (sin, cos, param);

            Assert.AreEqual (expected.vx, actual.vx);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-7);
            Assert.AreEqual (expected.speed, actual.speed, 1.0e-6);
        }

        [TestMethod ()]
        public void PlanarVelocityComputeForHyperbolaTest ()
        {
            double sh = 0.52109530549374736;
            double ch = 1.12762596520638079;
            double [] param = new double [] { 8.8712555300358739e+8, 1.4, 0.97979589711327124 };

            (double vx, double vy, double speed) expected = (-798852346.435183, 1693752848.47108, 1872688917.868874);

            (double vx, double vy, double speed) actual = Formulae.PlanarVelocity.ComputeForHyperbola (sh, ch, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-6);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-5);
            Assert.AreEqual (expected.speed, actual.speed, 1.0e-5);
        }

        [TestMethod ()]
        public void PlanarVelocityComputeForParabolaTest_AfterPericenter ()
        {
            double r = 2.6666666666666667;
            double y = 2.3094010767585031;
            double [] param = new double [] { 1.32712440018e+20, 4.0 };

            (double vx, double vy, double speed) expected = (-4.98834466565563e+9, 8.64006640658074e+9, 9.9766893313112642e+9);

            (double vx, double vy, double speed) actual = Formulae.PlanarVelocity.ComputeForParabola (r, y, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-5);
            Assert.AreEqual (expected.vy, actual.vy);
            Assert.AreEqual (expected.speed, actual.speed);
        }

        [TestMethod ()]
        public void PlanarVelocityComputeForParabolaTest_Pericenter ()
        {
            double r = 2.0;
            double y = 0.0;
            double [] param = new double [] { 1.32712440018e+20, 4.0 };

            (double vx, double vy, double speed) expected = (0.0, 1.15200885421077E+10, 1.15200885421077E+10);

            (double vx, double vy, double speed) actual = Formulae.PlanarVelocity.ComputeForParabola (r, y, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-4);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-4);
            Assert.AreEqual (expected.speed, actual.speed, 1.0e-4);
        }

        [TestMethod ()]
        public void PlanarVelocityComputeForParabolaTest_BeforePericenter ()
        {
            double r = 2.6666666666666667;
            double y = -2.3094010767585031;
            double [] param = new double [] { 1.32712440018e+20, 4.0 };

            (double vx, double vy, double speed) expected = (4.98834466565563e+9, 8.64006640658074e+9, 9.9766893313112642e+9);

            (double vx, double vy, double speed) actual = Formulae.PlanarVelocity.ComputeForParabola (r, y, param);

            Assert.AreEqual (expected.vx, actual.vx, 1.0e-5);
            Assert.AreEqual (expected.vy, actual.vy, 1.0e-5);
            Assert.AreEqual (expected.speed, actual.speed);
        }

        #endregion

        #region KeplerEquation

        [TestMethod ()]
        public void KeplerEquationSolveForEllipseTest ()
        {
            double [,] M = new double [,]
            {
              { -double.Pi / 2.0,   -0.1,                  0.0, 0.1,                  double.Pi / 2.0,   3.0,              double.Pi,        3.2 },
              { -1.0707963267949,   -0.0500832916765859,   0.0, 0.0500832916765859,   1.0707963267949,   2.92943999597007, 3.14159265358979, 3.22918707171379 },
              { -0.770796326794897, -0.0201332666825375,   0.0, 0.0201332666825375,   0.770796326794897, 2.88710399355211, 3.14159265358979, 3.24669931474206 },
              { -0.670796326794897, -0.0101499250178547,   0.0, 0.0101499250178547,   0.670796326794897, 2.87299199274612, 3.14159265358979, 3.25253672908482 },
              { -0.580796326794897, -0.00116491751964014,  0.0, 0.00116491751964014,  0.580796326794897, 2.86029119202073, 3.14159265358979, 3.25779040199330 },
              { -0.571796326794897, -0.000266416769818673, 0.0, 0.000266416769818673, 0.571796326794897, 2.85902111194819, 3.14159265358979, 3.25831576928415 }
            };
            double [] e = new double [] { 0.0, 0.5, 0.8, 0.9, 0.99, 0.999 };

            double [] expected = new double [] { -double.Pi / 2.0, -0.1, 0.0, 0.1, double.Pi / 2.0, 3.0, double.Pi, 3.2 };

            for (int i = 0; i < e.Length; i++)
            {
                for (int j = 0; j < expected.Length; j++)
                {
                    double actual = Formulae.KeplerEquation.SolveForEllipse (M [i, j], e [i]);

                    Assert.AreEqual (expected [j], actual, 1.0e-14);
                }
            }
        }

        [TestMethod ()]
        public void KeplerEquationSolveForHyperbolaTest ()
        {
            double [,] M = new double [,]
            {
              { -1.881152026666050, -0.050250125029766000, 0.0, 0.050250125029766000, 1.881152026666050, 12.02681239111490, 14.18151638229680, 15.16882599484820 },
              { -1.190762355973860, -0.020200100023812800, 0.0, 0.020200100023812800, 1.190762355973860,  9.02144991289188, 10.71689457511950, 11.49506079587860 },
              { -0.960632465743128, -0.010183425021828400, 0.0, 0.010183425021828400, 0.960632465743128,  8.01966242015089,  9.56202063939373, 10.27047239622200 },
              { -0.753515564535471, -0.001168417520042460, 0.0, 0.001168417520042460, 0.753515564535471,  7.11805367668400,  8.52263409724053,  9.16834283653115 },
              { -0.732803874414705, -0.000266916769863859, 0.0, 0.000266916769863859, 0.732803874414705,  7.02789280233731,  8.41869544302521,  9.05812988056206 }
            };
            double [] e = new double [] { 1.5, 1.2, 1.1, 1.01, 1.001 };

            double [] expected = new double [] { -double.Pi / 2.0, -0.1, 0.0, 0.1, double.Pi / 2.0, 3.0, double.Pi, 3.2 };

            for (int i = 0; i < e.Length; i++)
            {
                for (int j = 0; j < expected.Length; j++)
                {
                    double actual = Formulae.KeplerEquation.SolveForHyperbola (M [i, j], e [i]);

                    Assert.AreEqual (expected [j], actual, 1.0e-14);
                }
            }
        }

        [TestMethod ()]
        public void KeplerEquationSolveBarkerEquationTest ()
        {
            double A = 6.12372435695795;

            double expected = 1.87726052751656;

            double actual = Formulae.KeplerEquation.SolveBarkerEquation (A);

            Assert.AreEqual (expected, actual, 1.0e-14);
        }

        #endregion
    }
}