using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление звёздного времени.
    /// </summary>
    /// <remarks>Для проверки тестовых значений использовался ресурс https://aa.usno.navy.mil/data/siderealtime.</remarks>
    public static class SiderealTime
    {
        private static readonly double [] RotationSeries = new double [] 
        {   
            24110.54841   / AstroConst.Time.SEC_IN_DAY,
          8640184.812866  / AstroConst.Time.SEC_IN_DAY,
          AstroConst.Time.EARTHROTATION_IN_DAY,
                0.093104  / AstroConst.Time.SEC_IN_DAY,
               -0.0000062 / AstroConst.Time.SEC_IN_DAY 
        };

        /// <summary>
        /// Возвращает гринвичское среднее звёздное время для момента jd в долях звёздных суток (0 = 0 ч .. 1 = 24 ч).
        /// </summary>
        public static double GMSTInRotation (double jd)
        {
            double jd05 = jd + 0.5;
            double jd0  = double.Floor (jd05);

            double UTFraction = jd05 - jd0;
            double T0 = Time.GetJulianCentirues (jd0 - 0.5);
            double T  = Time.GetJulianCentirues (jd);

            return GMSTInRotation (UTFraction, T0, T);
        }

        /// <summary>
        /// Возвращает гринвичское среднее звёздное время в долях звёздных суток (0 = 0 ч .. 1 = 24 ч) для заданного момента времени.
        /// </summary>
        /// <param name="UTFraction">Всемирное время UT1 в заданный момент времени.</param>
        /// <param name="T0">0 ч всемирного времени для заданного дня в юлианских столетиях от эпохи J2000.</param>
        /// <param name="T">Заданный момент времени в юлианских столетиях от эпохи J2000.</param>
        public static double GMSTInRotation (double UTFraction, double T0, double T)
        {
            return (RotationSeries [0] + RotationSeries [1] * T0 + RotationSeries [2] * UTFraction + 
                T * T * (RotationSeries [3] + RotationSeries [4] * T)).Fraction ();
        }

        /// <summary>
        /// Возвращает локальное среднее звёздное время в долях звёздных суток (0 = 0 ч .. 1 = 24 ч) для заданных местоположения и 
        /// гринвичского среднего звёздного времени.
        /// </summary>
        public static double LMSTInRotation (Location location, double GMSTInRotation)
        {
            return LMSTInRotation (location.Longitude, GMSTInRotation);
        }

        /// <summary>
        /// Возвращает локальное среднее звёздное время в долях звёздных суток (0 = 0 ч .. 1 = 24 ч) для заданных долготы и 
        /// гринвичского среднего звёздного времени.
        /// </summary>
        public static double LMSTInRotation (double longitude, double GMSTInRotation)
        {
            return GMSTInRotation + Trigonometry.RadToRotation (longitude);
        }
    }
}