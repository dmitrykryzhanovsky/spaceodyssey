using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_E0 ()
        {
            Mass   central = Data.Sun.SI;
            Mass   probe   = Data.Earth.SI;
            double a       = 149598261000.0;
            double e       = 0.0;

            EllipticOrbit actual = EllipticOrbit.CreateBySemiMajorAxis (central, probe, a, e, 2451545.0);

            Assert.AreEqual (149598261000.0, actual.A);
            Assert.AreEqual (149598261000.0, actual.P);
            Assert.AreEqual (0.0, actual.E);
            Assert.AreEqual (149598261000.0, actual.RPeri);
            Assert.AreEqual (149598261000.0, actual.RApo);

            Assert.AreEqual (1.0, actual.RangeARp);
            Assert.AreEqual (1.0, actual.RangeRaA);
            Assert.AreEqual (1.0, actual.RangeRaRp);

            Assert.AreEqual (1.99097887285211e-7, actual.N, 1.0e-21);
            Assert.AreEqual (3.15582721286180e+7, actual.T, 1.0e-8);
            Assert.AreEqual (29784.6977066415, actual.VMean, 1.0e-10);
            Assert.AreEqual (29784.6977066415, actual.VPeri, 1.0e-10);            
            Assert.AreEqual (29784.6977066415, actual.VApo, 1.0e-10);

            Assert.AreEqual (-8.87128217476016e+8, actual.EnergyIntegral);
            Assert.AreEqual ( 4.45573898132426e+15, actual.ArealVelocity, 1.0e+1);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest_EEarth ()
        {
            Mass   central = Data.Sun.SI;
            Mass   probe   = Data.Earth.SI;
            double a       = 149598261000.0;
            double e       = 0.01671123;

            EllipticOrbit actual = EllipticOrbit.CreateBySemiMajorAxis (central, probe, a, e, 2451545.0);

            Assert.AreEqual (149598261000.0, actual.A);
            Assert.AreEqual (149556483410.509, actual.P, 1.0e-3);
            Assert.AreEqual (0.01671123, actual.E);
            Assert.AreEqual (147098290052.829, actual.RPeri, 1.0e-3);
            Assert.AreEqual (152098231947.171, actual.RApo, 1.0e-3);

            Assert.AreEqual (1.01699524138774, actual.RangeARp, 1.0e-14);
            Assert.AreEqual (1.01671123, actual.RangeRaA);
            Assert.AreEqual (1.03399048277547, actual.RangeRaRp, 1.0e-14);

            Assert.AreEqual (1.99097887285211e-7, actual.N, 1.0e-21);
            Assert.AreEqual (3.15582721286180e+7, actual.T, 1.0e-8);
            Assert.AreEqual (29784.6977066415, actual.VMean, 1.0e-10);
            Assert.AreEqual (30286.6659418261, actual.VPeri, 1.0e-10);
            Assert.AreEqual (29291.0490438264, actual.VApo, 1.0e-10);

            Assert.AreEqual (-8.87128217476016e+8, actual.EnergyIntegral);
            Assert.AreEqual ( 4.45573898132426e+15, actual.ArealVelocity, 1.0e+1);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI, 
                                                                       probe:  Mass.ProbeZeroMass, 
                                                                       a:  2.0, 
                                                                       e:  0.6, 
                                                                       t0: 2451545.0);

            double trueAnomaly = double.Pi * (2.0 / 3.0);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (1.8285714285714286, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_0 ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 1.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (0.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_60 ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 1.2;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_90 ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 1.5;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 2.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_120 ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi * 2.0 / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_180 ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_IncorrectDistanceLess ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 0.999999999999;

            bool flag = false;

            try
            {
                orbit.TrueAnomaly (r);
            }

            catch (ArgumentOutOfRangeException)
            {
                flag = true;
            }

            Assert.IsTrue (flag);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_IncorrectDistanceGteater ()
        {
            EllipticOrbit orbit = EllipticOrbit.CreateBySemiMajorAxis (center: Data.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a: 2.0,
                                                                       e: 0.5,
                                                                       t0: 2451545.0);

            double r = 3.000000000001;

            bool flag = false;

            try
            {
                orbit.TrueAnomaly (r);
            }

            catch (ArgumentOutOfRangeException)
            {
                flag = true;
            }

            Assert.IsTrue (flag);
        }
    }
}