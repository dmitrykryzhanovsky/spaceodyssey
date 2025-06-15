namespace SpaceOdyssey.Cosmodynamics
{
    /// <summary>
    /// Базовый класс для непараболических орбит (гиперболических и эллиптических, включая круговые).
    /// </summary>
    /// <remarks>Главной особенностью непараболических орбит является то, что для них определена большая полуось a – положительная для 
    /// эллипсов и отрицательная для гипербол. Все базовые формулы записываются через большую полуось.</remarks>
    public abstract class NonParabolicOrbit : KeplerOrbit
    {
        protected double _a;

        protected double _1me; // Вспомогательная величина 1 – e.
        protected double _1pe; // Вспомогательная величина 1 + e.

        /// <summary>
        /// Большая полуось орбиты.
        /// </summary>
        public double A
        {
            get => _a;
        }

        #region Constructors

        protected NonParabolicOrbit (Mass center, Mass probe) : base (center, probe)
        {
        }

        #endregion

        protected void ComputeOrbit ()
        {
            ComputeShape ();
            ComputeMotion ();
            ComputeIntegrals ();
        }

        protected virtual void ComputeShape ()
        {
            _1me = 1.0 - _e;
            _1pe = 1.0 + _e;

            ComputeShapeParameters ();
        }

        protected abstract void ComputeShapeParameters ();

        private void ComputeMotion ()
        {
            _mua = Formulae.GMA (_mu, _a);

            ComputeMotionParameters ();
        }

        protected abstract void ComputeMotionParameters ();

        private void ComputeIntegrals ()
        {
            _energyIntegral = -_mua;
            
            ComputeArealVelocity ();
        }

        protected abstract void ComputeArealVelocity ();
    }
}