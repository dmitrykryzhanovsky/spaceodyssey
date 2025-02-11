using Archimedes;
using Archimedes.Space3;

namespace SpaceOdyssey
{
    public static class CoordinateTransformation
    {
        public static class HorizontalToEquatorialHA
        {
            public static Vector3 Transform (Vector3 v, double latitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (v, MathConst.M_PI_2 - latitude);
            }

            public static Vector3 Transform (Vector3 v, double sinLatitude, double cosLatitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (v, cosLatitude, sinLatitude);
            }

            public static Polar3 Transform (Polar3 p, double latitude)
            {
                (double sinLatitude, double cosLatitude) = double.SinCos (latitude);

                return Transform (p, sinLatitude, cosLatitude);
            }

            public static Polar3 Transform (Polar3 p, double sinLatitude, double cosLatitude)
            {
                (double declination, double hourAngle) = ComputeNewAngles (p, sinLatitude, cosLatitude);

                return UnitPolar3.InitDirect (declination, hourAngle);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double latitude)
            {
                (double sinLatitude, double cosLatitude) = double.SinCos (latitude);

                return Transform (p, sinLatitude, cosLatitude);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double sinLatitude, double cosLatitude)
            {
                (double declination, double hourAngle) = ComputeNewAngles (p, sinLatitude, cosLatitude);

                return UnitPolar3.InitDirect (declination, hourAngle);
            }

            private static (double declination, double hourAngle) ComputeNewAngles (Polar3 p, double sinLatitude, double cosLatitude)
            {
                (double sinH, double cosH) = double.SinCos (p.Latitude);
                (double sinA, double cosA) = double.SinCos (p.Longitude);

                double dx   = -cosH * cosA * sinLatitude + sinH * cosLatitude;
                double dy   = -cosH * sinA;
                double sinD =  cosH * cosA * cosLatitude + sinH * sinLatitude;

                return (declination: Trigonometry.AsinSmall (sinD),
                        hourAngle:   Trigonometry.Atan2Small (dy, dx));
            }
        }

        public static class EquatorialHAToHorizontal
        {
            public static Vector3 Transform (Vector3 v, double latitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (v, MathConst.M_PI_2 - latitude);
            }

            public static Vector3 Transform (Vector3 v, double sinLatitude, double cosLatitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (v, cosLatitude, sinLatitude);
            }

            public static Polar3 Transform (Polar3 p, double latitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (p, MathConst.M_PI_2 - latitude);
            }

            public static Polar3 Transform (Polar3 p, double sinLatitude, double cosLatitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (p, cosLatitude, sinLatitude);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double latitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (p, MathConst.M_PI_2 - latitude);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double sinLatitude, double cosLatitude)
            {
                return Rotation.Apply.Passive.AroundOY.RotateSpace (p, cosLatitude, sinLatitude);
            }
        }

        /// <summary>
        /// Преобразование экваториальных координат в эклиптические.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///     <item>tilt – наклон оси вращения к эклиптике в радианах;</item>
        ///     <item>sinTilt, cosTilt – sin и cos наклона оси вращения к эклиптике.</item>
        /// </list>
        /// </remarks>
        public static class EquatorialToEcliptic
        {
            public static Vector3 Transform (Vector3 v, double tilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (v, tilt);
            }

            public static Vector3 Transform (Vector3 v, double sinTilt, double cosTilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (v, sinTilt, cosTilt);
            }

            public static Polar3 Transform (Polar3 p, double tilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, tilt);
            }

            public static Polar3 Transform (Polar3 p, double sinTilt, double cosTilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, sinTilt, cosTilt);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double tilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, tilt);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double sinTilt, double cosTilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, sinTilt, cosTilt);
            }
        }

        /// <summary>
        /// Преобразование эклиптических координат в экваториальные.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///     <item>tilt – наклон оси вращения к эклиптике в радианах;</item>
        ///     <item>sinTilt, cosTilt – sin и cos наклона оси вращения к эклиптике.</item>
        /// </list>
        /// </remarks>
        public static class EclipticToEquatorial
        {
            public static Vector3 Transform (Vector3 v, double tilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (v, -tilt);
            }

            public static Vector3 Transform (Vector3 v, double sinTilt, double cosTilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (v, -sinTilt, cosTilt);
            }

            public static Polar3 Transform (Polar3 p, double tilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, -tilt);
            }

            public static Polar3 Transform (Polar3 p, double sinTilt, double cosTilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, -sinTilt, cosTilt);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double tilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, -tilt);
            }

            public static UnitPolar3 Transform (UnitPolar3 p, double sinTilt, double cosTilt)
            {
                return Rotation.Apply.Passive.AroundOX.RotateSpace (p, -sinTilt, cosTilt);
            }
        }
    }
}