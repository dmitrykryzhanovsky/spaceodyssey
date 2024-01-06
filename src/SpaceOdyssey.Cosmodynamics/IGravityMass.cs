namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Интерфейс для гравитирующих масс.
    /// </summary>
    public interface IGravityMass
    {
        /// <summary>
        /// Гравитационный параметр – квадратный корень из произведения гравитационной постоянной Ньютона G и массы данного тела M: 
        /// sqrt (GM).
        /// </summary>
        double GravitationalParameter { get; }

        /// <summary>
        /// Квадрат гравитационного параметра – произведение гравитационной постоянной Ньютона G и массы данного тела M: GM.
        /// </summary>
        double GravitationalConstant { get; }
    }
}