using System;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private IGravityMass _orbitalCenter;

        private double _p;

        private double _e;

        private double _rmin;

        private double _n;

        protected KeplerOrbit (IGravityMass orbitalCenter, double p, double e, double rmin, double n)
        {
            _orbitalCenter = orbitalCenter;

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