using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceOdyssey.Tests
{
    // https://apps.aavso.org/v2/tools/julian-date-converter/
    // https://ssd.jpl.nasa.gov/tools/jdc/#/cd 

    [TestClass ()]
    public class JDTests
    {
        [TestMethod ()]
        public void GetJulianCenturiesTest_AtReferenceDate ()
        {
            double jd             = 2451545.0;
            double referenceEpoch = 2451545.0;

            double expected = 0.0;

            double actual = JD.GetJulianCenturies (jd, referenceEpoch);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianCenturiesTest_AfterReferenceDate ()
        {
            double jd             = 2451545.0;
            double referenceEpoch = 2415020.0;

            double expected = 1.0;

            double actual = JD.GetJulianCenturies (jd, referenceEpoch);

            Assert.AreEqual (expected, actual);
        }

        [TestMethod ()]
        public void GetJulianCenturiesTest_BeforeReferenceDate ()
        {
            double jd             = 2415020.0;
            double referenceEpoch = 2451545.0;

            double expected = -1.0;

            double actual = JD.GetJulianCenturies (jd, referenceEpoch);

            Assert.AreEqual (expected, actual);
        }
    }
}