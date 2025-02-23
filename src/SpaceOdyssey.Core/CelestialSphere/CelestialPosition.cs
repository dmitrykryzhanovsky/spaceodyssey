using Archimedes;

using SpaceOdyssey.CoordinateSystem;

namespace SpaceOdyssey.CelestialSphere
{
    public static class CelestialPosition
    {
        public static HorizontalPosition GetHorizonal (Location location, double LMSTInRotation, Polar3 equatorial)
        {
            EqHALocalPosition eqHALocalPosition = new EqHALocalPosition 
                (declination: equatorial.Latitude, 
                 hourAngle:   Trigonometry.RotationToRad (LMSTInRotation) - equatorial.Longitude);

            return EqHALocal.ToHorizontal (eqHALocalPosition, location.SinLatitude, location.CosLatitude);
        }
    }
}