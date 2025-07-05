namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Гиперболическая орбита.
    /// </summary>
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        private double _e2m1;     // Вспомогательная величина e^2 - 1.
        private double _sqrte2m1; // Вспомогательная величина корень из e^2 - 1.

        /// <summary>
        /// Асимптота орбиты.
        /// </summary>
        /// <remarks>Истинная аномалия, к которой будет стремиться тело при удалении на бесконечность. Возвращается в радианах.</remarks>
        public double Asymptote
        {
            get => Formulae.Shape.Asymptote (_e);
        }

        #region Constructors

        private HyperbolicOrbit (Mass center, Mass probe, double t0) : base (center, probe, t0)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация гиперболической орбиты по расстоянию в периапсисе rp и эксцентриситету e.
        /// </summary>
        /// <param name="rp">Должно быть положительным, иначе сгенерируется исключение.</param>
        /// <param name="e">Должно быть больше 1, иначе сгенерируется исключение.</param>
        /// <param name="t0">Момент прохождения перицентра.</param>
        public static HyperbolicOrbit CreateByPeriapsis (Mass center, Mass probe, double rp, double e, double t0)
        {
            Checkers.CheckPeriapsis (rp);
            Checkers.CheckEccentricityForHyperbola (e);

            HyperbolicOrbit orbit = new HyperbolicOrbit (center, probe, t0);

            orbit._rp = rp;
            orbit._e  = e;

            orbit.ComputeOrbit ();

            return orbit;
        }

        protected override void ComputeShapeParameters ()
        {
            _e2m1     = _e * _e - 1.0;
            _sqrte2m1 = double.Sqrt (_e2m1);

            _p = _rp * _1pe;
            _a = _rp / _1me;
        }

        protected override void ComputeMotionParameters ()
        {
            _muasqrt = Formulae.Motion.GMASqrt (-_mua);

            _n       = Formulae.Motion.MeanMotion (-_a, _muasqrt);
            _vp      = _muasqrt * double.Sqrt (-_1pe / _1me);
        }

        protected override void ComputeArealVelocity ()
        {
            _arealVelocity = Formulae.Integrals.ArealVelocityNonParabola (_mu, -_a);
        }

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <param name="r">Должно быть больше либо равно расстоянию в перицентре rp.</param>
        public override double TrueAnomaly (double r)
        {
            Checkers.CheckRNonClosed (r, _rp);

            return Formulae.Shape.ConicSectionInverse (r, _p, _e);
        }

        protected override OrbitalPosition ComputePositionByM (double t, double M)
        {
            double H  = Formulae.SolveKeplerEquationForHyperbola (M, _e);

            double sh = double.Sinh (H);
            double ch = double.Cosh (H);

            PlanarPosition pp = PlanarPosition.ComputePlanarPosition (Formulae.ComputePlanarPositionForHyperbola,
                H, sh, ch, -_a, _e, _sqrte2m1);

            double speed = Formulae.Motion.VelocityByDistance (pp.R, _mu, _energyIntegral);

            PlanarVelocity pv = PlanarVelocity.ComputePlanarVelocity (Formulae.ComputePlanarVelocityForHyperbola,
                speed, sh, ch, _muasqrt, _e, _sqrte2m1);

            return new OrbitalPosition (M: M, MPhase: M, E: H, t: t, planarPosition: pp, planarVelocity: pv);
        }
    }
}