namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private double _asymptote;
        private double _vinifinity;

        /// <summary>
        /// Свойство для отражения того факта, что орбита незамкнутая и уходит на бесконечность.
        /// </summary>
        public double RInfinity
        {
            get => double.PositiveInfinity;
        }

        /// <summary>
        /// Асимптота – истинная аномалия (в верхней полуплоскости), к которой тело стремится, удаляясь на бесконечность.
        /// </summary>
        public double Asymptote
        {
            get => _asymptote;
        }

        /// <summary>
        /// Скорость при удалении на бесконечность.
        /// </summary>
        public double VInfinity
        {
            get => _vinifinity;
        }

        protected HyperbolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        protected override void CheckR (double r)
        {
            CheckRForNonClosedOrbit (r, _rp);
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