using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Основные формулы для вычислений.
    /// </summary>
    public static class Formulae
    {
        public static double ConicSection (double trueAnomaly, double p, double e)
        {
            return p / (1.0 + e * double.Cos (trueAnomaly));
        }

        public static double ConicSectionParabola (double trueAnomaly, double p)
        {
            return p / (1.0 + double.Cos (trueAnomaly));
        }

        public static double ConicSectionInverse (double r, double p, double e)
        {
            return double.Acos ((p / r - 1.0) / e);
        }

        public static double ConicSectionInverseParabola (double r, double p)
        {
            return double.Acos (p / r - 1.0);
        }

        public static double PParabolaByRp (double rp)
        {
            return rp * 2.0;
        }

        public static double Asymptote (double e)
        {
            return double.Acos (-1.0 / e);
        }

        public static double RangeARp (double x1me)
        {
            return 1.0 / x1me;
        }

        public static double RangeRaA (double x1pe)
        {
            return x1pe;
        }

        public static double RangeRaRp (double x1me, double x1pe)
        {
            return x1pe / x1me;
        }

        public static double GMA (double mu, double a)
        {
            return mu / a;
        }

        public static double GMASqrt (double mua)
        {
            return double.Sqrt (mua);
        }

        public static double V1Circular (double mu, double r)
        {
            return double.Sqrt (mu / r);
        }

        public static double V2Escape (double mu, double r)
        {
            return double.Sqrt (2.0 * mu / r);
        }

        public static double MeanMotion (double a, double muasqrt)
        {
            return muasqrt / a;
        }

        public static double OrbitalPeriod (double a, double muasqrt)
        {
            return double.Tau * a / muasqrt;
        }

        public static double ArealVelocityNonParabola (double mu, double a)
        {
            return double.Sqrt (mu * a);
        }

        public static double ArealVelocityParabola (double mu, double rp)
        {
            return double.Sqrt (2.0 * mu * rp);
        }

        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForCircle (double anomaly, params double [] param)
        {
            (double sin, double cos) = double.SinCos (anomaly);

            double x = param [0] * cos;
            double y = param [0] * sin;
            double r = param [0];
            double trueAnomaly = anomaly;

            return (x, y, r, trueAnomaly);
        }

        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForEllipse (double anomaly, params double [] param)
        {
            (double sin, double cos) = double.SinCos (anomaly);

            double x = param [0] * (cos - param [1]);
            double y = param [0] * param [2] * sin;
            (double r, double trueAnomaly) = Space2.ComputePolarComponents (x, y);

            return (x, y, r, trueAnomaly);
        }

        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForHyperbola (double anomaly, params double [] param)
        {
            double x = param [0] * (param [1] - double.Cosh (anomaly));
            double y = param [0] * param [2] * double.Sinh (anomaly);
            (double r, double trueAnomaly) = Space2.ComputePolarComponents (x, y);

            return (x, y, r, trueAnomaly);
        }

        public static (double x, double y, double r, double trueAnomaly) ComputePlanarPositionForParabola (double anomaly, params double [] param)
        {
            double x = param [0] * (1 - anomaly * anomaly);
            double y = 2.0 * param [0] * anomaly;
            (double r, double trueAnomaly) = Space2.ComputePolarComponents (x, y);

            return (x, y, r, trueAnomaly);
        }
    }
}