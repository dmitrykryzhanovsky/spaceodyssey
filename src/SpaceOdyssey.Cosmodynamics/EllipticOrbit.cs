using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        protected double _b;

        protected double _amax;

        protected double _T;

        public EllipticOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        public void SetOrbitalElementsBySemiMajorAxis (double eccentricity, double semiMajorAxis)
        {
            CheckEccentricityForEllipse (eccentricity);
            CheckSemiMajorAxis (semiMajorAxis);

            _e = eccentricity;
            _a = semiMajorAxis;

            _e2factor = double.Sqrt (1.0 - _e * _e);
            
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _n = K / (_a * double.Sqrt (_a));
            _T = double.Tau / _n;
        }

        public void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion)
        {
            CheckEccentricityForEllipse (eccentricity);
            CheckMeanMotion (meanMotion);

            _e = eccentricity;
            _n = meanMotion;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _a    = double.Cbrt (K2 / (_n * _n)); ;
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _T = double.Tau / _n;
        }

        public void SetOrbitalElementsByOrbitalPeriod (double eccentricity, double orbitalPeriod)
        {
            CheckEccentricityForEllipse (eccentricity);
            CheckOrbitalPeriod (orbitalPeriod);

            _e = eccentricity;
            _T = orbitalPeriod;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _a    = double.Cbrt (K2 * _T * _T / MathConst.M_4_PI_SQR);
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _n = double.Tau / _T;
        }

        public void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis)
        {
            CheckEccentricityForEllipse (eccentricity);
            CheckNearestDistance (periapsis);

            _e    = eccentricity;
            _amin = periapsis;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _p    = _amin * (1.0 + _e);
            _a    = _amin / (1.0 - _e);
            _b    = _amin * double.Sqrt ((1.0 + _e) / (1.0 - _e));
            _amax = _amin * (1.0 + _e) / (1.0 - _e);

            _n = K / (_a * double.Sqrt (_a));
            _T = double.Tau / _n;
        }

        public void SetOrbitalElementsByApoapsis (double eccentricity, double apoapsis)
        {
            CheckEccentricityForEllipse (eccentricity);
            CheckFarthestDistance (apoapsis);

            _e    = eccentricity;
            _amax = apoapsis;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _p    = _amax * (1.0 - _e);
            _a    = _amax / (1.0 + _e);
            _b    = _amax * double.Sqrt ((1.0 - _e) / (1.0 + _e));
            _amin = _amax * (1.0 - _e) / (1.0 + _e);

            _n = K / (_a * double.Sqrt (_a));
            _T = double.Tau / _n;
        }

        public void SetOrbitalElementsByNearestFarthestDistances (double periapsis, double apoapsis)
        {
            CheckNearestDistance (periapsis);
            CheckFarthestDistance (apoapsis);
            CheckApsisDistances (periapsis, apoapsis);

            _amin = periapsis;
            _amax = apoapsis;

            double majorAxis = _amax + _amin;

            _e        = (_amax - _amin) / majorAxis;
            _e2factor = 2.0 * double.Sqrt (_amax * _amin) / majorAxis;

            _p = 2.0 * _amax * _amin / majorAxis;
            _a = majorAxis / 2.0;
            _b = double.Sqrt (_amax * _amin);

            _n = K / (_a * double.Sqrt (_a));
            _T = double.Tau / _n;
        }

        private static void CheckEccentricityForEllipse (double e)
        {
            if (!KeplerOrbitFormulae.IsEccentricityValidForEllipse (e)) throw new ArgumentOutOfRangeException (ExceptionMessageText.EllipseEccentricityRange);
        }

        protected static void CheckSemiMajorAxis (double a)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException (ExceptionMessageText.EllipseSemiMajorAxisRange);
        }

        private static void CheckFarthestDistance (double amax)
        {
            if (amax <= 0.0) throw new ArgumentOutOfRangeException (ExceptionMessageText.FarthestDistanceRange);
        }

        private static void CheckApsisDistances (double amin, double amax)
        {
            if (amin > amax) throw new ArgumentException (ExceptionMessageText.ApsisDistancesOrder);
        }        

        protected static void CheckOrbitalPeriod (double T)
        {
            if (T <= 0.0) throw new ArgumentOutOfRangeException (ExceptionMessageText.OrbitalPeriodRange);
        }
    }
}