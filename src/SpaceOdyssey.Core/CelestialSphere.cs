using Archimedes;

namespace SpaceOdyssey
{
    public static class CelestialSphere
    {
        /// <summary>
        /// Преобразование горизонтальных координат в 1-е экваториальные.
        /// </summary>
        /// <remarks><list type="bullet">
        ///     <item>Высота над горизонтом задаётся sinH и cosH.</item>
        ///     <item>Азимут (от точки севера по часовой стрелке) задаётся sinA и cosA.</item>
        ///     <item>Широта места наблюдения задаётся sinPhi и cosPhi.</item>
        /// </list></remarks>
        /// <returns>declination – склонение, hourAngle – часовой угол (от точки юга по часовой стрелке).</returns>
        public static (double declination, double hourAngle) HorizontalToEq1 (double sinH, double cosH, double sinA, double cosA, 
            double sinPhi, double cosPhi)
        {
            double declination = Trigonometry.AsinEpsilon  (               cosH * cosA * cosPhi + sinH * sinPhi, ComputingSettings.ZeroAngleEpsilon);
            double hourAngle   = Trigonometry.Atan2Epsilon (-cosH * sinA, -cosH * cosA * sinPhi + sinH * cosPhi, ComputingSettings.ZeroAngleEpsilon);

            return (declination, hourAngle);
        }

        public static (double altitude, double azimuth) Eq1ToHorizontal (double sinDec, double cosDec, double sinTau, double cosTau,
            double sinPhi, double cosPhi)
        {
            double altitude = Trigonometry.AsinEpsilon  (                   cosDec * cosTau * cosPhi + sinDec * sinPhi, ComputingSettings.ZeroAngleEpsilon);
            double azimuth  = Trigonometry.Atan2Epsilon (-cosDec * sinTau, -cosDec * cosTau * sinPhi - sinDec * cosPhi, ComputingSettings.ZeroAngleEpsilon);

            return (altitude, azimuth);
        }

        /// <summary>
        /// Преобразует экваториальные координаты в эклиптические. Угол наклона экватора к эклиптике задаётся своими синусом 
        /// <paramref name="sinEpsilon"/> и косинусом <paramref name="cosEpsilon"/>.
        /// </summary>
        public static EclipticPosition EquatorialToEcliptic (EquatorialPosition equatorial, double sinEpsilon, double cosEpsilon)
        {
            return new EclipticPosition (EquatorialToEcliptic (equatorial.ToPolar3 (), sinEpsilon, cosEpsilon));
        }

        /// <summary>
        /// Преобразует экваториальные координаты в эклиптические. Угол наклона экватора к эклиптике задаётся своими синусом 
        /// <paramref name="sinEpsilon"/> и косинусом <paramref name="cosEpsilon"/>.
        /// </summary>
        public static Polar3 EquatorialToEcliptic (Polar3 equatorial, double sinEpsilon, double cosEpsilon)
        {
            return Rotation3.Apply.Passive.AroundOX.RotateSpace (equatorial, sinEpsilon, cosEpsilon);
        }

        /// <summary>
        /// Преобразует эклиптические координаты в экваториальные. Угол наклона экватора к эклиптике задаётся своими синусом 
        /// <paramref name="sinEpsilon"/> и косинусом <paramref name="cosEpsilon"/>.
        /// </summary>
        public static EquatorialPosition EclipticToEquatorial (EclipticPosition ecliptic, double sinEpsilon, double cosEpsilon)
        {
            return new EquatorialPosition (EclipticToEquatorial (ecliptic.ToPolar3 (), sinEpsilon, cosEpsilon));
        }

        /// <summary>
        /// Преобразует эклиптические координаты в экваториальные. Угол наклона экватора к эклиптике задаётся своими синусом 
        /// <paramref name="sinEpsilon"/> и косинусом <paramref name="cosEpsilon"/>.
        /// </summary>
        public static Polar3 EclipticToEquatorial (Polar3 ecliptic, double sinEpsilon, double cosEpsilon)
        {
            return Rotation3.Apply.Passive.AroundOX.RotateSpace (ecliptic, -sinEpsilon, cosEpsilon);
        }
    }
}