using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Структура для хранения небесных координат эклиптической системе.
    /// </summary>
    /// <remarks>Проверка на корректность значений при инициализации не производится. Зачем нужна эта структура и про особенности 
    /// преобразования в сферические координаты см. https://github.com/dmitrykryzhanovsky/spaceodyssey/wiki/Чтобы-не-запутаться-в-координатах</remarks>
    public struct EclipticPosition
    {
        /// <summary>
        /// Широта.
        /// </summary>
        public double B;

        /// <summary>
        /// Долгота.
        /// </summary>
        /// <remarks>Отсчитывается от точки юга S против часовой стрелки.</remarks>
        public double L;

        public EclipticPosition (double latitude, double longitude)
        {
            B = latitude;
            L = longitude;
        }

        /// <summary>
        /// Преобразование сферических координат типа <see cref="Polar3"/> в структуру <see cref="EclipticPosition"/>.
        /// </summary>
        public EclipticPosition (Polar3 p)
        {
            B = p.Lat;
            L = p.Long;
        }

        /// <summary>
        /// Преобразование эклиптических координат в сферические типа <see cref="Polar3"/>.
        /// </summary>
        public Polar3 ToPolar3 ()
        {
            return new Polar3 (1.0, B, L);
        }
    }
}