using Archimedes;
using Archimedes.Space3;

namespace SpaceOdyssey
{
    public static class CoordinateTransformation
    {
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