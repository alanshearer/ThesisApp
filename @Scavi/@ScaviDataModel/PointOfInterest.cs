using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _ScaviDataModel
{

    public class PointOfInterest
    {
        public int ID { get; set; }
        public String name { get; set; }

        public String summary { get; set; }

        public String uripage { get; set; }

        public double rating { get; set; }


        public String type { get; set; }

        public GeoPolygon Polygon { get; set; }


    }
}