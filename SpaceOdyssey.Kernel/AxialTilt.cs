using System;

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

        /// <summary>
        /// Возвращает наклон земной оси в радианах для юлианской даты <paramref name="jd"/>, а также sin и cos для него.
        /// </summary>
        public static (double tilt, double sin, double cos) GetTiltSinCosForJD (double jd)
        {
            double tilt = GetTiltForJD (jd);
            (double sin, double cos) = Math.SinCos (tilt);

            return (tilt: tilt,
                    sin:  sin,
                    cos:  cos);
        }

        /// <summary>
        /// Возвращает наклон земной оси в радианах для юлианской даты <paramref name="jd"/>, sin и cos для него, и матрицы поворота 
        /// на этот угол в положительную (CCW) и отрицательную (CW) стороны.
        /// </summary>
        public static (double tilt, double sin, double cos, Matrix3 positiveRotation, Matrix3 negativeRotation) GetTiltSinCosMatricesForJD (double jd)
        {
            (double tilt, double sin, double cos) = GetTiltSinCosForJD (jd);
            (Matrix3 positive, Matrix3 negative)  = Space3.CreateRotationOX_CWCCW (sin, cos);

            return (tilt: tilt,
                    sin:  sin,
                    cos:  cos,
                    positiveRotation: positive,
                    negativeRotation: negative);
        }
    }
}