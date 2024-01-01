namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Круговая орбита.
    /// </summary>
    public class CircularOrbit : EllipticOrbit
    {
        /// <summary>
        /// Эксцентриситет круга равен 0.
        /// </summary>
        private const double CircularEccentricity = 0.0;

        /// <summary>
        /// Создаёт круговую орбиту.
        /// </summary>
        /// <param name="gravityMass">Гравитационный центр орбиты.</param>
        /// <param name="element">Элемент орбиты, через который осуществляется её инициализация. Для круговой орбиты это могут быть 
        /// большая полуось (она же расстояние до центра), среднее движение и орбитальный период.</param>
        /// <param name="value">Значение элемента орбиты, через который осуществляется её инициализация. В данном случае должно быть 
        /// строго больше 0.</param>
        /// <exception cref="DimensionalOrbitalElementNegativeException">Генерируется, если инициализация осуществляется через большую 
        /// полуось и для неё передано неположительное значение.</exception>
        /// <exception cref="TemporalOrbitalElementNegativeException">Генерируется, если инициализация осуществляется через среднее 
        /// движение или орбитальный период и для них передано неположительное значение.</exception>
        /// <exception cref="NotSuitableCircularOrbitalElementException">Генерируется, если в качестве параметра element передан элемент 
        /// орбиты, не подходящий в данном контексте для круговой орбиты.</exception>
        public static CircularOrbit CreateCircularOrbit (IGravityMass gravityMass, EOrbitalElement element, double value)
        {
            double a = 0.0, n = 0.0, T = 0.0;

            switch (element)
            {
                // Инициализация через большую полуось a.
                case EOrbitalElement.SemiMajorAxis:
                    if (value < 0.0) throw new DimensionalOrbitalElementNegativeException (element);
                    
                    else (n, T) = KeplerOrbitFormulae.ComputeMotionAndPeriodForEllipse (gravityMass.GravitationalParameter, value);
                    
                    break;

                // Инициализация через среднее движение n.
                case EOrbitalElement.MeanMotion:
                    if (value < 0.0) throw new TemporalOrbitalElementNegativeException (element);

                    else (a, T) = KeplerOrbitFormulae.ComputeSemiAxisAndPeriodForEllipse (gravityMass.GravitationalConstant, value);

                    break;

                // Инициализация через орбитальный период T.
                case EOrbitalElement.OrbitalPeriod:
                    if (value < 0.0) throw new TemporalOrbitalElementNegativeException (element);

                    else (a, n) = KeplerOrbitFormulae.ComputeSemiAxisAndMotionForEllipse (gravityMass.GravitationalConstant, value);

                    break;

                // В качестве параметра element передан элемент орбиты, не подходящий в данном контексте для круговой орбиты.
                default: throw new NotSuitableCircularOrbitalElementException (element);
            }

            return new CircularOrbit (gravityMass, a, n, T);
        }

        /// <summary>
        /// Конструктор для круговых орбит. Довычисляет остальные элементы и передаёт их в конструктор базового класса (для эллиптических 
        /// орбит).
        /// </summary>
        /// <param name="gravityMass">Гравитационный центр орбиты.</param>
        /// <param name="a">Большая полуось.</param>
        /// <param name="n">Среднее движение.</param>
        /// <param name="T">Орбитальный период.</param>
        private CircularOrbit (IGravityMass gravityMass, double a, double n, double T) :
            base (gravityMass, a, CircularEccentricity, a, a, a, n, T)
        {
        }
    }
}