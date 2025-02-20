using Archimedes;

namespace SpaceOdyssey.CelestialSphere
{
    public static class SunPosition
    {
        /// <summary>
        /// Приближённое вычисление положения Солнца в эклиптической системе координат для момента времени T.
        /// </summary>
        /// <param name="T">Момент времени в юлианских столетиях от эпохи J2000.</param>
        /// <remarks>Положение Солнца определяется в системе координат для эпохи J2000 с погрешностью около 20′.</remarks>
        public static UnitPolar3 ComputeApproximateInEcliptic (double T)
        {
            double m = (0.993133 + 99.997361 * T).Fraction ();
            double M = double.Tau * m;
            double L = Trigonometry.RotationFraction (0.7859453 + m + 
                (6893.0 * double.Sin (M) + 72.0 * double.Sin (2.0 * M) + 6191.2 * T) / MathConst.SEC_PER_ROTATION);

            return new UnitPolar3 (latitude: 0.0, longitude: L);
        }
    }
}