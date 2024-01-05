namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для кеплеровых орбит.
    /// </summary>
    public abstract class KeplerOrbit
    {
        // Гравитирующая масса, относительно которой проложена орбита.
        private IGravityMass _orbitalCenter;

        // Гравитационный параметр – квадратный корень из произведения гравитационной постоянной Ньютона G и массы центрального тела M:
        // sqrt (GM).
        protected double K => _orbitalCenter.GravitationalParameter;

        // Квадрат гравитационного параметра – произведение гравитационной постоянной Ньютона G и массы центрального тела M: GM.
        protected double K2 => _orbitalCenter.GravitationalConstant;

        // Эксцентриситет орбиты.
        protected double _e;

        // Орбитальный (фокальный) параметр – расстояние от фокуса орбиты до точки с истинной аномалией 90°.
        protected double _p;

        // Минимальное расстояние (расстояние в перицентре).
        protected double _amin;

        // Среднее движение, рад / единица времени.
        protected double _n;

        protected KeplerOrbit (IGravityMass orbitalCenter)
        {
            _orbitalCenter = orbitalCenter;
        }

        protected static void CheckPeriapsis (double periapsis)
        {
            if (periapsis <= 0.0) throw new DimensionalElementNegativeException ();
        }

        protected static void CheckMeanMotion (double meanMotion)
        {
            if (meanMotion <= 0.0) throw new TemporalElementNegativeException ();
        }
    }
}