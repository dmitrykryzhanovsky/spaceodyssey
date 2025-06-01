namespace SpaceOdyssey.Cosmodynamics
{
    public class CentralBody
    {
        private double _gParameter;
        private double _gConstant;

        /// <summary>
        /// Гравитационный параметр (квадрат гравитационной постоянной).
        /// </summary>
        public double GParameter
        {
            get => _gParameter;
        }

        /// <summary>
        /// Гравитационная постоянная (квадратный корень из гравитационного параметра).
        /// </summary>
        public double GConstant
        {
            get => _gConstant;
        }

        private CentralBody (double gParameter, double gConstant)
        {
            _gParameter = gParameter;
            _gConstant  = gConstant;
        }

        public static CentralBody CreateGParameter (double gParameter)
        {
            CheckGValue (gParameter);

            return new CentralBody (gParameter, double.Sqrt (gParameter));
        }

        public static CentralBody CreateGConstant (double gConstant)
        {
            CheckGValue (gConstant);

            return new CentralBody (gConstant * gConstant, gConstant);
        }

        private static void CheckGValue (double gValue)
        {
            if (gValue <= 0.0) throw new ArgumentOutOfRangeException (nameof (gValue));
        }
    }
}