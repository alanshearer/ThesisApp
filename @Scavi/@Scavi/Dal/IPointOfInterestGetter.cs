using _Scavi;
using _ScaviDataModel;
using Microsoft.Phone.Maps.Toolkit;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ScaviDal
{
    public interface IPointOfInterestGetter
    {
        List<PointOfInterest> GetPointsOfInterest();

        List<CustomPushpin> GetCustomPushpins();


        PointOfInterest GetPointOfInterestByPosition(GeoCoordinate coordinate);

    }
}
