using System;

using Archimedes.Numerical;

namespace SpaceOdyssey.Cosmodynamics
{
    public static class KeplerEquation
    {
        private static double EllipticEquation (double E, params double [] param)
        {
            return E - param [0] * Double.Sin (E) - param [1];
        }

        private static double EllipticDerivative (double E, params double [] param)
        {
            return 1.0 - param [0] * Double.Cos (E);
        }

        public static double Elliptic (double M, double eccentricity, double epsilon)
        {
            return NonLinearEquation.Newton (EllipticEquation, EllipticDerivative, epsilon, M, eccentricity, M);
        }
    }
}
