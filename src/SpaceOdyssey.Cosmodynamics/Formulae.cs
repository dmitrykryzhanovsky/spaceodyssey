using Archimedes;
using Archimedes.Numerical;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Основные формулы для вычислений.
    /// </summary>
    public static class Formulae
    {
        public static class Shape
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
            /// <remarks>Метод так назван, поскольку он фактически возвращает значение в соответствии с уравнением конического сечения 
            /// при e = 1.</remarks>
            public static double ConicSectionParabola (double trueAnomaly, double p)
            {
                return p / (1.0 + double.Cos (trueAnomaly));
            }

            /// <summary>
            /// Возвращает истинную аномалию (в верхней полуплоскости) при заданном расстоянии r от фокуса конического сечения.
            /// </summary>
            /// <param name="r">Расстояние от фокуса конического сечения.</param>
            /// <param name="p">Фокальный параметр.</param>
            /// <param name="e">Эксцентриситет.</param>
            /// <remarks>Метод так назван, поскольку он фактически возвращает значение в соответствии с обратным уравнением 
            /// конического сечения</remarks>
            public static double ConicSectionInverse (double r, double p, double e)
            {
                return double.Acos ((p / r - 1.0) / e);
            }

            /// <summary>
            /// Возвращает истинную аномалию (в верхней полуплоскости) при заданном расстоянии r от фокуса параболы.
            /// </summary>
            /// <param name="r">Расстояние от фокуса конического сечения.</param>
            /// <param name="p">Фокальный параметр.</param>
            /// <remarks>Метод так назван, поскольку он фактически возвращает значение в соответствии с обратным уравнением 
            /// конического сечения при e = 1.</remarks>
            public static double ConicSectionInverseParabola (double r, double p)
            {
                return double.Acos (p / r - 1.0);
            }

            /// <summary>
            /// Возвращает фокальный параметр для параболы по заданному расстоянию в перицентре rp.
            /// </summary>
            public static double PParabolaByRp (double rp)
            {
                return rp * 2.0;
            }

            /// <summary>
            /// Возвращает угол асимптоты (в верхней полуплоскости), к которой стремится незамкнутая орбита с эксцентриситетом e.
            /// </summary>
            public static double Asymptote (double e)
            {
                return double.Acos (-1.0 / e);
            }

            /// <summary>
            /// Возвращает отношение большой полуоси к расстоянию в перицентре для эллиптической орбиты.
            /// </summary>
            /// <param name="x1me">Величина 1 – e, где e – эксцентриситет орбиты.</param>
            public static double RangeARp (double x1me)
            {
                return 1.0 / x1me;
            }

            /// <summary>
            /// Возвращает отношение расстояния в апоцентре к большой полуоси для эллиптической орбиты.
            /// </summary>
            /// <param name="x1pe">Величина 1 + e, где e – эксцентриситет орбиты.</param>
            public static double RangeRaA (double x1pe)
            {
                return x1pe;
            }

            /// <summary>
            /// Возвращает отношение расстояния в апоцентре к расстоянию в перицентре для эллиптической орбиты.
            /// </summary>
            /// <param name="x1me">Величина 1 – e, где e – эксцентриситет орбиты.</param>
            /// <param name="x1pe">Величина 1 + e, где e – эксцентриситет орбиты.</param>
            public static double RangeRaRp (double x1me, double x1pe)
            {
                return x1pe / x1me;
            }
        }

        public static class Motion
        {
            /// <summary>
            /// Возвращает величину μ / a (~GM / a).
            /// </summary>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            /// <param name="a">Модуль большой полуоси орбиты.</param>
            public static double GMA (double mu, double a)
            {
                return mu / a;
            }

            /// <summary>
            /// Возвращает корень из величины μ / a (~sqrt (GM / a)).
            /// </summary>
            /// <param name="mua">Величина μ / a.</param>
            public static double GMASqrt (double mua)
            {
                return double.Sqrt (mua);
            }

            /// <summary>
            /// Возвращает 1-ю космическую (круговую) скорость на заданном расстоянии r.
            /// </summary>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            public static double V1Circular (double mu, double r)
            {
                return double.Sqrt (mu / r);
            }

            /// <summary>
            /// Возвращает 2-ю космическую (параболическую, убегания) скорость на заданном расстоянии r.
            /// </summary>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            public static double V2Escape (double mu, double r)
            {
                return double.Sqrt (2.0 * mu / r);
            }

            /// <summary>
            /// Возвращает скорость на заданном расстоянии от центра тяготения.
            /// </summary>
            /// <param name="r">Расстояние от центра тяготения.</param>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            /// <param name="h">Интеграл энергии.</param>
            public static double VelocityByDistance (double r, double mu, double h)
            {
                return double.Sqrt (h + 2 * mu / r);
            }

            /// <summary>
            /// Возвращает среднее движение для непараболических орбит, угловая единица / единица времени.
            /// </summary>
            /// <param name="a">Модуль большой полуоси орбиты.</param>
            /// <param name="muasqrt">Корень из величины μ / a.</param>
            public static double MeanMotionNonParabola (double a, double muasqrt)
            {
                return muasqrt / a;
            }

            /// <summary>
            /// Возвращает среднее движение для параболических орбит, угловая единица / единица времени.
            /// </summary>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            /// <param name="rp">Расстояние в перигелии.</param>
            public static double MeanMotionParabola (double mu, double rp)
            {
                return 1.5 * double.Sqrt (mu / (2.0 * rp)) / rp;
            }

            /// <summary>
            /// Возвращает период оборота по орбите.
            /// </summary>
            /// <param name="a">Модуль большой полуоси орбиты.</param>
            /// <param name="muasqrt">Корень из величины μ / a.</param>
            public static double OrbitalPeriod (double a, double muasqrt)
            {
                return double.Tau * a / muasqrt;
            }

            /// <summary>
            /// Возвращает среднюю аномалию для момента времени t.
            /// </summary>
            /// <param name="t0">Момент прохождения перицентра.</param>
            /// <param name="n">Среднее движение.</param>
            public static double MeanAnomalyForTime (double t, double t0, double n)
            {
                return n * (t - t0);
            }
        }

        public static class Integrals
        {
            /// <summary>
            /// Возвращает интеграл скорости для непараболической орбиты.
            /// </summary>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            /// <param name="a">Модуль большой полуоси орбиты.</param>
            public static double ArealVelocityNonParabola (double mu, double a)
            {
                return double.Sqrt (mu * a);
            }

            /// <summary>
            /// Возвращает интеграл скорости для параболической орбиты.
            /// </summary>
            /// <param name="mu">Локальная гравитационная постоянная.</param>
            /// <param name="rp">Расстояние в перицентре.</param>
            public static double ArealVelocityParabola (double mu, double rp)
            {
                return double.Sqrt (2.0 * mu * rp);
            }
        }

        public static class PlanarPosition
        {
            /// <summary>
            /// Вычисление положения на круговой орбите.
            /// </summary>
            /// <param name="anomaly">Средняя / истинная аномалия.</param>
            /// <param name="sin">Синус средней / истинной аномалии.</param>
            /// <param name="cos">Косинус средней / истинной аномалии.</param>
            /// <param name="param"><list type="number">
            /// – [0] – радиус круговой орбиты
            /// </list></param>
            public static (double x, double y, double r, double trueAnomaly) ComputeForCircle (double anomaly, double sin, double cos, 
                params double [] param)
            {
                double x           = param [0] * cos;
                double y           = param [0] * sin;
                double r           = param [0];
                double trueAnomaly = anomaly;

                return (x, y, r, trueAnomaly);
            }

            /// <summary>
            /// Вычисление положения на эллиптической орбите.
            /// </summary>
            /// <param name="sin">Синус эксцентрической аномалии E.</param>
            /// <param name="cos">Косинус эксцентрической аномалии E.</param>
            /// <param name="param"><list type="number">
            /// – [0] – большая полуось орбиты a
            /// – [1] – эксцентриситет орбиты e
            /// – [2] – корень из 1 – e^2
            /// </list></param>
            public static (double x, double y, double r, double trueAnomaly) ComputeForEllipse (double sin, double cos, 
                params double [] param)
            {
                double x = param [0] * (cos - param [1]);
                double y = param [0] * param [2] * sin;
                (double r, double trueAnomaly) = Space2.GetPolarCoordinates (x, y);

                return (x, y, r, trueAnomaly);
            }

            /// <summary>
            /// Вычисление положения на гиперболической орбите.
            /// </summary>
            /// <param name="sh">Гиперболический синус эксцентрической аномалии H.</param>
            /// <param name="ch">Гиперболический косинус эксцентрической аномалии H.</param>
            /// <param name="param"><list type="number">
            /// – [0] – модуль большой полуоси орбиты |a|
            /// – [1] – эксцентриситет орбиты e
            /// – [2] – корень из e^2 – 1
            /// </list></param>
            public static (double x, double y, double r, double trueAnomaly) ComputeForHyperbola (double sh, double ch, 
                params double [] param)
            {
                double x = param [0] * (param [1] - ch);
                double y = param [0] * param [2] * sh;
                (double r, double trueAnomaly) = Space2.GetPolarCoordinates (x, y);

                return (x, y, r, trueAnomaly);
            }

            /// <summary>
            /// Вычисление положения на параболической орбите.
            /// </summary>
            /// <param name="tanv2">tan (ν/2), где ν – истинная аномалия.</param>
            /// <param name="param"><list type="number">
            /// – [0] – расстояние в перицентре rp
            /// </list></param>
            public static (double x, double y, double r, double trueAnomaly) ComputeForParabola (double tanv2, params double [] param)
            {
                double x = param [0] * (1 - tanv2 * tanv2);
                double y = 2.0 * param [0] * tanv2;
                (double r, double trueAnomaly) = Space2.GetPolarCoordinates (x, y);

                return (x, y, r, trueAnomaly);
            }
        }

        public static class PlanarVelocity
        {
            /// <summary>
            /// Вычисление скорости на круговой орбите.
            /// </summary>
            /// <param name="sin">Синус средней / истинной аномалии.</param>
            /// <param name="cos">Косинус средней / истинной аномалии.</param>
            /// <param name="param"><list type="number">
            /// – [0] – корень из μ/a
            /// </list></param>
            public static (double vx, double vy, double speed) ComputeForCircle (double sin, double cos, params double [] param)
            {
                double vx    = -param [0] * sin;
                double vy    =  param [0] * cos;
                double speed =  param [0];

                return (vx, vy, speed);
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
            public static (double vx, double vy, double speed) ComputeForEllipse (double sin, double cos, params double [] param)
            {
                double denominator = 1.0 - param [1] * cos;

                double vx    = -param [0] * sin / denominator;
                double vy    =  param [0] * param [2] * cos / denominator;
                double speed =  param [0] * double.Sqrt ((1.0 + param [1] * cos) / denominator);

                return (vx, vy, speed);
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
            public static (double vx, double vy, double speed) ComputeForHyperbola (double sh, double ch, params double [] param)
            {
                double denominator = param [1] * ch - 1.0;

                double vx    = -param [0] * sh / denominator;
                double vy    =  param [0] * param [2] * ch / denominator;
                double speed =  param [0] * double.Sqrt ((param [1] * ch + 1.0) / denominator);

                return (vx, vy, speed);
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
            public static (double vx, double vy, double speed) ComputeForParabola (double r, double y, params double [] param)
            {
                double beta  = double.Atan2 (param [1], -y);
                double speed = Motion.V2Escape (param [0], r);

                (double sin, double cos) = double.SinCos (beta);

                double vx = speed * cos;
                double vy = speed * sin;

                return (vx, vy, speed);
            }
        }

        public static class KeplerEquation
        {
            /// <summary>
            /// Решает уравнение Кеплера для эллипса.
            /// </summary>
            /// <param name="M">Средняя аномалия в радианах.</param>
            /// <param name="e">Эксцентриситет орбиты.</param>
            /// <returns>Возвращает эксцентрическую аномалию в радианах с точностью 1.0e-14.</returns>
            public static double SolveForEllipse (double M, double e)
            {
                return Equation.Newton (KeplerEquationForEllipse, KeplerDerivativeForEllipse, ComputingSettings.NumericalEpsilon,
                    M, e, M);
            }

            private static double KeplerEquationForEllipse (double x, params double [] a)
            {
                return x - a [0] * double.Sin (x) - a [1];
            }

            private static double KeplerDerivativeForEllipse (double x, params double [] a)
            {
                return 1.0 - a [0] * double.Cos (x);
            }

            public static double SolveForHyperbola (double M, double e)
            {
                return Equation.Newton (KeplerEquationForHyperbola, KeplerDerivativeForHyperbola, ComputingSettings.NumericalEpsilon,
                    M, e, M);
            }

            private static double KeplerEquationForHyperbola (double x, params double [] a)
            {
                return a [0] * double.Sinh (x) - a [0] - a [1];
            }

            private static double KeplerDerivativeForHyperbola (double x, params double [] a)
            {
                return a [0] * double.Cosh (x) - 1.0;
            }

            /// <summary>
            /// Решение уравнения Баркера относительно средней аномалии (для параболических орбит обычно обозначается как A).
            /// </summary>
            /// <returns>Возвращает tan (v/2), где v – истинная аномалия.</returns>
            public static double SolveBarkerEquation (double M)
            {
                double B = double.Cbrt (M + double.Sqrt (M * M + 1));

                return B - 1.0 / B;
            }
        }
    }
}