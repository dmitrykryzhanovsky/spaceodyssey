using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Формулы для вычислений по астродинамике.
    /// </summary>
    public static class CosmodynamicsFormulae
    {
        /// <summary>
        /// Вычисляет расстояние до центра (одного из фокусов ) орбиты в точке с заданной истинной аномалией.
        /// </summary>
        /// <param name="p">Орбитальный параметр.</param>
        /// <param name="e">Эксцентриситет.</param>
        /// <param name="trueAnomaly">Истинная аномалия.</param>
        public static double Radius (double p, double e, double trueAnomaly)
        {
            return p / (1.0 + e * double.Cos (trueAnomaly));
        }

        /// <summary>
        /// Возвращает TRUE, если значение эксцентриситета e соответствует эллипсу, то есть лежит на полуинтервале [0; 1). В противном 
        /// случае FALSE.
        /// </summary>
        public static bool IsEccentricityValidForEllipse (double e)
        {
            return ((0.0 <= e) && (e < 1.0));
        }

        /// <summary>
        /// Возвращает TRUE, если значение эксцентриситета e соответствует гиперболе, то есть строго больше 1. В противном случае FALSE.
        /// </summary>
        public static bool IsEccentricityValidForHyperbola (double e)
        {
            return (e > 1.0);
        }

        /// <summary>
        /// Вычисляет большую полуось орбиты по квадрату её гравитационной постоянной k2 и среднему движению n.
        /// </summary>
        /// <remarks>Возвращает положительное число. Таким образом, для гиперболической орбиты вычисляется не собственно большая полуось, 
        /// а её абсолютное значение.</remarks>
        public static double SemiMajorAxisByMeanMotion (double k2, double n)
        {
            return double.Cbrt (k2 / (n * n));
        }

        /// <summary>
        /// Вычисляет большую полуось орбиты по квадрату её гравитационной постоянной k2 и орбитальному периоду T.
        /// </summary>
        /// <remarks>Возвращает положительное число. Таким образом, для гиперболической орбиты вычисляется не собственно большая полуось, 
        /// а её абсолютное значение.</remarks>
        public static double SemiMajorAxisByOrbitalPeriod (double k2, double T)
        {
            return double.Cbrt (k2 * T * T / MathConst.M_4_PI_SQR);
        }

        /// <summary>
        /// Вычисляет среднее движение по эллиптической орбите по её гравитационной постоянной k и большой полуоси a.
        /// </summary>
        /// <param name="a">Для эллипса a должно быть положительным.</param>
        public static double MeanMotionBySemiMajorAxisForEllipse (double k, double a)
        {
            return k / (a * double.Sqrt (a));
        }

        /// <summary>
        /// Вычисляет среднее движение по гиперболической орбите по её гравитационной постоянной k и большой полуоси a.
        /// </summary>
        /// <param name="a">Для гиперболы a должно быть отрицательным.</param>
        public static double MeanMotionBySemiMajorAxisForHyperbola (double k, double a)
        {
            return k / (-a * double.Sqrt (-a));
        }

        /// <summary>
        /// Вычисляет среднее движение по орбитальному периоду T.
        /// </summary>
        public static double MeanMotionByOrbitalPeriod (double T)
        {
            return double.Tau / T;
        }

        /// <summary>
        /// Вычисляет орбитальный период по среднему движению n.
        /// </summary>
        public static double OrbitalPeriodByMeanMotion (double n)
        {
            return double.Tau / n;
        }
    }
}