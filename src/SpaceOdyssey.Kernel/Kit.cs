namespace SpaceOdyssey
{
    public static class Kit
    {
        public static double GetDayFraction (int hour, int min, int sec, int millisec)
        {
            return (double)(hour * AstroConst.Time.MillisecondsPerHour   + 
                            min  * AstroConst.Time.MillisecondsPerMinute + 
                            sec  * AstroConst.Time.MillisecondsPerSecond + 
                            millisec) 
                   / AstroConst.Time.MillisecondsPerDay;
        }

        public static (int hour, int min, int sec, int millisec) GetDayTime (double dayFraction)
        {
            int millisec = (int)(dayFraction * AstroConst.Time.MillisecondsPerDay);

            (int hour, millisec) = int.DivRem (millisec, AstroConst.Time.MillisecondsPerHour);
            (int min,  millisec) = int.DivRem (millisec, AstroConst.Time.MillisecondsPerMinute);
            (int sec,  millisec) = int.DivRem (millisec, AstroConst.Time.MillisecondsPerSecond);

            return (hour, min, sec, millisec);
        }
    }
}