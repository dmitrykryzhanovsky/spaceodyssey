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
                    return double.Acos (((p / r) - 1.0) / e);
                }

                /// <summary>
                /// Возвращает фокальный параметр по заданным расстоянию в перицентре rp и вспомогательной величине aux1pe = 1 + e, где e 
                /// – эксцентриситет.
                /// </summary>
                public static double FocalParameterByRP (double rp, double aux1pe)
                {
                    return rp * aux1pe;
                }

                /// <summary>
                /// Возвращает большую полуось по заданным расстоянию в перицентре rp и вспомогательной величине aux1me = 1 - e, где e 
                /// – эксцентриситет.
                /// </summary>
                public static double SemiMajorAxisByRP (double rp, double aux1me)
                {
                    return rp / aux1me;
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
                    return double.Acos ((p / r) - 1.0);
                }

                /// <summary>
                /// Возвращает фокальный параметр для параболы по заданному расстоянию в перицентре rp.
                /// </summary>
                public static double FocalParameterByRP (double rp)
                {
                    return 2.0 * rp;
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
                /// <param name="sqrtmu">Квадратный корень из локальной гравитационной постоянной.</param>
                /// <param name="a">Большая полуось орбиты: положительная для эллипса, отрицательная для гиперболы.</param>
                public static double MeanMotion (double sqrtmu, double a)
                {
                    double absa = double.Abs (a);

                    return sqrtmu / (absa * double.Sqrt (absa));
                }

                /// <summary>
                /// Возвращает скорость на непараболической орбите в перицентре.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <param name="rp">Расстояние в перицентре.</param>
                /// <param name="aux1pe">Вспомогательная величина 1 + e, где e – эксцентриситет.</param>
                public static double SpeedAtPeriapsisByRP (double mu, double rp, double aux1pe)
                {
                    return double.Sqrt (mu * aux1pe / rp);
                }
            }

            public static class Parabola
            {
                /// <summary>
                /// Возвращает среднее движение для параболической орбиты.
                /// </summary>
                /// <param name="sqrtmu">Квадратный корень из локальной гравитационной постоянной.</param>
                /// <param name="rp">Расстояние в перицентре.</param>
                public static double MeanMotion (double sqrtmu, double rp)
                {
                    return sqrtmu / (rp * double.Sqrt (2.0 * rp));
                }

                /// <summary>
                /// Возвращает скорость на параболической орбите на расстоянии r.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                public static double SpeedAtRadius (double mu, double r)
                {
                    return double.Sqrt (2.0 * mu / r);
                }
            }
        }

        public static class Integrals
        {
            public static class NonParabola
            {
                /// <summary>
                /// Возвращает интеграл энергии.
                /// </summary>
                /// <param name="mu">Локальная гравитационная постоянная для данной орбиты.</param>
                /// <param name="a">Большая полуось орбиты: положительная для эллипса, отрицательная для гиперболы.</param>
                public static double EnergyIntegral (double mu, double a)
                {
                    return -mu / a;
                }
            }
        }
    }
}