using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    public class EarthPrecessionTests
    {
        [TestClass ()]
        public class EquatorialTests
        {
            [TestClass ()]
            public class ReferenceAnglesInArcsecTests
            {
                [TestMethod ()]
                public void VernalEquinoxTest ()
                {
                    double T0 = 0.1;
                    double dT = 0.24983801049509377;

                    double expected = 576.234954477912;

                    double actual = EarthPrecession.Equatorial.ReferenceAnglesInArcsec.VernalEquinox (T0, dT);

                    Assert.AreEqual (expected, actual, 1.0e-11);
                }

                [TestMethod ()]
                public void NutationTest ()
                {
                    double T0 = 0.1;
                    double dT = 0.24983801049509377;

                    double expected = 500.704443644915;

                    double actual = EarthPrecession.Equatorial.ReferenceAnglesInArcsec.Nutation (T0, dT);

                    Assert.AreEqual (expected, actual, 1.0e-11);
                }

                [TestMethod ()]
                public void InLongitudeTest ()
                {
                    double T0 = 0.1;
                    double dT = 0.24983801049509377;

                    double expected = 0.0494915704885585;

                    double actual = EarthPrecession.Equatorial.ReferenceAnglesInArcsec.InLongitude (T0, dT);

                    Assert.AreEqual (expected, actual, 1.0e-15);
                }
            }

            [TestClass ()]
            public class ReferenceAnglesJ2000InArcsecTests
            {
                [TestMethod ()]
                public void VernalEquinoxTest ()
                {
                    double dT = 0.24983801049509377;

                    double expected = 576.20006560145;

                    double actual = EarthPrecession.Equatorial.ReferenceAnglesJ2000InArcsec.VernalEquinox (dT);

                    Assert.AreEqual (expected, actual, 1.0e-11);
                }

                [TestMethod ()]
                public void NutationTest ()
                {
                    double dT = 0.24983801049509377;

                    double expected = 500.725764218992;

                    double actual = EarthPrecession.Equatorial.ReferenceAnglesJ2000InArcsec.Nutation (dT);

                    Assert.AreEqual (expected, actual, 1.0e-11);
                }

                [TestMethod ()]
                public void InLongitudeTest ()
                {
                    double dT = 0.24983801049509377;

                    double expected = 0.0494890050663643;

                    double actual = EarthPrecession.Equatorial.ReferenceAnglesJ2000InArcsec.InLongitude (dT);

                    Assert.AreEqual (expected, actual, 1.0e-15);
                }
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                EulerAngles expected = new EulerAngles (0.00279366589464422, 0.00242748364471393, 0.00279390583654895);

                EulerAngles actual = EarthPrecession.Equatorial.EulerAnglesForPrecession (T0, dT);

                Assert.AreEqual (expected.Alpha, actual.Alpha, 1.0e-11);
                Assert.AreEqual (expected.Beta,  actual.Beta,  1.0e-11);
                Assert.AreEqual (expected.Gamma, actual.Gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionJ2000Test ()
            {
                double dT = 0.24983801049509377;

                EulerAngles expected = new EulerAngles (0.00279349674859795, 0.00242758700977395, 0.00279373667806516);

                EulerAngles actual = EarthPrecession.Equatorial.EulerAnglesForPrecessionJ2000 (dT);

                Assert.AreEqual (expected.Alpha, actual.Alpha, 1.0e-11);
                Assert.AreEqual (expected.Beta,  actual.Beta,  1.0e-11);
                Assert.AreEqual (expected.Gamma, actual.Gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void UpdateCoordinatesTest_ThetaPerseiAt2462088_Meeus_Polar3 ()
            {
                double dT = Time.GetJulianCentirues (2462088.69);

                Polar3 thetaPerseiAt2462088 = new Polar3 (1.0, 0.859186320848639, 0.716528561944535);

                Polar3 expected = new Polar3 (1.0, 0.861293515032213, 0.725135653150745);

                EulerAngles eulerAngles = EarthPrecession.Equatorial.EulerAnglesForPrecessionJ2000 (dT);

                Polar3 actual = EarthPrecession.Equatorial.UpdateCoordinates (thetaPerseiAt2462088, eulerAngles);

                Assert.AreEqual (0.2886705, dT, 1.0e-7);
                Assert.AreEqual (0.00322770865332424, eulerAngles.Alpha, 1.0e-10);
                Assert.AreEqual (0.00280488421910873, eulerAngles.Beta,  1.0e-9);
                Assert.AreEqual (0.00322802911516745, eulerAngles.Gamma, 1.0e-10);
                Assert.AreEqual (expected.Latitude,   actual.Latitude,   1.0e-8);
                Assert.AreEqual (expected.Longitude,  actual.Longitude,  1.0e-7);
            }

            [TestMethod ()]
            public void UpdateCoordinatesTest_ThetaPerseiAt2462088_Meeus_UnitPolar3 ()
            {
                double dT = Time.GetJulianCentirues (2462088.69);

                UnitPolar3 thetaPerseiAt2462088 = new UnitPolar3 (0.859186320848639, 0.716528561944535);

                UnitPolar3 expected = new UnitPolar3 (0.861293515032213, 0.725135653150745);

                EulerAngles eulerAngles = EarthPrecession.Equatorial.EulerAnglesForPrecessionJ2000 (dT);

                Polar3 actual = EarthPrecession.Equatorial.UpdateCoordinates (thetaPerseiAt2462088, eulerAngles);

                Assert.AreEqual (0.2886705, dT, 1.0e-7);
                Assert.AreEqual (0.00322770865332424, eulerAngles.Alpha, 1.0e-10);
                Assert.AreEqual (0.00280488421910873, eulerAngles.Beta,  1.0e-9);
                Assert.AreEqual (0.00322802911516745, eulerAngles.Gamma, 1.0e-10);
                Assert.AreEqual (expected.Latitude,   actual.Latitude,   1.0e-8);
                Assert.AreEqual (expected.Longitude,  actual.Longitude,  1.0e-7);
            }
        }

        [TestClass ()]
        public class EclipticTests
        {
            [TestClass ()]
            public class ReferenceAnglesInArcsecTests
            {
                [TestMethod ()]
                public void VernalEquinoxTest ()
                {
                    double T0 = 0.1;
                    double dT = 0.24983801049509377;

                    double expected = 629666.614220079;

                    double actual = EarthPrecession.Ecliptic.ReferenceAnglesInArcsec.VernalEquinox (T0, dT);

                    Assert.AreEqual (expected, actual, 1.0e-6);
                }

                [TestMethod ()]
                public void NutationTest ()
                {
                    double T0 = 0.1;
                    double dT = 0.24983801049509377;

                    double expected = 11.739406429065;

                    double actual = EarthPrecession.Ecliptic.ReferenceAnglesInArcsec.Nutation (T0, dT);

                    Assert.AreEqual (expected, actual, 1.0e-12);
                }

                [TestMethod ()]
                public void InLongitudeTest ()
                {
                    double T0 = 0.1;
                    double dT = 0.24983801049509377;

                    double expected = 1256.58436483115;

                    double actual = EarthPrecession.Ecliptic.ReferenceAnglesInArcsec.InLongitude (T0, dT);

                    Assert.AreEqual (expected, actual, 1.0e-11);
                }
            }

            [TestClass ()]
            public class ReferenceAnglesJ2000InArcsecTests
            {
                [TestMethod ()]
                public void VernalEquinoxTest ()
                {
                    double dT = 0.24983801049509377;

                    double expected = 629337.67288245;

                    double actual = EarthPrecession.Ecliptic.ReferenceAnglesJ2000InArcsec.VernalEquinox (dT);

                    Assert.AreEqual (expected, actual, 1.0e-6);
                }

                [TestMethod ()]
                public void NutationTest ()
                {
                    double dT = 0.24983801049509377;

                    double expected = 11.7410508827589;

                    double actual = EarthPrecession.Ecliptic.ReferenceAnglesJ2000InArcsec.Nutation (dT);

                    Assert.AreEqual (expected, actual, 1.0e-12);
                }

                [TestMethod ()]
                public void InLongitudeTest ()
                {
                    double dT = 0.24983801049509377;

                    double expected = 1256.52884469653;

                    double actual = EarthPrecession.Ecliptic.ReferenceAnglesJ2000InArcsec.InLongitude (dT);

                    Assert.AreEqual (expected, actual, 1.0e-11);
                }
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionTest ()
            {
                double T0 = 0.1;
                double dT = 0.24983801049509377;

                EulerAngles expected = new EulerAngles (3.05270989111815, 5.69142484491593e-5, -3.05880198403353);

                EulerAngles actual = EarthPrecession.Ecliptic.EulerAnglesForPrecession (T0, dT);

                Assert.AreEqual (expected.Alpha, actual.Alpha, 1.0e-11);
                Assert.AreEqual (expected.Beta,  actual.Beta,  1.0e-18);
                Assert.AreEqual (expected.Gamma, actual.Gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void EulerAnglesForPrecessionJ2000Test ()
            {
                double dT = 0.24983801049509377;

                EulerAngles expected = new EulerAngles (3.0511151385105, 5.69222209856469e-5, -3.05720696225667);

                EulerAngles actual = EarthPrecession.Ecliptic.EulerAnglesForPrecessionJ2000 (dT);

                Assert.AreEqual (expected.Alpha, actual.Alpha, 1.0e-11);
                Assert.AreEqual (expected.Beta,  actual.Beta,  1.0e-18);
                Assert.AreEqual (expected.Gamma, actual.Gamma, 1.0e-11);
            }

            [TestMethod ()]
            public void UpdateCoordinatesTest_MarsAtJ2000_Stellarium_Polar3 ()
            {
                Polar3 marsAtJ2000 = new Polar3 (1.0, 0.06406037093972742897700971000097, 2.153471103877435781735340725301);

                Polar3 expected = new Polar3 (1.0, 0.06410497379838950628841998209838, 2.1595618181532148824228108161689);

                EulerAngles eulerAngles = new EulerAngles (3.0511151385105, 5.69222209856469e-5, -3.05720696225667);                                

                Polar3 actual = EarthPrecession.Ecliptic.UpdateCoordinates (marsAtJ2000, eulerAngles); ;

                Assert.AreEqual (expected.Latitude,  actual.Latitude,  1.0e-7);
                Assert.AreEqual (expected.Longitude, actual.Longitude, 1.0e-5);
            }

            [TestMethod ()]
            public void UpdateCoordinatesTest_MarsAtJ2000_Stellarium_UnitPolar3 ()
            {
                UnitPolar3 marsAtJ2000 = new UnitPolar3 (0.06406037093972742897700971000097, 2.153471103877435781735340725301);

                UnitPolar3 expected = new UnitPolar3 (0.06410497379838950628841998209838, 2.1595618181532148824228108161689);

                EulerAngles eulerAngles = new EulerAngles (3.0511151385105, 5.69222209856469e-5, -3.05720696225667);

                UnitPolar3 actual = EarthPrecession.Ecliptic.UpdateCoordinates (marsAtJ2000, eulerAngles); ;

                Assert.AreEqual (expected.Latitude,  actual.Latitude,  1.0e-7);
                Assert.AreEqual (expected.Longitude, actual.Longitude, 1.0e-5);
            }

            [TestMethod ()]
            public void UpdateCoordinatesTest_VenusAt1643074_Meeus_Polar3 ()
            {
                double dT = Time.GetJulianCentirues (1643074.5);

                Polar3 venusAt1643074 = new Polar3 (1.0, 0.0308136134110347, 2.60895202526861);                

                Polar3 expected = new Polar3 (1.0, 0.0281870674197084, 2.07177563528735);

                EulerAngles eulerAngles = EarthPrecession.Ecliptic.EulerAnglesForPrecessionJ2000 (dT);

                Polar3 actual = EarthPrecession.Ecliptic.UpdateCoordinates (venusAt1643074, eulerAngles); ;

                Assert.AreEqual (-22.134716, dT, 1.0e-6);
                Assert.AreEqual (  3.14559364636707,    eulerAngles.Alpha, 1.0e-6);
                Assert.AreEqual ( -0.00512557144011029, eulerAngles.Beta,  1.0e-8);
                Assert.AreEqual ( -2.60855017775275,    eulerAngles.Gamma, 1.0e-6);
                Assert.AreEqual (expected.Latitude,     actual.Latitude,   1.0e-5);
                Assert.AreEqual (expected.Longitude,    actual.Longitude,  1.0e-5);
            }

            [TestMethod ()]
            public void UpdateCoordinatesTest_VenusAt1643074_Meeus_UnitPolar3 ()
            {
                double dT = Time.GetJulianCentirues (1643074.5);

                UnitPolar3 venusAt1643074 = new UnitPolar3 (0.0308136134110347, 2.60895202526861);

                UnitPolar3 expected = new UnitPolar3 (0.0281870674197084, 2.07177563528735);

                EulerAngles eulerAngles = EarthPrecession.Ecliptic.EulerAnglesForPrecessionJ2000 (dT);

                UnitPolar3 actual = EarthPrecession.Ecliptic.UpdateCoordinates (venusAt1643074, eulerAngles); ;

                Assert.AreEqual (-22.134716, dT, 1.0e-6);
                Assert.AreEqual (  3.14559364636707,    eulerAngles.Alpha, 1.0e-6);
                Assert.AreEqual ( -0.00512557144011029, eulerAngles.Beta,  1.0e-8);
                Assert.AreEqual ( -2.60855017775275,    eulerAngles.Gamma, 1.0e-6);
                Assert.AreEqual (expected.Latitude,     actual.Latitude,   1.0e-5);
                Assert.AreEqual (expected.Longitude,    actual.Longitude,  1.0e-5);
            }
        }
    }
}