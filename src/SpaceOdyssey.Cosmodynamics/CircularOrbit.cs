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

        /// <summary>
        /// Расстояние до центра тяготения при истинной аномалии trueAnomaly.
        /// </summary>
        /// <remarks>В случае круговой орбиты одно и то же для всех значений истинной аномалии и равно большой полуоси (радиусу) 
        /// орбиты.</remarks>
        public override double Radius (double trueAnomaly)
        {
            return _a;
        }

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <param name="r">Так как для круговой орбиты расстояние до центра остаётся неизменным при изменении истинной аномалии, по её 
        /// значение определить расстояние нельзя. Поэтому в том случае, если r = a (большой полуоси орбиты), метод возвращает NaN. 
        /// Если же r ≠ a, генерируется исключение, так как для данной круговой орбиты такое расстояние некорректно.</param>
        public override double TrueAnomaly (double r)
        {
            if (r == _a) return double.NaN;

            else throw new ArgumentOutOfRangeException ();
        }
    }
}