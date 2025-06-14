namespace SpaceOdyssey.Cosmodynamics
{
    public class EllipticOrbit : KeplerOrbit
    {        
        public double RangeARp
        {
            get => 1.0 / (1.0 - _e);
        }

        public double RangeRaA
        {
            get => 1.0 + _e;
        }

        public double RangeRaRp
        {
            get => (1.0 + _e) / (1.0 - _e);
        }

        protected EllipticOrbit () : base ()
        {
        }
    }
}