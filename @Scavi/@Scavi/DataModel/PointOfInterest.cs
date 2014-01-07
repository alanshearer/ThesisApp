using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;

namespace _ScaviDataModel
{

    public class PointOfInterest
    {
        public String name { get; set; }

        public String summary { get; set; }

        public Uri uripage { get; set; }


        public PointOfInterestType type { get; set; }

        public GeoCoordinate center { get; set; }

        public GeoPolygon Polygon { get; set; }


    }
}