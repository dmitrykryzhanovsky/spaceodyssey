using System;

namespace SpaceOdyssey.Cosmodynamics
{
    public class NonPositiveOrbitalElementException : ArgumentOutOfRangeException
    {
        private const string MessageAffix = " must be positive (greater than 0).";

        public NonPositiveOrbitalElementException (string? messagePrefix) : base (messagePrefix + MessageAffix)
        {
        }
    }
}