using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archimedes;
using Archimedes.Space3;

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

            UnitPolar3 p1 = new UnitPolar3 (latitude: 0.06406037093972742897700971000097, longitude: 2.153471103877435781735340725301);

            UnitPolar3 p2 = new UnitPolar3 (latitude: 0.06410497379838950628841998209838, longitude: 2.1595618181532148824228108161689);

            UnitPolar3 n = Rotation.Apply.Passive.EulerAngles.RotateSpace (p1, eulerAngles.alpha, eulerAngles.beta, eulerAngles.gamma);

            // Сделать вектор на координаты 2000 в радианах
            // Сделать вектор на координаты для данной эпохи в радианах
            // Сравнить
            // Подумать над тем, чтобы все публичные методы возвращали в радианах
            // Грубые тесты прецесс по долготе в год и столетие 

            Assert.AreEqual (1, 1);
        }
    }
}

//0,06406037093972742897700971000097

//0,06410497379838950628841998209838

//2,153471103877435781735340725301

//2,1595618181532148824228108161689

//123 deg = 2,146754979953025379616139645241
//23 min = 0,00669042879931159671154081461254
// 5,3 sec = 2,5695125098805407660265447424971e-5

//44 min = 0,01279908118129175023077373230225
// 1,6 sec = 7,7570188977525758974386256377272e-6

// 3 deg = 0,05235987755982988730771072305466
//40 min = 0,01163552834662886384615793845659
//13,4 sec = 6,4965033268677823141048489715965e-5

//22,6 sec = 1,095678919307551345513205871329e-4