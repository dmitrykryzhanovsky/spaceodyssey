using static SpaceOdyssey.Cosmodynamics.Formulae;

namespace SpaceOdyssey.Cosmodynamics
{
    public class ParabolicOrbit : KeplerOrbit
    {
        /// <summary>
        /// Свойство для отражения того факта, что орбита незамкнутая и уходит на бесконечность.
        /// </summary>
        public double RInfinity
        {
            get => double.PositiveInfinity;
        }

        /// <summary>
        /// Асимптота – истинная аномалия (в верхней полуплоскости), к которой тело стремится, удаляясь на бесконечность.
        /// </summary>
        /// <remarks>Для параболы всегда равна π.</remarks>
        public double Asymptote
        {
            get => double.Pi;
        }

        /// <summary>
        /// Скорость при удалении на бесконечность.
        /// </summary>
        /// <remarks>Для параболы всегда равна 0.</remarks>
        public double VInfinity
        {
            get => 0.0;
        }

        #region Constructors

        private ParabolicOrbit (Mass center, Mass orbiting) : base (center, orbiting)
        {
        }

        #endregion

        #region Init and compute orbit

        /// <summary>
        /// Создаёт параболическую орбиту, инициализируя расстояние в перицентре rp и момент прохождения перицентра t0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Генерируется, если rp <= 0.</exception>
        public static ParabolicOrbit CreateByPeriapsis (Mass center, Mass orbiting, double rp)
        {
            Checkers.CheckRPositive (rp);

            ParabolicOrbit orbit = new ParabolicOrbit (center, orbiting);

            orbit.ComputeOrbitByPeriapsis (rp);

            return orbit;
        }

        private void ComputeOrbitByPeriapsis (double rp)
        {
            SetParametersByPeriapsis (ParabolicEccentricity, rp);

            _p  = 2.0 * _rp;
            _h  = 0.0;
            _n  = double.Sqrt (_mu / _p) / _rp;
            _vp = Formulae.Motion.Parabola.SpeedForRadius (_mu, _rp);
        }

        #endregion

        public override double Radius (double trueAnomaly)
        {
            return Formulae.Shape.Parabola.ConicSectionEquation (_p, trueAnomaly);
        }

        protected override double ConicSectionInverseEquation (double r)
        {
            return Formulae.Shape.Parabola.ConicSectionInverseEquation (_p, r);
        }

        public override double SpeedForRadius (double r)
        {
            return Formulae.Motion.Parabola.SpeedForRadius (_mu, r);
        }

        public override double SpeedForTrueAnomaly (double trueAnomaly)
        {
            return Formulae.Motion.Parabola.SpeedForTrueAnomaly (_mu, _p, trueAnomaly);
        }

        public override OrbitalPosition ComputePosition (double t)
        {
            double M     = MeanAnomalyForTime (t);
            double tgv2  = Formulae.KeplerEquation.Parabola.SolveBarkerEquation (M);

            double trueAnomaly = 2.0 * double.Atan (tgv2);
            double r           = Radius (trueAnomaly);
            double x           = _rp * (1.0 - tgv2 * tgv2);
            double y           = _p * tgv2;

            double beta  = Formulae.PlanarVelocity.Parabola.VelocityAngle (_p, y);
            double speed = SpeedForRadius (r);

            (double sin, double cos) = double.SinCos (beta);

            double vx    = speed * cos;
            double vy    = speed * sin;

            return new OrbitalPosition (t, M, tgv2, x, y, r, trueAnomaly, vx, vy);
        }
    }
}