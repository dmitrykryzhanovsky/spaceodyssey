using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Наклон земной оси.
    /// </summary>
    public static class AxialTilt
    {
        // Вычисление наклона земной оси к плоскости эклиптики происходит по формуле ε = Series [0] + Series [1] * T + Series [2] * T^2 + 
        // Series [3] * T^3.
        private static readonly double [] Series = new double []
        {
            Trigonometry.DegToRad ( 23.43929111), 
            Trigonometry.SecToRad (-46.815), 
            Trigonometry.SecToRad ( -0.00059), 
            Trigonometry.SecToRad (  0.001813)
        };

        /// <summary>
        /// Возвращает наклон земной оси в радианах для момента времени, заданного через параметр T.
        /// </summary>
        /// <param name="T">Количество юлианских столетий, прошедших после эпохи J2000. Отрицательное значение параметра соответствует 
        /// времени до эпохи J2000.</param>
        public static double GetTilt (double T)
        {
            return T * (T * (T * Series [3] + Series [2]) + Series [1]) + Series [0];
        }

        /// <summary>
        /// Возвращает наклон земной оси в радианах для юлианской даты jd.
        /// </summary>
        public static double GetTiltForJD (double jd)
        {
            double T = JD.GetJulianCenturies (jd);

            return GetTilt (T);
        }
    }
}