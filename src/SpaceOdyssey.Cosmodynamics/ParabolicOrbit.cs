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

        public ParabolicOrbit (CentralBody centralBody) : base (centralBody, ParabolicEccentricity)
        {
        }

        /// <summary>
        /// Устанавливает параметры параболической орбиты по расстоянию в перицентре.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="amin"/> меньше или равно 0.</exception>
        public void SetAmin (double amin)
        {
            CheckAmin (amin);

            _amin = amin;
            _p    = ParabolicFocalParameter ();

            ComputeN ();
        }

        // Пустой метод, нужен только для поддержки иерархии классов.
        protected override void CheckE (double e)
        {            
        }

        private double ParabolicFocalParameter ()
        {
            return 2.0 * _amin;
        }

        private void ComputeN ()
        {
            double asqrta = _amin * double.Sqrt (2.0 * _amin);

            _n = K / asqrta;
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
            CheckR (r);

            return double.Acos (_p / r - 1.0);
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            throw new NotImplementedException ();
            //double M = MeanAnomaly (t);

            //double A     = 1.5 * M;
            //double B     = double.Cbrt (A + double.Sqrt (A * A + 1.0));
            //double tanV2 = B - 1.0 / B;

            //double V = 2.0 * double.Atan (tanV2);

            //return new OrbitalPosition (x: _amin * (1.0 - tanV2 * tanV2),
            //                            y: 2.0 * _amin *tanV2,
            //                            r: Radius (V),
            //                            trueAnomaly: V,
            //                            vx: -_gu * shH / denominator,
            //                            vy: _gu * _sqrt1e * chH / denominator,
            //                            M: M,
            //                            E: M);
        }

        public override double SolveKeplerEquation (double M)
        {
            return 0.0;
        }
    }
}