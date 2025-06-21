namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эллиптическая орбита.
    /// </summary>
    public class EllipticOrbit : NonParabolicOrbit
    {
        protected double _ra;

        private double _1me2; // Вспомогательная величина 1 – e^2.

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
            get => Formulae.RangeARp (_1me);
        }

        /// <summary>
        /// Отношение Ra / A.
        /// </summary>
        public virtual double RangeRaA
        {
            get => Formulae.RangeRaA (_1pe);
        }

        /// <summary>
        /// Отношение Ra / Rp.
        /// </summary>
        public virtual double RangeRaRp
        {
            get => Formulae.RangeRaRp (_1me, _1pe);
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

        protected EllipticOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация эллиптической орбиты по большой полуоси a и эксцентриситету e.
        /// </summary> 
        /// <param name="a">Должно быть положительным, иначе сгенерируется исключение.</param>
        /// <param name="e">Должно лежать на полуинтервале [0; 1), иначе сгенерируется исключение.</param>
        public static EllipticOrbit CreateBySemiMajorAxis (Mass center, Mass probe, double a, double e)
        {
            Checkers.CheckA (a);
            Checkers.CheckEccentricityForEllipse (e);

            EllipticOrbit orbit = new EllipticOrbit (center, probe);

            orbit._a = a;
            orbit._e = e;

            orbit.ComputeOrbit ();

            return orbit;
        }

        protected override void ComputeShapeParameters ()
        {
            _1me2 = _1me * _1pe;

            _p    = _a * _1me2;
            _rp   = _a * _1me;
            _ra   = _a * _1pe;
        }

        protected override void ComputeMotionParameters ()
        {            
            _muasqrt = Formulae.GMASqrt (_mua);

            _n       = Formulae.MeanMotion (_a, _muasqrt);
            _T       = Formulae.OrbitalPeriod (_a, _muasqrt);
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
            _arealVelocity = Formulae.ArealVelocityNonParabola (_mu, _a);
        }

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <param name="r">Должно быть заключено на отрезке [rp; ra], где rp – расстояние в перицентре, а ra – расстояние в апоцентре.</param>
        public override double TrueAnomaly (double r)
        {
            Checkers.CheckRClosed (r, _rp, _ra);

            return Formulae.ConicSectionInverse (r, _p, _e);
        }
    }
}