namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
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
        /// <remarks>Для параболы всегда равна π.</remarks>
        public double Asymptote
        {
            get => double.Pi;
        }

        /// <summary>
        /// Скорость при удалении на бесконечность.
        /// </summary>
        /// <remarks>Для параболы всегда равна 0.</remarks>
        public double VInfinity
        {
            get => 0.0;
        }

        #region Constructors

        protected ParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        #region Init and compute orbit

        /// <summary>
        /// Создаёт параболическую орбиту, инициализируя расстояние в перицентре rp и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если rp <= 0.</exception>
        public static ParabolicOrbit CreateByRPeriapsis (Mass center, Mass orbiting, double rp, double t0)
        {
            CheckRPositive (rp);

            ParabolicOrbit orbit = new ParabolicOrbit (center, orbiting);

            orbit.ComputeOrbit (rp, t0);

            return orbit;
        }

        private void ComputeOrbit (double rp, double t0)
        {
            _p  = Formulae.Shape.Parabola.FocalParameterByRP (rp);
            _e  = 1.0;
            _rp = rp;

            _n  = Formulae.Motion.Parabola.MeanMotion (_sqrtmu, _rp);
            _vp = Formulae.Motion.Parabola.SpeedAtRadius (_mu, _rp);

            _h  = 0.0;

            _t0 = t0;
        }

        #endregion

        public override double Radius (double trueAnomaly)
        {
            return Formulae.Shape.Parabola.ConicSectionEquation (_p, trueAnomaly);
        }

        protected override void CheckR (double r)
        {
            CheckRForNonClosedOrbit (r, _rp);
        }

        protected override double ConicSectionInverseEquation (double r)
        {
            return Formulae.Shape.Parabola.ConicSectionInverseEquation (_p, r);
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