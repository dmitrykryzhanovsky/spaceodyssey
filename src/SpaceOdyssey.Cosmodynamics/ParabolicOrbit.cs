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

        private ParabolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация параболической орбиты по расстоянию в периапсисе rp.
        /// </summary>
        /// <param name="rp">Должно быть положительным, иначе сгенерируется исключение.</param>

        public static ParabolicOrbit CreateByPeriapsis (Mass center, Mass probe, double rp)
        {
            Checkers.CheckPeriapsis (rp);

            ParabolicOrbit orbit = new ParabolicOrbit (center, probe);

            orbit._rp = rp;

            orbit.ComputeOrbit ();

            return orbit;
        }

        protected override void ComputeShape ()
        {
            _e = 1.0;
            _p = Formulae.PParabolaByRp (_rp);            
        }

        protected override void ComputeMotion ()
        {
            _vp = Formulae.V2Escape (_mu, _rp);
        }

        protected override void ComputeIntegrals ()
        {
            _energyIntegral = 0.0;
            _arealVelocity  = Formulae.ArealVelocityParabola (_mu, _rp);
        }

        public override double Radius (double trueAnomaly)
        {
            return Formulae.ConicSectionParabola (trueAnomaly, _p);
        }

        public override double TrueAnomaly (double r)
        {
            Checkers.CheckRNonClosed (r, _rp);

            return Formulae.ConicSectionInverseParabola (r, _p);
        }
    }
}