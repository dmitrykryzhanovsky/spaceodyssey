using System;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Размер орбиты имеет неположительное значение.
    /// </summary>
    public class DimensionalOrbitalElementNegativeException : ArgumentOutOfRangeException
    {
        private const string MessageText = "The value of {0} must be > 0.0.";

        public DimensionalOrbitalElementNegativeException (EOrbitalElement orbitalElement) : 
            base (String.Format (MessageText, KeplerOrbit.OrbitalElementName [(int)orbitalElement]))
        {
        }
    }
}