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

        /// <summary>
        /// Преобразования декартовых координат из экваториальной системы в эклиптическую.
        /// </summary>
        /// <param name="eq">Экваториальные координаты.</param>
        /// <param name="positiveMatrix">Матрица поворота на положительный угол (угол наклона земной оси).</param>
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

        /// <summary>
        /// Преобразования декартовых координат из эклиптической системы в экваториальную.
        /// </summary>
        /// <param name="ec">Экваториальные координаты.</param>
        /// <param name="negativeMatrix">Матрица поворота на отрицательный угол (равный по абсолютной величине углу наклона земной оси).</param>
        public static Vector3 EcToEqTransform (Vector3 ec, Matrix3 negativeMatrix)
        {
            return Space3.ReferenceRotationOX (ec, negativeMatrix);
        }
    }
}