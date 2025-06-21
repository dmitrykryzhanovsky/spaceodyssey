namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Гиперболическая орбита.
    /// </summary>
    public class HyperbolicOrbit : NonParabolicOrbit
    {
        /// <summary>
        /// Асимптота орбиты.
        /// </summary>
        /// <remarks>Истинная аномалия, к которой будет стремиться тело при удалении на бесконечность. Возвращается в радианах.</remarks>
        public double Asymptote
        {
            get => Formulae.Asymptote (_e);
        }

        #region Constructors

        private HyperbolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация гиперболической орбиты по расстоянию в периапсисе rp и эксцентриситету e.
        /// </summary>
        /// <param name="rp">Должно быть положительным, иначе сгенерируется исключение.</param>
        /// <param name="e">Должно быть больше 1, иначе сгенерируется исключение.</param>
        public static HyperbolicOrbit CreateByPeriapsis (Mass center, Mass probe, double rp, double e)
        {
            Checkers.CheckPeriapsis (rp);
            Checkers.CheckEccentricityForHyperbola (e);

            HyperbolicOrbit orbit = new HyperbolicOrbit (center, probe);

            orbit._rp = rp;
            orbit._e  = e;

            orbit.ComputeOrbit ();

            return orbit;
        }

        protected override void ComputeShapeParameters ()
        {
            _p = _rp * _1pe;
            _a = _rp / _1me;
        }

        protected override void ComputeMotionParameters ()
        {
            _muasqrt = Formulae.GMASqrt (-_mua);

            _n       = Formulae.MeanMotion (-_a, _muasqrt);
            _vp      = _muasqrt * double.Sqrt (-_1pe / _1me);
        }

        protected override void ComputeArealVelocity ()
        {
            _arealVelocity = Formulae.ArealVelocityNonParabola (_mu, -_a);
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

            return Formulae.ConicSectionInverse (r, _p, _e);
        }
    }
}