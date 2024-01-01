using System;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Формулы для вычислений для кеплеровых орбит.
    /// </summary>
    public static class KeplerOrbitFormulae
    {
        /// <summary>
        /// Вычисляет среднее движение n и орбитальный период T для эллиптической орбиты по большой полуоси a.
        /// </summary>
        /// <param name="k">Гравитационный параметр.</param>
        public static (double n, double T) ComputeMotionAndPeriodForEllipse (double k, double a)
        {
            double n = k / (a * Double.Sqrt (a));
            double T = Double.Tau / n;

            return (n, T);
        }

        /// <summary>
        /// Вычисляет большую полуось a и орбитальный период T для эллиптической орбиты по среднему движению n.
        /// </summary>
        /// <param name="k2">Квадрат гравитационного параметра.</param>
        public static (double a, double T) ComputeSemiAxisAndPeriodForEllipse (double k2, double n)
        {
            double a = Double.Cbrt (k2 / (n * n));
            double T = Double.Tau / n;

            return (a, T);
        }

        /// <summary>
        /// Вычисляет большую полуось a и среднее движение n для эллиптической орбиты по орбитальному периоду T.
        /// </summary>
        /// <param name="k2">Квадрат гравитационного параметра.</param>
        public static (double a, double n) ComputeSemiAxisAndMotionForEllipse (double k2, double T)
        {
            double n = Double.Tau / T;
            double a = Double.Cbrt (k2 / (n * n));

            return (a, n);
        }

        public static double ComputeMotionForHyperbola (double k, double a)
        {
            return k / (-a * Double.Sqrt (-a));
        }
    }
}