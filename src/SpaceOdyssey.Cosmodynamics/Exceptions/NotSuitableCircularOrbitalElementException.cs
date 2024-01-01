using System;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Элемент орбиты не подходит для круговой орбиты в данном контексте.
    /// </summary>
    public class NotSuitableCircularOrbitalElementException : NotSuitableOrbitalElementException
    {
        private const string MessageText = "The orbital element {0} is not suitable for a circular orbit in the given context.";

        public NotSuitableCircularOrbitalElementException (EOrbitalElement orbitalElement) :
            base (orbitalElement, String.Format (MessageText, KeplerOrbit.OrbitalElementName [(int)orbitalElement]))
        {
        }
    }
}