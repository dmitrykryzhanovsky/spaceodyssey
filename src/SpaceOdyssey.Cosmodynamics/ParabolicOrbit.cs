namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Параболическая орбита.
    /// </summary>
    public class ParabolicOrbit : KeplerOrbit
    {
        public ParabolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        public void SetOrbitalElementsByMeanMotion (double meanMotion)
        {
            CheckMeanMotion (meanMotion);

            _n = meanMotion;

            _e    = 1.0;
            _amin = double.Cbrt (K2 / (2.0 * _n * _n));
            _p    = 2.0 * _amin;
        }

        public void SetOrbitalElementsByPeriapsis (double periapsis)
        {
            CheckPeriapsis (periapsis);

            _amin = periapsis;

            _e = 1.0;
            _p = 2.0 * _amin;
            _n = K / (_amin * double.Sqrt (2.0 * _amin));
        }
    }
}