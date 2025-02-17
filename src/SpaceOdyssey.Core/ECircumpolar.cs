namespace SpaceOdyssey
{
    /// <summary>
    /// Тип небесного светила для данной точки наблюдения по характеру суточного движения.
    /// </summary>
    public enum ECircumpolar
    {
        /// <summary>
        /// Незаходящее.
        /// </summary>
        NoDeclining,

        /// <summary>
        /// Обычное (восходит и заходит в течение суток).
        /// </summary>
        Usual,

        /// <summary>
        /// Невосходящее (из данной точки наблюдения невидно).
        /// </summary>
        NoRising
    }
}