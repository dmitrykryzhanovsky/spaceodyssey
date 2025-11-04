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

        #region Orbit parameter computations

        protected override void ComputeShapeParameters ()
        {
            _e2m1     = _e * _e - 1.0;
            _sqrte2m1 = double.Sqrt (_e2m1);

            _p  = _rp * _1pe;
            _a  = _rp / _1me;
            _ra = NonClosedApoapsisDistance;
        }

        protected override void ComputeMotionParameters ()
        {
            _muasqrt = Formulae.Motion.GMASqrt (-_mua);
            _n       = Formulae.Motion.MeanMotionNonParabola (-_a, _muasqrt);
            _va      = _muasqrt;
        }

        protected override void ComputeArealVelocity ()
        {
            _arealVelocity = Formulae.Integrals.ArealVelocityNonParabola (_mu, -_a);
        }

        #endregion

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

        #region Compute position in the orbit plane

        /// <summary>
        /// Для гиперболической орбиты пройденная средняя аномалия лежит в диапазоне (-π; +π].
        /// </summary>
        protected override double GetMeanAnolamyForThisOrbitType (double passedMeanAnomaly)
        {
            return passedMeanAnomaly;
        }

        /// <summary>
        /// Решает уравнение Кеплера и возвращает эксцентрическую аномалию H.
        /// </summary>
        protected override double SolveKeplerEquation (double M, double e)
        {
            return Formulae.KeplerEquation.SolveForHyperbola (M, e);
        }

        /// <summary>
        /// Определяет характеристики положения на орбите на основе эксцентрической аномалии H.
        /// </summary>
        protected override (double x, double y, double r, double trueAnomaly, double vx, double vy, double speed) GetPositionElements 
            (double H)
        {
            double sh = double.Sinh (H);
            double ch = double.Cosh (H);

            (double x, double y, double r, double trueAnomaly) = Formulae.PlanarPosition.ComputeForHyperbola (sh, ch, -_a, _e, _sqrte2m1);
            (double vx, double vy, double speed) = Formulae.PlanarVelocity.ComputeForHyperbola (sh, ch, _muasqrt, _e, _sqrte2m1);

            return (x, y, r, trueAnomaly, vx, vy, speed);
        }

        #endregion
    }
}