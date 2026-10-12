using Archimedes;

namespace SpaceOdyssey
{
    public static class CelestialSphere
    {
        public static Eq1Position HorizontalToEquatorial1 (double sinH, double cosH, double sinA, double cosA, double sinPhi, double cosPhi)
        {
            double dec = Trigonometry.AsinEpsilon  (               cosH * cosA * cosPhi + sinH * sinPhi, ComputingSettings.ZeroAngleEpsilon);
            double tau = Trigonometry.Atan2Epsilon (-cosH * sinA, -cosH * cosA * sinPhi + sinH * cosPhi, ComputingSettings.ZeroAngleEpsilon);

            return new Eq1Position (dec, tau);
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