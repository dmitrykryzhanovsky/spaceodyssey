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

        public HyperbolicOrbit (CentralBody centralBody) : base (centralBody)
        {
        }

        public void SetAminP (double amin, double p)
        {
            CheckAmin (amin);
            CheckP (amin, p);

            double Q = p / amin;

            _p    = p;
            _e    = Q - 1.0;
            _amin = amin;
            _a    = p / (Q * (2.0 - Q));

            _asymptote = HyperbolicAsymptote ();
            
            ComputeN ();
        }

        public void SetAminE (double amin, double e)
        {
            CheckAmin (amin);
            CheckE (e);

            _p    = amin * (1.0 + e);
            _e    = e;
            _amin = amin;
            _a    = amin / (1.0 - e);

            _asymptote = HyperbolicAsymptote ();

            ComputeN ();
        }

        private void CheckP (double amin, double p)
        {
            if (p <= amin) throw new ArgumentOutOfRangeException (nameof (p));
        }

        protected override void CheckE (double e)
        {
            if (e <= 1.0) throw new ArgumentOutOfRangeException (nameof (e));
        }

        private double HyperbolicAsymptote ()
        {
            return double.Acos (-1.0 / _e);
        }

        private void ComputeN ()
        {
            double asqrta = -_a * double.Sqrt (-_a);

            _n = K / asqrta;
        }


        /// <summary>
        /// Создаёт гиперболическую орбиту по расстоянию в перицентре и фокальному параметру.
        /// </summary>
        /// <param name="centralBody">Центральное тело, создающее гравитационное поле орбиты.</param>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="p">Фокальный параметр – должен быть строго больше расстояния в перицентре.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – фокальный параметр <paramref name="p"/> меньше либо равен расстоянию в перицентре <paramref name="amin"/>
        /// </exception>

        /// <summary>
        /// Создаёт гиперболическую орбиту по её расстоянию в перицентре и эксцентриситету.
        /// </summary>
        /// <param name="centralBody">Центральное тело, создающее гравитационное поле орбиты.</param>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="e">Эксцентриситет – должен быть строго больше 1.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – эксцентриситет <paramref name="e"/> меньше либо равен 1
        /// </exception>
    }
}