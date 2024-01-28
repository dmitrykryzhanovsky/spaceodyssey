namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Интерфейс для центрального тела орбитальной системы.
    /// </summary>
    public interface ICentralBody
    {
        /// <summary>
        /// Гравитационная постоянная – квадратный корень из произведения гравитационной постоянной Ньютона G на массу данного тела M: 
        /// sqrt (GM).
        /// </summary>
        double GravitationalConstant { get; }

        /// <summary>
        /// Гравитационный параметр – произведение гравитационной постоянной Ньютона G на массу данного тела M: GM.
        /// </summary>
        double GravitationalParameter { get; }

        /// <summary>
        /// Вторая космическая скорость (параболическая скорость, скорость убегания) для данного тела на расстоянии r от него.
        /// </summary>
        double EscapeVelocity (double r)
        {
            return GravitationalConstant * double.Sqrt (2.0 / r);
        }
    }
}