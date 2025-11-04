using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Масса – центральное тело системы или спутник (любое тело, совершающее обращение вокруг центрального тела).
    /// </summary>
    public class Mass : ICloneable
    {
        /// <summary>
        /// Тело нулевой массы.
        /// </summary>
        public static readonly Mass ZeroMass = new Mass (0.0, 0.0, 0.0);

        private readonly double _mass;
        private readonly double _GM;
        private readonly double _sqrtGM;

        /// <summary>
        /// Масса тела.
        /// </summary>
        public double M
        {
            get => _mass;
        }

        /// <summary>
        /// Локальная гравитационная постоянная, связанная с данным телом.
        /// </summary>
        /// <remarks>Произведение универсальной гравитационной постоянной G на массу данного тела M.</remarks>
        public double GM
        {
            get => _GM;
        }

        /// <summary>
        /// Квадратный корень из локальной гравитационной постоянной, связанной с данным телом.
        /// </summary>
        /// <remarks>Квадратный корень из произведения GM, где G – универсальная гравитационная постоянная, M – масса данного тела.</remarks>
        public double SqrtGM
        {
            get => _sqrtGM;
        }

        #region Constructors

        private Mass (double mass, double GM, double sqrtGM)
        {
            _mass   = mass;
            _GM     = GM;
            _sqrtGM = sqrtGM;
        }

        public Mass (Mass other) : this (other._mass, other._GM, other._sqrtGM)
        {
        }

        public object Clone ()
        {
            return new Mass (this);
        }

        #endregion

        public static Mass CreateByMass (double mass)
        {
            ArgumentOutOfRangeCheckers.CheckNotNegative (mass);

            double GM = PhysConst.G * mass;

            return new Mass (mass: mass, GM: GM, sqrtGM: double.Sqrt (GM));
        }

        public static Mass CreateByGM (double GM)
        {
            ArgumentOutOfRangeCheckers.CheckNotNegative (GM);

            return new Mass (mass: GM / PhysConst.G, GM: GM, sqrtGM: double.Sqrt (GM));
        }

        public static Mass CreateBySqrtGM (double sqrtGM)
        {
            ArgumentOutOfRangeCheckers.CheckNotNegative (sqrtGM);

            double GM = sqrtGM * sqrtGM;

            return new Mass (mass: GM / PhysConst.G, GM: GM, sqrtGM: sqrtGM);
        }
    }
}