using Archimedes;
using Archimedes.Numerical;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эллиптическая орбита.
    /// </summary>
    public class EllipticOrbit : KeplerOrbit
    {
        private const double KeplerEquationInitialSolutionEccentricity = 0.8;

        protected double _a;
        protected double _amax;

        protected double _T;

        private   double _sqrt1e; // Квадратный корень из (1 – e^2).
        private   double _sqrta;  // Квадратный корень из большой полуоси a.
        protected double _u;      // Квадратный корень из (GM / a).

        /// <summary>
        /// Большая полуось.
        /// </summary>
        public double A
        {
            get => _a;
        }

        /// <summary>
        /// Расстояние в апоцентре.
        /// </summary>
        public double Amax
        {
            get => _amax;
        }

        /// <summary>
        /// Период обращения.
        /// </summary>
        public double T
        {
            get => _T;
        }

        public EllipticOrbit (CentralBody centralBody) : base (centralBody)
        {
        }

        protected EllipticOrbit (CentralBody centralBody, double e) : base (centralBody, e)
        {
        }

        /// <summary>
        /// Устанавливает параметры эллиптической орбиты по её большой полуоси и эксцентриситету.
        /// </summary>
        /// <param name="a">Большая полуось – должна быть положительной.</param>
        /// <param name="e">Эксцентриситет – для эллипса должен быть на полуинтервале [0; 1).</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – большая полуось <paramref name="a"/> задана неположительной
        /// – эксцентриситет <paramref name="e"/> меньше 0 или больше либо равен 1
        /// </exception>
        public void SetAE (double a, double e)
        {
            CheckA (a);
            CheckE (e);

            double ep1 = 1.0 + e;

            _e    = e;
            _amin = a * (1.0 - e);
            _a    = a;
            _amax = a * ep1;
            _p    = _amin * ep1;

            ComputeAuxiliaries ();

            ComputeNT ();
        }

        /// <summary>
        /// Устанавливает параметры эллиптической орбиты по её расстояниям в перицентре и апоцентре.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="amax">Расстояние в апоцентре – должно быть больше либо равным расстоянию в перицентре <paramref name="amin"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – расстояние в апоцентре <paramref name="amax"/> меньше расстояния в перицентре <paramref name="amin"/>
        /// </exception>
        public void SetAminAmax (double amin, double amax)
        {
            CheckAmin (amin);
            CheckAmax (amin, amax);

            double major = amax + amin;

            _e    = (amax - amin) / major;
            _p    = amin * (1.0 + _e);
            _amin = amin;
            _a    = major / 2.0;
            _amax = amax;
            
            ComputeAuxiliaries ();

            ComputeNT ();            
        }

        protected override void CheckE (double e)
        {
            if ((e < 0.0) || (e >= 1.0)) throw new ArgumentOutOfRangeException (nameof (e));
        }

        protected static void CheckA (double a)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException (nameof (a));
        }

        private static void CheckAmax (double amin, double amax)
        {
            if (amax < amin) throw new ArgumentOutOfRangeException (nameof (amax));
        }

        protected static void CheckT (double T)
        {
            if (T <= 0.0) throw new ArgumentOutOfRangeException (nameof (T));
        }

        protected void ComputeNT ()
        {
            double asqrta = _a * _sqrta;

            _n = K / asqrta;
            _T = double.Tau * asqrta / K;
        }

        protected void ComputeAT ()
        {
            _a = double.Cbrt (Mu / (_n * _n));
            _T = double.Tau / _n;
        }

        protected void ComputeAN ()
        {
            _a = double.Cbrt (_T * _T * Mu / MathConst.M4_PiSqr);
            _n = double.Tau / _T;
        }

        protected void ComputeAuxiliaries ()
        {
            _sqrt1e = double.Sqrt (1.0 - _e * _e);
            _sqrta  = double.Sqrt (_a);
            _u      = K / _sqrta;
        }

        protected override void CheckR (double r)
        {
            if ((r < _amin) || (r > _amax)) throw new ArgumentOutOfRangeException (nameof (r));
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            double M = MeanAnomaly (t);
            double E = SolveKeplerEquation (M);

            (double sinE, double cosE) = double.SinCos (E);
            (double x,    double y)    = EllipticPlanarCartesianCoordinates (_e, _a, _sqrt1e, sinE, cosE);
            (double r,    double V)    = Space2D.PolarCoordinates (x, y);
            (double vx,   double vy)   = EllipticPlanarVelocityComponents (_e, _sqrt1e, _u, sinE, cosE);

            return new OrbitalPosition (x, y, r, V, vx, vy, M, E);
        }

        /// <summary>
        /// Решает уравнение Кеплера относительно заданного значения средней аномалии M.
        /// </summary>
        public override double SolveKeplerEquation (double M)
        {
            double MModulo = double.Ieee754Remainder (M, double.Tau);

            double [] a  = new double [] { _e, MModulo };
            double    x0 = (_e < KeplerEquationInitialSolutionEccentricity) ? MModulo : double.Pi;            

            return Equation.Newton (EllipticKeplerEquation, EllipticKeplerDerivative, a, ComputingSettings.KeplerEquationEpsilon, x0);
        }

        private static double EllipticKeplerEquation (double E, params double [] a)
        {
            return E - a [0] * double.Sin (E) - a [1];
        }

        private static double EllipticKeplerDerivative (double E, params double [] a)
        {
            return 1.0 - a [0] * double.Cos (E);
        }

        /// <summary>
        /// Вычисляет координаты небесного тела x и y в плоскости орбиты.
        /// </summary>
        private static (double x, double y) EllipticPlanarCartesianCoordinates (double e, double a, double sqrt1e, 
            double sinE, double cosE)
        {
            double x = a * (cosE - e);
            double y = a * sqrt1e * sinE;

            return (x, y);
        }

        /// <summary>
        /// Вычисляет компоненты скорости vx и vy в плоскости орбиты.
        /// </summary>
        private static (double vx, double vy) EllipticPlanarVelocityComponents (double e, double sqrt1e, double u, 
            double sinE, double cosE)
        {
            double denominator = 1.0 - e * cosE;

            double vx = -u * sinE / denominator;
            double vy =  u * sqrt1e * cosE / denominator;

            return (vx, vy);
        }
    }
}