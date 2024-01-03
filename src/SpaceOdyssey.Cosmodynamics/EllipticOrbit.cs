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
            CheckEccentricity (eccentricity);
            CheckSemiMajorAxis (semiMajorAxis);

            _e = eccentricity;
            _a = semiMajorAxis;

            _e2factor = double.Sqrt (1.0 - _e * _e);
            
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);
        }

        public void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion)
        {
            CheckEccentricity (eccentricity);
            CheckMeanMotion (meanMotion);

            _e = eccentricity;
            _n = meanMotion;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _a    = CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (K2, _n);
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);
        }

        public void SetOrbitalElementsByOrbitalPeriod (double eccentricity, double orbitalPeriod)
        {
            CheckEccentricity (eccentricity);
            CheckOrbitalPeriod (orbitalPeriod);

            _e = eccentricity;
            _T = orbitalPeriod;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _a    = CosmodynamicsFormulae.SemiMajorAxisByOrbitalPeriod (K2, _T);
            _p    = _a * (1.0 - _e * _e);
            _b    = _a * _e2factor;
            _amin = _a * (1.0 - _e);
            _amax = _a * (1.0 + _e);

            _n = CosmodynamicsFormulae.MeanMotionByOrbitalPeriod (_T);
        }

        public void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis)
        {
            CheckEccentricity (eccentricity);
            CheckPeriapsis (periapsis);

            _e    = eccentricity;
            _amin = periapsis;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _p    = _amin * (1.0 + _e);
            _a    = _amin / (1.0 - _e);
            _b    = _amin * double.Sqrt ((1.0 + _e) / (1.0 - _e));
            _amax = _amin * (1.0 + _e) / (1.0 - _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);
        }

        public void SetOrbitalElementsByApoapsis (double eccentricity, double apoapsis)
        {
            CheckEccentricity (eccentricity);
            CheckApoapsis (apoapsis);

            _e    = eccentricity;
            _amax = apoapsis;

            _e2factor = double.Sqrt (1.0 - _e * _e);

            _p    = _amax * (1.0 - _e);
            _a    = _amax / (1.0 + _e);
            _b    = _amax * double.Sqrt ((1.0 - _e) / (1.0 + _e));
            _amin = _amax * (1.0 - _e) / (1.0 + _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);
        }

        public void SetOrbitalElementsByNearestFarthestDistances (double periapsis, double apoapsis)
        {
            CheckPeriapsis (periapsis);
            CheckApoapsis (apoapsis);
            CheckApsisDistances (periapsis, apoapsis);

            _amin = periapsis;
            _amax = apoapsis;

            double majorAxis = _amax + _amin;

            _e        = (_amax - _amin) / majorAxis;
            _e2factor = 2.0 * double.Sqrt (_amax * _amin) / majorAxis;

            _p = 2.0 * _amax * _amin / majorAxis;
            _a = majorAxis / 2.0;
            _b = double.Sqrt (_amax * _amin);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForEllipse (K, _a);
            _T = CosmodynamicsFormulae.OrbitalPeriodByMeanMotion (_n);
        }

        private static void CheckEccentricity (double eccentricity)
        {
            if (!CosmodynamicsFormulae.IsEccentricityValidForEllipse (eccentricity)) throw new EllipseEccentricityOutOfRangeException ();
        }

        protected static void CheckSemiMajorAxis (double semiMajorAxis)
        {
            if (semiMajorAxis <= 0.0) throw new DimensionalElementNegativeException ();
        }

        private static void CheckApoapsis (double apoapsis)
        {
            if (apoapsis <= 0.0) throw new DimensionalElementNegativeException ();
        }

        private static void CheckApsisDistances (double periapsis, double apoapsis)
        {
            if (periapsis > apoapsis) throw new MinMaxDisorderException ("periapsis", "apoapsis");
        }        

        protected static void CheckOrbitalPeriod (double orbitalPeriod)
        {
            if (orbitalPeriod <= 0.0) throw new TemporalElementNegativeException ();
        }
    }
}