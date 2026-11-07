namespace SpaceOdyssey
{
    /// <summary>
    /// Настройки вычислений.
    /// </summary>
    public static class ComputingSettings
    {
        /// <summary>
        /// Угол в радианах, по абсолютной величине меньший этого значения, считается равным 0.
        /// </summary>
        internal const double ZeroAngleEpsilon = 1.0e-14;
    }
}