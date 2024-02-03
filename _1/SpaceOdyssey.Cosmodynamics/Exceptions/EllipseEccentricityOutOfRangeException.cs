namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эксцентриситету передано значение, не соответствующее эллипсу.
    /// </summary>
    /// <remarks>Эксцентриситет эллипса должен находить на интервале 0 <= e < 1.</remarks>
    public class EllipseEccentricityOutOfRangeException : EccentricityOutOfRangeException
    {
        public EllipseEccentricityOutOfRangeException () : base ()
        {
        }
    }
}