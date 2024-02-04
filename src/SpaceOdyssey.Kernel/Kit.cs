namespace SpaceOdyssey
{
    public static class Kit
    {
        /// <summary>
        /// Возвращает долю суток [0; 1), прошедшую после полуночи, для момента времени, заданного компонентами времени суток.
        /// </summary>
        public static double GetDayFraction (int hour, int min, int sec, int millisec)
        {
            return (double)(hour * AstroConst.Time.MillisecondsPerHour   + 
                            min  * AstroConst.Time.MillisecondsPerMinute + 
                            sec  * AstroConst.Time.MillisecondsPerSecond + 
                            millisec) 
                   / AstroConst.Time.MillisecondsPerDay;
        }

        /// <summary>
        /// Возвращает компоненты времени суток для момента времени, заданного долей суток [0; 1) <paramref name="dayFraction"/>, 
        /// прошедшей после полуночи.
        /// </summary>
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