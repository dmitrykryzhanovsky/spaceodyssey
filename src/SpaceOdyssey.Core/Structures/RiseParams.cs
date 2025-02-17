namespace SpaceOdyssey
{
    public class RiseParams
    {
        public ECircumpolar Circumpolar { get; private set; }

        public double RiseAzimuth { get; private set; }

        public double RiseHourAngle { get; private set; }

        public double DeclineAzimuth { get; private set; }

        public double DeclineHourAngle { get; private set; }

        public RiseParams (ECircumpolar circumpolar)
        {
            Circumpolar = circumpolar;
        }

        public RiseParams (ECircumpolar circumpolar, double riseHourAngle)
        {
            Circumpolar      = circumpolar;
            RiseHourAngle    = riseHourAngle;
            RiseAzimuth      = double.Pi + RiseHourAngle;
            DeclineHourAngle = -RiseHourAngle;
            DeclineAzimuth   = double.Pi - RiseHourAngle;
        }
    }
}