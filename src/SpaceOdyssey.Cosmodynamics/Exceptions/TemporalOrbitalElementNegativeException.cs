using System;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Временной параметр орбиты имеет неположительное значение.
    /// </summary>
    public class TemporalOrbitalElementNegativeException : ArgumentOutOfRangeException
    {
        private const string MessageText = "The value of {0} must be > 0.0.";

        public TemporalOrbitalElementNegativeException (EOrbitalElement orbitalElement) : 
            base (String.Format (MessageText, KeplerOrbit.OrbitalElementName [(int)orbitalElement]))
        {
        }
    }
}