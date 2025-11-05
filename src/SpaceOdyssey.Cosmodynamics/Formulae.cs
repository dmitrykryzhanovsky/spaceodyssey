namespace SpaceOdyssey.Cosmodynamics
{
    public static class Formulae
    {
        public static class Shape
        {
            public static class Parabola
            {
                public static double FocalParameterByRP (double rp)
                {
                    return 2.0 * rp;
                }
            }

            public static class Hyperbola
            {
                public static double Asymptote (double e)
                {
                    return double.Acos (-1.0 / e);
                }
            }
        }
    }
}