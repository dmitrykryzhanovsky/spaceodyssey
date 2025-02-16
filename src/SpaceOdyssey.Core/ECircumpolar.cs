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
        /// Светило находится на горизонте в одной точке.
        /// </summary>
        AtHorizonPoint,

        /// <summary>
        /// Светило находится на горизонте, обходя в течение суток его по полному кругу.
        /// </summary>
        AtHorizonCircle, 

        /// <summary>
        /// Невосходящее (из данной точки наблюдения невидно).
        /// </summary>
        NoRising
    }
}