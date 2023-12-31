using System;

using Archimedes;

namespace SpaceOdyssey
{
    public static class Coordinates
    {
        public static (double b, double l) EquatorialToEcliptic (double d, double a, double epsilon)
        {
            return Rotation3.Reference.RotateAroundOX (d, a, epsilon);
        }

        public static (double b, double l) EquatorialToEcliptic (double d, double a, double sinE, double cosE)
        {
            return Rotation3.Reference.RotateAroundOX (d, a, sinE, cosE);
        }

        public static Polar3 EquatorialToEcliptic (Polar3 p, double epsilon)
        {
            return Rotation3.Reference.RotateAroundOX (p, epsilon);
        }

        public static Polar3 EquatorialToEcliptic (Polar3 p, double sinE, double cosE)
        {
            return Rotation3.Reference.RotateAroundOX (p, sinE, cosE);
        }

        public static Vector3 EquatorialToEcliptic (Vector3 v, double epsilon)
        {
            return Rotation3.Reference.RotateAroundOX (v, epsilon);
        }

        public static Vector3 EquatorialToEcliptic (Vector3 v, double sinE, double cosE)
        {
            return Rotation3.Reference.RotateAroundOX (v, sinE, cosE);
        }

        public static (double d, double a) EclipticToEquatorial (double b, double l, double epsilon)
        {
            return Rotation3.Reference.RotateAroundOX (b, l, -epsilon);
        }

        public static (double d, double a) EclipticToEquatorial (double b, double l, double sinE, double cosE)
        {
            return Rotation3.Reference.RotateAroundOX (b, l, -sinE, cosE);
        }

        public static Polar3 EclipticToEquatorial (Polar3 p, double epsilon)
        {
            return Rotation3.Reference.RotateAroundOX (p, -epsilon);
        }

        public static Polar3 EclipticToEquatorial (Polar3 p, double sinE, double cosE)
        {
            return Rotation3.Reference.RotateAroundOX (p, -sinE, cosE);
        }

        public static Vector3 EclipticToEquatorial (Vector3 v, double epsilon)
        {
            return Rotation3.Reference.RotateAroundOX (v, -epsilon);
        }

        public static Vector3 EclipticToEquatorial (Vector3 v, double sinE, double cosE)
        {
            return Rotation3.Reference.RotateAroundOX (v, -sinE, cosE);
        }
    }
}