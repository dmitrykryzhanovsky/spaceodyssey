using Archimedes;

namespace SpaceOdyssey
{
    public static class Precession
    {
        private static readonly double [] LongitudePrecession_Series = new double []
        {
            Trigonometry.SecToRad (5029.0966),
            Trigonometry.SecToRad (   2.22226),
            Trigonometry.SecToRad (  -0.000042),
            Trigonometry.SecToRad (   1.11113),
            Trigonometry.SecToRad (  -0.000042),
            Trigonometry.SecToRad (  -0.000006)
        };

        public static double GetLongitudePrecession (double T0, double dT)
        {
            return dT * (dT * (dT * LongitudePrecession_Series [5] + 
                              (T0 * LongitudePrecession_Series [4] + LongitudePrecession_Series [3])) + 
                        (T0 * (T0 * LongitudePrecession_Series [2] + LongitudePrecession_Series [1]) + LongitudePrecession_Series [0]));
        }
    }
}