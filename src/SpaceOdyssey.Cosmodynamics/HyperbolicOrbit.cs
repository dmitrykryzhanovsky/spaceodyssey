using System.Numerics;

namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private double _asymptote;

        public HyperbolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        public void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion)
        {
            CheckEccentricity (eccentricity);
            CheckMeanMotion (meanMotion);

            _e = eccentricity;
            _n = meanMotion;

            _e2factor  = double.Sqrt (_e * _e - 1.0);
            _asymptote = double.Acos (-1.0 / _e);

            _a    = -CosmodynamicsFormulae.SemiMajorAxisByMeanMotion (K2, _n);
            _p    = _a * (1.0 - _e * _e);
            _amin = _a * (1.0 - _e);
        }

        public void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis)
        {
            CheckEccentricity (eccentricity);
            CheckPeriapsis (periapsis);

            _e    = eccentricity;
            _amin = periapsis;

            _e2factor  = double.Sqrt (_e * _e - 1.0);
            _asymptote = double.Acos (-1.0 / _e);

            _p = _amin * (1.0 + _e);
            _a = _amin / (1.0 - _e);

            _n = CosmodynamicsFormulae.MeanMotionBySemiMajorAxisForHyperbola (K, _a);
        }

        private static void CheckEccentricity (double eccentricity)
        {
            if (!CosmodynamicsFormulae.IsEccentricityValidForHyperbola (eccentricity)) throw new HyperbolaEccentricityOutOfRangeException ();
        }
    }
}