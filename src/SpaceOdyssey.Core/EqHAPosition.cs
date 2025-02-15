using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат в первой горизонтальной системе (склонение – часовой угол).
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится. Зачем нужна эта структура и про особенности 
    /// преобразования в сферические координаты см. https://github.com/dmitrykryzhanovsky/spaceodyssey/wiki/Чтобы-не-запутаться-в-координатах</remarks>
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

        /// <summary>
        /// Преобразование сферических координат типа <see cref="Polar3"/> в структуру <see cref="EqHAPosition"/>.
        /// </summary>
        public EqHAPosition (Polar3 p)
        {
            Dec =  p.Latitude;
            HA  = -p.Longitude;
        }

        /// <summary>
        /// Преобразование экваториальных-1 координат в сферические типа <see cref="Polar3"/>.
        /// </summary>
        public UnitPolar3 ToPolar3 ()
        {
            return new UnitPolar3 (Dec, -HA);
        }
    }
}