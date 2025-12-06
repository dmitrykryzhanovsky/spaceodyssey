using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public static class Formulae
    {
        public static class Shape
        {
            public static class NonParabola
            {
                /// <summary>
                /// Возвращает расстояние от фокуса при данном полярном угле phi.
                /// </summary>
                /// <param name="p">Фокальный параметр.</param>
                /// <param name="e">Эксцентриситет.</param>
                /// <remarks>Вычисляет уравнение конического сечения в полярных координатах.</remarks>
                public static double ConicSectionEquation (double p, double e, double phi)
                {
                    return p / (1.0 + e * double.Cos (phi));
                }

                /// <summary>
                /// Возвращает полярный угол для данного расстояния от фокуса r.
                /// </summary>
                /// <param name="p">Фокальный параметр.</param>
                /// <param name="e">Эксцентриситет.</param>
                /// <returns>Вычисляет обратное уравнение конического сечения в полярных координатах.</returns>
                public static double ConicSectionInverseEquation (double p, double e, double r)
                {
                    return double.Acos ((p - r) / (r * e));
                }
            }

            public static class Hyperbola
            {
                /// <summary>
                /// Возвращает асимптотический угол, к которому стремится гипербола при удалении на бесконечность при данном 
                /// эксцентриситете e.
                /// </summary>
                public static double Asymptote (double e)
                {
                    return double.Acos (-1.0 / e);
                }
            }

            public static class Parabola
            {
                /// <summary>
                /// Возвращает расстояние от фокуса при данном полярном угле phi.
                /// </summary>
                /// <param name="p">Фокальный параметр.</param>
                /// <remarks>Вычисляет уравнение конического сечения в полярных координатах при эксцентриситете e = 1.</remarks>
                public static double ConicSectionEquation (double p, double phi)
                {
                    return p / (1.0 + double.Cos (phi));
                }

                /// <summary>
                /// Возвращает полярный угол для данного расстояния от фокуса r.
                /// </summary>
                /// <param name="p">Фокальный параметр.</param>
                /// <returns>Вычисляет обратное уравнение конического сечения в полярных координатах при эксцентриситете e = 1.</returns>
                public static double ConicSectionInverseEquation (double p, double r)
                {
                    return double.Acos ((p - r) / r);
                }
            }
        }

        public static class Integrals
        {
            public static class NonParabola
            {
                /// <summary>
                /// Возвращает интеграл энергии для непараболической орбиты.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <param name="a">Большая полуось орбиты: положительная для эллипса, отрицательная для гиперболы.</param>
                public static double EnergyIntegral (double mu, double a)
                {
                    return -mu / a;
                }
            }
        }

        public static class Motion
        {
            public static class NonParabola
            {
                /// <summary>
                /// Возвращает среднее движение для непараболической орбиты.
                /// </summary>
                /// <param name="sqrth">Квадратный корень из абсолютного значения интеграла энергии.</param>
                /// <param name="a">Большая полуось орбиты: положительная для эллипса, отрицательная для гиперболы.</param>
                public static double MeanMotion (double sqrth, double a)
                {
                    return sqrth / double.Abs (a);
                }

                /// <summary>
                /// Возвращает скорость на непараболической орбите на расстоянии r.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <param name="a">Большая полуось орбиты: положительная для эллипса, отрицательная для гиперболы.</param>
                public static double SpeedForRadius (double mu, double r, double a)
                {
                    return double.Sqrt (mu * (2.0 / r - 1.0 / a));
                }

                /// <summary>
                /// Возвращает скорость на непараболической орбите для истинной аномалии trueAnomaly.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <param name="e">Эксцентриситет орбиты.</param>
                /// <param name="p">Фокальный параметр.</param>
                public static double SpeedForTrueAnomaly (double mu, double e, double p, double trueAnomaly)
                {
                    return double.Sqrt ((mu / p) * (1.0 + 2.0 * e * double.Cos (trueAnomaly) + e * e));
                }
            }

            public static class Ellipse
            {
                /// <summary>
                /// Приводит среднюю аномалию, накопившуюся при среднем движении n за интервал времени dt, в диапазон [-π; +π].
                /// </summary>
                public static double NormalizeMeanAnomaly (double n, double dt)
                {
                    return Trigonometry.NormalizeHalfTurnInRad (n * dt);
                }

                /// <summary>
                /// Возвращает среднюю скорость для эллиптической орбиты.
                /// </summary>
                /// <param name="a">Большая полуось.</param>
                /// <param name="sqrt1me2">Вспомогательная величина sqrt (1 - e^2).</param>
                /// <param name="T">Период обращения.</param>
                public static double SpeedMean (double a, double sqrt1me2, double T)
                {
                    return Geometry2.Ellipse.Length (a, sqrt1me2) / T; ;
                }
            }

            public static class Circle
            {
                /// <summary>
                /// Возвращает скорость на круговой орбите на расстоянии r.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <remarks>Фактически это 1-я космическая скорость.</remarks>
                public static double SpeedForRadius (double mu, double r)
                {
                    return double.Sqrt (mu / r);
                }
            }

            public static class Parabola
            {
                /// <summary>
                /// Возвращает скорость на параболической орбите на расстоянии r.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <remarks>Фактически это 2-я космическая скорость.</remarks>
                public static double SpeedForRadius (double mu, double r)
                {
                    return double.Sqrt (mu * 2.0 / r);
                }

                /// <summary>
                /// Возвращает скорость на параболической орбите для истинной аномалии trueAnomaly.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <param name="p">Фокальный параметр.</param>
                /// <remarks>Фактически это 2-я космическая скорость.</remarks>
                public static double SpeedForTrueAnomaly (double mu, double p, double trueAnomaly)
                {
                    return double.Sqrt ((mu / p) * 2.0 * (1.0 + double.Cos (trueAnomaly)));
                }
            }
        }
    }
}