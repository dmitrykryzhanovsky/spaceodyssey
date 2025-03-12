namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эллиптическая орбита.
    /// </summary>
    public class EllipticOrbit : KeplerOrbit
    {
        protected double _a;

        private double _amax;

        private double _T;

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
        /// <remarks>Задаётся в сутках.</remarks>
        public double T
        {
            get => _T;
        }

        protected EllipticOrbit (double p, double e, double a, double amin, double amax) : base (p, e, amin)
        {
            _a    = a;
            _amax = amax;
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту по её большой полуоси и эксцентриситету.
        /// </summary>
        /// <param name="a">Большая полуось.</param>
        /// <param name="e">Эксцентриситет – для эллипса должен быть на полуинтервале [0; 1).</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – большая полуось <paramref name="a"/> задана неположительной
        /// – эксцентриситет <paramref name="e"/> меньше 0 или больше либо равен 1
        /// </exception>
        public static EllipticOrbit CreateAE (double a, double e)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException ();
            if ((e < 0.0) || (e >= 1.0)) throw new ArgumentOutOfRangeException ();

            double ep1  = 1.0 + e;
            double amin = a * (1.0 - e);
            double amax = a * ep1;
            double p    = amin * ep1;

            return new EllipticOrbit (p, e, a, amin, amax);
        }

        /// <summary>
        /// Создаёт эллиптическую орбиту по её расстояниям в перицентре и апоцентре.
        /// </summary>
        /// <param name="amin">Расстояние в перицентре – должно быть строго положительным.</param>
        /// <param name="amax">Расстояние в апоцентре – должно быть больше либо равным расстоянию в перицентре <paramref name="amin"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если имеет место хотя бы одно из условий:
        /// – расстояние в перицентре <paramref name="amin"/> меньше либо равно 0
        /// – расстояние в апоцентре <paramref name="amax"/> меньше расстояния в перицентре <paramref name="amin"/>
        /// </exception>
        public static EllipticOrbit CreateAminAmax (double amin, double amax)
        {
            if (amin <= 0.0) throw new ArgumentOutOfRangeException ();
            if (amax < amin) throw new ArgumentOutOfRangeException ();

            double major = amax + amin;
            double a     = major / 2.0;
            double e     = (amax - amin) / major;
            double p     = amin * (1.0 + e);

            return new EllipticOrbit (p, e, a, amin, amax);
        }

        protected override void CheckParametersForTrueAnomaly (double r)
        {
            if ((r < _amin) || (r > _amax)) throw new ArgumentOutOfRangeException ();
        }
    }
}
