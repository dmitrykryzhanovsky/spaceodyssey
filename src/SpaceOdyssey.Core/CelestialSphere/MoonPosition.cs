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
            // 1. Вычисление вспомогательных величин.

            // Средняя аномалия Луны в радианах.
            double moonMA = Trigonometry.RotationFraction (0.374897 + 1325.552410 * T);

            // Средняя аномалия Солнца в радианах.
            double sunMA = Trigonometry.RotationFraction (0.993133 + 99.997361 * T);

            // Разница долгот Луны и Солнца в радианах.
            double D = Trigonometry.RotationFraction (0.827361 + 1236.853086 * T);

            // Расстояние от восходящего узла в радианах.
            double F = Trigonometry.RotationFraction (0.259086 + 1342.227825 * T);

            // 2. Вычисление долготы.

            // Возмущения по долготе в секундах.
            double dLArсsec = 22640.0 * double.Sin (moonMA)
                             +  769.0 * double.Sin (2.0 * moonMA)
                             -  110.0 * double.Sin (moonMA + sunMA)
                             -  206.0 * double.Sin (moonMA + sunMA - 2.0 * D)
                             +  148.0 * double.Sin (moonMA - sunMA)
                             +  192.0 * double.Sin (moonMA + 2.0 * D)
                             - 4586.0 * double.Sin (moonMA - 2.0 * D)
                             -  212.0 * double.Sin (2.0 * (moonMA - D))
                             -  668.0 * double.Sin (sunMA)
                             -  165.0 * double.Sin (sunMA - 2.0 * D)
                             -  125.0 * double.Sin (D)
                             + 2370.0 * double.Sin (2.0 * D)
                             -  412.0 * double.Sin (2.0 * F)
                             -   55.0 * double.Sin (2.0 * (F - D));

            // Средняя долгота Луны в полных оборотах.
            double L0Rotation = (0.606433 + 1336.855225 * T).Fraction ();

            // Вычисляем долготу Луны в оборотах.
            double longRotation = L0Rotation + dLArсsec / MathConst.SEC_PER_ROTATION;

            // Преобразуем её в радианы.
            double l = Trigonometry.RotationFraction (longRotation);

            // 3. Вычисление широты.

            double S = F + Trigonometry.SecToRad (dLArсsec + 541.0 * double.Sin (sunMA) + 412.0 * double.Sin (2.0 * F));
            double h = F - 2.0 * D;

            // Возмущения по широте в секундах.
            double NArcsec = -526.0 * double.Sin (h)
                             + 44.0 * double.Sin (moonMA + h)        - 31.0 * double.Sin (-moonMA + h)
                             - 23.0 * double.Sin (sunMA + h)         + 11.0 * double.Sin (-sunMA + h)
                             - 25.0 * double.Sin (-2.0 * moonMA + F) + 21.0 * double.Sin (-moonMA + F);

            // Вычисляем широту Луны в радианах.
            double b = Trigonometry.SecToRad (18520.0 * double.Sin (S) + NArcsec);            

            return new UnitPolar3 (latitude: b, longitude: l);
        }
    }
}