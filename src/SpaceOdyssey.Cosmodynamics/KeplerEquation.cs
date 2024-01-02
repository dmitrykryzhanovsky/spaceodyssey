using Archimedes.Numerical;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Решение уравнения Кеплера.
    /// </summary>
    public static class KeplerEquation
    {
        /// <summary>
        /// Уравнение Кеплера для эллиптической орбиты y = E - e * sin (E) - M.
        /// </summary>
        /// <param name="param"><list type="number">
        /// <item>param [0] - эксцентриситет орбиты e;</item>
        /// <item>param [1] - средняя аномалия M, для которой нужно найти решение.</item>
        /// </list></param>
        private static double EllipticEquation (double E, params double [] param)
        {
            return E - param [0] * double.Sin (E) - param [1];
        }

        /// <summary>
        /// Производная уравнения Кеплера для эллиптической орбиты y'(E) = 1 - e * cos (E).
        /// </summary>
        /// <param name="param"><list type="number">
        /// <item>param [0] - эксцентриситет орбиты e;</item>
        /// <item>param [1] - средняя аномалия M, для которой нужно найти решение.</item>
        /// </list></param>
        private static double EllipticDerivative (double E, params double [] param)
        {
            return 1.0 - param [0] * double.Cos (E);
        }

        /// <summary>
        /// Решение уравнения Кеплера для эллиптической орбиты.
        /// </summary>
        /// <param name="M">Средняя аномалия, для которой нужно найти решение.</param>
        /// <param name="eccentricity">Эксцентриситет орбиты.</param>
        /// <param name="epsilon">Полуточность решения.</param>
        public static double Elliptic (double M, double eccentricity, double epsilon)
        {
            return NonLinearEquation.Newton (EllipticEquation, EllipticDerivative, epsilon, M, eccentricity, M);
        }

        /// <summary>
        /// Уравнение Кеплера для гиперболической орбиты y = e * sh (H) - H - M.
        /// </summary>
        /// <param name="param"><list type="number">
        /// <item>param [0] - эксцентриситет орбиты e;</item>
        /// <item>param [1] - средняя аномалия M, для которой нужно найти решение.</item>
        /// </list></param>
        private static double HyperbolicEquation (double H, params double [] param)
        {
            return param [0] * double.Sinh (H) - H - param [1];
        }

        /// <summary>
        /// Производная уравнения Кеплера для гиперболической орбиты y'(H) = e * ch (H) - 1.
        /// </summary>
        /// <param name="param"><list type="number">
        /// <item>param [0] - эксцентриситет орбиты e;</item>
        /// <item>param [1] - средняя аномалия M, для которой нужно найти решение.</item>
        /// </list></param>
        private static double HyperbolicDerivative (double H, params double [] param)
        {
            return param [0] * double.Cosh (H) - 1.0;
        }

        /// <summary>
        /// Решение уравнения Кеплера для гиперболической орбиты.
        /// </summary>
        /// <param name="M">Средняя аномалия, для которой нужно найти решение.</param>
        /// <param name="eccentricity">Эксцентриситет орбиты.</param>
        /// <param name="epsilon">Полуточность решения.</param>
        public static double Hyperbolic (double M, double eccentricity, double epsilon)
        {
            return NonLinearEquation.Newton (HyperbolicEquation, HyperbolicDerivative, epsilon, M, eccentricity, M);
        }
    }
}