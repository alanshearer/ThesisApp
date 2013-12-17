using _ScaviService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _ScaviService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScaviService" in both code and config file together.
    [ServiceContract]
    public interface IScaviService
    {
        [OperationContract]
        List<PointOfInterest> GetPointsOfInterest();
    }
}
