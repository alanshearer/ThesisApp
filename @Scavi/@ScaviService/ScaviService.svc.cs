using _ScaviService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _ScaviService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScaviService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ScaviService.svc or ScaviService.svc.cs at the Solution Explorer and start debugging.
    public class ScaviService : IScaviService
    {
        public List<PointOfInterest> GetPointsOfInterest()
        {
            return new List<PointOfInterest>();
        }
    }
}
