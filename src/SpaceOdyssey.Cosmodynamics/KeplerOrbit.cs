using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class KeplerOrbit
    {
        private double _centralMu;

        private double _satteliteMass;

        private double _satteliteMu;

        protected double _mu;

        protected double _k;

        protected double _p;

        protected double _e;

        protected double _rp;

        protected double _n;

        protected double _vp;

        protected double _energyIntegral;

        protected double _arealVelocity;

        //private Vector3 _angularMomentum;

        protected KeplerOrbit ()
        {
            NotInitializedGravity ();
            NotInitializedShape ();
            NotInitializedMotion ();
            NotInitializedIntegrals ();
        }

        private void NotInitializedGravity ()
        {
            _centralMu     = double.NaN;
            _satteliteMass = double.NaN;
            _satteliteMu   = double.NaN;
            _mu            = double.NaN;
            _k             = double.NaN;
        }

        private void NotInitializedShape ()
        {
            _p  = double.NaN;
            _e  = double.NaN;
            _rp = double.NaN;
        }

        private void NotInitializedMotion ()
        {
            _n  = double.NaN;
            _vp = double.NaN;
        }

        private void NotInitializedIntegrals ()
        {
            _energyIntegral  = double.NaN;
            _arealVelocity   = double.NaN;
            //_angularMomentum = null;
        }

        public void SetGravity_OnlyCentralMass (double centralMu)
        {
            _centralMu     = centralMu;
            _satteliteMass = 0.0;
            _satteliteMu   = 0.0;

            ComputeMuK ();
        }

        public void SetGravity_SatteliteMass (double centralMu, double satteliteMass)
        {
            _centralMu     = centralMu;
            _satteliteMass = satteliteMass;
            _satteliteMu   = satteliteMass * PhysConst.G;

            ComputeMuK ();
        }

        public void SetGravity_SatteliteMu (double centralMu, double satteliteMu)
        {
            _centralMu     = centralMu;            
            _satteliteMass = satteliteMu / PhysConst.G;
            _satteliteMu   = satteliteMu;

            ComputeMuK ();
        }

        private void ComputeMuK ()
        {
            _mu = _centralMu + _satteliteMu;
            _k  = double.Sqrt (_mu);
        }

        protected double ArealVelocity ()
        {
            // TODO
            return double.NaN;
        }
    }
}