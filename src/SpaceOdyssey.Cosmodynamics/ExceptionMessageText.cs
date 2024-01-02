namespace SpaceOdyssey.Cosmodynamics
{
    internal static class ExceptionMessageText
    {
        internal const string EllipseSemiMajorAxisRange = "Ellipse semi-major axis must be positive (greater than 0).";

        internal const string NearestDistanceRange = "The nearest distance between the orbit and its gravitational center must be positive (greater than 0).";

        internal const string FarthestDistanceRange = "The farthest distance between the orbit and its gravitational center must be positive (greater than 0).";

        internal const string ApsisDistancesOrder = "The nearest distance must be less or equal to the farthest distance.";

        internal const string MeanMotionRange = "Mean motion must be positive (greater than 0).";

        internal const string OrbitalPeriodRange = "Orbital period must be positive (greater than 0).";
    }
}