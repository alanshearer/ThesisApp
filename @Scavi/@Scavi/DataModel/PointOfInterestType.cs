using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _ScaviDataModel
{
    public enum PointOfInterestTypeEnum
    {
        Tempio = 1,
        Via = 3,
        Casa = 4,
        Altro =10
    }

    public class PointOfInterestType
    {
        public PointOfInterestTypeEnum type { get; set; }
        public PointOfInterestType(PointOfInterestTypeEnum type)
        {
            this.type = type;
        }
    }
}