using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление наклона земной оси.
    /// </summary>
    public static class AxialTilt
    {
        /// <summary>
        /// Коэффициенты полинома относительно эпохи J2000.
        /// </summary>
        private static readonly double [] Series = new double []
        {
            Trigonometry.DegToRad ( 23.43929111), 
            Trigonometry.SecToRad (-46.815), 
            Trigonometry.SecToRad ( -0.00059), 
            Trigonometry.SecToRad (  0.001813)
        };

        /// <summary>
        /// Возвращает наклон земной оси в радианах для юлианской даты, отстоящей от эпохи J2000 на <paramref name="dT"/> юлианских столетий.
        /// </summary>
        /// <param name="dT">Больше 0, если заданная дата была позже эпохи J2000. Меньше 0, если заданная дата была до эпохи J2000.</param>
        public static double GetTilt (double dT)
        {
            return ((Series [3] * dT + Series [2]) * dT + Series [1]) * dT + Series [0];
        }

        /// <summary>
        /// Возвращает наклон земной оси в радианах для юлианской даты <paramref name="jd"/>.
        /// </summary>
        public static double GetTiltForJD (double jd)
        {
            return GetTilt ((jd - AstroConst.J2000) / AstroConst.JulianCentury);
        }
    }
}