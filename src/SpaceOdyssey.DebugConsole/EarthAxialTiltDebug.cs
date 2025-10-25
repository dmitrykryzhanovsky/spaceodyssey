namespace SpaceOdyssey.DebugConsole
{
    internal static class EarthAxialTiltDebug
    {
        internal static void CompareMethods ()
        {
            double [] centuries = new double [] { 0, 1, 10, 100 };

            Console.WriteLine ("DE200 model:\t{0}\t{1}\t\t{2}\t\t{3}",
                EarthAxialTilt.ComputeDE200InArcsec (centuries [0]),
                EarthAxialTilt.ComputeDE200InArcsec (centuries [1]),
                EarthAxialTilt.ComputeDE200InArcsec (centuries [2]),
                EarthAxialTilt.ComputeDE200InArcsec (centuries [3]));

            Console.WriteLine ("P03 model:\t{0}\t{1}\t{2}\t\t{3}",
                EarthAxialTilt.ComputeP03InArcsec (centuries [0]),
                EarthAxialTilt.ComputeP03InArcsec (centuries [1]),
                EarthAxialTilt.ComputeP03InArcsec (centuries [2]),
                EarthAxialTilt.ComputeP03InArcsec (centuries [3]));

            Console.WriteLine ("Laskar's model:\t{0}\t{1}\t{2}\t{3}",
                EarthAxialTilt.ComputeLaskarInArcsec (centuries [0]),
                EarthAxialTilt.ComputeLaskarInArcsec (centuries [1]),
                EarthAxialTilt.ComputeLaskarInArcsec (centuries [2]),
                EarthAxialTilt.ComputeLaskarInArcsec (centuries [3]));
        }
    }
}