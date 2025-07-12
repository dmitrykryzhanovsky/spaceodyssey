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
            _e = 1.0;
            _p = Formulae.Shape.PParabolaByRp (_rp);            
        }

        protected override void ComputeMotion ()
        {
            _n  = Formulae.Motion.MeanMotionParabola (_mu, _rp);
            _vp = Formulae.Motion.V2Escape (_mu, _rp);
        }

        protected override void ComputeIntegrals ()
        {
            _energyIntegral = 0.0;
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

        protected override OrbitalPosition ComputePositionByM (double t, double M)
        {
            double tanv2 = Formulae.KeplerEquation.SolveBarkerEquation (M);

            (double x, double y, double r, double trueAnomaly) = Formulae.PlanarPosition.ComputeForParabola (tanv2, _rp);

            (double vx, double vy, double speed) = Formulae.PlanarVelocity.ComputeForParabola (r, y, _mu, _p);

            return new OrbitalPosition (t, M, M, M, x, y, r, trueAnomaly, vx, vy, speed);
        }
    }
}