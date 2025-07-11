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

        public override OrbitalPosition ComputePosition (double t)
        {
            //double M = _n * (t - _t0);
            //double H;

            //double sh = double.Sinh (H);
            //double ch = double.Cosh (H);

            //PlanarPosition planarPosition = PlanarPosition.ComputePlanarPosition (Formulae.ComputePlanarPositionForHyperbola,
            //    H, sh, ch, -_a, _e, _sqrte2m1);

            //double speed = Formulae.VelocityByDistance (planarPosition.R, _mu, _energyIntegral);

            //PlanarVelocity planarVelocity = PlanarVelocity.ComputePlanarVelocity (Formulae.ComputePlanarVelocityForHyperbola,
            //    speed, sh, ch, _muasqrt, _e, _sqrte2m1);

            //return new OrbitalPosition (M, M, H, t, planarPosition, planarVelocity);

            return new OrbitalPosition ();
        }
    }
}