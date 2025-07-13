using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Тип для представления тяготеющей массы – центрального тела системы или спутника.
    /// </summary>
    public class Mass : ICloneable
    {
        /// <summary>
        /// Спутник нулевой массы.
        /// </summary>
        public static readonly Mass ProbeZeroMass = CreateByMass (0.0);

        /// <summary>
        /// Масса тела.
        /// </summary>
        public double M { get; private set; }

        /// <summary>
        /// Локальная гравитационная постоянная, связанная с данным телом.
        /// </summary>
        /// <remarks>Равна GM, т.е. произведению универсальной гравитационной постоянной на массу тела.</remarks>
        public double GM { get; private set; }

        /// <summary>
        /// Квадратный корень из локальной гравитационной постоянной, связанной с данным телом.
        /// </summary>
        /// <remarks>Равен sqrt (GM), т.е. квадратному корню из произведения универсальной гравитационной постоянной на массу тела.</remarks>
        public double GMSqrt { get; private set; }

        #region Constructors

        private Mass (double m, double gm, double gmsqrt)
        {
            M      = m;
            GM     = gm;
            GMSqrt = gmsqrt;
        }

        private Mass (Mass other) : this (other.M, other.GM, other.GMSqrt)
        {
        }

        public object Clone ()
        {
            return new Mass (this);
        }

        #endregion

        /// <summary>
        /// Инициализация по массе тела.
        /// </summary>
        /// <param name="m">Должно быть положительным, иначе сгенерируется исключение.</param>
        public static Mass CreateByMass (double m)
        {
            ArgumentOutOfRangeCheckers.CheckNotNegative (m);

            double gm = m * PhysConst.G;

            return new Mass (m, gm, double.Sqrt (gm));
        }

        /// <summary>
        /// Инициализация по локальной гравитационной постоянной (произведению GM).
        /// </summary>
        /// <param name="gm">Должно быть положительным, иначе сгенерируется исключение.</param>
        public static Mass CreateByGM (double gm)
        {
            ArgumentOutOfRangeCheckers.CheckNotNegative (gm);

            return new Mass (gm / PhysConst.G, gm, double.Sqrt (gm));
        }

        /// <summary>
        /// Инициализация по квадратному корню из локальной гравитационной постоянной sqrt (GM).
        /// </summary>
        /// <param name="gmsqrt">Должно быть положительным, иначе сгенерируется исключение.</param>
        public static Mass CreateByGMSqrt (double gmsqrt)
        {
            ArgumentOutOfRangeCheckers.CheckNotNegative (gmsqrt);

            double gm = gmsqrt * gmsqrt;

            return new Mass (gm / PhysConst.G, gm, gmsqrt);
        }
    }
}