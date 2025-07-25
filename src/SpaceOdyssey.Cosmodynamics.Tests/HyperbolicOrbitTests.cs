﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class HyperbolicOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   central = Data.SunSI;
            Mass   probe   = Data.EarthSI;
            double rp      = 147098290052.82897;
            double e       = 1.98328877;

            HyperbolicOrbit actual = HyperbolicOrbit.CreateByPeriapsis (central, probe, rp, e);

            Assert.AreEqual (-149598261000.0, actual.A, 1.0e-4);
            Assert.AreEqual ( 438836676800.80737, actual.P);
            Assert.AreEqual ( 1.98328877, actual.E);
            Assert.AreEqual ( 147098290052.82897, actual.RPeri);

            Assert.AreEqual (2.0992667373965830, actual.Asymptote);

            Assert.AreEqual (1.99097887285211e-7, actual.N, 1.0e-21);
            Assert.AreEqual (51880.040177546139, actual.VPeri);

            Assert.AreEqual (8.87128217476016e+8, actual.EnergyIntegral, 1.0e-6);
            Assert.AreEqual (4.45573898132426e+15, actual.ArealVelocity, 1.0e+1);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                       probe:  Data.ProbeZeroMass,
                                                                       rp: 2.0,
                                                                       e:  1.6);

            double trueAnomaly = double.Pi * (2.0 / 3.0);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (26, actual, 1.0e-13);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_0 ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                       probe:  Data.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0);

            double r = 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (0.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_60 ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                       probe:  Data.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0);

            double r = 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_90 ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                       probe:  Data.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0);

            double r = 6.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 2.0, actual);
        }               

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_Asymptote ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                       probe:  Data.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0);

            double r = double.PositiveInfinity;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi * 2.0 / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_IncorrectDistanceLess ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Data.EarthSI,
                                                                       probe:  Data.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0);

            double r = 1.999999999999;

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