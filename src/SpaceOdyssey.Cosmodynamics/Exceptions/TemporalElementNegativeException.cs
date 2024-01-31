namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Элементу орбиты, задающему её характеристики во времени, передано отрицательное значение или 0.
    /// </summary>
    /// <remarks>К характеристикам во времени относятся среднее движение и период обращения.</remarks>
    public class TemporalElementNegativeException : ArgumentOutOfRangeException
    {
        public TemporalElementNegativeException () : base ()
        {
        }
    }
}