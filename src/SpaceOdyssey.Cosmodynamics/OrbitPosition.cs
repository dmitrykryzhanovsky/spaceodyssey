namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Положение на орбите.
    /// </summary>
    public struct OrbitPosition
    {
        /// <summary>
        /// Расстояние до центра тяготения.
        /// </summary>
        public double R;

        /// <summary>
        /// Истинная аномалия.
        /// </summary>
        /// <remarks>Задаётся в радианах.</remarks>
        public double TrueAnomaly;
    }
}