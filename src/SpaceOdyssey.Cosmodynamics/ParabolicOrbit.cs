namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        /// <summary>
        /// Асимптота орбиты.
        /// </summary>
        /// <remarks>Истинная аномалия, к которой будет стремиться тело при удалении на бесконечность. Возвращается в радианах. Для 
        /// параболической орбиты равна π.</remarks>
        public double Asymptote
        {
            get => double.Pi;
        }

        #region Constructors

        private ParabolicOrbit (Mass center, Mass probe, double t0) : base (center, probe, t0)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация параболической орбиты по расстоянию в периапсисе rp.
        /// </summary>
        /// <param name="rp">Должно быть положительным, иначе сгенерируется исключение.</param>
        /// <param name="t0">Момент прохождения перицентра.</param>
        public static ParabolicOrbit CreateByPeriapsis (Mass center, Mass probe, double rp, double t0)
        {
            Checkers.CheckPeriapsis (rp);

            ParabolicOrbit orbit = new ParabolicOrbit (center, probe, t0);

            orbit._rp = rp;

            orbit.ComputeOrbit ();

            return orbit;
        }

        #region Orbit parameter computations

        protected override void ComputeShape ()
        {
            _e = ParabolicEccentricity;
            _p = Formulae.Shape.PParabolaByRp (_rp);            
        }

        protected override void ComputeMotion ()
        {
            _n  = Formulae.Motion.MeanMotionParabola (_mu, _rp);
            _vp = Formulae.Motion.V2Escape (_mu, _rp);
        }

        protected override void ComputeIntegrals ()
        {
            _energyIntegral = ParabolicEnergyIntegral;
            _arealVelocity  = Formulae.Integrals.ArealVelocityParabola (_mu, _rp);
        }

        #endregion

        public override double Radius (double trueAnomaly)
        {
            return Formulae.Shape.ConicSectionParabola (trueAnomaly, _p);
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

            return Formulae.Shape.ConicSectionInverseParabola (r, _p);
        }

        #region Compute position in the orbit plane

        /// <summary>
        /// Для параболической орбиты пройденная средняя аномалия лежит в диапазоне (-π; +π].
        /// </summary>
        protected override double GetMeanAnolamyForThisOrbitType (double passedMeanAnomaly)
        {
            return passedMeanAnomaly;
        }

        /// <summary>
        /// Решает уравнение Баркера и возвращает величину tan (v/2), где v – истинная аномалия.
        /// </summary>
        protected override double SolveKeplerEquation (double M, double e)
        {
            return Formulae.KeplerEquation.SolveBarkerEquation (M);
        }

        /// <summary>
        /// Определяет характеристики положения на орбите на основе величины tan (v/2), где v – истинная аномалия.
        /// </summary>
        protected override (double x, double y, double r, double trueAnomaly, double vx, double vy, double speed) GetPositionElements
            (double tanv2)
        {
            (double x, double y, double r, double trueAnomaly) = Formulae.PlanarPosition.ComputeForParabola (tanv2, _rp);
            (double vx, double vy, double speed) = Formulae.PlanarVelocity.ComputeForParabola (r, y, _mu, _p);

            return (x, y, r, trueAnomaly, vx, vy, speed);
        }

        #endregion
    }
}