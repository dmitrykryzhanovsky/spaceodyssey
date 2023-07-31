using Archimedes;

namespace SpaceOdyssey
{
    public static class Space
    {
        /// <summary>
        /// Преобразование угловых координат из экваториальной системы в эклиптическую.
        /// </summary>
        /// <param name="p1">Экваториальные координаты.</param>
        /// <param name="sinEpsilon">Синус угла наклона земной оси.</param>
        /// <param name="cosEpsilon">Косинус угла наклона земной оси.</param>
        public static Polar3 EqToEcTransform (Polar3 p1, double sinEpsilon, double cosEpsilon)
        {
            return Space3.ReferenceRotationOX (p1, sinEpsilon, cosEpsilon);
        }

        /// <summary>
        /// Преобразование угловых координат из эклиптической системы в экваториальную.
        /// </summary>
        /// <param name="p1">Эклиптические координаты.</param>
        /// <param name="sinEpsilon">Синус угла наклона земной оси.</param>
        /// <param name="cosEpsilon">Косинус угла наклона земной оси.</param>
        public static Polar3 EcToEqTransform (Polar3 p1, double sinEpsilon, double cosEpsilon)
        {
            return Space3.ReferenceRotationOX (p1, -sinEpsilon, cosEpsilon);
        }
    }
}