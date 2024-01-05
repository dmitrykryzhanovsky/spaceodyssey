using Microsoft.VisualStudio.TestTools.UnitTesting;

using SpaceOdyssey.Cosmodynamics;

namespace SpaceOdyssey.Cosmodynamics.Tests
{
    [TestClass ()]
    public class EllipticOrbitTests
    {
        [TestMethod ()]
        public void SetOrbitalElementsBySemiMajorAxisTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double eccentricity = 0.0;
            double semiMajorAxis = 0.999999022929777;

            orbit.SetOrbitalElementsBySemiMajorAxis (eccentricity, semiMajorAxis);

            Assert.AreEqual (0.0, orbit.Eccentricity);
            Assert.AreEqual (1.0, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis);
            Assert.AreEqual (0.999999022929777, orbit.OrbitalParameter);
            Assert.AreEqual (0.999999022929777, orbit.B);
            Assert.AreEqual (0.999999022929777, orbit.Periapsis);
            Assert.AreEqual (0.999999022929777, orbit.Apoapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByMeanMotionTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double eccentricity = 0.25;
            double meanMotion = 0.0172021241615188;

            orbit.SetOrbitalElementsByMeanMotion (eccentricity, meanMotion);

            Assert.AreEqual (0.25, orbit.Eccentricity);
            Assert.AreEqual (0.96824583655185422, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15); 
            Assert.AreEqual (0.937499083996666, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.968244890507679, orbit.B, 1.0e-15);
            Assert.AreEqual (0.749999267197333, orbit.Periapsis, 1.0e-15);
            Assert.AreEqual (1.249998778662221, orbit.Apoapsis, 1.0e-15);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByOrbitalPeriodTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double eccentricity = 0.999999;
            double orbitalPeriod = 365.256363004;

            orbit.SetOrbitalElementsByOrbitalPeriod (eccentricity, orbitalPeriod);

            Assert.AreEqual (0.999999, orbit.Eccentricity);
            Assert.AreEqual (0.00141421320881966, orbit.E2Factor, 1.0e-13);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.000001999997046, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.001414211827034, orbit.B, 1.0e-13);
            Assert.AreEqual (0.000000999999023, orbit.Periapsis, 1.0e-15);
            Assert.AreEqual (1.999997045860531, orbit.Apoapsis, 1.0e-15);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByPeriapsisTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double eccentricity = 0.25;
            double periapsis = 0.749999267197333;

            orbit.SetOrbitalElementsByPeriapsis (eccentricity, periapsis);

            Assert.AreEqual (0.25, orbit.Eccentricity);
            Assert.AreEqual (0.96824583655185422, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.937499083996666, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.968244890507679, orbit.B, 1.0e-15);
            Assert.AreEqual (0.749999267197333, orbit.Periapsis);
            Assert.AreEqual (1.249998778662221, orbit.Apoapsis, 1.0e-15);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByPeriapsisAndMeanMotionTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double periapsis = 0.000000999999023;
            double meanMotion = 0.0172021241615188;

            orbit.SetOrbitalElementsByPeriapsisAndMeanMotion (periapsis, meanMotion);

            Assert.AreEqual (0.999999, orbit.Eccentricity);
            Assert.AreEqual (0.00141421320881966, orbit.E2Factor, 1.0e-13);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.000001999997046, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.001414211827034, orbit.B, 1.0e-13);
            Assert.AreEqual (0.000000999999023, orbit.Periapsis);
            Assert.AreEqual (1.999997045860531, orbit.Apoapsis, 1.0e-14);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByApoapsisTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double eccentricity = 0.25;
            double apoapsis = 1.249998778662221;

            orbit.SetOrbitalElementsByApoapsis (eccentricity, apoapsis);

            Assert.AreEqual (0.25, orbit.Eccentricity);
            Assert.AreEqual (0.96824583655185422, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.937499083996666, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.968244890507679, orbit.B, 1.0e-15);
            Assert.AreEqual (0.749999267197333, orbit.Periapsis, 1.0e-15);
            Assert.AreEqual (1.249998778662221, orbit.Apoapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }

        [TestMethod ()]
        public void SetOrbitalElementsByApsisDistancesTest ()
        {
            EllipticOrbit orbit = new EllipticOrbit (SolarSystem.Sun);
            double periapsis = 0.749999267197333;
            double apoapsis = 1.249998778662221;

            orbit.SetOrbitalElementsByApsisDistances (periapsis, apoapsis);

            Assert.AreEqual (0.25, orbit.Eccentricity, 1.0e-15);
            Assert.AreEqual (0.96824583655185422, orbit.E2Factor);

            Assert.AreEqual (0.999999022929777, orbit.SemiMajorAxis, 1.0e-15);
            Assert.AreEqual (0.937499083996666, orbit.OrbitalParameter, 1.0e-15);
            Assert.AreEqual (0.968244890507679, orbit.B, 1.0e-15);
            Assert.AreEqual (0.749999267197333, orbit.Periapsis);
            Assert.AreEqual (1.249998778662221, orbit.Apoapsis);

            Assert.AreEqual (0.0172021241615188, orbit.MeanMotion, 1.0e-16);
            Assert.AreEqual (365.256363004, orbit.OrbitalPeriod, 1.0e-12);
        }
    }
}