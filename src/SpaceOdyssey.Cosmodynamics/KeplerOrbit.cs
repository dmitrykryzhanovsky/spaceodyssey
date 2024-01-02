namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private IGravityMass _orbitalCenter;

        protected double K => _orbitalCenter.GravitationalParameter;

        protected double K2 => _orbitalCenter.GravitationalConstant;

        protected double _e;

        protected double _p;

        protected double _amin;

        protected double _n;

        protected KeplerOrbit (IGravityMass orbitalCenter)
        {
            _orbitalCenter = orbitalCenter;
        }

        protected static void CheckNearestDistance (double amin)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException (ExceptionMessageText.NearestDistanceRange);
        }

        protected static void CheckMeanMotion (double n)
        {
            if (n <= 0.0) throw new ArgumentOutOfRangeException (ExceptionMessageText.MeanMotionRange);
        }
    }
}