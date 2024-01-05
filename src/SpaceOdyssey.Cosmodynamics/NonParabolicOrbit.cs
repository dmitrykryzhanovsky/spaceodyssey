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

        protected NonParabolicOrbit (IGravityMass orbitalCenter) : base (orbitalCenter)
        {
        }

        public abstract void SetOrbitalElementsByMeanMotion (double eccentricity, double meanMotion);

        public abstract void SetOrbitalElementsByPeriapsis (double eccentricity, double periapsis);

        public abstract void SetOrbitalElementsByPeriapsisAndMeanMotion (double periapsis, double meanMotion);
    }
}