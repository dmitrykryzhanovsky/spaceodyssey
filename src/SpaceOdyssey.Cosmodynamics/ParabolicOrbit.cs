namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Параболическая орбита.
    /// </summary>
    public class ParabolicOrbit : KeplerOrbit
    {
        private const double ParabolicEccentricity = 1.0;

        private const double ParabolicAsymptote = double.Pi;

        /// <summary>
        /// Истинная аномалия, при которой параболическая орбита уходит на бесконечность.
        /// </summary>
        /// <remarks>У параболической орбиты всегда равна π радиан.</remarks>
        public double Asymptote
        {
            get => ParabolicAsymptote;
        }

        private ParabolicOrbit (double amin) : base (FocalParameter (amin), ParabolicEccentricity, amin)
        {
        }

        /// <summary>
        /// Создаёт параболическую орбиту по расстоянию в перицентре.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="amin"/> меньше или равно 0.</exception>
        public static ParabolicOrbit Create (double amin)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();

            return new ParabolicOrbit (amin);
        }

        private static double FocalParameter (double amin)
        {
            return 2.0 * amin;
        }

        /// <summary>
        /// Расстояние до центра тяготения при истинной аномалии trueAnomaly.
        /// </summary>
        /// <param name="trueAnomaly">Задаётся в радианах.</param>
        public override double Radius (double trueAnomaly)
        {
            return _p / (1.0 + double.Cos (trueAnomaly));
        }

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <param name="r">Должно быть больше или равно расстояния в перицентре.</param>
        /// <returns>Одному и тому же значению r соответствуют два значения истинной аномалии: x и -x. Данный метод возвращает 
        /// неотрицательное значение из двух корректных.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="r"/> меньше расстояния в перицентре (то 
        /// есть не может иметь места для данной орбиты).</exception>
        public override double TrueAnomaly (double r)
        {
            if (r < _amin) throw new ArgumentOutOfRangeException ();

            return double.Acos (_p / r - 1.0);
        }
    }
}