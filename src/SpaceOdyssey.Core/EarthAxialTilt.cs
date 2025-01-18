using Archimedes;

namespace SpaceOdyssey
{
    public static class EarthAxialTilt
    {
        private const double ApproximationArcmin = 84360;

        private static readonly double [] ArcsecondSeries_DE200  = new double [] {   21.448, 
                                                                                    -46.8150, 
                                                                                     -0.00059, 
                                                                                      0.001813 };

        private static readonly double [] ArcsecondSeries_P03    = new double [] {   21.406, 
                                                                                    -46.836769, 
                                                                                     -0.0001831, 
                                                                                      0.00200340, 
                                                                                     -0.000000576, 
                                                                                     -0.0000000434 };

        private static readonly double [] ArcsecondSeries_Laskar = new double [] {   21.448, 
                                                                                  -4680.93, 
                                                                                     -1.55, 
                                                                                   1999.25, 
                                                                                    -51.38, 
                                                                                   -249.67, 
                                                                                    -39.05, 
                                                                                      7.12, 
                                                                                     27.87, 
                                                                                      5.79, 
                                                                                      2.45 };

        public static double ComputeDE200 (double T)
        {
            return ApproximationArcmin + PolynomialAlgorithm.ComputeCube (T, ArcsecondSeries_DE200);
        }

        public static double ComputeP03 (double T)
        {
            return ApproximationArcmin + PolynomialAlgorithm.Compute (T, ArcsecondSeries_P03);
        }

        public static double ComputeLaskar (double T)
        {
            return ApproximationArcmin + PolynomialAlgorithm.Compute (T / 100.0, ArcsecondSeries_Laskar);
        }
    }
}