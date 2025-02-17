namespace SpaceOdyssey
{
    public static class CelestialSphere
    {
        public static RiseParams RiseAzimuth (double declination, Location location)
        {
            double cosT = -double.Sin (declination) / location.CosLatitude;

            if (cosT < -1.0) return new RiseParams (ECircumpolar.NoDeclining);
            else if (cosT > 1.0) return new RiseParams (ECircumpolar.NoRising);
            else return new RiseParams (ECircumpolar.Usual, -double.Acos (cosT));
        }
    }
}