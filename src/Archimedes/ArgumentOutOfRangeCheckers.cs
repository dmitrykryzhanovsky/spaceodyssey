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
    }
}