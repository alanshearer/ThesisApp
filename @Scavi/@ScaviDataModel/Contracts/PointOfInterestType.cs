using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _ScaviDataModel.Contracts
{
    [DataContract]
    public enum PointOfInterestTypeEnum
    {
        Tempio = 1,
        Via = 3,
        Casa = 4,

    }

    [DataContract]
    public class PointOfInterestType
    {
        PointOfInterestTypeEnum type { get; set; }
        public PointOfInterestType(PointOfInterestTypeEnum type)
        {
            this.type = type;
        }
    }
}