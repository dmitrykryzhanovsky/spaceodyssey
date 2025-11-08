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