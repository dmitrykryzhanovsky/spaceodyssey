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
    }
}