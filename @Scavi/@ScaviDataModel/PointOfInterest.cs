using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _ScaviDataModel.Contracts
{

    public class PointOfInterest
    {
        public String name { get; set; }

        public String summary { get; set; }

        public Uri uripage { get; set; }


        public PointOfInterestType type { get; set; }

        public GeoCoordinate geocoordinate { get; set; }


    }
}