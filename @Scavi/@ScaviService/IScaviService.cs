using _ScaviDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace _ScaviService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScaviService" in both code and config file together.
    [ServiceContract]
    public interface IScaviService
    {
        [OperationContract]
        String GetPointsOfInterestRSS();

        //[OperationContract(AsyncPattern=true)]
        //IAsyncResult BeginGetPointOfInterestRSS(AsyncCallback callback, object state);
        //string EndGetPointOfInterestRSS(IAsyncResult result);

    }
}
