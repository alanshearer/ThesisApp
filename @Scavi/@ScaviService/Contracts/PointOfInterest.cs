using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace _ScaviService.Contracts
{
    public class PointOfInterest
    {
        public String name { get; set; }

        public Uri uripage { get; set; }

         
        public GeoCoordinate geocoordinate { get; set; }


    }
}