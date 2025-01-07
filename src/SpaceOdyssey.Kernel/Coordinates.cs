using Archimedes;

namespace SpaceOdyssey
{
    public static class Coordinates
    {
        ///////////////////////////////////////////////////////////////////////////////////
        // Преобразования из экваториальной системы координат в эклиптическую для Земли. //
        ///////////////////////////////////////////////////////////////////////////////////

        public static Vector3 EquatorialToEclipticForJD (this Vector3 v, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (v, AxialTilt.GetTiltForJD (jd));
        }

        public static Vector3 EquatorialToEclipticForJulianCenturies (this Vector3 v, double T)
        {
            return Rotation3.RotateSpaceAroundOX (v, AxialTilt.GetTiltForJulianCenturies (T));
        }

        public static Vector3 EquatorialToEclipticForTilt (this Vector3 v, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, tilt);
        }

        public static Vector3 EquatorialToEclipticForSinCos (this Vector3 v, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, sinTilt, cosTilt);
        }

        public static Polar3 EquatorialToEclipticForJD (this Polar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTiltForJD (jd));
        }

        public static Polar3 EquatorialToEclipticForJulianCenturies (this Polar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTiltForJulianCenturies (T));
        }

        public static Polar3 EquatorialToEclipticForTilt (this Polar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, tilt);
        }

        public static Polar3 EquatorialToEclipticForSinCos (this Polar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, sinTilt, cosTilt);
        }

        public static UnitPolar3 EquatorialToEclipticForJD (this UnitPolar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTiltForJD (jd));
        }

        public static UnitPolar3 EquatorialToEclipticForJulianCenturies (this UnitPolar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, AxialTilt.GetTiltForJulianCenturies (T));
        }

        public static UnitPolar3 EquatorialToEclipticForTilt (this UnitPolar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, tilt);
        }

        public static UnitPolar3 EquatorialToEclipticForSinCos (this UnitPolar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, sinTilt, cosTilt);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        // Преобразования из эклиптической системы координат в экваториальную для Земли. //
        ///////////////////////////////////////////////////////////////////////////////////

        public static Vector3 EclipticToEquatorialForJD (this Vector3 v, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (v, -AxialTilt.GetTiltForJD (jd));
        }

        public static Vector3 EclipticToEquatorialForJulianCenturies (this Vector3 v, double T)
        {
            return Rotation3.RotateSpaceAroundOX (v, -AxialTilt.GetTiltForJulianCenturies (T));
        }

        public static Vector3 EclipticToEquatorialForTilt (this Vector3 v, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, -tilt);
        }

        public static Vector3 EclipticToEquatorialForSinCos (this Vector3 v, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (v, -sinTilt, cosTilt);
        }

        public static Polar3 EclipticToEquatorialForJD (this Polar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTiltForJD (jd));
        }

        public static Polar3 EclipticToEquatorialForJulianCenturies (this Polar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTiltForJulianCenturies (T));
        }

        public static Polar3 EclipticToEquatorialForTilt (this Polar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -tilt);
        }

        public static Polar3 EclipticToEquatorialForSinCos (this Polar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -sinTilt, cosTilt);
        }

        public static UnitPolar3 EclipticToEquatorialForJD (this UnitPolar3 p, double jd)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTiltForJD (jd));
        }

        public static UnitPolar3 EclipticToEquatorialForJulianCenturies (this UnitPolar3 p, double T)
        {
            return Rotation3.RotateSpaceAroundOX (p, -AxialTilt.GetTiltForJulianCenturies (T));
        }

        public static UnitPolar3 EclipticToEquatorialForTilt (this UnitPolar3 p, double tilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -tilt);
        }

        public static UnitPolar3 EclipticToEquatorialForSinCos (this UnitPolar3 p, double sinTilt, double cosTilt)
        {
            return Rotation3.RotateSpaceAroundOX (p, -sinTilt, cosTilt);
        }
    }
}