namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эксцентриситету передано значение, не соответствующее гиперболе.
    /// </summary>
    /// <remarks>Эксцентриситет гиперболы должен быть e > 1.</remarks>
    public class HyperbolaEccentricityOutOfRangeException : EccentricityOutOfRangeException
    {
        public HyperbolaEccentricityOutOfRangeException () : base ()
        {
        }
    }
}