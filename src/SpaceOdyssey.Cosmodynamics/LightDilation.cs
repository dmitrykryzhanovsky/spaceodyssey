using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public static class LightDilation
    {
        public static double ComputeLightDilation (double t0, KeplerOrbit observer, KeplerOrbit sattelite, double halpEpsilon)
        {
            OrbitalPosition oBgein = observer.ComputePosition (t0);
            OrbitalPosition sBegin = sattelite.ComputePosition (t0);
            
            oBgein.ComputeSpatialPositionCartesian ();
            sBegin.ComputeSpatialPositionCartesian ();

            double dBegin = Space3.Distance (oBgein.SpatialPositionCartesian, sBegin.SpatialPositionCartesian);
            double e      = 2.0 * dBegin / AstroConst.LightSpeed_MD;
            double t1     = t0 - e;            

            while (e > halpEpsilon)
            {
                double          t = (t0 + t1) / 2.0;
                OrbitalPosition o = observer.ComputePosition (t);
                OrbitalPosition s = sattelite.ComputePosition (t);

                o.ComputeSpatialPositionCartesian ();
                s.ComputeSpatialPositionCartesian ();

                double d = Space3.Distance (o.SpatialPositionCartesian, s.SpatialPositionCartesian);
                double f = AstroConst.LightSpeed_MD * (t0 - t) - d;

                if (f > 0.0) t1 = t;
                else if (f < 0.0) t0 = t;
                else return t;

                e = t0 - t1;
            }

            return (t0 + t1) / 2.0;
        }
    }
}