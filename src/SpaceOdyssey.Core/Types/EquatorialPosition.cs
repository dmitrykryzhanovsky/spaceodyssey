using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат во второй экваториальной системе (склонение – прямое восхождение).
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится. Зачем нужна эта структура и про особенности 
    /// преобразования в сферические координаты см. https://github.com/dmitrykryzhanovsky/spaceodyssey/wiki/Чтобы-не-запутаться-в-координатах</remarks>
    public struct EquatorialPosition
    {
        /// <summary>
        /// Склонение.
        /// </summary>
        public double Declination;

        /// <summary>
        /// Прямое восхождение.
        /// </summary>
        /// <remarks>Отсчитывается от точки юга S против часовой стрелки.</remarks>
        public double RightAscension;

        public EquatorialPosition (double declination, double rightAscension)
        {
            Declination    = declination;
            RightAscension = rightAscension;
        }

        /// <summary>
        /// Преобразование сферических координат типа <see cref="Polar3"/> в структуру <see cref="EquatorialPosition"/>.
        /// </summary>
        public EquatorialPosition (Polar3 p)
        {
            Declination    = p.Lat;
            RightAscension = p.Long;
        }

        /// <summary>
        /// Преобразование экваториальных-2 координат в сферические типа <see cref="Polar3"/>.
        /// </summary>
        public Polar3 ToPolar3 ()
        {
            return new Polar3 (1.0, Declination, RightAscension);
        }
    }
}