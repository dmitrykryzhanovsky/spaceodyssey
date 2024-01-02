namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipseEccentricityOutOfRangeException : EccentricityOutOfRangeException
    {
        private const string MessageText = "Ellipse eccentricity must be grater or equal to 0 and less than 1.";

        public EllipseEccentricityOutOfRangeException () : base (MessageText)
        {
        }
    }
}