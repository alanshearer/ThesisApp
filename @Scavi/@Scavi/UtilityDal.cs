using _ScaviDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ScaviDal
{
    public static class UtilityDal
    {
        public static Uri GetUriFromString(String uriString)
        {
            return new Uri(uriString);
        }

        public static PointOfInterestTypeEnum GetTypeEnumFromString(String typeString)
        {
            PointOfInterestTypeEnum result;
            if (Enum.TryParse<PointOfInterestTypeEnum>(typeString, out result))
            {
                return result;
            }
            return PointOfInterestTypeEnum.Altro;
        }

        public static PointOfInterestType GetTypeFromString(String typeString)
        {
            PointOfInterestTypeEnum type = GetTypeEnumFromString(typeString);
            return new PointOfInterestType(type);
        }

    }
}
