namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Элементу орбиты, задающему её размер, передано отрицательное значение или 0.
    /// </summary>
    public class DimensionalElementNegativeException : ArgumentOutOfRangeException
    {
        private const string MessageText = "An orbital element related to the sizes must be positive (greater than 0).";

        public DimensionalElementNegativeException () : base (MessageText)
        {
        }
    }
}