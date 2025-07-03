namespace SpaceOdyssey.Cosmodynamics
{
    public delegate (double, double, double, double) ComputePlanarPositionDelegate (double anomaly, double sin, double cos, params double [] param);

    public delegate (double, double) ComputePlanarVelocityDelegate (double sin, double cos, params double [] param);

    public delegate double SolveKeplerEquationDelegate (double M, double e);
}