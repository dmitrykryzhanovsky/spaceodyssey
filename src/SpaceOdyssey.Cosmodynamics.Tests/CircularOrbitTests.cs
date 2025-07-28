using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class CircularOrbitTests
    {
        [TestMethod ()]
        public void RangeARpTest ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit actual = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            Assert.AreEqual (1.0, actual.RangeARp);
        }

        [TestMethod ()]
        public void RangeRaATest ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit actual = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            Assert.AreEqual (1.0, actual.RangeRaA);
        }

        [TestMethod ()]
        public void RangeRaRpTest ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit actual = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            Assert.AreEqual (1.0, actual.RangeRaRp);
        }

        [TestMethod ()]
        public void CreateBySemiMajorAxisTest ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit actual = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            Assert.AreEqual (6471000.0, actual.A);
            Assert.AreEqual (6471000.0, actual.P);
            Assert.AreEqual (0.0, actual.E);
            Assert.AreEqual (6471000.0, actual.RPeri);
            Assert.AreEqual (6471000.0, actual.RApo);

            Assert.AreEqual (1.21286311340135e-3, actual.N, 1.0e-17);
            Assert.AreEqual (5180.45708353602, actual.T, 1.0e-11);
            Assert.AreEqual (7848.43720682015, actual.VMean, 1.0e-11);
            Assert.AreEqual (7848.43720682015, actual.VPeri, 1.0e-11);
            Assert.AreEqual (7848.43720682015, actual.VApo, 1.0e-11);

            Assert.AreEqual (-6.15979665893989e+7, actual.EnergyIntegral, 1.0e-7);
            Assert.AreEqual ( 5.07872371653332e+10, actual.ArealVelocity, 1.0e-4);
        }

        [TestMethod ()]
        public void RadiusTest ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            double trueAnomaly = 1.42;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (6471000.0, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_CorrectDistance ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            double r = 6471000.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.IsTrue (double.IsNaN (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_IncorrectDistanceLess ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            double r = 6470999.999;

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
        public void TrueAnomalyTest_IncorrectDistanceGreater ()
        {
            Mass   central = Data.Earth.SI;
            Mass   probe   = Mass.ProbeZeroMass;
            double a       = 6471000.0;

            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (central, probe, a, 2451545.0);

            double r = 6471000.001;

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
            // TODO: Начать с проверки этого теста
            CircularOrbit orbit = CircularOrbit.CreateBySemiMajorAxis (center: Mass.CreateByGMSqrt (10.0),
                                                                       probe:  Mass.ProbeZeroMass,
                                                                       a:      3.0,
                                                                       t0:     2.0);

            double t = 5.0;

            OrbitalPosition actual = orbit.ComputePosition (t);

            Assert.AreEqual (5.0, actual.Time);

            Assert.AreEqual (6.12372435695795, actual.MTotal, 1.0e-14);
            Assert.AreEqual (6.12372435695795, actual.M, 1.0e-14);
            Assert.AreEqual (6.12372435695795, actual.E, 1.0e-14);

            Assert.AreEqual (-7.57232126451531, actual.PlanarPosition.X, 1.0e-14);
            Assert.AreEqual (11.2635631650994, actual.PlanarPosition.Y, 1.0e-13);
            Assert.AreEqual (13.5723212645153, actual.R, 1.0e-13);
            Assert.AreEqual (2.16267826462284, actual.TrueAnomaly, 1.0e-14);

            Assert.AreEqual (-3.38802060241961, actual.PlanarPosition.VX, 1.0e-14);
            Assert.AreEqual (1.80476846594204, actual.PlanarPosition.VY, 1.0e-14);
            Assert.AreEqual (3.83873323090815, actual.Speed, 1.0e-14);
        }
    }
}