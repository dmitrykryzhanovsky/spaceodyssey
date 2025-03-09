using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class HyperbolicOrbitTests
    {
        [TestMethod ()]
        public void CreateAminPTest_Common ()
        {
            double amin = 2.0;
            double p    = 5.0;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminP (amin, p);

            Assert.AreEqual ( 5.0, orbit.P);
            Assert.AreEqual ( 1.5, orbit.E);
            Assert.AreEqual (-4.0, orbit.A);
            Assert.AreEqual ( 2.0, orbit.Amin);
            Assert.AreEqual ( 2.3005239830218629826861183514531, orbit.Asymptote);
        }

        [TestMethod ()]
        public void CreateAminPTest_AminZero ()
        {
            double amin = 0.0;
            double p    = 5.0;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminP (amin, p);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminPTest_AminNegative ()
        {
            double amin = -2.0;
            double p    =  5.0;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminP (amin, p);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminPTest_PLessThanAmin ()
        {
            double amin = 2.0;
            double p    = 1.999999999999999;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminP (amin, p);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminPTest_PEqualsAmin ()
        {
            double amin = 2.0;
            double p    = 2.0;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminP (amin, p);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminETest_Common ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            Assert.AreEqual ( 5.0, orbit.P);
            Assert.AreEqual ( 1.5, orbit.E);
            Assert.AreEqual (-4.0, orbit.A);
            Assert.AreEqual ( 2.0, orbit.Amin);
            Assert.AreEqual ( 2.3005239830218629826861183514531, orbit.Asymptote);
        }

        [TestMethod ()]
        public void CreateAminETest_AminZero ()
        {
            double amin = 0.0;
            double e    = 1.5;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminETest_AminNegative ()
        {
            double amin = -2.0;
            double e    =  1.5;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminETest_ELessThanOne ()
        {
            double amin = 2.0;
            double e    = 0.999999999999999;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void CreateAminETest_EOne ()
        {
            double amin = 2.0;
            double e    = 1.0;

            bool wasException = false;

            try
            {
                HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }

        [TestMethod ()]
        public void RadiusTest_Anomaly0 ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double trueAnomaly = 0.0;

            double expected = 2.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI_3 ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double trueAnomaly = double.Pi / 3.0;

            double expected = 20.0 / 7.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void RadiusTest_AnomalyPI_2 ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double trueAnomaly = double.Pi / 2.0;

            double expected = 5.0;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void RadiusTest_Asymptote ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double trueAnomaly = 2.3005239830218629826861183514531;

            double actual = orbit.Radius (trueAnomaly);

            Assert.AreEqual (true, double.IsPositiveInfinity (actual));
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Anomaly0 ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double r = 2.0;

            double expected = 0.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI_3 ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double r = 20.0 / 7.0;

            double expected = double.Pi / 3.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual, 1.0e-15);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_AnomalyPI_2 ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double r = 5.0;

            double expected = double.Pi / 2.0;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_Asymptote ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            double r = double.PositiveInfinity;

            double expected = 2.3005239830218629826861183514531;

            double actual = orbit.TrueAnomaly (r);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void TrueAnomalyTest_RadiusLessThanAmin ()
        {
            double amin = 2.0;
            double e    = 1.5;

            HyperbolicOrbit orbit = HyperbolicOrbit.CreateAminE (amin, e);

            bool wasException = false;

            try
            {
                orbit.TrueAnomaly (1.999999999999999);
            }

            catch (ArgumentOutOfRangeException)
            {
                wasException = true;
            }

            Assert.AreEqual (true, wasException);
        }
    }
}