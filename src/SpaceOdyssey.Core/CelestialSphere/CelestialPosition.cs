using Archimedes;

using SpaceOdyssey.CoordinateSystem;

namespace SpaceOdyssey.CelestialSphere
{
    public static class CelestialPosition
    {
        public static HorizontalPosition GetHorizonal (Location location, double localSidearlTimeInRad, Polar3 equatorial)
        {
            EqHALocalPosition eqHALocalPosition = new EqHALocalPosition (declination: equatorial.Latitude, 
                hourAngle: localSidearlTimeInRad - equatorial.Longitude);

            return EqHALocal.ToHorizontal (eqHALocalPosition, location.SinLatitude, location.CosLatitude);
        }
    }
}