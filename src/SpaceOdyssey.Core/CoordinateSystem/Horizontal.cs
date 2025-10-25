using Archimedes;
using Archimedes.Space3;

namespace SpaceOdyssey.CoordinateSystem
{
    /// <summary>
    /// Преобразование горизонтальных координат в экваториальные-1.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    ///     <item>latitude – широта места наблюдения в радианах;</item>
    ///     <item>sinLatitude, cosLatitude – sin и cos широты места наблюдения.</item>
    /// </list>
    /// </remarks>
    public static class Horizontal
    {        
        public static Vector3 ToEqHALocal (Vector3 v, double latitude)
        {
            return Rotation.Apply.Passive.AroundOY.RotateSpace (v, MathConst.PI_2 - latitude);
        }

        public static Vector3 ToEqHALocal (Vector3 v, double sinLatitude, double cosLatitude)
        {
            return Rotation.Apply.Passive.AroundOY.RotateSpace (v, cosLatitude, sinLatitude);
        }

        public static EqHALocalPosition ToEqHALocal (HorizontalPosition p, double latitude)
        {
            (double sinLatitude, double cosLatitude) = double.SinCos (latitude);

            return ToEqHALocal (p, sinLatitude, cosLatitude);
        }

        public static EqHALocalPosition ToEqHALocal (HorizontalPosition p, double sinLatitude, double cosLatitude)
        {
            return ComputeNewAngles (p, sinLatitude, cosLatitude);
        }

        private static EqHALocalPosition ComputeNewAngles (HorizontalPosition p, double sinLatitude, double cosLatitude)
        {
            (double sinH, double cosH) = double.SinCos(p.H);
            (double sinA, double cosA) = double.SinCos(p.A);

            double dx   = -cosH * cosA * sinLatitude + sinH * cosLatitude;
            double dy   = -cosH * sinA;
            double sinD =  cosH * cosA * cosLatitude + sinH * sinLatitude;

            return new EqHALocalPosition (declination: Trigonometry.AsinSmall (sinD),
                                          hourAngle:   Trigonometry.Atan2Small (dy, dx));
        }
    }
}