namespace Archimedes
{
    public static class Space2
    {
        /// <summary>
        /// Вычисляет полярные координаты для пары декартовых координат (x; y).
        /// </summary>
        public static (double r, double heading) ComputePolarComponents (double x, double y)
        {
            double r = double.Hypot (x, y);
            double heading = double.Atan2 (y, x);

            return (r, heading);
        }
    }
}