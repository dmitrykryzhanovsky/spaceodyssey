namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        protected double _auxe2m1;        // Вспомогательная величина e^2 - 1.
        protected double _auxsqrte2m1;    // Вспомогательная величина sqrt (e^2 - 1).
        protected double _auxsqrtmue2m1a; // Вспомогательная величина sqrt (μ * (e^2 - 1) / a).

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

        private HyperbolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
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
        public static HyperbolicOrbit CreateByPeriapsis (Mass center, Mass orbiting, double e, double rp)
        {
            Checkers.CheckEForHyperbola (e);
            Checkers.CheckRPositive (rp);

            HyperbolicOrbit orbit = new HyperbolicOrbit (center, orbiting);

            orbit.ComputeOrbitByPeriapsis (e, rp);

            return orbit;
        }

        protected override void ComputeOrbitByPeriapsis (double e, double rp)
        {
            base.ComputeOrbitByPeriapsis (e, rp);

            _asymptote = Formulae.Shape.Hyperbola.Asymptote (_e);
            _vinfinity = _auxsqrth;
        }

        #region Auxiliaries

        protected override void ComputeAuxiliariesByEccentricity ()
        {
            base.ComputeAuxiliariesByEccentricity ();

            _auxe2m1     = _e * _e - 1.0;
            _auxsqrte2m1 = double.Sqrt (_auxe2m1);
        }

        #endregion

        #region Integrals

        protected override void ComputeIntegrals ()
        {
            base.ComputeIntegrals ();

            _auxsqrtmue2m1a = _auxsqrth * _auxsqrte2m1;
        }

        #endregion

        #endregion

        public override OrbitalPosition ComputePosition (double t)
        {
            double M = Formulae.Motion.Ellipse.NormalizeMeanAnomaly (_n, t - _t0);
            double H = Formulae.KeplerEquation.Hyperbola.Solve (M, _e);

            // Вычисление положения в плоскости орбиты.
            double shH       = double.Sinh (H);
            double chH       = double.Cosh (H);
            double eccentric = _e * chH - 1.0;

            double x = -_a * (_e - chH);
            double y = -_a * _auxsqrte2m1 * shH;
            double r = -_a * eccentric;
            double trueAnomaly = double.Atan2 (y, x);

            // Вычисление скорости в плоскости орбиты.
            double vx = -_auxsqrth * shH / eccentric;
            double vy =  _auxsqrtmue2m1a * chH / eccentric;

            return new OrbitalPosition (this, t, M, H, x, y, r, trueAnomaly, vx, vy);
        }
    }
}