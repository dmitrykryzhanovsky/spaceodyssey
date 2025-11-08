namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        protected double _aux1pe; // Вспомогательная величина 1 + e.
        protected double _aux1me; // Вспомогательная величина 1 - e.

        protected double _a;        

        /// <summary>
        /// Большая полуось.
        /// </summary>
        public double A
        {
            get => _a;
        }

        #region Constructors

        protected NonParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        #region Init and compute orbit

        protected virtual void ComputeOrbitByRPE (double rp, double e, double t0)
        {
            _e  = e;
            _rp = rp;

            _aux1pe = 1.0 + _e;
            _aux1me = 1.0 - _e;

            _a  = Formulae.Shape.NonParabola.SemiMajorAxisByRP (_rp, _aux1me);
            _p  = Formulae.Shape.NonParabola.FocalParameterByRP (_rp, _aux1pe);

            _n  = Formulae.Motion.NonParabola.MeanMotion (_sqrtmu, _a);
            _vp = Formulae.Motion.NonParabola.SpeedAtPeriapsisByRP (_mu, _rp, _aux1pe);

            _h  = Formulae.Integrals.NonParabola.EnergyIntegral (_mu, _a);

            _t0 = t0;
        }

        #endregion

        public override double Radius (double trueAnomaly)
        {
            return Formulae.Shape.NonParabola.ConicSectionEquation (_p, _e, trueAnomaly);
        }

        protected override double ConicSectionInverseEquation (double r)
        {
            return Formulae.Shape.NonParabola.ConicSectionInverseEquation (_p, _e, r);
        }

        public override double SpeedForRadius (double r)
        {
            throw new NotImplementedException ();
        }

        public override double SpeedForTrueAnomaly (double trueAnomaly)
        {
            throw new NotImplementedException ();
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            throw new NotImplementedException ();
        }

        public override OrbitalPosition.PlanarPosition ComputePlanarPosition (double trueAnomaly)
        {
            throw new NotImplementedException ();
        }
    }
}