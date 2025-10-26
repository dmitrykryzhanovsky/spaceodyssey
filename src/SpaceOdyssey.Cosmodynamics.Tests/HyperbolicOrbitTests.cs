using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class HyperbolicOrbitTests
    {
        [TestMethod ()]
        public void CreateByPeriapsisTest ()
        {
            Mass   central = Astrodata.Sun.SI;
            Mass   probe   = Astrodata.Earth.SI;
            double rp      = 147098290052.82897;
            double e       = 1.98328877;

            HyperbolicOrbit actual = HyperbolicOrbit.CreateByPeriapsis (central, probe, rp, e, 2451545.0);

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
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Astrodata.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       rp: 2.0,
                                                                       e:  1.6,
                                                                       t0: 2451545.0);

            double trueAnomaly = double.Pi * (2.0 / 3.0);

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (26, actual, 1.0e-13);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_0 ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Astrodata.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0,
                                                                       t0:     2451545.0);

            double r = 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (0.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_60 ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Astrodata.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0,
                                                                       t0:     2451545.0);

            double r = 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_90 ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Astrodata.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0,
                                                                       t0:     2451545.0);

            double r = 6.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi / 2.0, actual);
        }               

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance_Asymptote ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Astrodata.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0,
                                                                       t0:     2451545.0);

            double r = double.PositiveInfinity;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (double.Pi * 2.0 / 3.0, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_IncorrectDistanceLess ()
        {
            HyperbolicOrbit orbit = HyperbolicOrbit.CreateByPeriapsis (center: Astrodata.Earth.SI,
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       rp:     2.0,
                                                                       e:      2.0,
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

        [TestMethod ()]
        public void ComputePositionTest ()
        {
            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center: Mass.CreateByGMSqrt (10.0),
                                                                       probe: Mass.ProbeZeroMass,
                                                                       a: 3.0,
                                                                       t0: 2.0);

            double t = 5.0;

            OrbitalPosition actual = orbit.ComputePosition (t);

            Assert.AreEqual (5.0, actual.Time);

            Assert.AreEqual (5.77350269189626, actual.PassedMeanAnomaly, 1.0e-14);
            Assert.AreEqual (-0.509682615283329, actual.M, 1.0e-14);
            Assert.AreEqual (-0.509682615283329, actual.E, 1.0e-14);

            Assert.AreEqual (2.61869821104968, actual.PlanarPosition.X, 1.0e-14);
            Assert.AreEqual (-1.46370067959444, actual.PlanarPosition.Y, 1.0e-14);
            Assert.AreEqual (3.0, actual.R, 1.0e-14);
            Assert.AreEqual (-0.509682615283329, actual.TrueAnomaly, 1.0e-14);

            Assert.AreEqual (2.81689327125629, actual.PlanarPosition.VX, 1.0e-14);
            Assert.AreEqual (5.03968705691975, actual.PlanarPosition.VY, 1.0e-14);
            Assert.AreEqual (5.77350269189626, actual.Speed, 1.0e-14);
        }
    }
}