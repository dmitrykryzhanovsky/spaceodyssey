using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эллиптическая орбита.
    /// </summary>
    public class EllipticOrbit : NonParabolicOrbit
    {
        protected double _ra;

        private double _1me2;     // Вспомогательная величина 1 – e^2.
        private double _sqrt1me2; // Вспомогательная величина корень из 1 – e^2.

        protected double _T;
        protected double _vmean;
        protected double _va;

        /// <summary>
        /// Расстояние в апоцентре.
        /// </summary>
        public double RApo
        {
            get => _ra;
        }

        /// <summary>
        /// Отношение A / Rp.
        /// </summary>
        public virtual double RangeARp
        {
            get => Formulae.Shape.RangeARp (_1me);
        }

        /// <summary>
        /// Отношение Ra / A.
        /// </summary>
        public virtual double RangeRaA
        {
            get => Formulae.Shape.RangeRaA (_1pe);
        }

        /// <summary>
        /// Отношение Ra / Rp.
        /// </summary>
        public virtual double RangeRaRp
        {
            get => Formulae.Shape.RangeRaRp (_1me, _1pe);
        }

        /// <summary>
        /// Орбитальный период.
        /// </summary>
        public double T
        {
            get => _T;
        }

        /// <summary>
        /// Средняя скорость движения по орбите.
        /// </summary>
        public double VMean
        {
            get => _vmean;
        }

        /// <summary>
        /// Орбитальная скорость в апоцентре.
        /// </summary>
        public double VApo
        {
            get => _va;
        }

        #region Constructors

        protected EllipticOrbit (Mass center, Mass probe, double t0) : base (center, probe, t0)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация эллиптической орбиты по большой полуоси a и эксцентриситету e.
        /// </summary> 
        /// <param name="a">Должно быть положительным, иначе сгенерируется исключение.</param>
        /// <param name="e">Должно лежать на полуинтервале [0; 1), иначе сгенерируется исключение.</param>
        /// <param name="t0">Момент прохождения перицентра.</param>
        public static EllipticOrbit CreateBySemiMajorAxis (Mass center, Mass probe, double a, double e, double t0)
        {
            Checkers.CheckA (a);
            Checkers.CheckEccentricityForEllipse (e);

            EllipticOrbit orbit = new EllipticOrbit (center, probe, t0);

            orbit._a = a;
            orbit._e = e;

            orbit.ComputeOrbit ();

            return orbit;
        }

        #region Orbit parameter computations

        protected override void ComputeShapeParameters ()
        {
            _1me2     = _1me * _1pe;
            _sqrt1me2 = double.Sqrt (_1me2);

            _p    = _a * _1me2;
            _rp   = _a * _1me;
            _ra   = _a * _1pe;
        }

        protected override void ComputeMotionParameters ()
        {            
            _muasqrt = Formulae.Motion.GMASqrt (_mua);

            _n       = Formulae.Motion.MeanMotionNonParabola (_a, _muasqrt);
            _T       = Formulae.Motion.OrbitalPeriod (_a, _muasqrt);
            _vmean   = _muasqrt;

            ComputeVelocityPA ();
        }

        protected virtual void ComputeVelocityPA ()
        {
            _vp = _muasqrt * double.Sqrt (_1pe / _1me);
            _va = _muasqrt * double.Sqrt (_1me / _1pe);
        }

        protected override void ComputeArealVelocity ()
        {
            _arealVelocity = Formulae.Integrals.ArealVelocityNonParabola (_mu, _a);
        }

        #endregion

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <param name="r">Должно быть заключено на отрезке [rp; ra], где rp – расстояние в перицентре, а ra – расстояние в апоцентре.</param>
        public override double TrueAnomaly (double r)
        {
            Checkers.CheckRClosed (r, _rp, _ra);

            return Formulae.Shape.ConicSectionInverse (r, _p, _e);
        }

        #region Compute position in the orbit plane

        /// <summary>
        /// Решает уравнение Кеплера и возвращает эксцентрическую аномалию E.
        /// </summary>
        protected override double SolveKeplerEquation (double M, double e)
        {
            return Formulae.KeplerEquation.SolveForEllipse (M, e);
        }

        /// <summary>
        /// Определяет характеристики положения на орбите на основе эксцентрической аномалии E.
        /// </summary>
        protected override (double x, double y, double r, double trueAnomaly, double vx, double vy, double speed) GetPositionElements
            (double E)
        {
            (double sin, double cos) = double.SinCos (E);

            (double x, double y, double r, double trueAnomaly) = Formulae.PlanarPosition.ComputeForEllipse (sin, cos, _a, _e, _1me2);
            (double vx, double vy, double speed) = Formulae.PlanarVelocity.ComputeForEllipse (sin, cos, _muasqrt, _e, _1me2);

            return (x, y, r, trueAnomaly, vx, vy, speed);
        }

        #endregion
    }
}