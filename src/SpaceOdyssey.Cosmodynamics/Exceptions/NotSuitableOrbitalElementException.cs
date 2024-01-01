using System;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Элемент орбиты неприменим в данном контексте.
    /// </summary>
    public class NotSuitableOrbitalElementException : ArgumentException
    {
        public NotSuitableOrbitalElementException (EOrbitalElement orbitalElement, string? message) : base (message)
        {
        }
    }
}