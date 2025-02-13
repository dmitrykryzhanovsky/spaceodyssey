namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат в первой горизонтальной системе (склонение – часовой угол).
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится.</remarks>
    public struct EqHAPosition
    {
        /// <summary>
        /// Склонение.
        /// </summary>
        public double Dec;

        /// <summary>
        /// Часовой угол.
        /// </summary>
        /// <remarks>Отсчитывается от точки юга S по часовой стрелке.</remarks>
        public double HA;

        public EqHAPosition (double declination, double hourAngle)
        {
            Dec = declination;
            HA  = hourAngle;
        }
    }
}