namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Гиперболическая орбита.
    /// </summary>
    public class HyperbolicOrbit : KeplerOrbit
    {
        private double _a;
        private double _asymptote;

        private double _sqrt1e;
        private double _sqrta;
        private double _gu;

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

        /// <summary>
        /// Устанавливает параметры гиперболической орбиты по расстоянию в перицентре и фокальному параметру.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="p">Фокальный параметр – должен быть строго больше расстояния в перицентре.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – фокальный параметр <paramref name="p"/> меньше либо равен расстоянию в перицентре <paramref name="amin"/>
        /// </exception>
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

        /// <summary>
        /// Устанавливает параметры гиперболической орбиты по её расстоянию в перицентре и эксцентриситету.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="e">Эксцентриситет – должен быть строго больше 1.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – эксцентриситет <paramref name="e"/> меньше либо равен 1
        /// </exception>
        public void SetAminE (double amin, double e)
        {
            CheckAmin (amin);
            CheckE (e);

            _p    = amin * (1.0 + e);
            _e    = e;
            _amin = amin;
            _a    = amin / (1.0 - e);

            _asymptote = HyperbolicAsymptote ();

            ComputeAuxiliaries ();

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
            double asqrta = -_a * _sqrta;

            _n = K / asqrta;
        }

        protected void ComputeAuxiliaries ()
        {
            _sqrt1e = double.Sqrt (_e * _e - 1.0);
            _sqrta  = double.Sqrt (-_a);
            _gu     = K / _sqrta;
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            double M = MeanAnomaly (t);
            double H = SolveKeplerEquation (M);

            double shH = double.Sinh (H);
            double chH = double.Cosh (H);

            double x = -_a * (_e - chH);
            double y = -_a * _sqrt1e * shH;
            double V = double.Atan2 (y, x);

            double denominator = _e * chH - 1.0;

            return new OrbitalPosition (x: x,
                                        y: y,
                                        r: Radius (V),
                                        trueAnomaly: V,
                                        vx: -_gu * shH / denominator,
                                        vy:  _gu * _sqrt1e * chH / denominator,
                                        M: M,
                                        E: H);
        }

        public override double SolveKeplerEquation (double M)
        {
            throw new NotImplementedException ();
        }
    }
}