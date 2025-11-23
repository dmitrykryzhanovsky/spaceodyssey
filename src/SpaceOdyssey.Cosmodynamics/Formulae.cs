using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public static class Formulae
    {
        public static class Shape
        {
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

            public static class Parabola
            {
                /// <summary>
                /// Возвращает скорость на параболической орбите на расстоянии r.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                public static double Speed (double mu, double r)
                {
                    return double.Sqrt (2.0 * mu / r);
                }
            }
        }
    }
}