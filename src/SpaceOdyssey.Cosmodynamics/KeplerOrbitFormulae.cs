namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Формулы для вычислений для кеплеровых орбит.
    /// </summary>
    public static class KeplerOrbitFormulae
    {
        public static bool IsEccentricityValidForEllipse (double e)
        {
            return ((0.0 <= e) && (e < 1.0));
        }

        public static bool IsEccentricityValidForHyperbola (double e)
        {
            return (e > 1.0);
        }
    }
}