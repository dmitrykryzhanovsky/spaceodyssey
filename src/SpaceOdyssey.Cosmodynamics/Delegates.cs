namespace SpaceOdyssey.Cosmodynamics
{
    public delegate (double, double, double, double) ComputePlanarPositionDelegate (double sin, double cos, double anomaly, params double [] param);

    public delegate (double, double) ComputePlanarVelocityDelegate (double sin, double cos, double anomaly, params double [] param);
}