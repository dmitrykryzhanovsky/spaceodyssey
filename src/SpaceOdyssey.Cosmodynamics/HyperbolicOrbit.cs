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
            CheckEccentricityForHyperbola (eccentricity);
            CheckMeanMotion (meanMotion);

            _e = eccentricity;
            _n = meanMotion;

            _e2factor  = double.Sqrt (_e * _e - 1.0);
            _asymptote = double.Acos (-1.0 / _e);

            _a    = -double.Cbrt (K2 / (_n * _n)); ;
            _p    = _a * (1.0 - _e * _e);
            _amin = _a * (1.0 - _e);
        }

        public void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis)
        {
            CheckEccentricityForHyperbola (eccentricity);
            CheckNearestDistance (periapsis);

            _e    = eccentricity;
            _amin = periapsis;

            _e2factor = double.Sqrt (_e * _e - 1.0);
            _asymptote = double.Acos (-1.0 / _e);

            _p = _amin * (1.0 + _e);
            _a = _amin / (1.0 - _e);

            _n = K / (-_a * double.Sqrt (-_a));
        }

        private static void CheckEccentricityForHyperbola (double e)
        {
            if (!KeplerOrbitFormulae.IsEccentricityValidForHyperbola (e)) throw new ArgumentOutOfRangeException (ExceptionMessageText.HyperbolaEccentricityRange);
        }
    }
}