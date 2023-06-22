using SpaceOdyssey.Cosmodynamics;

namespace SpaceOdyssey.Debug.Win
{
    public class GravitationalCenterData
    {
        internal double K { get; private set; }

        internal double R { get; private set; }

        internal double V1 { get; private set; }

        internal double V2 { get; private set; }

        internal GravitationalCenterData (CelestialObject celestialObject)
        {
            K  = celestialObject.K;
            R  = celestialObject.R / 1000.0;
            V1 = celestialObject.GetV1 () / 1000.0;
            V2 = celestialObject.GetV2 () / 1000.0;
        }
    }
}