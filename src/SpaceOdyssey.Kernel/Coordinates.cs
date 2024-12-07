using Archimedes;

namespace SpaceOdyssey
{
    public static class Coordinates
    {
        public static Vector EquatorialToEclipticForJD (this Vector3 v, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (v, AxialTilt.GetTilt (jd));
        }

        public static Vector EquatorialToEclipticForTime (this Vector3 v, double T)
        {
            return Rotation3.RotateSpaceAroundOX (v, AxialTilt.GetTilt (T));
        }

        public static Vector EquatorialToEcliptic (this Vector3 v, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, tilt);
        }

        public static Vector EquatorialToEcliptic (this Vector3 v, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, sinTilt, cosTilt);
        }

        public static Polar3 EquatorialToEclipticForJD (this Polar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTilt (jd));
        }

        public static Polar3 EquatorialToEclipticForTime (this Polar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTilt (T));
        }

        public static Polar3 EquatorialToEcliptic (this Polar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, tilt);
        }

        public static Polar3 EquatorialToEcliptic (this Polar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, sinTilt, cosTilt);
        }

        public static UnitPolar3 EquatorialToEclipticForJD (this UnitPolar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTilt (jd));
        }

        public static UnitPolar3 EquatorialToEclipticForTime (this UnitPolar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTilt (T));
        }

        public static UnitPolar3 EquatorialToEcliptic (this UnitPolar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, tilt);
        }

        public static UnitPolar3 EquatorialToEcliptic (this UnitPolar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, sinTilt, cosTilt);
        }

        public static Vector EclipticToEquatorialForJD (this Vector3 v, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (v, -AxialTilt.GetTilt (jd));
        }

        public static Vector EclipticToEquatorialForTime (this Vector3 v, double T)
        {
            return Rotation3.RotateSpaceAroundOX (v, -AxialTilt.GetTilt (T));
        }

        public static Vector EclipticToEquatorial (this Vector3 v, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, -tilt);
        }

        public static Vector EclipticToEquatorial (this Vector3 v, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, -sinTilt, cosTilt);
        }

        public static Polar3 EclipticToEquatorialForJD (this Polar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTilt (jd));
        }

        public static Polar3 EclipticToEquatorialForTime (this Polar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTilt (T));
        }

        public static Polar3 EclipticToEquatorial (this Polar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -tilt);
        }

        public static Polar3 EclipticToEquatorial (this Polar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -sinTilt, cosTilt);
        }

        public static UnitPolar3 EclipticToEquatorialForJD (this UnitPolar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTilt (jd));
        }

        public static UnitPolar3 EclipticToEquatorialForTime (this UnitPolar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTilt (T));
        }

        public static UnitPolar3 EclipticToEquatorial (this UnitPolar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -tilt);
        }

        public static UnitPolar3 EclipticToEquatorial (this UnitPolar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -sinTilt, cosTilt);
        }
    }
}