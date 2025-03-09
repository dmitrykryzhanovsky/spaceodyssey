namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Круговая орбита.
    /// </summary>
    public class CircularOrbit : EllipticOrbit
    {
        private const double CircularEccentricity = 0.0;

        private CircularOrbit (double a) : base (a, CircularEccentricity, a, a, a)
        {
        }

        /// <summary>
        /// Создаёт круговую орбиту по её радиусу a.
        /// </summary>
        /// <param name="a">Радиус круговой орбиты – должен быть строго положительным.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="a"/> меньше или равно 0.</exception>
        public static CircularOrbit Create (double a)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException ();

            return new CircularOrbit (a);
        }

        /// <summary>
        /// Расстояние до центра тяготения при истинной аномалии trueAnomaly.
        /// </summary>
        /// <remarks>В случае круговой орбиты расстояние для всех значений истинной аномалии постоянно и равно радиусу орбиты.</remarks>
        public override double Radius (double trueAnomaly)
        {
            return _a;
        }

        /// <summary>
        /// Истинная аномалия при расстоянии до центра тяготения r.
        /// </summary>
        /// <param name="r">Должно быть строго равно радиусу данной орбиты.</param>
        /// <returns>Так как в случае круговой орбиты расстояние одинаково для всех значений истинной аномалии, определить по 
        /// расстоянию истинную аномалию нельзя. Поэтому данный метод работает следующим образом:
        /// – если r = _a (радиусу орбиты), возвращается NaN
        /// – если r ≠ _a, генерируется исключение, так как такого значения для данной орбиты быть не может
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="r"/> неравно радиусу данной орбиты.</exception>
        public override double TrueAnomaly (double r)
        {
            if (r == _a) return double.NaN;

            else throw new ArgumentOutOfRangeException ();
        }
    }
}