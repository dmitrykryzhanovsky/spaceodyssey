using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат в горизонтальной системе.
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится. Зачем нужна эта структура и про особенности 
    /// преобразования в сферические координаты см. https://github.com/dmitrykryzhanovsky/spaceodyssey/wiki/Чтобы-не-запутаться-в-координатах</remarks>
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

        /// <summary>
        /// Преобразование сферических координат типа <see cref="Polar3"/> в структуру <see cref="HorizontalPosition"/>.
        /// </summary>
        public HorizontalPosition (Polar3 p)
        {
            H = p.Latitude;
            A = double.Pi - p.Longitude;
        }

        /// <summary>
        /// Преобразование горизонтальных координат в сферические типа <see cref="Polar3"/>.
        /// </summary>
        public UnitPolar3 ToPolar3 ()
        {
            return UnitPolar3.InitDirect (H, double.Pi - A);
        }
    }
}