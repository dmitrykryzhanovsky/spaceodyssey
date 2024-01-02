using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Круговая орбита.
    /// </summary>
    public class CircularOrbit : EllipticOrbit
    {
        public CircularOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        public void SetOrbitalElementsBySemiMajorAxis (double semiMajorAxis)
        {
            CheckSemiMajorAxis (semiMajorAxis);

            _a = semiMajorAxis;

            _e        = 0.0;
            _e2factor = 1.0;

            _p    = _a;
            _b    = _a;
            _amin = _a;
            _amax = _a;

            _n = K / (_a * double.Sqrt (_a));
            _T = double.Tau / _n;
        }

        public void SetOrbitalElementsByMeanMotion (double meanMotion)
        {
            CheckMeanMotion (meanMotion);

            _n = meanMotion;

            _e        = 0.0;
            _e2factor = 1.0;

            _a    = double.Cbrt (K2 / (_n * _n)); ;
            _p    = _a;
            _b    = _a;
            _amin = _a;
            _amax = _a;

            _T = double.Tau / _n;
        }

        public void SetOrbitalElementsByOrbitalPeriod (double orbitalPeriod)
        {
            CheckOrbitalPeriod (orbitalPeriod);

            _T = orbitalPeriod;

            _e        = 0.0;
            _e2factor = 1.0;

            _a    = double.Cbrt (K2 * _T * _T / MathConst.M_4_PI_SQR);
            _p    = _a;
            _b    = _a;
            _amin = _a;
            _amax = _a;

            _n = double.Tau / _T;
        }
    }
}