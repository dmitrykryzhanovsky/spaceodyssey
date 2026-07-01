using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат в первой горизонтальной системе (склонение – часовой угол).
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится. Зачем нужна эта структура и про особенности 
    /// преобразования в сферические координаты см. https://github.com/dmitrykryzhanovsky/spaceodyssey/wiki/Чтобы-не-запутаться-в-координатах</remarks>
    public struct Eq1Position
    {
        /// <summary>
        /// Склонение.
        /// </summary>
        public double Declination;

        /// <summary>
        /// Часовой угол.
        /// </summary>
        /// <remarks>Отсчитывается от точки юга S по часовой стрелке.</remarks>
        public double HourAngle;

        public Eq1Position(double declination, double hourAngle)
        {
            Declination = declination;
            HourAngle   = hourAngle;
        }

        /// <summary>
        /// Преобразование сферических координат типа <see cref="Polar3"/> в структуру <see cref="Eq1Position"/>.
        /// </summary>
        public Eq1Position (Polar3 p)
        {
            Declination =  p.Lat;
            HourAngle   = -p.Long;
        }

        /// <summary>
        /// Преобразование экваториальных-1 координат в сферические типа <see cref="Polar3"/>.
        /// </summary>
        public Polar3 ToPolar3 ()
        {
            return new Polar3 (1.0, Declination, -HourAngle);
        }
    }
}