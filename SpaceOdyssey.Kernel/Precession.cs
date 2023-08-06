using System;

using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление прецессии.
    /// </summary>
    public static class Precession
    {
        private static readonly double [] Series_Ecliptic_StartAngle = new double []
        {
            Trigonometry.DegToRad ( 174.876383889),
            Trigonometry.SecToRad (3289.4789),
            Trigonometry.SecToRad (   0.60622),
            Trigonometry.SecToRad (-869.8089),
            Trigonometry.SecToRad (  -0.50491),
            Trigonometry.SecToRad (   0.03536)
        };

        private static readonly double [] Series_Ecliptic_StartAngle_J2000 = new double []
        {
            Series_Ecliptic_StartAngle [0],
            Series_Ecliptic_StartAngle [3],
            Series_Ecliptic_StartAngle [5]
        };

        private static readonly double [] Series_Ecliptic_Longitude = new double []
        {
            Trigonometry.SecToRad (5029.0966),
            Trigonometry.SecToRad (   2.22226),
            Trigonometry.SecToRad (  -0.000042),
            Trigonometry.SecToRad (   1.11113),
            Trigonometry.SecToRad (  -0.000042),
            Trigonometry.SecToRad (  -0.000006)
        };

        private static readonly double [] Series_Ecliptic_Longitude_J2000 = new double []
        {
            Series_Ecliptic_Longitude [0],
            Series_Ecliptic_Longitude [3],
            Series_Ecliptic_Longitude [5]
        };

        private static readonly double [] Series_Ecliptic_Inclination = new double []
        {
            Trigonometry.SecToRad (47.0029),
            Trigonometry.SecToRad (-0.06603),
            Trigonometry.SecToRad ( 0.000598),
            Trigonometry.SecToRad (-0.03302),
            Trigonometry.SecToRad ( 0.000598),
            Trigonometry.SecToRad ( 0.000060)
        };

        private static readonly double [] Series_Ecliptic_Inclination_J2000 = new double []
        {
            Series_Ecliptic_Inclination [0],
            Series_Ecliptic_Inclination [3],
            Series_Ecliptic_Inclination [5]
        };

        public static double EclipticPrecessionLongitude (double T1, double dT)
        {
            return (((Series_Ecliptic_Longitude [5] * dT) + 
                     (Series_Ecliptic_Longitude [3] + Series_Ecliptic_Longitude [4] * T1)) * dT + 
                     (Series_Ecliptic_Longitude [0] + Series_Ecliptic_Longitude [1] * T1 + Series_Ecliptic_Longitude [2] * T1 * T1)) * dT;
        }

        public static double EclipticPrecessionLongitude_J2000 (double dT)
        {
            return ((Series_Ecliptic_Longitude_J2000 [2] * dT + Series_Ecliptic_Longitude_J2000 [1]) * dT + Series_Ecliptic_Longitude_J2000 [0]) * dT;
        }

        public static double EclipticPrecessionStartAngle (double T1, double dT)
        {
            return ((Series_Ecliptic_StartAngle [5] * dT) +
                    (Series_Ecliptic_StartAngle [3] + Series_Ecliptic_StartAngle [4] * T1)) * dT +
                    (Series_Ecliptic_StartAngle [0] + Series_Ecliptic_StartAngle [1] * T1 + Series_Ecliptic_StartAngle [2] * T1 * T1);
        }

        public static double EclipticPrecessionStartAngle_J2000 (double dT)
        {
            return (Series_Ecliptic_StartAngle [2] * dT + Series_Ecliptic_StartAngle [1]) * dT + Series_Ecliptic_StartAngle [0];
        }

        public static double EclipticPrecessionInclination (double T1, double dT)
        {
            return (((Series_Ecliptic_Inclination [5] * dT) +
                     (Series_Ecliptic_Inclination [3] + Series_Ecliptic_Inclination [4] * T1)) * dT +
                     (Series_Ecliptic_Inclination [0] + Series_Ecliptic_Inclination [1] * T1 + Series_Ecliptic_Inclination [2] * T1 * T1)) * dT;
        }

        public static double EclipticPrecessionInclination_J2000 (double dT)
        {
            return ((Series_Ecliptic_Inclination_J2000 [2] * dT + Series_Ecliptic_Inclination_J2000 [1]) * dT + Series_Ecliptic_Inclination_J2000 [0]) * dT;
        }

        /// <summary>
        /// Возвращает матрицу поворота для перехода от эклиптических координат эпохи 1 <paramref name="T1"/> к эклиптическим координатам 
        /// эпохи 2 <paramref name="T1"/> + <paramref name="dT"/>.
        /// </summary>
        /// <param name="T1">Разница в юлианских столетиях между эпохой 1 (для которой координаты нам известны) и эпохой J2000.</param>
        /// <param name="dT">Разница в юлианских столетиях между эпохой 2 (к координатам которой нужно перейти) и эпохой 1 <paramref name="T1"/>.</param>
        public static Matrix3 EclipticPrecessionRotationMatrix (double T1, double dT)
        {
            double pi = EclipticPrecessionInclination (T1, dT);
            double P  = EclipticPrecessionStartAngle (T1, dT);
            double s  = EclipticPrecessionLongitude (T1, dT);
            double L  = P + s;

            return ComputeEclipticPrecessionRotationMatrix (pi, P, L);
        }

        /// <summary>
        /// Возвращает матрицу поворота для перехода от эклиптических координат эпохи J2000 к эклиптическим координатам эпохи 
        /// J2000 + <paramref name="dT"/>.
        /// </summary>
        /// <param name="dT">Разница в юлианских столетиях между эпохой, к координатам которой нужно перейти, и эпохой J2000.</param>
        public static Matrix3 EclipticPrecessionRotationMatrix_J2000 (double dT)
        {
            double pi = EclipticPrecessionInclination_J2000 (dT);
            double P  = EclipticPrecessionStartAngle_J2000 (dT);
            double s  = EclipticPrecessionLongitude_J2000 (dT);
            double L  = P + s;

            return ComputeEclipticPrecessionRotationMatrix (pi, P, L);
        }

        private static Matrix3 ComputeEclipticPrecessionRotationMatrix (double pi, double P, double L)
        {
            (double sinpi, double cospi) = Math.SinCos (pi);
            (double sinP,  double cosP)  = Math.SinCos (P);
            (double sinL,  double cosL)  = Math.SinCos (L);

            return new Matrix3 ( cosL * cosP + sinL * sinP * cospi,
                                 cosL * sinP - sinL * cosP * cospi,
                                -sinL * sinpi,
                                 sinL * cosP - cosL * sinP * cospi,
                                 sinL * sinP + cosL * cosP * cospi,
                                 cosL * sinpi,
                                 sinP * sinpi,                                                                 
                                -cosP * sinpi,
                                 cospi);
        }
    }
}