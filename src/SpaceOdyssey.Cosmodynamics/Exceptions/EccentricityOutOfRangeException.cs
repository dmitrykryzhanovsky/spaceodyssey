using System;

namespace SpaceOdyssey.Cosmodynamics
{
    public abstract class EccentricityOutOfRangeException : ArgumentOutOfRangeException
    {
        protected EccentricityOutOfRangeException (string? message) : base (message)
        {
        }
    }
}