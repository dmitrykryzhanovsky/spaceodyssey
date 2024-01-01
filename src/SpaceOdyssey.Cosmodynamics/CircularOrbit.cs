using System;

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
        /// Создаёт круговую орбиту, инициализируя её через большую полуось a.
        /// </summary>
        /// <param name="orbitalCenter">Гравитационный центр орбиты.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если a <= 0.</exception>
        public static CircularOrbit CreateBySemiMajorAxis (IGravityMass orbitalCenter, double a)
        {
            if (a <= 0.0) throw new ArgumentOutOfRangeException ();

            (double n, double T) = KeplerOrbitFormulae.ComputeMotionAndPeriodForEllipse (orbitalCenter.GravitationalParameter, a);

            return new CircularOrbit (orbitalCenter, a, n, T);
        }

        /// <summary>
        /// Создаёт круговую орбиту, инициализируя её через среднее движение n.
        /// </summary>
        /// <param name="orbitalCenter">Гравитационный центр орбиты.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если n <= 0.</exception>
        public static CircularOrbit CreateByMeanMotion (IGravityMass orbitalCenter, double n)
        {
            if (n <= 0.0) throw new ArgumentOutOfRangeException ();

            (double a, double T) = KeplerOrbitFormulae.ComputeSemiAxisAndPeriodForEllipse (orbitalCenter.GravitationalParameter, n);

            return new CircularOrbit (orbitalCenter, a, n, T);
        }

        /// <summary>
        /// Создаёт круговую орбиту, инициализируя её через орбитальный период T.
        /// </summary>
        /// <param name="orbitalCenter">Гравитационный центр орбиты.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если T <= 0.</exception>
        public static CircularOrbit CreateByOrbitalPeriod (IGravityMass orbitalCenter, double T)
        {
            if (T <= 0.0) throw new ArgumentOutOfRangeException ();

            (double a, double n) = KeplerOrbitFormulae.ComputeSemiAxisAndMotionForEllipse (orbitalCenter.GravitationalParameter, T);

            return new CircularOrbit (orbitalCenter, a, n, T);
        }
        
        /// <summary>
        /// Конструктор для круговых орбит. Довычисляет остальные элементы и передаёт их в конструктор базового класса (для эллиптических 
        /// орбит).
        /// </summary>
        /// <param name="orbitalCenter">Гравитационный центр орбиты.</param>
        /// <param name="a">Большая полуось.</param>
        /// <param name="n">Среднее движение.</param>
        /// <param name="T">Орбитальный период.</param>
        private CircularOrbit (IGravityMass orbitalCenter, double a, double n, double T) :
            base (orbitalCenter, a, CircularEccentricity, a, a, a, n, T)
        {
        }
    }
}