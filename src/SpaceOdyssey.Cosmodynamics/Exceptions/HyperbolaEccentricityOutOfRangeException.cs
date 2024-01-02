namespace SpaceOdyssey.Cosmodynamics
{
    public class HyperbolaEccentricityOutOfRangeException : EccentricityOutOfRangeException
    {
        private const string MessageText = "Hyperbola eccentricity must be grater than 1.";

        public HyperbolaEccentricityOutOfRangeException () : base (MessageText)
        {
        }
    }
}