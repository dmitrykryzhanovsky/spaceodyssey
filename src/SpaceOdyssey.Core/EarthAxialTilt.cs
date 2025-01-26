using Archimedes;

namespace SpaceOdyssey
{
    /// <summary>
    /// Вычисление наклона земной оси.
    /// </summary>
    /// <remarks><para>
    ///     Формулы для вычислений взяты из https://en.wikipedia.org/wiki/Axial_tilt#Short_term. Они релевантны на интервале 
    ///     нескольких десятков тысяч лет до и после эпохи J2000.0. Более точно моменты, в которые формулы начинают расходиться, можно 
    ///     определить, как экстремумы полиномов (по которым происходят вычисления в методах), после которых значения полиномов уходят 
    ///     на бесконечность.
    /// </para>
    /// <para>
    ///     Момент времени T, для которого происходит вычисление наклона земной оси, во всех методах задаётся количеством 
    ///     юлианских столетий, прошедших от эпохи J2000.0 до интересующего нас момента времени. Если интересующий нас момент времени 
    ///     предшествовал эпохе J2000.0, значение T будет отрицательным.
    /// </para>
    /// <para>
    ///     Все методы в этом классе возвращают наклон земной оси в секундах.
    /// </para>
    /// </remarks>
    public static class EarthAxialTilt
    {
        /// <summary>
        /// 23°23′ в секундах – это наклон земной оси с точностью до минуты для эпохи J2000.0. Все вычисления в данном классе нужны 
        /// для определения наклона земной оси с точностью до секунды и её долей.
        /// </summary>
        private const double InitialApproximation = 84360;

        private static readonly double [] ArcsecondSeries_DE200  = new double [] {    21.448, 
                                                                                     -46.8150, 
                                                                                      -0.00059, 
                                                                                       0.001813 };

        private static readonly double [] ArcsecondSeries_P03    = new double [] {    21.406, 
                                                                                     -46.836769, 
                                                                                      -0.0001831, 
                                                                                       0.00200340, 
                                                                                      -0.000000576, 
                                                                                      -0.0000000434 };

        private static readonly double [] ArcsecondSeries_Laskar = new double [] {    21.448, 
                                                                                   -4680.93, 
                                                                                      -1.55, 
                                                                                    1999.25, 
                                                                                     -51.38, 
                                                                                    -249.67, 
                                                                                     -39.05, 
                                                                                       7.12, 
                                                                                      27.87, 
                                                                                       5.79, 
                                                                                       2.45 };

        /// <summary>
        /// Вычисление наклона земной оси в секундах по эфемеридам JPL 1983 г.
        /// </summary>
        public static double ComputeDE200InArcsec (double T)
        {
            return InitialApproximation + PolynomialAlgorithm.ComputeCube (T, ArcsecondSeries_DE200);
        }

        /// <summary>
        /// Вычисление наклона земной оси в секундах по модели P03 от IAU (МАС) 2006 г.
        /// </summary>
        public static double ComputeP03InArcsec (double T)
        {
            return InitialApproximation + PolynomialAlgorithm.Compute (T, ArcsecondSeries_P03);
        }

        /// <summary>
        /// Вычисление наклона земной оси в секундах по модели Жака Ласкара.
        /// </summary>
        public static double ComputeLaskarInArcsec (double T)
        {
            return InitialApproximation + PolynomialAlgorithm.Compute (T / 100.0, ArcsecondSeries_Laskar);
        }
    }
}