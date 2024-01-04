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

        public static bool IsEccentricityValidForEllipse (double e)
        {
            return ((0.0 <= e) && (e < 1.0));
        }

        public static bool IsEccentricityValidForHyperbola (double e)
        {
            return (e > 1.0);
        }

        public static double SemiMajorAxisByMeanMotion (double K2, double n)
        {
            return double.Cbrt (K2 / (n * n));
        }

        public static double SemiMajorAxisByOrbitalPeriod (double K2, double T)
        {
            return double.Cbrt (K2 * T * T / MathConst.M_4_PI_SQR);
        }

        public static double MeanMotionBySemiMajorAxisForEllipse (double k, double a)
        {
            return k / (a * double.Sqrt (a));
        }

        public static double MeanMotionBySemiMajorAxisForHyperbola (double k, double a)
        {
            return k / (-a * double.Sqrt (-a));
        }

        public static double MeanMotionByOrbitalPeriod (double T)
        {
            return double.Tau / T;
        }

        public static double OrbitalPeriodByMeanMotion (double n)
        {
            return double.Tau / n;
        }
    }
}