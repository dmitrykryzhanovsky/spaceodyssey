namespace SpaceOdyssey.Cosmodynamics
{
    public struct OrbitalPosition
    {
        private readonly double _M;
        private readonly double _MPhase;
        private readonly double _E;
        private readonly double _t;

        private readonly PlanarPosition _planarPosition;

        private readonly PlanarVelocity _planarVelocity;

        public double M
        {
            get => _M;
        }

        public double MPhase
        {
            get => _MPhase;
        }

        public double E
        {
            get => _E;
        }

        public double Time
        {
            get => _t;
        }

        public PlanarPosition PlanarPosition
        {
            get => _planarPosition;
        }

        public PlanarVelocity PlanarVelocity
        {
            get => _planarVelocity;
        }

        public OrbitalPosition (double M, double MPhase, double E, double t, PlanarPosition planarPosition, 
            PlanarVelocity planarVelocity)
        {
            _M      = M;
            _MPhase = MPhase;
            _E      = E;
            _t      = t;

            _planarPosition = planarPosition;
            _planarVelocity = planarVelocity;
        }
    }
}