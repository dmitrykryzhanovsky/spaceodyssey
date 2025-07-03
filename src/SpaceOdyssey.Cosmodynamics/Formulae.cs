using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Основные формулы для вычислений.
    /// </summary>
    public static class Formulae
    {
        /// <summary>
        /// Возвращает расстояние от фокуса конического сечения.
        /// </summary>
        /// <param name="trueAnomaly">Истинная аномалия.</param>
        /// <param name="p">Фокальный параметр.</param>
        /// <param name="e">Эксцентриситет.</param>
        /// <remarks>Метод так назван, поскольку он фактически возвращает значение в соответствии с уравнением конического сечения.</remarks>
        public static double ConicSection (double trueAnomaly, double p, double e)
        {
            return p / (1.0 + e * double.Cos (trueAnomaly));
        }

        /// <summary>
        /// Возвращает расстояние от фокуса параболы.
        /// </summary>
        /// <param name="trueAnomaly">Истинная аномалия.</param>
        /// <param name="p">Фокальный параметр.</param>
        /// <remarks>Метод так назван, поскольку он фактически возвращает значение в соответствии с уравнением конического сечения при 
        /// e = 1.</remarks>
        public static double ConicSectionParabola (double trueAnomaly, double p)
        {
            return p / (1.0 + double.Cos (trueAnomaly));
        }

        public static double ConicSectionInverse (double r, double p, double e)
        {
            return double.Acos ((p / r - 1.0) / e);
        }

        public static double ConicSectionInverseParabola (double r, double p)
        {
            return double.Acos (p / r - 1.0);
        }

        public static double PParabolaByRp (double rp)
        {
            return rp * 2.0;
        }

        public static double Asymptote (double e)
        {
            return double.Acos (-1.0 / e);
        }

        public static double RangeARp (double x1me)
        {
            return 1.0 / x1me;
        }

        public static double RangeRaA (double x1pe)
        {
            return x1pe;
        }

        public static double RangeRaRp (double x1me, double x1pe)
        {
            return x1pe / x1me;
        }

        public static double GMA (double mu, double a)
        {
            return mu / a;
        }

        public static double GMASqrt (double mua)
        {
            return double.Sqrt (mua);
        }

        public static double V1Circular (double mu, double r)
        {
            return double.Sqrt (mu / r);
        }

        public static double V2Escape (double mu, double r)
        {
            return double.Sqrt (2.0 * mu / r);
        }

        public static double VelocityByDistance (double r, double mu, double h)
        {
            return double.Sqrt (h + 2 * mu / r);
        }

        public static double MeanMotion (double a, double muasqrt)
        {
            return muasqrt / a;
        }

        public static double OrbitalPeriod (double a, double muasqrt)
        {
            return double.Tau * a / muasqrt;
        }

        public static double ArealVelocityNonParabola (double mu, double a)
        {
            return double.Sqrt (mu * a);
        }

        public static double ArealVelocityParabola (double mu, double rp)
        {
            return double.Sqrt (2.0 * mu * rp);
        }

        /// <summary>
        /// Вычисление положения на круговой орбите.
        /// </summary>
        /// <param name="anomaly">Средняя / истинная аномалия.</param>
        /// <param name="sin">Синус средней / истинной аномалии.</param>
        /// <param name="cos">Косинус средней / истинной аномалии.</param>
        /// <param name="param"><list type="number">
        /// – [0] – радиус круговой орбиты
        /// </list></param>
        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForCircle (double anomaly, double sin,
            double cos, params double [] param)
        {
            double x = param [0] * cos;
            double y = param [0] * sin;
            double r = param [0];
            double trueAnomaly = anomaly;

            return (x, y, r, trueAnomaly);
        }

        /// <summary>
        /// Вычисление положения на эллиптической орбите.
        /// </summary>
        /// <param name="anomaly">В данном методе в вычислениях не участвует.</param>
        /// <param name="sin">Синус эксцентрической аномалии E.</param>
        /// <param name="cos">Косинус эксцентрической аномалии E.</param>
        /// <param name="param"><list type="number">
        /// – [0] – большая полуось орбиты a
        /// – [1] – эксцентриситет орбиты e
        /// – [2] – корень из 1 – e^2
        /// </list></param>
        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForEllipse (double anomaly, double sin,
            double cos, params double [] param)
        {
            double x = param [0] * (cos - param [1]);
            double y = param [0] * param [2] * sin;
            (double r, double trueAnomaly) = Space2.ComputePolarComponents (x, y);

            return (x, y, r, trueAnomaly);
        }

        /// <summary>
        /// Вычисление положения на гиперболической орбите.
        /// </summary>
        /// <param name="anomaly">В данном методе в вычислениях не участвует.</param>
        /// <param name="sh">Гиперболический синус эксцентрической аномалии H.</param>
        /// <param name="ch">Гиперболический косинус эксцентрической аномалии H.</param>
        /// <param name="param"><list type="number">
        /// – [0] – модуль большой полуоси орбиты |a|
        /// – [1] – эксцентриситет орбиты e
        /// – [2] – корень из e^2 – 1
        /// </list></param>
        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForHyperbola (double anomaly, double sh,
            double ch, params double [] param)
        {
            double x = param [0] * (param [1] - ch);
            double y = param [0] * param [2] * sh;
            (double r, double trueAnomaly) = Space2.ComputePolarComponents (x, y);

            return (x, y, r, trueAnomaly);
        }

        /// <summary>
        /// Вычисление положения на параболической орбите.
        /// </summary>
        /// <param name="anomaly">tan (ν/2), где ν – истинная аномалия.</param>
        /// <param name="sin">В данном методе в вычислениях не участвует.</param>
        /// <param name="cos">В данном методе в вычислениях не участвует.</param>
        /// <param name="param"><list type="number">
        /// – [0] – расстояние в перицентре rp
        /// </list></param>
        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForParabola (double anomaly, double sin,
            double cos, params double [] param)
        {
            double x = param [0] * (1 - anomaly * anomaly);
            double y = 2.0 * param [0] * anomaly;
            (double r, double trueAnomaly) = Space2.ComputePolarComponents (x, y);

            return (x, y, r, trueAnomaly);
        }

        /// <summary>
        /// Вычисление скорости на круговой орбите.
        /// </summary>
        /// <param name="sin">Синус средней / истинной аномалии.</param>
        /// <param name="cos">Косинус средней / истинной аномалии.</param>
        /// <param name="param"><list type="number">
        /// – [0] – корень из μ/a
        /// </list></param>
        public static (double vx, double vy) ComputePlanarVelocityForCircle (double sin, double cos, params double [] param)
        {
            double vx = -param [0] * sin;
            double vy =  param [0] * cos;

            return (vx, vy);
        }

        /// <summary>
        /// Вычисление скорости на эллиптической орбите.
        /// </summary>
        /// <param name="sin">Синус эксцентрической аномалии E.</param>
        /// <param name="cos">Косинус эксцентрической аномалии E.</param>
        /// <param name="param"><list type="number">
        /// – [0] – корень из μ/a
        /// – [1] – эксцентриситет орбиты e
        /// – [2] – корень из 1 – e^2
        /// </list></param>
        public static (double vx, double vy) ComputePlanarVelocityForEllipse (double sin, double cos, params double [] param)
        {
            double denominator = 1.0 - param [1] * cos;

            double vx = -param [0] * sin / denominator;
            double vy =  param [0] * param [2] * cos / denominator;

            return (vx, vy);
        }

        /// <summary>
        /// Вычисление скорости на гиперболической орбите.
        /// </summary>
        /// <param name="sh">Гиперболический синус эксцентрической аномалии H.</param>
        /// <param name="ch">Гиперболический косинус эксцентрической аномалии H.</param>
        /// <param name="param"><list type="number">
        /// – [0] – корень из μ/|a|
        /// – [1] – эксцентриситет орбиты e
        /// – [2] – корень из e^2 – 1
        /// </list></param>
        public static (double vx, double vy) ComputePlanarVelocityForHyperbola (double sh, double ch, params double [] param)
        {
            double denominator = param [1] * ch - 1.0;

            double vx = -param [0] * sh / denominator;
            double vy =  param [0] * param [2] * ch / denominator;

            return (vx, vy);
        }

        /// <summary>
        /// Вычисление скорости на параболической орбите.
        /// </summary>
        /// <param name="r">Расстояние от тела до фокуса орбиты.</param>
        /// <param name="y">Координата y в плоскости орбиты.</param>
        /// <param name="param"><list type="number">
        /// – [0] – локальная гравитационная постоянная μ
        /// – [1] – фокальный параметр орбиты p
        /// </list></param>
        public static (double vx, double vy) ComputePlanarVelocityForParabola (double r, double y, params double [] param)
        {
            double beta = double.Atan2 (param [1], -y);
            double v    = V2Escape (param [0], r);

            (double sin, double cos) = double.SinCos (beta);

            double vx = v * cos;
            double vy = v * sin;

            return (vx, vy);
        }

        public static double SolveKeplerEquationForEllipse (double M, double e)
        {
            throw new NotImplementedException ();
        }

        public static double SolveKeplerEquationForHyperbola (double M, double e)
        {
            throw new NotImplementedException ();
        }
    }
}