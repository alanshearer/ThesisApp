using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _ScaviDataModel.Contracts
{
    [DataContract]
    public class PointOfInterest
    {
        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String summary { get; set; }

        [DataMember]
        public Uri uripage { get; set; }

        [DataMember]
        public PointOfInterestType type { get; set; }

        [DataMember]
        public GeoCoordinate geocoordinate { get; set; }


    }
}