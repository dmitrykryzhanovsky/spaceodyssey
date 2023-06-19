using System;

using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class CelestialObject : IGravitationalCenter
    {
        private double _K;
        private double _KRoot;
        private double _K2Root;
        private double _C;
        private double _R;

        public double K
        {
            get => _K;
        }

        public double KRoot
        {
            get => _KRoot;
        }

        public double C
        {
            get => _C;
        }

        public double R
        {
            get => _R;
        }

        public CelestialObject (double K, double R)
        {
            _K      = K;
            _KRoot  = Math.Sqrt (_K);
            _K2Root = Math.Sqrt (2.0 * _K);
            _C      = Math.Tau / _KRoot;
            _R      = R;
        }

        public static CelestialObject InitByMass (double M, double R)
        {
            double K = PhysConst.G * M;

            return new CelestialObject (K, R);
        }

        public double GetV1 ()
        {
            return GetV1 (_R);
        }

        public double GetV1 (double r)
        {
            return _KRoot / Math.Sqrt (r);
        }

        public double [] GetV1 (params double [] r)
        {
            double [] output = new double [r.Length];

            for (int i = 0; i < r.Length; i++)
            {
                output [i] = GetV1 (r [i]);
            }

            return output;
        }

        public double GetV2 ()
        {
            return GetV2 (_R);
        }

        public double GetV2 (double r)
        {
            return _K2Root / Math.Sqrt (r);
        }

        public double [] GetV2 (params double [] r)
        {
            double [] output = new double [r.Length];

            for (int i = 0; i < r.Length; i++)
            {
                output [i] = GetV2 (r [i]);
            }

            return output;
        }

        public (double, double) GetEscapeVelocities ()
        {
            return GetEscapeVelocities (_R);
        }

        public (double, double) GetEscapeVelocities (double r)
        {
            double v1 = GetV1 (r);
            double v2 = v1 * MathConst.M_SQRT_2;

            return (v1, v2);
        }

        public (double, double) [] GetEscapeVelocities (params double [] r)
        {
            (double, double) [] output = new (double, double) [r.Length];

            for (int i = 0; i < r.Length; i++)
            {
                output [i] = GetEscapeVelocities (r [i]);
            }

            return output;
        }
    }
}