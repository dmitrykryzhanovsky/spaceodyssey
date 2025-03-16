using Archimedes;

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
            double M     = MeanAnomaly (t);
            double tanV2 = SolveKeplerEquation (M);

            (double x,  double y)  = ParabolicPlanarCartesianCoordinates (_amin, tanV2);
            (double r,  double V)  = Space2D.PolarCoordinates (x, y);
            (double vx, double vy) = ParabolicPlanarVelocityComponents (_p, K, y, r);

            return new OrbitalPosition (x, y, r, V, vx, vy, M, tanV2);
        }

        public override double SolveKeplerEquation (double M)
        {
            double A = 1.5 * M;
            double B = double.Cbrt (A + double.Sqrt (A * A + 1.0));

            return B - 1.0 / B;
        }

        private static (double x, double y) ParabolicPlanarCartesianCoordinates (double amin, double tanV2)
        {
            double x = amin * (1.0 - tanV2 * tanV2);
            double y = 2.0 * amin * tanV2;

            return (x, y);
        }

        private static (double vx, double vy) ParabolicPlanarVelocityComponents (double p, double k, double y, double r)
        {
            double v    = k * MathConst.Sqrt_2 / double.Sqrt (r);
            double beta = double.Atan (-p / y);

            (double sinB, double cosB) = double.SinCos (beta);

            double vx = v * cosB;
            double vy = v * sinB;

            return (vx, vy);
        }
    }
}