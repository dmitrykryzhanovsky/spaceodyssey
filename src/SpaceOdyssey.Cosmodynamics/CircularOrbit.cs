﻿namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Круговая орбита.
    /// </summary>
    public class CircularOrbit : EllipticOrbit
    {
        private const double CircularEccentricity = 0.0;

        public CircularOrbit (CentralBody centralBody) : base (centralBody, CircularEccentricity)
        {
        }

        /// <summary>
        /// Устанавливает параметры круговой орбиты через её радиус.
        /// </summary>
        /// <param name="a">Радиус круговой орбиты – должен быть положительным.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="a"/> меньше или равно 0.</exception>
        public void SetA (double a)
        {
            CheckA (a);

            _p    = a;
            _amin = a;
            _a    = a;
            _amax = a;
            
            ComputeAuxiliaries ();

            ComputeNT ();
        }

        /// <summary>
        /// Устанавливает параметры круговой орбиты через среднее суточное движение.
        /// </summary>
        /// <param name="n">Среднее суточное движение – должно быть положительным.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="n"/> меньше или равно 0.</exception>
        public void SetMeanMotion (double n)
        {
            CheckN (n);

            _n = n;

            ComputeAT ();

            _p    = _a;
            _amin = _a;
            _amax = _a;

            ComputeAuxiliaries ();
        }

        /// <summary>
        /// Устанавливает параметры круговой орбиты через период орбитального обращения.
        /// </summary>
        /// <param name="T">Период обращения – должен быть положительным.</param>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если <paramref name="T"/> меньше или равно 0.</exception>
        public void SetT (double T)
        {
            CheckT (T);

            _T = T;

            ComputeAN ();

            _p    = _a;
            _amin = _a;
            _amax = _a;

            ComputeAuxiliaries ();
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

            else throw new ArgumentOutOfRangeException (nameof (r));
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            double M = MeanAnomaly (t);
            double MModulo = double.Ieee754Remainder (M, double.Tau);

            (double sinV, double cosV) = double.SinCos (MModulo);
            (double x,    double y)    = CircularPlanarCartesianCoordinates (_a, sinV, cosV);
            (double vx,   double vy)   = CircularPlanarVelocityComponents (_u, sinV, cosV);

            return new OrbitalPosition (x, y, _a, MModulo, vx, vy, M, MModulo);
        }

        private static (double x, double y) CircularPlanarCartesianCoordinates (double a, double sinV, double cosV)
        {
            double x = a * cosV;
            double y = a * sinV;

            return (x, y);
        }

        private static (double vx, double vy) CircularPlanarVelocityComponents (double u, double sinV, double cosV)
        {
            double vx = -u * sinV;
            double vy =  u * cosV;

            return (vx, vy);
        }
    }
}