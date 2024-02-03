namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Эксцентриситету передано значение, не соответствующее данному типу конических сечений.
    /// </summary>
    public abstract class EccentricityOutOfRangeException : ArgumentOutOfRangeException
    {
        protected EccentricityOutOfRangeException () : base ()
        {
        }
    }
}