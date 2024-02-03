namespace SpaceOdyssey.Cosmodynamics
{
    public class Sun : ICentralBody
    {
        public double GravitationalConstant
        {
            get => AstroConst.GaussianGravitationalConstant;
        }

        public double GravitationalParameter
        {
            get => AstroConst.GaussianGravitationalParameter;
        }

        internal Sun ()
        {
        }
    }
}