using Archimedes;

namespace SpaceOdyssey.Cosmodynamics
{
    public partial struct OrbitalPosition
    {
        private readonly double _t;

        private readonly double _path;
        private readonly double _M;
        private readonly double _E;

        private readonly PlanarPosition _planar;

        /// <summary>
        /// Момент времени, соответствующий данному положению на орбите.
        /// </summary>
        public double T
        {
            get => _t;
        }

        /// <summary>
        /// Средняя аномалия для данного момента времени.
        /// </summary>
        /// <remarks>В случае замкнутой орбиты (эллиптической или круговой) здесь указывается приведённое значение средней аномалии, в 
        /// диапазоне от -π до +π.</remarks>
        public double M
        {
            get => _M;
        }

        /// <summary>
        /// Эксцентрическая аномалия.
        /// </summary>
        public double E
        {
            get => _E;
        }

        /// <summary>
        /// Параметры положения и скорости тела в плоскости орбиты.
        /// </summary>
        public PlanarPosition Planar
        {
            get => _planar;
        }

        #region Nested types

        /// <summary>
        /// Параметры положения и скорости тела в плоскости орбиты.
        /// </summary>
        public struct PlanarPosition
        {
            private readonly PlanarCoordinates _coordinates;
            private readonly PlanarVelocity    _velocity;
            private readonly double            _inclintaion;
            private readonly double            _orthogonality;

            /// <summary>
            /// Положение тела в плоскости орбиты.
            /// </summary>
            public PlanarCoordinates Coordinates
            {
                get => _coordinates;
            }

            /// <summary>
            /// Скорость тела в плоскости орбиты.
            /// </summary>
            public PlanarVelocity Velocity
            {
                get => _velocity;
            }

            /// <summary>
            /// Угол между касательной к орбите и вектором скорости в данной точке орбиты, в радианах.
            /// </summary>
            public double Inclination
            {
                get => _inclintaion;
            }

            /// <summary>
            /// Угол между касательной к орбите и радиус-вектором в данной точке орбиты, в радианах.
            /// </summary>
            public double Orthogonality
            {
                get => _orthogonality;
            }

            #region Nested types

            /// <summary>
            /// Положение тела в плоскости орбиты.
            /// </summary>
            public struct PlanarCoordinates
            {
                private readonly Vector2 _cartesian;
                private readonly Polar2  _polar;

                /// <summary>
                /// Положение тела в декартовых координатах.
                /// </summary>
                public Vector2 Cartesian
                {
                    get => _cartesian;
                }

                /// <summary>
                /// X-координата.
                /// </summary>
                public double X
                {
                    get => _cartesian.X;
                }

                /// <summary>
                /// Y-координата.
                /// </summary>
                public double Y
                {
                    get => _cartesian.X;
                }

                /// <summary>
                /// Положение тела в полярных координатах.
                /// </summary>
                public Polar2 Polar
                {
                    get => _polar;
                }

                /// <summary>
                /// Длина радиус-вектора.
                /// </summary>
                public double R
                {
                    get => _polar.R;
                }

                /// <summary>
                /// Истинная аномалия.
                /// </summary>
                public double TrueAnomaly
                {
                    get => _polar.Heading;
                }

                internal PlanarCoordinates (double x, double y, double r, double trueAnomaly)
                {
                    _cartesian = new Vector2 (x, y);
                    _polar     = new Polar2 (r, trueAnomaly);
                }

                internal PlanarCoordinates (Vector2 cartesian, Polar2 polar)
                {
                    _cartesian = cartesian;
                    _polar     = polar;
                }
            }

            /// <summary>
            /// Скорость тела в плоскости орбиты.
            /// </summary>
            public struct PlanarVelocity
            {
                private readonly Vector2 _velocity;

                /// <summary>
                /// Вектор скорости.
                /// </summary>
                public Vector2 Velocity
                {
                    get => _velocity;
                }

                /// <summary>
                /// X-компонента скорости.
                /// </summary>
                public double VX
                {
                    get => _velocity.X;
                }

                /// <summary>
                /// Y-компонента скорости.
                /// </summary>
                public double VY
                {
                    get => _velocity.Y;
                }

                /// <summary>
                /// Величина скорости.
                /// </summary>
                public double Speed
                {
                    get => _velocity.GetLength ();
                }

                internal PlanarVelocity (double x, double y)
                {
                    _velocity = new Vector2 (x, y);
                }

                internal PlanarVelocity (Vector2 velocity)
                {
                    _velocity = velocity;
                }
            }

            #endregion
        }

        #endregion
    }
}