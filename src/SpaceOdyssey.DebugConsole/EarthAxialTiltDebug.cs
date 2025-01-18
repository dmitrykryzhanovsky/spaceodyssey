namespace SpaceOdyssey.DebugConsole
{
    internal static class EarthAxialTiltDebug
    {
        internal static void CompareMethods ()
        {
            double [] centuries = new double [] { 0, 1, 10, 100 };

            Console.WriteLine ("DE200 model:\t{0}\t{1}\t\t{2}\t\t{3}",
                EarthAxialTilt.ComputeDE200 (centuries [0]),
                EarthAxialTilt.ComputeDE200 (centuries [1]),
                EarthAxialTilt.ComputeDE200 (centuries [2]),
                EarthAxialTilt.ComputeDE200 (centuries [3]));

            Console.WriteLine ("P03 model:\t{0}\t{1}\t{2}\t\t{3}",
                EarthAxialTilt.ComputeP03 (centuries [0]),
                EarthAxialTilt.ComputeP03 (centuries [1]),
                EarthAxialTilt.ComputeP03 (centuries [2]),
                EarthAxialTilt.ComputeP03 (centuries [3]));

            Console.WriteLine ("Laskar's model:\t{0}\t{1}\t{2}\t{3}",
                EarthAxialTilt.ComputeLaskar (centuries [0]),
                EarthAxialTilt.ComputeLaskar (centuries [1]),
                EarthAxialTilt.ComputeLaskar (centuries [2]),
                EarthAxialTilt.ComputeLaskar (centuries [3]));
        }
    }
}