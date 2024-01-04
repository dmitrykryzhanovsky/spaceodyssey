namespace SpaceOdyssey
{
    /// <summary>
    /// Астрономические константы.
    /// </summary>
    public static class AstroConst
    {
        /// <summary>
        /// Количество суток в юлианском столетии.
        /// </summary>
        public const int JulianCentury = 36525;

        /// <summary>
        /// Юлианская эпоха J2000 = 1.5 января 2000 (полдень 1 января 2000 г.)
        /// </summary>
        public const double J2000 = 2451545.0;

        /// <summary>
        /// Юлианская эпоха J1900 = 0.5 января 1900 (полдень 31 декабря 1899 г.)
        /// </summary>
        public const double J1900 = 2415020.0;

        /// <summary>
        /// Гауссова гравитационная постоянная.
        /// </summary>
        /// <remarks>Квадратный корень из гравитационной постоянной Ньютона, выраженной в астрономической системе единиц (сутки, масса 
        /// Солнца, астрономическая единица). Значение взято из https://en.wikipedia.org/wiki/Astronomical_constant#Table_of_astronomical_constants.</remarks>
        public const double GaussianGravitationalConstant = 0.01720209895;

        /// <summary>
        /// Квадрат гауссовой гравитационной постоянной.
        /// </summary>
        public const double GaussianGravitationalConstant2 = GaussianGravitationalConstant * GaussianGravitationalConstant;
    }
}