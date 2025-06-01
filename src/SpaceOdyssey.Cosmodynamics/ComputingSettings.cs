namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Настройки вычислений.
    /// </summary>
    internal static class ComputingSettings
    {
        /// <summary>
        /// Точность в радианах, с которой ищется численное решение уравнения Кеплера.
        /// </summary>
        internal const double KeplerEquationEpsilon = 1.0E-12;
    }
}