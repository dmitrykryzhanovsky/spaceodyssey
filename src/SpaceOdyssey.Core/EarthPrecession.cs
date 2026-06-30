using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление изменений координат между двумя моментами времени вследствие прецессии земной оси.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Общие замечания по вычислению прецессии см. в https://github.com/dmitrykryzhanovsky/spaceodyssey/wiki/Вычисление-прецессии.
    /// </para>
    /// <para>
    ///     Данный класс содержит два вложенных класса: <see cref="Equatorial"/> для вычисления прецессии в экваториальных и 
    ///     <see cref="Ecliptic"/> для вычисления прецессии в эклиптических координатах.
    /// </para>
    /// <para>
    ///     Каждый из вложенных классов содержит методы для вычисления углов прецессии и методы для вычисления координат, изменившихся 
    ///     в результате прецессии.
    /// </para>
    /// <para>
    ///     Методы Alpha, Beta и GammaComponent в подклассе ComputeEulerAnglesInArcsec вычисляют углы, на которые сместилась 
    ///     система небесных координат в результате прецессии с момента времени T0 до момента времени T0 + dT. Подкласс 
    ///     ComputeEulerAnglesInArcsecJ2000 – это их аналоги для случая, когда T0 = 0, то есть соответствует моменту времени J2000. T0 
    ///     задаётся в юлианских столетиях от момента времени J2000, dT – тоже в юлианских столетиях от момента времени T0. 
    ///     Все эти шесть методов возвращают углы, выраженные в секундах.
    /// </para>
    /// <para>
    ///     В случае эклиптической системы координат (класс <see cref="Ecliptic"/>) 
    ///     <list type="bullet">
    ///         <item>угол, возвращаемый методом Alpha, показывает угол, на который линия узлов отстоит от точки весеннего 
    ///         равноденствия;</item> 
    ///         <item>угол, возвращаемый методом Beta, показывает угол, на который плоскость эклиптики поворачивается за время dT;</item> 
    ///         <item>угол, возвращаемый методом GammaComponent, показывает угол, на который точка весеннего равноденствия 
    ///         смещается за время dT по долготе.</item> 
    ///     </list>    
    ///     Для экваториальной системы координат (класс <see cref="Equatorial"/>) смысл схожий, но есть отличия, поэтому напрямую 
    ///     эти углы применять нельзя.
    /// </para>
    /// <para>
    ///     Методы GetEulerAnglesForPrecession и GetEulerAnglesForPrecessionJ2000 возвращают углы, вычисляемые на основе смещений 
    ///     системы координат, которые уже непосредственно используются для определения новых координат. В случае эклиптических 
    ///     координат (класс <see cref="Ecliptic"/>) это углы Эйлера, задающие поворот системы координат. Данные методы возвращают 
    ///     углы в радианах.
    /// </para>
    /// <para>
    ///     Для вычисления новых координат нужно воспользоваться методом UpdateCoordinates. Вместо вычислений через углы Эйлера здесь 
    ///     используются прямые формулы, взятые из [Jean Meeuse. Astronomical algorithms. 2nd ed. Chapter 21]. Параметр eulerAngles – 
    ///     это углы, возвращаемые методом GetEulerAnglesForPrecession. И входные параметры, и выходные результаты метода 
    ///     UpdateCoordinates выражены в радианах.
    /// </para>
    /// </remarks>
    public static class EarthPrecession
    {
        /// <summary>
        /// Вычисление прецессии в экваториальных координатах.
        /// </summary>
        public static class Equatorial
        {
            private static readonly double [] ArcsecondSeriesForPrecession_Alpha          = new double [] { 2306.2181,
                                                                                                               1.39656,
                                                                                                              -0.000139,
                                                                                                               0.30188,
                                                                                                              -0.000345,
                                                                                                               0.017998 };

            private static readonly double [] ArcsecondSeriesForPrecession_Beta           = new double [] { 2004.3109, 
                                                                                                              -0.85330, 
                                                                                                              -0.000217, 
                                                                                                              -0.42665, 
                                                                                                              -0.000217, 
                                                                                                              -0.041833 };

            private static readonly double [] ArcsecondSeriesForPrecession_GammaComponent = new double [] {    0.79280,
                                                                                                               0.000411,
                                                                                                               0.000205 };

            public static class ComputeEulerAnglesInArcsec
            {
                public static double Alpha (double T0, double dT)
                {
                    return Series.SeriesXY13 (T0, dT, ArcsecondSeriesForPrecession_Alpha);
                }

                public static double Beta (double T0, double dT)
                {
                    return Series.SeriesXY13 (T0, dT, ArcsecondSeriesForPrecession_Beta);
                }

                public static double GammaComponent (double T0, double dT)
                {
                    return dT * dT * ((dT * ArcsecondSeriesForPrecession_GammaComponent [2]) +
                                      (T0 * ArcsecondSeriesForPrecession_GammaComponent [1]  + ArcsecondSeriesForPrecession_GammaComponent [0]));
                }
            }

            public static class ComputeEulerAnglesInArcsecJ2000
            {
                public static double Alpha (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_Alpha [5] + ArcsecondSeriesForPrecession_Alpha [3]) +
                                      ArcsecondSeriesForPrecession_Alpha [0]);
                }

                public static double Beta (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_Beta [5] + ArcsecondSeriesForPrecession_Beta [3]) +
                                      ArcsecondSeriesForPrecession_Beta [0]);
                }

                public static double GammaComponent (double dT)
                {
                    return dT * dT * (dT * ArcsecondSeriesForPrecession_GammaComponent [2] + 
                                      ArcsecondSeriesForPrecession_GammaComponent [0]);
                }
            }

            public static (double alpha, double beta, double gamma) GetEulerAnglesForPrecession (double T0, double dT)
            {
                double vernalEquinox = ComputeEulerAnglesInArcsec.Alpha (T0, dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox), 
                        beta:  Trigonometry.SecToRad (ComputeEulerAnglesInArcsec.Beta (T0, dT)), 
                        gamma: Trigonometry.SecToRad (vernalEquinox + ComputeEulerAnglesInArcsec.GammaComponent (T0, dT)));
            }

            public static (double alpha, double beta, double gamma) GetEulerAnglesForPrecessionJ2000 (double dT)
            {
                double vernalEquinox = ComputeEulerAnglesInArcsecJ2000.Alpha (dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox), 
                        beta:  Trigonometry.SecToRad (ComputeEulerAnglesInArcsecJ2000.Beta (dT)), 
                        gamma: Trigonometry.SecToRad (vernalEquinox + ComputeEulerAnglesInArcsecJ2000.GammaComponent (dT)));
            }

            public static Polar3 UpdateCoordinates (Polar3 p, double alpha, double beta, double gamma)
            {
                (double declination, double rightAscension) = ComputeNewAngles (p, alpha, beta, gamma);

                return Polar3.CreateUnsafe (p.R, declination, rightAscension);
            }

            private static (double declination, double rightAscension) ComputeNewAngles (Polar3 p, 
                double alpha, double beta, double gamma)
            {
                (double sinAlpha, double cosAlpha) = double.SinCos (p.Long + alpha);
                (double sinBeta,  double cosBeta)  = double.SinCos (beta);
                (double sinLat,   double cosLat)   = double.SinCos (p.Lat);

                double A = cosLat  * sinAlpha;
                double B = cosBeta * cosLat * cosAlpha - sinBeta * sinLat;
                double C = sinBeta * cosLat * cosAlpha + cosBeta * sinLat;

                return (declination:    Trigonometry.AsinEpsilon (C),
                        rightAscension: Trigonometry.Atan2Epsilon (A, B) + gamma);
            }
        }

        /// <summary>
        /// Вычисление прецессии в эклиптических координатах.
        /// </summary>
        public static class Ecliptic
        {
            private static readonly double [] ArcsecondSeriesForPrecession_Alpha          = new double [] { 629554.982000,
                                                                                                              3289.4789,
                                                                                                                 0.60622,
                                                                                                              -869.8089,
                                                                                                                -0.50491,
                                                                                                                 0.03536 };

            private static readonly double [] ArcsecondSeriesForPrecession_Beta           = new double [] {     47.0029,
                                                                                                                -0.06603,
                                                                                                                 0.000598,
                                                                                                                -0.03302,
                                                                                                                 0.000598,
                                                                                                                 0.00006 };

            private static readonly double [] ArcsecondSeriesForPrecession_GammaComponent = new double [] {   5029.0966,
                                                                                                                 2.22226,
                                                                                                                -0.000042,
                                                                                                                 1.11113,
                                                                                                                -0.000042,
                                                                                                                -0.000006 };

            public static class ComputeEulerAnglesInArcsec
            {
                public static double Alpha (double T0, double dT)
                {
                    return Series.SeriesXY02 (T0, dT, ArcsecondSeriesForPrecession_Alpha);
                }

                public static double Beta (double T0, double dT)
                {
                    return Series.SeriesXY13 (T0, dT, ArcsecondSeriesForPrecession_Beta);
                }

                public static double GammaComponent (double T0, double dT)
                {
                    return Series.SeriesXY13 (T0, dT, ArcsecondSeriesForPrecession_GammaComponent);
                }
            }

            public static class ComputeEulerAnglesInArcsecJ2000
            {
                public static double Alpha (double dT)
                {
                    return dT * (dT * ArcsecondSeriesForPrecession_Alpha [5] + ArcsecondSeriesForPrecession_Alpha [3]) +
                                ArcsecondSeriesForPrecession_Alpha [0];
                }

                public static double Beta (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_Beta [5] + ArcsecondSeriesForPrecession_Beta [3]) +
                                      ArcsecondSeriesForPrecession_Beta [0]);
                }

                public static double GammaComponent (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_GammaComponent [5] + ArcsecondSeriesForPrecession_GammaComponent [3]) +
                                      ArcsecondSeriesForPrecession_GammaComponent [0]);
                }
            }

            public static (double alpha, double beta, double gamma) GetEulerAnglesForPrecession (double T0, double dT)
            {
                double vernalEquinox = ComputeEulerAnglesInArcsec.Alpha (T0, dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox),
                        beta:  Trigonometry.SecToRad (ComputeEulerAnglesInArcsec.Beta (T0, dT)),
                        gamma: Trigonometry.SecToRad (-vernalEquinox - ComputeEulerAnglesInArcsec.GammaComponent (T0, dT)));
            }

            public static (double alpha, double beta, double gamma) GetEulerAnglesForPrecessionJ2000 (double dT)
            {
                double vernalEquinox = ComputeEulerAnglesInArcsecJ2000.Alpha (dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox),
                        beta:  Trigonometry.SecToRad (ComputeEulerAnglesInArcsecJ2000.Beta (dT)),
                        gamma: Trigonometry.SecToRad (-vernalEquinox - ComputeEulerAnglesInArcsecJ2000.GammaComponent (dT)));
            }

            public static Polar3 UpdateCoordinates (Polar3 p, double alpha, double beta, double gamma)
            {
                (double latitude, double longitude) = ComputeNewAngles (p, alpha, beta, gamma);

                return Polar3.CreateUnsafe (p.R, latitude, longitude);
            }

            private static (double latitude, double longitude) ComputeNewAngles (Polar3 p, double alpha, double beta, double gamma)
            {
                (double sinAlpha, double cosAlpha) = double.SinCos (alpha - p.Long);
                (double sinBeta,  double cosBeta)  = double.SinCos (beta);
                (double sinLat,   double cosLat)   = double.SinCos (p.Lat);

                double A = cosBeta * cosLat * sinAlpha - sinBeta * sinLat;                
                double B = cosLat  * cosAlpha;
                double C = sinBeta * cosLat * sinAlpha + cosBeta * sinLat;

                return (latitude:   Trigonometry.AsinEpsilon (C),
                        longitude: -gamma - Trigonometry.Atan2Epsilon (A, B));
            }
        }
    }
}