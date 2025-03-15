﻿namespace SpaceOdyssey.Cosmodynamics
{
    public class CentralBody
    {
        private double _gParameter;

        private double _gConstant;

        public double GParameter
        {
            get => _gParameter;
        }

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
            if (gParameter <= 0.0) throw new ArgumentOutOfRangeException (nameof (gParameter));

            return new CentralBody (gParameter, double.Sqrt (gParameter));
        }

        public static CentralBody CreateGConstant (double gConstant)
        {
            if (gConstant <= 0.0) throw new ArgumentOutOfRangeException (nameof (gConstant));

            return new CentralBody (gConstant * gConstant, gConstant);
        }
    }
}