using Archimedes;

namespace SpaceOdyssey
{
    public static class EarthPrecession
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

        public static double VernalEquinoxPrecession (double T0, double dT)
        {
            return Function.Series_02 (T0, dT, ArcsecondSeries_VernalEquinoxPrecession);
        }

        public static double VernalEquinoxPrecessionJ2000 (double dT)
        {
            return dT * (dT * ArcsecondSeries_VernalEquinoxPrecession [5] + ArcsecondSeries_VernalEquinoxPrecession [3]) +
                   ArcsecondSeries_VernalEquinoxPrecession [0];
        }

        public static double PrecessionNutation (double T0, double dT)
        {
            return Function.Series_13 (T0, dT, ArcsecondSeries_PrecessionNutation);
        }

        public static double PrecessionNutationJ2000 (double dT)
        {
            return dT * (dT * (dT * ArcsecondSeries_PrecessionNutation [5] + ArcsecondSeries_PrecessionNutation [3]) +
                         ArcsecondSeries_PrecessionNutation [0]);
        }

        public static double LongitudePrecession (double T0, double dT)
        {
            return Function.Series_13 (T0, dT, ArcsecondSeries_LongitudePrecession);
        }

        public static double LongitudePrecessionJ2000 (double dT)
        {
            return dT * (dT * (dT * ArcsecondSeries_LongitudePrecession [5] + ArcsecondSeries_LongitudePrecession [3]) +
                         ArcsecondSeries_LongitudePrecession [0]);
        }

        public static (double alpha, double beta, double gamma) EulerAnglesForPrecession (double T0, double dT)
        {
            double vernalEquinox = VernalEquinoxPrecession (T0, dT);

            return (alpha: Trigonometry.SecToRad (vernalEquinox), 
                    beta:  Trigonometry.SecToRad (PrecessionNutation (T0, dT)), 
                    gamma: Trigonometry.SecToRad (-vernalEquinox - LongitudePrecession (T0, dT)));
        }
    }
}