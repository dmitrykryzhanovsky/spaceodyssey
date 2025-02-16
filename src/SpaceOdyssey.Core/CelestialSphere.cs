using Archimedes;

namespace SpaceOdyssey
{
    public static class CelestialSphere
    {
        //public static bool IsNorthCelestialPole (double declination)
        //{
        //    return (declination == MathConst.M_PI_2);
        //}

        //public static bool IsSouthCelestialPole (double declination)
        //{
        //    return (declination == -MathConst.M_PI_2);
        //}

        public static RiseParams RiseAzimuth (double declination, Location location)
        {
            RiseParams riseParams;

            switch (location.LocationOption)
            {
                case ELocationOption.NorthPole:
                
                    if (declination > 0.0) riseParams.Circumpolar = ECircumpolar.NoDeclining;
                    else if (declination < 0.0) riseParams.Circumpolar = ECircumpolar.NoRising;
                    else riseParams.Circumpolar = ECircumpolar.AtHorizonCircle;
                    
                    break;

                case ELocationOption.SouthPole:

                    if (declination > 0.0) riseParams.Circumpolar = ECircumpolar.NoRising;
                    else if (declination < 0.0) riseParams.Circumpolar = ECircumpolar.NoDeclining;
                    else riseParams.Circumpolar = ECircumpolar.AtHorizonCircle;

                    break;

                case ELocationOption.Equator:

                    if ((declination == MathConst.M_PI_2) || (declination == -MathConst.M_PI_2)) 
                        riseParams.Circumpolar = ECircumpolar.AtHorizonPoint;
                    else 
                        riseParams.Circumpolar = ECircumpolar.Usual;

                    break;

                default:

                    break;
            }

            //ECircumpolar circumpolar;
            //double       cosT = 0.0;

            //if (IsNorthCelestialPole (declination))
            //{
            //    if ((location.LocationOption == ELocationOption.NorthPole) || 
            //        (location.LocationOption == ELocationOption.NorthHemisphere)) circumpolar = ECircumpolar.NoDeclining;

            //    else if (location.LocationOption == ELocationOption.Equator)
            //    {
            //        circumpolar = ECircumpolar.Usual;
            //        cosT        = -1.0;
            //    }

            //    else circumpolar = ECircumpolar.NoRising;
            //}

            //else if (IsSouthCelestialPole (declination))
            //{
            //    if ((location.LocationOption == ELocationOption.NorthPole) ||
            //        (location.LocationOption == ELocationOption.NorthHemisphere)) circumpolar = ECircumpolar.NoRising;

            //    else if (location.LocationOption == ELocationOption.Equator)
            //    {
            //        circumpolar = ECircumpolar.Usual;
            //        cosT        = 1.0;
            //    }

            //    else circumpolar = ECircumpolar.NoDeclining;
            //}

            //else if (location.LocationOption == ELocationOption.NorthPole)
            //{
            //    if (declination > 0.0) circumpolar = ECircumpolar.NoDeclining;

            //    else if (declination == 0.0)
            //    {
            //        circumpolar = ECircumpolar.Usual;
            //        cosT        = -1.0;
            //    }

            //    else circumpolar = ECircumpolar.NoRising;
            //}

            //else if (location.LocationOption == ELocationOption.SouthPole)
            //{
            //    if (declination > 0.0) circumpolar = ECircumpolar.NoRising;

            //    else if (declination == 0.0)
            //    {
            //        circumpolar = ECircumpolar.Usual;
            //        cosT        = 1.0;
            //    }

            //    else circumpolar = ECircumpolar.NoDeclining;
            //}

            //else
            //{
            //    cosT = -double.Tan (declination) * location.TanLatitude;

            //    if ((-1.0 <= cosT) && (cosT <= 1.0)) circumpolar = ECircumpolar.Usual;
            //    else if (cosT < -1.0) circumpolar = ECircumpolar.NoDeclining;
            //    else circumpolar = ECircumpolar.NoRising;
            //}

            //return RiseParams.Create (circumpolar, cosT);

            return riseParams;
        }
    }
}