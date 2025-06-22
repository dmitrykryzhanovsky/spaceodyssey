namespace Archimedes
{
    public class Polar2
    {
        private double _r;
        private double _heading;

        public double R
        {
            get => _r;

            set => _r = value;
        }

        public double Heading
        {
            get => _heading;

            set => _heading = value;
        }

        public Polar2 (double r, double heading)
        {
            _r       = r;
            _heading = heading;
        }
    }
}