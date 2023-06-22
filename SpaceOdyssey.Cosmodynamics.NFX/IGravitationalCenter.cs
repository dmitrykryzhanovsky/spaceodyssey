namespace SpaceOdyssey.Cosmodynamics
{
    public interface IGravitationalCenter
    {
        double K { get; }

        double KRoot { get; }

        double C { get; }

        double R { get; }

        double GetV1 ();

        double GetV1 (double r);

        double [] GetV1 (params double [] r);

        double GetV2 ();

        double GetV2 (double r);

        double [] GetV2 (params double [] r);

        (double, double) GetEscapeVelocities ();

        (double, double) GetEscapeVelocities (double r);

        (double, double) [] GetEscapeVelocities (params double [] r);
    }
}