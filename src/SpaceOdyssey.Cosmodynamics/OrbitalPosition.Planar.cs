using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public partial struct OrbitalPosition
    {
        /// <summary>
        /// Положение тела в плоскости орбиты.
        /// </summary>
        public struct Planar
        {
            private readonly Vector2 _u;
            private readonly Polar2  _p;
            private readonly Vector2 _v;
            private readonly double  _speed;
            private readonly double  _inclintaion;
            private readonly double  _orthogonality;

            /// <summary>
            /// Радиус-вектор в плоскости орбиты в декартовых координатах.
            /// </summary>
            public Vector2 CartesianPosition
            {
                get => _u;
            }

            public double X
            {
                get => _u.X;
            }

            public double Y
            {
                get => _u.Y;
            }

            /// <summary>
            /// Радиус-вектор в плоскости орбиты в полярных координатах.
            /// </summary>
            public Polar2 PolarPosition
            {
                get => _p;
            }

            /// <summary>
            /// Вектор скорости в плоскости орбиты.
            /// </summary>
            public Vector2 Velocity
            {
                get => _v;
            }

            /// <summary>
            /// Проекция скорости vx в плоскости орбиты.
            /// </summary>
            public double VX
            {
                get => _v.X;
            }

            /// <summary>
            /// Проекция скорости vy в плоскости орбиты.
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

            /// <summary>
            /// Угол между касательной и вектором скорости в данной точке орбиты, в радианах.
            /// </summary>
            public double Inclination
            {
                get => _inclintaion;
            }

            /// <summary>
            /// Угол между касательной и радиус-векторов в данной точке орбиты, в радианах.
            /// </summary>
            public double Orthogonality
            {
                get => _orthogonality;
            }

            internal Planar (double x, double y, double r, double trueAnomaly, 
                             double vx, double vy, double speed)
            {
                _u     = new Vector2 (x, y);
                _p     = new Polar2 (r, trueAnomaly);
                _v     = new Vector2 (vx, vy);
                _speed = speed;
            }
        }
    }
}