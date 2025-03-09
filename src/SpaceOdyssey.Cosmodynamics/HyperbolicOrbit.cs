namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Гиперболическая орбита.
    /// </summary>
    public class HyperbolicOrbit : KeplerOrbit
    {
        private double _a;

        private double _asymptote;

        /// <summary>
        /// Большая полуось.
        /// </summary>
        /// <remarks>Для гиперболической орбиты большая полуось отрицательна.</remarks>
        public double A
        {
            get => _a;
        }

        /// <summary>
        /// Истинная аномалия, при которой гиперболическая орбита уходит на бесконечность.
        /// </summary>
        public double Asymptote
        {
            get => _asymptote;
        }

        private HyperbolicOrbit (double p, double e, double a, double amin) : base (p, e, amin)
        {
            _a         = a;
            _asymptote = double.Acos (-1.0 / e);
        }

        /// <summary>
        /// Создаёт гиперболическую орбиту по расстоянию в перицентре и фокальному параметру.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="p">Фокальный параметр – должен быть строго больше расстояния в перицентре.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – фокальный параметр <paramref name="p"/> меньше либо равен расстоянию в перицентре <paramref name="amin"/>
        /// </exception>
        public static HyperbolicOrbit CreateAminP (double amin, double p)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();
            if (p <= amin) throw new ArgumentOutOfRangeException ();

            double Q = p / amin;
            double e = Q - 1.0;
            double a = p / (Q * (2.0 - Q));

            return new HyperbolicOrbit (p, e, a, amin);
        }

        /// <summary>
        /// Создаёт гиперболическую орбиту по её расстоянию в перицентре и эксцентриситету.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="e">Эксцентриситет – должен быть строго больше 1.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – эксцентриситет <paramref name="e"/> меньше либо равен 1
        /// </exception>
        public static HyperbolicOrbit CreateAminE (double amin, double e)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();
            if (e <= 1.0) throw new ArgumentOutOfRangeException ();

            double p = amin * (1.0 + e);
            double a = amin / (1.0 - e);

            return new HyperbolicOrbit (p, e, a, amin);
        }
    }
}