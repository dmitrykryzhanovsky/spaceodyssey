using Archimedes;

namespace SpaceOdyssey
{
    public static class Precession
    {
        private static readonly double [] VernalEquinoxPrecession_Series = new double []
        {
            Trigonometry.DegToRad ( 174.876383889),
            Trigonometry.SecToRad (3289.4789),
            Trigonometry.SecToRad (   0.60622),
            Trigonometry.SecToRad (-869.8089),
            Trigonometry.SecToRad (  -0.50491),
            Trigonometry.SecToRad (   0.03536)
        };

        private static readonly double [] PrecessionNutation_Series = new double []
        {
            Trigonometry.SecToRad (47.0029),
            Trigonometry.SecToRad (-0.06603),
            Trigonometry.SecToRad ( 0.000598),
            Trigonometry.SecToRad (-0.03302),
            Trigonometry.SecToRad ( 0.000598),
            Trigonometry.SecToRad ( 0.00006)
        };

        private static readonly double [] LongitudePrecession_Series = new double []
        {
            Trigonometry.SecToRad (5029.0966),
            Trigonometry.SecToRad (   2.22226),
            Trigonometry.SecToRad (  -0.000042),
            Trigonometry.SecToRad (   1.11113),
            Trigonometry.SecToRad (  -0.000042),
            Trigonometry.SecToRad (  -0.000006)
        };

        public static double GetVernalEquinoxPrecession (double T0, double dT)
        {
            return dT * (dT * VernalEquinoxPrecession_Series [5] +
                        (T0 * VernalEquinoxPrecession_Series [4] + VernalEquinoxPrecession_Series [3])) +
                   T0 * (T0 * VernalEquinoxPrecession_Series [2] + VernalEquinoxPrecession_Series [1]) + VernalEquinoxPrecession_Series [0];
        }

        public static double GetVernalEquinoxPrecessionJ2000 (double dT)
        {
            return dT * (dT * VernalEquinoxPrecession_Series [5] + VernalEquinoxPrecession_Series [3]) + 
                              VernalEquinoxPrecession_Series [0];
        }

        public static double GetPrecessionNutation (double T0, double dT)
        {
            return dT * (dT * (dT * PrecessionNutation_Series [5] +
                              (T0 * PrecessionNutation_Series [4] + PrecessionNutation_Series [3])) +
                        (T0 * (T0 * PrecessionNutation_Series [2] + PrecessionNutation_Series [1]) + PrecessionNutation_Series [0]));
        }

        public static double GetPrecessionNutationJ2000 (double dT)
        {
            return dT * (dT * (dT * PrecessionNutation_Series [5] + PrecessionNutation_Series [3]) + 
                                    PrecessionNutation_Series [0]);
        }

        public static double GetLongitudePrecession (double T0, double dT)
        {
            return dT * (dT * (dT * LongitudePrecession_Series [5] + 
                              (T0 * LongitudePrecession_Series [4] + LongitudePrecession_Series [3])) + 
                        (T0 * (T0 * LongitudePrecession_Series [2] + LongitudePrecession_Series [1]) + LongitudePrecession_Series [0]));
        }

        public static double GetLongitudePrecessionJ2000 (double dT)
        {
            return dT * (dT * (dT * LongitudePrecession_Series [5] + LongitudePrecession_Series [3]) +
                                    LongitudePrecession_Series [0]);
        }

        public static (double, double, double) GetEulerAnglesForPrecession (double T0, double dT)
        {
            double alpha = GetVernalEquinoxPrecession (T0, dT);
            double beta  = GetPrecessionNutation (T0, dT);
            double gamma = -alpha - GetLongitudePrecession (T0, dT);

            return (alpha, beta, gamma);
        }

        public static (double, double, double) GetEulerAnglesForPrecessionJ2000 (double dT)
        {
            double alpha = GetVernalEquinoxPrecessionJ2000 (dT);
            double beta  = GetPrecessionNutationJ2000 (dT);
            double gamma = - alpha - GetLongitudePrecessionJ2000 (dT);

            return (alpha, beta, gamma);
        }
    }
}