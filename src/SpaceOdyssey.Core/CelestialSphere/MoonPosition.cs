using Archimedes;

namespace SpaceOdyssey.CelestialSphere
{
    public static class MoonPosition
    {
        /// <summary>
        /// Приближённое вычисление положения Луны в эклиптической системе координат для момента времени T.
        /// </summary>
        /// <param name="T">Момент времени в юлианских столетиях от эпохи J2000.</param>
        /// <remarks>Положение Луны определяется в системе координат для эпохи J2000 с погрешностью около **.</remarks>
        public static UnitPolar3 ComputeApproximateInEcliptic (double T)
        {
            // Средняя аномалия Луны в радианах.
            double moonMA = Trigonometry.RotationFraction (0.374897 + 1325.552410 * T);

            // Средняя аномалия Солнца в радианах.
            double sunMA = Trigonometry.RotationFraction (0.993133 + 99.997361 * T);

            // Разница долгот Луны и Солнца в радианах.
            double longDifference = Trigonometry.RotationFraction (0.827361 + 1236.853086 * T);

            // Расстояние от восходящего узла в радианах.
            double F = Trigonometry.RotationFraction (0.259086 + 1342.227825 * T);

            double dLArsec = 22640.0 * double.Sin (moonMA) + 769.0 * double.Sin (2.0 * moonMA) 
                - 4586.0 * double.Sin (moonMA - 2.0 * longDifference) 
                - 668.0 * double.Sin (sunMA)
                + 2370.0 * double.Sin (2.0 * longDifference)

            double S;
            double NArcsec;

            // Вычисляем широту Луны в радианах.
            double b = Trigonometry.SecToRad (18520.0 * double.Sin (S) + NArcsec);

            // Средняя долгота Луны в полных оборотах.
            double L0Rotation = (0.606433 + 1336.855225 * T).Fraction ();

            // Вычисляем долготу Луны в оборотах.
            double longRotation = L0Rotation + dLArsec / MathConst.SEC_PER_ROTATION;

            // Преобразуем её в радианы.
            double l = Trigonometry.RotationFraction (longRotation);

            return new UnitPolar3 (latitude: b, longitude: l);
        }
    }
}