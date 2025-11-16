namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private double _asymptote;
        private double _vinfinity;

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
            get => _vinfinity;
        }

        #region Constructors

        protected HyperbolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        #region Init and compute orbit

        /// <summary>
        /// Создаёт гиперболическую орбиту, инициализируя расстояние в перицентре rp, эксцентриситет e и момент прохождения перицентра 
        /// t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <list type="number">
        /// <item>e <= 1 или</item>
        /// <item>rp <= 0.</item></list></exception>
        public static HyperbolicOrbit CreateByRPeriapsis (Mass center, Mass orbiting, double rp, double e, double t0)
        {
            CheckEForHyperbola (e);
            CheckRPositive (rp);

            HyperbolicOrbit orbit = new HyperbolicOrbit (center, orbiting);

            orbit.ComputeOrbitByRPE (rp, e, t0);

            return orbit;
        }

        protected void ComputeOrbitByRPE (double rp, double e, double t0)
        {
            _e  = e;
            _rp = rp;

            ComputeAuxiliary ();
            ComputeShapeByRPE ();
            ComputeMotionByRPE ();
            ComputeIntegrals ();
            
            _asymptote = Formulae.Shape.NonParabola.Hyperbola.Asymptote (_e);
            _vinfinity = double.Sqrt (_h);

            _t0 = t0;            
        }

        #endregion

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