using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат в горизонтальной системе.
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится.</remarks>
    public struct HorizontalPosition
    {
        /// <summary>
        /// Высота.
        /// </summary>
        public double H;

        /// <summary>
        /// Азимут.
        /// </summary>
        /// <remarks>Отсчитывается от точки севера N по часовой стрелке.</remarks>
        public double A;

        public HorizontalPosition (double altitude, double azimuth)
        {
            H = altitude;
            A = azimuth;
        }

        public HorizontalPosition (Polar3 p)
        {
            H = p.Latitude;
            A = double.Pi - p.Longitude;
        }

        public UnitPolar3 ToPolar3 ()
        {
            return UnitPolar3.InitDirect (H, double.Pi - A);
        }
    }
}