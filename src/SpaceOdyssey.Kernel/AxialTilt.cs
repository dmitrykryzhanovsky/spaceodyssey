using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление наклона земной оси.
    /// </summary>
    public static class AxialTilt
    {
        private static readonly double [] Series = new double []
        {
            Trigonometry.DegToRad ( 23.43929111), 
            Trigonometry.SecToRad (-46.815), 
            Trigonometry.SecToRad ( -0.00059), 
            Trigonometry.SecToRad (  0.001813)
        };

        /// <summary>
        /// Возвращает наклон земной оси в радианах для момента времени <paramref name="T"/>.
        /// </summary>
        /// <param name="T">Количество юлианских столетий между заданным моментом времени и эпохой J2000. Для моментов времени, бывших 
        /// ранее эпохи J2000, отрицательно.</param>
        public static double GetTilt (double T)
        {
            return ((Series [3] * T + Series [2]) * T + Series [1]) * T + Series [0];
        }
    }
}