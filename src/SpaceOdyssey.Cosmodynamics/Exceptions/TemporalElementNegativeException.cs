namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Элементу орбиты, задающему её характеристики во времени, передано отрицательное значение или 0.
    /// </summary>
    /// <remarks>К характеристикам во времени относятся среднее движение и период обращения.</remarks>
    public class TemporalElementNegativeException : ArgumentOutOfRangeException
    {
        private const string MessageText = "An orbital element related to the temporal durations must be positive (greater than 0).";

        public TemporalElementNegativeException () : base (MessageText)
        {
        }
    }
}