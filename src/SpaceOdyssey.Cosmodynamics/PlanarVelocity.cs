using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Скорость тела в плоскости орбиты.
    /// </summary>
    public struct PlanarVelocity
    {
        private readonly Vector2 _v;
        private readonly double  _speed;

        /// <summary>
        /// Вектор скорости в плоскости орбиты.
        /// </summary>
        public Vector2 Vector
        {
            get => _v;
        }

        /// <summary>
        /// Проекция скорости vx.
        /// </summary>
        public double VX
        {
            get => _v.X;
        }

        /// <summary>
        /// Проекция скорости vy.
        /// </summary>
        public double VY
        {
            get => _v.Y;
        }

        /// <summary>
        /// Величина скорости.
        /// </summary>
        public double Speed
        {
            get => _speed;
        }

        private PlanarVelocity (double vx, double vy, double speed)
        {
            _v     = new Vector2 (vx, vy);
            _speed = speed;
        }

        /// <summary>
        /// Определение скорости в плоскости орбиты.
        /// </summary>
        /// <param name="method">Метод вычисления (зависит от геометрической формы орбиты).</param>
        /// <param name="speed">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        /// <param name="sin">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        /// <param name="cos">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        /// <param name="param">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        public static PlanarVelocity ComputePlanarVelocity (ComputePlanarVelocityDelegate method, double speed, 
            double sin, double cos, params double [] param)
        {
            (double vx, double vy) = method (sin, cos, param);

            return new PlanarVelocity (vx, vy, speed);
        }
    }
}