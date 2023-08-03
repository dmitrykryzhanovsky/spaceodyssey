using Archimedes;

namespace SpaceOdyssey
{
    public static class Space
    {
        /// <summary>
        /// Преобразование угловых координат из экваториальной системы в эклиптическую.
        /// </summary>
        /// <param name="eq">Экваториальные координаты.</param>
        /// <param name="sinEpsilon">Синус угла наклона земной оси.</param>
        /// <param name="cosEpsilon">Косинус угла наклона земной оси.</param>
        public static Polar3 EqToEcTransform (Polar3 eq, double sinEpsilon, double cosEpsilon)
        {
            return Space3.ReferenceRotationOX (eq, sinEpsilon, cosEpsilon);
        }

        public static Vector3 EqToEcTransform (Vector3 eq, Matrix3 positiveMatrix)
        {
            return Space3.ReferenceRotationOX (eq, positiveMatrix);
        }

        /// <summary>
        /// Преобразование угловых координат из эклиптической системы в экваториальную.
        /// </summary>
        /// <param name="ec">Эклиптические координаты.</param>
        /// <param name="sinEpsilon">Синус угла наклона земной оси.</param>
        /// <param name="cosEpsilon">Косинус угла наклона земной оси.</param>
        public static Polar3 EcToEqTransform (Polar3 ec, double sinEpsilon, double cosEpsilon)
        {
            return Space3.ReferenceRotationOX (ec, -sinEpsilon, cosEpsilon);
        }

        public static Vector3 EcToEqTransform (Vector3 ec, Matrix3 positiveMatrix)
        {
            return Space3.ReferenceRotationOX (ec, positiveMatrix);
        }
    }
}