using Archimedes;
using Archimedes.Space3;
using SpaceOdyssey.Structures;

namespace SpaceOdyssey.CoordinateSystem
{
    /// <summary>
    /// Преобразование экваториальных-1 координат в горизонтальные.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    ///     <item>latitude – широта места наблюдения в радианах;</item>
    ///     <item>sinLatitude, cosLatitude – sin и cos широты места наблюдения.</item>
    /// </list>
    /// </remarks>
    public static class EqHALocal
    {        
        public static Vector3 ToHorizontal (Vector3 v, double latitude)
        {
            return Rotation.Apply.Passive.AroundOY.RotateSpace (v, latitude - MathConst.M_PI_2);
        }

        public static Vector3 ToHorizontal (Vector3 v, double sinLatitude, double cosLatitude)
        {
            return Rotation.Apply.Passive.AroundOY.RotateSpace (v, cosLatitude, sinLatitude);
        }

        public static HorizontalPosition ToHorizontal (EqHALocalPosition p, double latitude)
        {
            (double sinLatitude, double cosLatitude) = double.SinCos (latitude);

            return ToHorizontal (p, sinLatitude, cosLatitude);
        }

        public static HorizontalPosition ToHorizontal (EqHALocalPosition p, double sinLatitude, double cosLatitude)
        {
            return ComputeNewAngles (p, sinLatitude, cosLatitude);
        }

        private static HorizontalPosition ComputeNewAngles (EqHALocalPosition p, double sinLatitude, double cosLatitude)
        {
            (double sinD, double cosD) = double.SinCos(p.Dec);
            (double sinT, double cosT) = double.SinCos(p.HA);

            double dx   = -cosD * cosT * sinLatitude + sinD * cosLatitude;
            double dy   = -cosD * sinT;
            double sinH =  cosD * cosT * cosLatitude + sinD * sinLatitude;

            return new HorizontalPosition (altitude: Trigonometry.AsinSmall (sinH),
                                           azimuth:  Trigonometry.Atan2Small (dy, dx));
        }
    }
}