namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private readonly Mass _center;
        private readonly Mass _orbiting;

        private readonly double _mu;

        private readonly double _p;
        
        private readonly double _e;
        private readonly double _rp;
        private readonly double _ra;

        protected KeplerOrbit (Mass center, Mass orbiting)
        {
            _center   = center;
            _orbiting = orbiting;
        }
    }
}