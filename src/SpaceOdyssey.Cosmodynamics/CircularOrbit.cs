using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Круговая орбита.
    /// </summary>
    public class CircularOrbit : EllipticOrbit
    {
        /// <summary>
        /// Отношение A / Rp (для круговой орбиты равно 1).
        /// </summary>
        public override double RangeARp
        {
            get => 1.0;
        }

        /// <summary>
        /// Отношение Ra / A (для круговой орбиты равно 1).
        /// </summary>
        public override double RangeRaA
        {
            get => 1.0;
        }

        /// <summary>
        /// Отношение Ra / Rp (для круговой орбиты равно 1).
        /// </summary>
        public override double RangeRaRp
        {
            get => 1.0;
        }

        private CircularOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        /// <summary>
        /// Инициализация круговой орбиты по большой полуоси (радиусу) a.
        /// </summary>
        /// <param name="a">Должно быть положительным, иначе сгенерируется исключение.</param>
        public static CircularOrbit CreateBySemiMajorAxis (Mass center, Mass probe, double a)
        {
            ArgumentOutOfRangeCheckers.CheckPositive (a);

            CircularOrbit orbit = new CircularOrbit (center, probe);

            orbit._a = a;

            orbit.ComputeShape ();
            orbit.ComputeMotion ();
            orbit.ComputeIntegrals ();

            return orbit;
        }

        private void ComputeShape ()
        {
            _p  = _a;
            _e  = 0.0;
            _rp = _a;
            _ra = _a;
        }

        protected override void ComputeVelocityPA ()
        {
            _vp = _muasqrt;
            _va = _muasqrt;
        }
    }
}