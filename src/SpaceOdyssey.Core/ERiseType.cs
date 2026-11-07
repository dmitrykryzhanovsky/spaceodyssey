namespace SpaceOdyssey
{
    /// <summary>
    /// Тип светила по восходу над горизонтом.
    /// </summary>
    public enum ERiseType
    {
        /// <summary>
        /// Незаходящее светило.
        /// </summary>
        NotSet = 1,

        /// <summary>
        /// Светило восходит и заходит.
        /// </summary>
        Usual,

        /// <summary>
        /// Невосходящее светило.
        /// </summary>
        NotRise
    }
}