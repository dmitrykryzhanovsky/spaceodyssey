using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эллиптическая орбита.
    /// </summary>
    public class EllipticOrbit : KeplerOrbit
    {
        protected double _a;

        protected double _amax;

        protected double _T;

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

            ComputeNT ();
        }

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

            ComputeNT ();
        }

        protected override void CheckE (double e)
        {
            if ((e < 0.0) || (e >= 1.0)) throw new ArgumentOutOfRangeException (nameof (e));
        }

        protected void CheckA (double a)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException (nameof (a));
        }

        private void CheckAmax (double amin, double amax)
        {
            if (amax < amin) throw new ArgumentOutOfRangeException (nameof (amax));
        }

        protected void CheckT (double T)
        {
            if (T <= 0.0) throw new ArgumentOutOfRangeException (nameof (T));
        }

        protected void ComputeNT ()
        {
            double asqrta = _a * double.Sqrt (_a);

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
            _a = double.Cbrt (_T * _T * Mu / MathConst._4_PI_SQR);
            _n = double.Tau / _T;
        }

        




        /// <summary>
        /// Создаёт эллиптическую орбиту по её большой полуоси и эксцентриситету.
        /// </summary>
        /// <param name="centralBody">Центральное тело, создающее гравитационное поле орбиты.</param>
        /// <param name="a">Большая полуось.</param>
        /// <param name="e">Эксцентриситет – для эллипса должен быть на полуинтервале [0; 1).</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – большая полуось <paramref name="a"/> задана неположительной
        /// – эксцентриситет <paramref name="e"/> меньше 0 или больше либо равен 1
        /// </exception>

        /// <summary>
        /// Создаёт эллиптическую орбиту по её расстояниям в перицентре и апоцентре.
        /// </summary>
        /// <param name="centralBody">Центральное тело, создающее гравитационное поле орбиты.</param>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="amax">Расстояние в апоцентре – должно быть больше либо равным расстоянию в перицентре <paramref name="amin"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – расстояние в апоцентре <paramref name="amax"/> меньше расстояния в перицентре <paramref name="amin"/>
        /// </exception>

        protected override void CheckR (double r)
        {
            if ((r < _amin) || (r > _amax)) throw new ArgumentOutOfRangeException (nameof (r));
        }
    }
}