using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление изменений координат между двумя моментами времени вследствие прецессии земной оси.
    /// </summary>
    public static class EarthPrecession
    {
        /// <summary>
        /// Вычисление процессии в экваториальных координатах.
        /// </summary>
        public static class Equatorial
        {
            private static readonly double [] ArcsecondSeries_VernalEquinoxPrecession = new double [] { 2306.2181,
                                                                                                           1.39656,
                                                                                                          -0.000139,
                                                                                                           0.30188,
                                                                                                          -0.000345,
                                                                                                           0.017998 };

            private static readonly double [] ArcsecondSeries_PrecessionNutation      = new double [] { 2004.3109, 
                                                                                                          -0.85330, 
                                                                                                          -0.000217, 
                                                                                                          -0.42665, 
                                                                                                          -0.000217, 
                                                                                                          -0.041833 };

            private static readonly double [] ArcsecondSeries_LongitudePrecession     = new double [] {    0.79280,
                                                                                                           0.000411,
                                                                                                           0.000205 };

            public static double VernalEquinoxPrecessionInArcsec (double T0, double dT)
            {
                return Function.Series_13 (T0, dT, ArcsecondSeries_VernalEquinoxPrecession);
            }

            public static double VernalEquinoxPrecessionJ2000InArcsec (double dT)
            {
                return dT * (dT * (dT * ArcsecondSeries_VernalEquinoxPrecession [5] + ArcsecondSeries_VernalEquinoxPrecession [3]) +
                             ArcsecondSeries_VernalEquinoxPrecession [0]);
            }

            public static double PrecessionNutationInArcsec (double T0, double dT)
            {
                return Function.Series_13 (T0, dT, ArcsecondSeries_PrecessionNutation);
            }

            public static double PrecessionNutationJ2000InArcsec (double dT)
            {
                return dT * (dT * (dT * ArcsecondSeries_PrecessionNutation [5] + ArcsecondSeries_PrecessionNutation [3]) +
                             ArcsecondSeries_PrecessionNutation [0]);
            }

            public static double LongitudePrecessionInArcsec (double T0, double dT)
            {
                return dT * dT * ((dT * ArcsecondSeries_LongitudePrecession [2]) + 
                                  (T0 * ArcsecondSeries_LongitudePrecession [1] + ArcsecondSeries_LongitudePrecession [0]));
            }

            public static double LongitudePrecessionJ2000InArcsec (double dT)
            {
                return dT * dT * ((dT * ArcsecondSeries_LongitudePrecession [2]) +
                                  ArcsecondSeries_LongitudePrecession [0]);
            }

            public static (double alpha, double beta, double gamma) EulerAnglesForPrecession (double T0, double dT)
            {
                double vernalEquinox = VernalEquinoxPrecessionInArcsec (T0, dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox),
                        beta:  Trigonometry.SecToRad (PrecessionNutationInArcsec (T0, dT)),
                        gamma: Trigonometry.SecToRad (vernalEquinox + LongitudePrecessionInArcsec (T0, dT)));
            }

            public static (double alpha, double beta, double gamma) EulerAnglesForPrecessionJ2000 (double dT)
            {
                double vernalEquinox = VernalEquinoxPrecessionJ2000InArcsec (dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox),
                        beta:  Trigonometry.SecToRad (PrecessionNutationJ2000InArcsec (dT)),
                        gamma: Trigonometry.SecToRad (vernalEquinox + LongitudePrecessionJ2000InArcsec (dT)));
            }

            public static (double newLatitude, double newLongitude) TransformCoordinates (double oldLatitude, double oldLongitude,
                (double alpha, double beta, double gamma) eulerAngles)
            {
                (double sinAlpha, double cosAlpha) = double.SinCos (oldLongitude + eulerAngles.alpha);
                (double sinBeta, double cosBeta) = double.SinCos (eulerAngles.beta);
                (double sinLat, double cosLat) = double.SinCos (oldLatitude);

                double A = cosLat * sinAlpha;
                double B = cosBeta * cosLat * cosAlpha - sinBeta * sinLat;
                double C = sinBeta * cosLat * cosAlpha + cosBeta * sinLat;

                return (newLatitude:  Trigonometry.AsinSmall (C),
                        newLongitude: Trigonometry.Atan2Small (A, B) + eulerAngles.gamma);
            }
        }

        /// <summary>
        /// Вычисление процессии в эклиптических координатах.
        /// </summary>
        public static class Ecliptic
        {
            private static readonly double [] ArcsecondSeries_VernalEquinoxPrecession = new double [] { 629554.982000,
                                                                                                          3289.4789,
                                                                                                             0.60622,
                                                                                                          -869.8089,
                                                                                                            -0.50491,
                                                                                                             0.03536 };

            private static readonly double [] ArcsecondSeries_PrecessionNutation      = new double [] {     47.0029,
                                                                                                            -0.06603,
                                                                                                             0.000598,
                                                                                                            -0.03302,
                                                                                                             0.000598,
                                                                                                             0.00006 };

            private static readonly double [] ArcsecondSeries_LongitudePrecession     = new double [] {   5029.0966,
                                                                                                             2.22226,
                                                                                                            -0.000042,
                                                                                                             1.11113,
                                                                                                            -0.000042,
                                                                                                            -0.000006 };

            public static double VernalEquinoxPrecessionInArcsec (double T0, double dT)
            {
                return Function.Series_02 (T0, dT, ArcsecondSeries_VernalEquinoxPrecession);
            }

            public static double VernalEquinoxPrecessionJ2000InArcsec (double dT)
            {
                return dT * (dT * ArcsecondSeries_VernalEquinoxPrecession [5] + ArcsecondSeries_VernalEquinoxPrecession [3]) +
                       ArcsecondSeries_VernalEquinoxPrecession [0];
            }

            public static double PrecessionNutationInArcsec (double T0, double dT)
            {
                return Function.Series_13 (T0, dT, ArcsecondSeries_PrecessionNutation);
            }

            public static double PrecessionNutationJ2000InArcsec (double dT)
            {
                return dT * (dT * (dT * ArcsecondSeries_PrecessionNutation [5] + ArcsecondSeries_PrecessionNutation [3]) +
                             ArcsecondSeries_PrecessionNutation [0]);
            }

            public static double LongitudePrecessionInArcsec (double T0, double dT)
            {
                return Function.Series_13 (T0, dT, ArcsecondSeries_LongitudePrecession);
            }

            public static double LongitudePrecessionJ2000InArcsec (double dT)
            {
                return dT * (dT * (dT * ArcsecondSeries_LongitudePrecession [5] + ArcsecondSeries_LongitudePrecession [3]) +
                             ArcsecondSeries_LongitudePrecession [0]);
            }

            public static (double alpha, double beta, double gamma) EulerAnglesForPrecession (double T0, double dT)
            {
                double vernalEquinox = VernalEquinoxPrecessionInArcsec (T0, dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox),
                        beta:  Trigonometry.SecToRad (PrecessionNutationInArcsec (T0, dT)),
                        gamma: Trigonometry.SecToRad (-vernalEquinox - LongitudePrecessionInArcsec (T0, dT)));
            }

            public static (double alpha, double beta, double gamma) EulerAnglesForPrecessionJ2000 (double dT)
            {
                double vernalEquinox = VernalEquinoxPrecessionJ2000InArcsec (dT);

                return (alpha: Trigonometry.SecToRad (vernalEquinox),
                        beta:  Trigonometry.SecToRad (PrecessionNutationJ2000InArcsec (dT)),
                        gamma: Trigonometry.SecToRad (-vernalEquinox - LongitudePrecessionJ2000InArcsec (dT)));
            }

            public static (double newLatitude, double newLongitude) TransformCoordinates (double oldLatitude, double oldLongitude,
                (double alpha, double beta, double gamma) eulerAngles)
            {
                (double sinAlpha, double cosAlpha) = double.SinCos (eulerAngles.alpha - oldLongitude);
                (double sinBeta,  double cosBeta)  = double.SinCos (eulerAngles.beta);
                (double sinLat,   double cosLat)   = double.SinCos (oldLatitude);

                double A = cosBeta * cosLat * sinAlpha - sinBeta * sinLat;                
                double B = cosLat * cosAlpha;
                double C = sinBeta * cosLat * sinAlpha + cosBeta * sinLat;

                return (newLatitude:  Trigonometry.AsinSmall (C),
                        newLongitude: -eulerAngles.gamma - Trigonometry.Atan2Small (A, B));
            }
        }
    }
}