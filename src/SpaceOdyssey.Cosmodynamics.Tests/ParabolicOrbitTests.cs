using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class ParabolicOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   central = Data.Sun.SI;
            Mass   probe   = Data.Earth.SI;
            double rp      = 74799130500.0;

            ParabolicOrbit actual = ParabolicOrbit.CreateByPeriapsis (central, probe, rp, 2451545.0);

            Assert.AreEqual (149598261000.0, actual.P);
            Assert.AreEqual (1.0, actual.E);
            Assert.AreEqual (74799130500.0, actual.RPeri);

            Assert.AreEqual (double.Pi, actual.Asymptote);

            Assert.AreEqual (59569.395413283, actual.VPeri, 1.0e-9);

            Assert.AreEqual (0.0, actual.EnergyIntegral);
            Assert.AreEqual (4.45573898132426e+15, actual.ArealVelocity, 1.0e+1);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

            double trueAnomaly = double.Pi * (2.0 / 3.0);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (8.0, actual, 1.0e-14);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_0 ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

            double r = 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (0.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_60 ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

            double r = 8.0 / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_90 ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

            double r = 4.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 2.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_120 ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

            double r = 8.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi * 2.0 / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_Asymptote ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

            double r = double.PositiveInfinity;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_IncorrectDistanceLess ()
        {
            ParabolicOrbit orbit = ParabolicOrbit.CreateByPeriapsis (center: Data.Earth.SI,
                                                                     probe:  Data.ProbeZeroMass,
                                                                     rp:     2.0,
                                                                     t0:     2451545.0);

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