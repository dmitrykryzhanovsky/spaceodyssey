﻿namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : NonParabolicOrbit
    {
        private double _rmax;

        private double _T;

        protected EllipticOrbit (IGravityMass orbitalCenter, double p, double e, double a, double rmin, double rmax, double n, double T) :
            base (orbitalCenter, p, e, a, rmin, n)
        {
        }
    }
}