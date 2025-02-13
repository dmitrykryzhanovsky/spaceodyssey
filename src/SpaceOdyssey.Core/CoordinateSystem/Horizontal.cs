﻿using Archimedes;
using Archimedes.Space3;

namespace SpaceOdyssey.CoordinateSystem
{
    public static class Horizontal
    {        
        public static Vector3 ToEqHA (Vector3 v, double latitude)
        {
            return Rotation.Apply.Passive.AroundOY.RotateSpace (v, MathConst.M_PI_2 - latitude);
        }

        public static Vector3 ToEqHA (Vector3 v, double sinLatitude, double cosLatitude)
        {
            return Rotation.Apply.Passive.AroundOY.RotateSpace (v, cosLatitude, sinLatitude);
        }

        public static EqHAPosition ToEqHA (HorizontalPosition p, double latitude)
        {
            (double sinLatitude, double cosLatitude) = double.SinCos (latitude);

            return ToEqHA (p, sinLatitude, cosLatitude);
        }

        public static EqHAPosition ToEqHA (HorizontalPosition p, double sinLatitude, double cosLatitude)
        {
            return ComputeNewAngles (p, sinLatitude, cosLatitude);
        }

        private static EqHAPosition ComputeNewAngles (HorizontalPosition p, double sinLatitude, double cosLatitude)
        {
            (double sinH, double cosH) = double.SinCos(p.H);
            (double sinA, double cosA) = double.SinCos(p.A);

            double dx   = -cosH * cosA * sinLatitude + sinH * cosLatitude;
            double dy   = -cosH * sinA;
            double sinD =  cosH * cosA * cosLatitude + sinH * sinLatitude;

            return new EqHAPosition (declination: Trigonometry.AsinSmall (sinD),
                                     hourAngle:   Trigonometry.Atan2Small (dy, dx));
        }
    }
}