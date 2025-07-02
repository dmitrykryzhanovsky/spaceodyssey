using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Положение тела в плоскости орбиты.
    /// </summary>
    public struct PlanarPosition
    {
        private readonly Vector2 _v;
        private readonly Polar2  _p;

        /// <summary>
        /// Радиус-вектор в декартовых координатах.
        /// </summary>
        public Vector2 CartesianPosition
        {
            get => _v;
        }

        /// <summary>
        /// Радиус-вектор в полярных координатах.
        /// </summary>
        public Polar2 PolarPosition
        {
            get => _p;
        }

        public double X
        {
            get => _v.X;
        }

        public double Y
        {
            get => _v.Y;
        }

        /// <summary>
        /// Расстояние до центра орбиты.
        /// </summary>
        public double R
        {
            get => _p.R;
        }

        /// <summary>
        /// Истинная аномалия.
        /// </summary>
        public double TrueAnomaly
        {
            get => _p.Heading;
        }

        private PlanarPosition (double x, double y, double r, double trueAnomaly)
        {
            _v = new Vector2 (x, y);
            _p = new Polar2 (r, trueAnomaly);
        }

        /// <summary>
        /// Определение положения в плоскости орбиты.
        /// </summary>
        /// <param name="method">Метод вычисления (зависит от геометрической формы орбиты).</param>
        /// <param name="sin">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        /// <param name="cos">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        /// <param name="anomaly">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        /// <param name="param">Зависит от геометрической формы орбиты. Смотри комментарии к соответствующему методу в классе Formulae.</param>
        public static PlanarPosition ComputePlanarPosition (ComputePlanarPositionDelegate method, double sin, double cos, 
            double anomaly, params double [] param)
        {
            (double x, double y, double r, double trueAnomaly) = method (sin, cos, anomaly, param);

            return new PlanarPosition (x, y, r, trueAnomaly);
        }
    }
}