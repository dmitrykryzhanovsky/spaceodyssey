using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;

namespace SpaceOdyssey.Tests
{
    [TestClass ()]
    public class EarthPrecessionTests
    {
        [TestMethod ()]
        public void EulerAnglesForPrecessionTest ()
        {
            double T0 = 0.0;
            double dT = 0.24983801049509377;

            (double alpha, double beta, double gamma) eulerAngles = EarthPrecession.EulerAnglesForPrecession (T0, dT);
            
            // Сделать вектор на координаты 2000 в радианах
            // Сделать вектор на координаты для данной эпохи в радианах
            // Сравнить
            // Подумать над тем, чтобы все публичные методы возвращали в радианах

            Assert.AreEqual (1, 1);
        }
    }
}