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

        #region Constructors

        private CircularOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация круговой орбиты по большой полуоси (радиусу) a.
        /// </summary>
        /// <param name="a">Должно быть положительным, иначе сгенерируется исключение.</param>
        public static CircularOrbit CreateBySemiMajorAxis (Mass center, Mass probe, double a)
        {
            Checkers.CheckA (a);

            CircularOrbit orbit = new CircularOrbit (center, probe);

            orbit._a = a;

            orbit.ComputeOrbit ();

            return orbit;
        }

        /// <summary>
        /// Для круговой орбиты все геометрические параметры численно равны большой полуоси (радиусу), а эксцентриситет = 0.
        /// </summary>
        protected override void ComputeShape ()
        {
            _e  = 0.0;
            _p  = _a;
            _rp = _a;
            _ra = _a;
        }

        /// <summary>
        /// На круговой орбите скорость не изменяется.
        /// </summary>
        protected override void ComputeVelocityPA ()
        {
            _vp = _muasqrt;
            _va = _muasqrt;
        }
    }
}