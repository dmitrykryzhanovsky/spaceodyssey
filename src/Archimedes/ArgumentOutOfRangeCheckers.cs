using System.Numerics;

namespace Archimedes
{
    /// <summary>
    /// Методы для проверки числовых значений на соответствие заданным диапазонам.
    /// </summary>
    public static class ArgumentOutOfRangeCheckers
    {
        /// <summary>
        /// Проверяет, является ли число x положительным, и если нет, то генерирует исключение.
        /// </summary>
        public static void CheckPositive<T> (T x) where T : INumber<T>
        {
            if (x.CompareTo (T.Zero) <= 0) throw new ArgumentOutOfRangeException ();
        }

        /// <summary>
        /// Проверяет, является ли число x положительным или равным 0, и если нет, то генерирует исключение.
        /// </summary>
        public static void CheckNotNegative<T> (T x) where T : INumber<T>
        {
            if (x.CompareTo (T.Zero) < 0) throw new ArgumentOutOfRangeException ();
        }

        /// <summary>
        /// Проверяет, что число x больше числа a, и если нет, то генерирует исключение.
        /// </summary>
        public static void CheckGreater<T> (T x, T a) where T : INumber<T>
        {
            if (x.CompareTo (a) <= 0) throw new ArgumentOutOfRangeException ();
        }

        /// <summary>
        /// Проверяет, лежит ли число x на полуинтервале [a; b), и если нет, то генерирует исключение.
        /// </summary>
        public static void CheckInLeftSemiInterval<T> (T x, T a, T b) where T : INumber<T>
        {
            if ((x.CompareTo (a) <  0) ||
                (x.CompareTo (b) >= 0)) throw new ArgumentOutOfRangeException ();
        }         
   }
}