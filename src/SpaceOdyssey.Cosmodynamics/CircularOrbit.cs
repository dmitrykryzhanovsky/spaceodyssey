using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public class CircularOrbit : EllipticOrbit
    {
        public override double RatioAP
        {
            get => 1.0;
        }

        public override double RatioAMean
        {
            get => 1.0;
        }

        public override double RatioMeanP
        {
            get => 1.0;
        }

        protected CircularOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        public override double Radius (double trueAnomaly)
        {
            return _a;
        }

        protected override void CheckR (double r)
        {
            ArgumentOutOfRangeCheckers.CheckEqual (r, _a);
        }

        protected override double ConicSectionInverseEquation (double r)
        {
            return double.NaN;
        }
    }
}