namespace SpaceOdyssey.Cosmodynamics
{
    public class Sun : IGravityMass
    {
        public double GravitationalParameter
        {
            get => AstroConst.GaussianGravitationalConstant;
        }

        public double GravitationalConstant
        {
            get => AstroConst.GaussianGravitationalConstant2;
        }

        internal Sun ()
        {
        }
    }
}