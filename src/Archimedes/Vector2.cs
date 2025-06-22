namespace Archimedes
{
    public class Vector2
    {
        private double [] _x;

        public double X
        {
            get => _x [0];

            set => _x [0] = value;
        }

        public double Y
        {
            get => _x [1];

            set => _x [1] = value;
        }

        public Vector2 (double x, double y)
        {
            _x = new double [2];

            _x [0] = x;
            _x [1] = y;
        }
    }
}