namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Элементу орбиты, задающему её размер, передано отрицательное значение или 0.
    /// </summary>
    public class DimensionalElementNegativeException : ArgumentOutOfRangeException
    {
        public DimensionalElementNegativeException () : base ()
        {
        }
    }
}