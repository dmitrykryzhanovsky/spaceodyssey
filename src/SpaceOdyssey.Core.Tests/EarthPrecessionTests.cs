using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    public class EarthPrecessionTests
    {
        [TestClass ()]
        public class Equatorial
        {
            [TestMethod ()]
            public void VernalEquinoxPrecessionInArcsecTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                double expected = 576.234954477912;

                double actual = EarthPrecession.Equatorial.VernalEquinoxInArcsec (T0, dT);

                Assert.AreEqual (expected, actual, 1.0e-11);
            }

            [TestMethod ()]
            public void VernalEquinoxPrecessionJ2000InArcsecTest ()
            {
                double dT = 0.24983801049509377;

                double expected = 576.20006560145;

                double actual = EarthPrecession.Equatorial.VernalEquinoxJ2000InArcsec (dT);

                Assert.AreEqual (expected, actual, 1.0e-11);
            }

            [TestMethod ()]
            public void PrecessionNutationInArcsecTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                double expected = 500.704443644915;

                double actual = EarthPrecession.Equatorial.NutationInArcsec (T0, dT);

                Assert.AreEqual (expected, actual, 1.0e-11);
            }

            [TestMethod ()]
            public void PrecessionNutationJ2000InArcsecTest ()
            {
                double dT = 0.24983801049509377;

                double expected = 500.725764218992;

                double actual = EarthPrecession.Equatorial.NutationJ2000InArcsec (dT);

                Assert.AreEqual (expected, actual, 1.0e-11);
            }

            [TestMethod ()]
            public void LongitudePrecessionInArcsecTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                double expected = 0.0494915704885585;

                double actual = EarthPrecession.Equatorial.InLongitudeInArcsec (T0, dT);

                Assert.AreEqual (expected, actual, 1.0e-15);
            }

            [TestMethod ()]
            public void LongitudePrecessionJ2000InArcsecTest ()
            {
                double dT = 0.24983801049509377;

                double expected = 0.0494890050663643;

                double actual = EarthPrecession.Equatorial.InLongitudeJ2000InArcsec (dT);

                Assert.AreEqual (expected, actual, 1.0e-15);
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                (double alpha, double beta, double gamma) expected = (0.00279366589464422, 0.00242748364471393, 0.00279390583654895);

                (double alpha, double beta, double gamma) actual = EarthPrecession.Equatorial.EulerAnglesForPrecession (T0, dT);

                Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-11);
                Assert.AreEqual (expected.beta, actual.beta, 1.0e-11);
                Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionJ2000Test ()
            {
                double dT = 0.24983801049509377;

                (double alpha, double beta, double gamma) expected = (0.00279349674859795, 0.00242758700977395, 0.00279373667806516);

                (double alpha, double beta, double gamma) actual = EarthPrecession.Equatorial.EulerAnglesForPrecessionJ2000 (dT);

                Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-11);
                Assert.AreEqual (expected.beta, actual.beta, 1.0e-11);
                Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void TransformCoordinatesTest_ThetaPerseiAt2462088_Meeus ()
            {
                double dT = Time.GetJulianCentirues (2462088.69);

                (double latitude, double longitude) thetaPerseiAt2462088 = (0.859186320848639, 0.716528561944535);

                (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Equatorial.EulerAnglesForPrecessionJ2000 (dT);

                (double latitude, double longitude) expected = (0.861293515032213, 0.725135653150745);

                (double latitude, double longitude) actual = EarthPrecession.Equatorial.UpdateCoordinates (thetaPerseiAt2462088.latitude, thetaPerseiAt2462088.longitude, eulerAngles); ;

                Assert.AreEqual (0.2886705, dT, 1.0e-7);
                Assert.AreEqual (0.00322770865332424, eulerAngles.alpha, 1.0e-10);
                Assert.AreEqual (0.00280488421910873, eulerAngles.beta, 1.0e-9);
                Assert.AreEqual (0.00322802911516745, eulerAngles.gamma, 1.0e-10);
                Assert.AreEqual (expected.latitude, actual.latitude, 1.0e-8);
                Assert.AreEqual (expected.longitude, actual.longitude, 1.0e-7);
            }
        }

        [TestClass ()]
        public class Ecliptic
        {
            [TestMethod ()]
            public void VernalEquinoxPrecessionInArcsecTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                double expected = 629666.614220079;

                double actual = EarthPrecession.Ecliptic.VernalEquinoxPrecessionInArcsec (T0, dT);

                Assert.AreEqual (expected, actual, 1.0e-6);
            }

            [TestMethod ()]
            public void VernalEquinoxPrecessionJ2000InArcsecTest ()
            {
                double dT = 0.24983801049509377;

                double expected = 629337.67288245;

                double actual = EarthPrecession.Ecliptic.VernalEquinoxPrecessionJ2000InArcsec (dT);

                Assert.AreEqual (expected, actual, 1.0e-6);
            }

            [TestMethod ()]
            public void PrecessionNutationInArcsecTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                double expected = 11.739406429065;

                double actual = EarthPrecession.Ecliptic.PrecessionNutationInArcsec (T0, dT);

                Assert.AreEqual (expected, actual, 1.0e-12);
            }

            [TestMethod ()]
            public void PrecessionNutationJ2000InArcsecTest ()
            {
                double dT = 0.24983801049509377;

                double expected = 11.7410508827589;

                double actual = EarthPrecession.Ecliptic.PrecessionNutationJ2000InArcsec (dT);

                Assert.AreEqual (expected, actual, 1.0e-12);
            }

            [TestMethod ()]
            public void LongitudePrecessionInArcsecTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                double expected = 1256.58436483115;

                double actual = EarthPrecession.Ecliptic.LongitudePrecessionInArcsec (T0, dT);

                Assert.AreEqual (expected, actual, 1.0e-11);
            }

            [TestMethod ()]
            public void LongitudePrecessionJ2000InArcsecTest ()
            {
                double dT = 0.24983801049509377;

                double expected = 1256.52884469653;

                double actual = EarthPrecession.Ecliptic.LongitudePrecessionJ2000InArcsec (dT);

                Assert.AreEqual (expected, actual, 1.0e-11);
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                (double alpha, double beta, double gamma) expected = (3.05270989111815, 5.69142484491593e-5, -3.05880198403353);

                (double alpha, double beta, double gamma) actual = EarthPrecession.Ecliptic.EulerAnglesForPrecession (T0, dT);

                Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-11);
                Assert.AreEqual (expected.beta, actual.beta, 1.0e-18);
                Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionJ2000Test ()
            {
                double dT = 0.24983801049509377;

                (double alpha, double beta, double gamma) expected = (3.0511151385105, 5.69222209856469e-5, -3.05720696225667);

                (double alpha, double beta, double gamma) actual = EarthPrecession.Ecliptic.EulerAnglesForPrecessionJ2000 (dT);

                Assert.AreEqual (expected.alpha, actual.alpha, 1.0e-11);
                Assert.AreEqual (expected.beta, actual.beta, 1.0e-18);
                Assert.AreEqual (expected.gamma, actual.gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void TransformCoordinatesTest_MarsAtJ2000_Stellarium ()
            {
                (double latitude, double longitude) marsAtJ2000 = (0.06406037093972742897700971000097, 2.153471103877435781735340725301);

                (double alpha, double beta, double gamma) eulerAngles = (3.0511151385105, 5.69222209856469e-5, -3.05720696225667);

                (double latitude, double longitude) expected = (0.06410497379838950628841998209838, 2.1595618181532148824228108161689);

                (double latitude, double longitude) actual = EarthPrecession.Ecliptic.TransformCoordinates (marsAtJ2000.latitude, marsAtJ2000.longitude, eulerAngles); ;

                Assert.AreEqual (expected.latitude, actual.latitude, 1.0e-7);
                Assert.AreEqual (expected.longitude, actual.longitude, 1.0e-5);
            }

            [TestMethod ()]
            public void TransformCoordinatesTest_VenusAt1643074_Meeus ()
            {
                double dT = Time.GetJulianCentirues (1643074.5);

                (double latitude, double longitude) venusAt1643074 = (0.0308136134110347, 2.60895202526861);

                (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.Ecliptic.EulerAnglesForPrecessionJ2000 (dT);

                (double latitude, double longitude) expected = (0.0281870674197084, 2.07177563528735);

                (double latitude, double longitude) actual = EarthPrecession.Ecliptic.TransformCoordinates (venusAt1643074.latitude, venusAt1643074.longitude, eulerAngles); ;

                Assert.AreEqual (-22.134716, dT, 1.0e-6);
                Assert.AreEqual (  3.14559364636707, eulerAngles.alpha, 1.0e-6);
                Assert.AreEqual ( -0.00512557144011029, eulerAngles.beta, 1.0e-8);
                Assert.AreEqual ( -2.60855017775275, eulerAngles.gamma, 1.0e-6);
                Assert.AreEqual (expected.latitude, actual.latitude, 1.0e-5);
                Assert.AreEqual (expected.longitude, actual.longitude, 1.0e-5);
            }
        }
    }
}