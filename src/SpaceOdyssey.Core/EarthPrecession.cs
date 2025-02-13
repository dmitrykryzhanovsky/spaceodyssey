using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление изменений координат между двумя моментами времени вследствие прецессии земной оси.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Данный класс содержит два вложенных класса: <see cref="Equatorial"/> для вычисления прецессии в экваториальных и 
    ///     <see cref="Ecliptic"/> для вычисления прецессии в эклиптических координатах.
    /// </para>
    /// <para>
    ///     Каждый из вложенных классов содержит методы для вычисления углов прецессии и методы для вычисления координат, изменившихся 
    ///     в результате прецессии.
    /// </para>
    /// <para>
    ///     Методы VernalEquinox, Nutation и InLongitude в подклассе ReferenceAnglesInArcsec вычисляют углы, на которые сместилась 
    ///     система небесных координат в результате прецессии с момента времени T0 до момента времени T0 + dT. Подкласс 
    ///     ReferenceAnglesJ2000InArcsec – это их аналоги для случая, когда T0 = 0, то есть соответствует моменту времени J2000. T0 
    ///     задаётся в юлианских столетиях от момента времени J2000, dT – тоже в юлианских столетиях от момента времени T0. 
    ///     Все эти шесть методов возвращают углы, выраженные в секундах.
    /// </para>
    /// <para>
    ///     В случае эклиптической системы координат (класс <see cref="Ecliptic"/>) 
    ///     <list type="bullet">
    ///         <item>угол, возвращаемый методом VernalEquinox, показывает угол, на который линия узлов отстоит от точки весеннего 
    ///         равноденствия;</item> 
    ///         <item>угол, возвращаемый методом Nutation, показывает угол, на который плоскость эклиптики поворачивается за время dT;</item> 
    ///         <item>угол, возвращаемый методом InLongitude, показывает угол, на который точка весеннего равноденствия смещается за 
    ///         время dT по долготе.</item> 
    ///     </list>    
    ///     Для экваториальной системы координат (класс <see cref="Equatorial"/>) смысл схожий, но есть отличия, поэтому напрямую эти 
    ///     углы применять нельзя.
    /// </para>
    /// <para>
    ///     Методы EulerAnglesForPrecession и EulerAnglesForPrecessionJ2000 возвращают углы, вычисляемые на основе смещений системы 
    ///     координат, которые уже непосредственно используются для определения новых координат. В случае эклиптических координат 
    ///     (класс <see cref="Ecliptic"/>) это углы Эйлера, задающие поворот системы координат. Данные методы возвращают углы в 
    ///     радианах.
    /// </para>
    /// <para>
    ///     Для вычисления новых координат нужно воспользоваться методом UpdateCoordinates. Вместо вычислений через углы Эйлера здесь 
    ///     используются прямые формулы, взятые из [Jean Meeuse. Astronomical algorithms. 2nd ed. Chapter 21]. Параметр eulerAngles – 
    ///     это углы, возвращаемые методом EulerAnglesForPrecession. И входные параметры, и выходные результаты метода 
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
            private static readonly double [] ArcsecondSeriesForPrecession_VernalEquinox = new double [] { 2306.2181,
                                                                                                              1.39656,
                                                                                                             -0.000139,
                                                                                                              0.30188,
                                                                                                             -0.000345,
                                                                                                              0.017998 };

            private static readonly double [] ArcsecondSeriesForPrecession_Nutation      = new double [] { 2004.3109, 
                                                                                                             -0.85330, 
                                                                                                             -0.000217, 
                                                                                                             -0.42665, 
                                                                                                             -0.000217, 
                                                                                                             -0.041833 };

            private static readonly double [] ArcsecondSeriesForPrecession_InLongitude   = new double [] {    0.79280,
                                                                                                              0.000411,
                                                                                                              0.000205 };

            public static class ReferenceAnglesInArcsec
            {
                public static double VernalEquinox (double T0, double dT)
                {
                    return Function.Series_13 (T0, dT, ArcsecondSeriesForPrecession_VernalEquinox);
                }

                public static double Nutation (double T0, double dT)
                {
                    return Function.Series_13 (T0, dT, ArcsecondSeriesForPrecession_Nutation);
                }

                public static double InLongitude (double T0, double dT)
                {
                    return dT * dT * ((dT * ArcsecondSeriesForPrecession_InLongitude [2]) +
                                      (T0 * ArcsecondSeriesForPrecession_InLongitude [1] + ArcsecondSeriesForPrecession_InLongitude [0]));
                }
            }

            public static class ReferenceAnglesJ2000InArcsec
            {
                public static double VernalEquinox (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_VernalEquinox [5] + ArcsecondSeriesForPrecession_VernalEquinox [3]) +
                                 ArcsecondSeriesForPrecession_VernalEquinox [0]);
                }

                public static double Nutation (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_Nutation [5] + ArcsecondSeriesForPrecession_Nutation [3]) +
                                 ArcsecondSeriesForPrecession_Nutation [0]);
                }

                public static double InLongitude (double dT)
                {
                    return dT * dT * ((dT * ArcsecondSeriesForPrecession_InLongitude [2]) +
                                      ArcsecondSeriesForPrecession_InLongitude [0]);
                }
            }

            public static EulerAngles EulerAnglesForPrecession (double T0, double dT)
            {
                double vernalEquinox = ReferenceAnglesInArcsec.VernalEquinox (T0, dT);

                return new EulerAngles (alpha: Trigonometry.SecToRad (vernalEquinox), 
                                        beta:  Trigonometry.SecToRad (ReferenceAnglesInArcsec.Nutation (T0, dT)), 
                                        gamma: Trigonometry.SecToRad (vernalEquinox + ReferenceAnglesInArcsec.InLongitude (T0, dT)));
            }

            public static EulerAngles EulerAnglesForPrecessionJ2000 (double dT)
            {
                double vernalEquinox = ReferenceAnglesJ2000InArcsec.VernalEquinox (dT);

                return new EulerAngles (alpha: Trigonometry.SecToRad (vernalEquinox), 
                                        beta:  Trigonometry.SecToRad (ReferenceAnglesJ2000InArcsec.Nutation (dT)), 
                                        gamma: Trigonometry.SecToRad (vernalEquinox + ReferenceAnglesJ2000InArcsec.InLongitude (dT)));
            }

            public static Polar3 UpdateCoordinates (Polar3 p, EulerAngles eulerAngles)
            {
                (double declination, double rightAscension) = ComputeNewAngles (p, eulerAngles);

                return Polar3.InitDirect (p.R, declination, rightAscension);
            }

            public static UnitPolar3 UpdateCoordinates (UnitPolar3 p, EulerAngles eulerAngles)
            {
                (double declination, double rightAscension) = ComputeNewAngles (p, eulerAngles);

                return UnitPolar3.InitDirect (declination, rightAscension);
            }

            private static (double declination, double rightAscension) ComputeNewAngles (Polar3 p, EulerAngles eulerAngles)
            {
                (double sinAlpha, double cosAlpha) = double.SinCos (p.Longitude + eulerAngles.Alpha);
                (double sinBeta,  double cosBeta)  = double.SinCos (eulerAngles.Beta);
                (double sinLat,   double cosLat)   = double.SinCos (p.Latitude);

                double A = cosLat  * sinAlpha;
                double B = cosBeta * cosLat * cosAlpha - sinBeta * sinLat;
                double C = sinBeta * cosLat * cosAlpha + cosBeta * sinLat;

                return (declination:    Trigonometry.AsinSmall (C),
                        rightAscension: Trigonometry.Atan2Small (A, B) + eulerAngles.Gamma);
            }
        }

        /// <summary>
        /// Вычисление прецессии в эклиптических координатах.
        /// </summary>
        public static class Ecliptic
        {
            private static readonly double [] ArcsecondSeriesForPrecession_VernalEquinox = new double [] { 629554.982000,
                                                                                                             3289.4789,
                                                                                                                0.60622,
                                                                                                             -869.8089,
                                                                                                               -0.50491,
                                                                                                                0.03536 };

            private static readonly double [] ArcsecondSeriesForPrecession_Nutation      = new double [] {     47.0029,
                                                                                                               -0.06603,
                                                                                                                0.000598,
                                                                                                               -0.03302,
                                                                                                                0.000598,
                                                                                                                0.00006 };

            private static readonly double [] ArcsecondSeriesForPrecession_InLongitude   = new double [] {   5029.0966,
                                                                                                                2.22226,
                                                                                                               -0.000042,
                                                                                                                1.11113,
                                                                                                               -0.000042,
                                                                                                               -0.000006 };

            public static class ReferenceAnglesInArcsec
            {
                public static double VernalEquinox (double T0, double dT)
                {
                    return Function.Series_02 (T0, dT, ArcsecondSeriesForPrecession_VernalEquinox);
                }

                public static double Nutation (double T0, double dT)
                {
                    return Function.Series_13 (T0, dT, ArcsecondSeriesForPrecession_Nutation);
                }

                public static double InLongitude (double T0, double dT)
                {
                    return Function.Series_13 (T0, dT, ArcsecondSeriesForPrecession_InLongitude);
                }
            }

            public static class ReferenceAnglesJ2000InArcsec
            {
                public static double VernalEquinox (double dT)
                {
                    return dT * (dT * ArcsecondSeriesForPrecession_VernalEquinox [5] + ArcsecondSeriesForPrecession_VernalEquinox [3]) +
                                 ArcsecondSeriesForPrecession_VernalEquinox [0];
                }

                public static double Nutation (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_Nutation [5] + ArcsecondSeriesForPrecession_Nutation [3]) +
                                 ArcsecondSeriesForPrecession_Nutation [0]);
                }

                public static double InLongitude (double dT)
                {
                    return dT * (dT * (dT * ArcsecondSeriesForPrecession_InLongitude [5] + ArcsecondSeriesForPrecession_InLongitude [3]) +
                                 ArcsecondSeriesForPrecession_InLongitude [0]);
                }
            }

            public static EulerAngles EulerAnglesForPrecession (double T0, double dT)
            {
                double vernalEquinox = ReferenceAnglesInArcsec.VernalEquinox (T0, dT);

                return new EulerAngles (alpha: Trigonometry.SecToRad (vernalEquinox),
                                        beta:  Trigonometry.SecToRad (ReferenceAnglesInArcsec.Nutation (T0, dT)),
                                        gamma: Trigonometry.SecToRad (-vernalEquinox - ReferenceAnglesInArcsec.InLongitude (T0, dT)));
            }

            public static EulerAngles EulerAnglesForPrecessionJ2000 (double dT)
            {
                double vernalEquinox = ReferenceAnglesJ2000InArcsec.VernalEquinox (dT);

                return new EulerAngles (alpha: Trigonometry.SecToRad (vernalEquinox),
                                        beta:  Trigonometry.SecToRad (ReferenceAnglesJ2000InArcsec.Nutation (dT)),
                                        gamma: Trigonometry.SecToRad (-vernalEquinox - ReferenceAnglesJ2000InArcsec.InLongitude (dT)));
            }

            public static Polar3 UpdateCoordinates (Polar3 p, EulerAngles eulerAngles)
            {
                (double declination, double rightAscension) = ComputeNewAngles (p, eulerAngles);

                return Polar3.InitDirect (p.R, declination, rightAscension);
            }

            public static UnitPolar3 UpdateCoordinates (UnitPolar3 p, EulerAngles eulerAngles)
            {
                (double declination, double rightAscension) = ComputeNewAngles (p, eulerAngles);

                return UnitPolar3.InitDirect (declination, rightAscension);
            }

            public static (double latitude, double longitude) ComputeNewAngles (Polar3 p, EulerAngles eulerAngles)
            {
                (double sinAlpha, double cosAlpha) = double.SinCos (eulerAngles.Alpha - p.Longitude);
                (double sinBeta,  double cosBeta)  = double.SinCos (eulerAngles.Beta);
                (double sinLat,   double cosLat)   = double.SinCos (p.Latitude);

                double A = cosBeta * cosLat * sinAlpha - sinBeta * sinLat;                
                double B = cosLat  * cosAlpha;
                double C = sinBeta * cosLat * sinAlpha + cosBeta * sinLat;

                return (latitude:   Trigonometry.AsinSmall (C),
                        longitude: -eulerAngles.Gamma - Trigonometry.Atan2Small (A, B));
            }
        }
    }
}