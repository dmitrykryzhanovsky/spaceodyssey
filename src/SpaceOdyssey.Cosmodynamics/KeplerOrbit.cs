using System;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        internal static readonly string [] OrbitalElementName = new string []
        {
            "semi-major axis",
            "mean motion",
            "orbital period"
        };

        private IGravityMass _gravityMass;

        private double _p;

        private double _e;

        private double _rmin;

        private double _n;

        protected KeplerOrbit (IGravityMass gravityMass, double p, double e, double rmin, double n)
        {
            _gravityMass = gravityMass;

            _p    = p;
            _e    = e;
            _rmin = rmin;
            _n    = n;
        }

        public double Distance (double trueAnomaly)
        {
            return _p / (1.0 + _e * Double.Cos (trueAnomaly));
        }
    }
}