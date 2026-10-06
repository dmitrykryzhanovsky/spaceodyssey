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
    }
}