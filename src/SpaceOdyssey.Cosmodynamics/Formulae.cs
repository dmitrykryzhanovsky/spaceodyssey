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