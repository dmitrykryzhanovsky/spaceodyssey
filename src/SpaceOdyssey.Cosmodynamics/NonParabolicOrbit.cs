namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для непараболических орбит.
    /// </summary>
    /// <remarks>Сюда относятся эллиптические (в т.ч. круговые) и гиперболические орбиты, т.е. те, у которых определена большая полуось 
    /// (положительная или отрицательная).</remarks>
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        // Множитель, связанный с эксцентриситетом: sqrt (1 – e^2) для эллипса и sqrt (e^2 – 1) для гиперболы.
        protected double _e2factor;

        // Большая полуось орбиты, положительная для эллипса и отрицательная для гиперболы.
        protected double _a;

        // Множитель, связанный с гравитационным параметром и большой полуосью: sqrt (GM/|a|).
        protected double _gmFactor;

        /// <summary>
        /// Большая полуось орбиты.
        /// </summary>
        public double SemiMajorAxis
        {
            get => _a;
        }

        #region Constructors

        protected NonParabolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        #endregion

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и среднее движение meanMotion.
        /// </summary>
        public abstract void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion);

        /// <summary>
        /// Инициализация элементов орбиты через эксцентриситет eccentricity и расстояние в перицентре periapsis.
        /// </summary>
        public abstract void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis);

        /// <summary>
        /// Инициализация элементов орбиты через расстояние в перицентре periapsis и среднее движение meanMotion.
        /// </summary>
        public abstract void SetOrbitalElementsByPeriapsisAndMeanMotion (double periapsis, double meanMotion);
    }
}